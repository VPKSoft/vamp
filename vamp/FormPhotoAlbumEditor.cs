#region License
/*
vamp#

A software for video audio and photo playback.
Copyright © 2019 VPKSoft, Petteri Kautonen

Contact: vpksoft@vpksoft.net

This file is part of vamp#.

vamp# is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

vamp# is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with vamp#.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using MetadataExtractor; // (C): https://github.com/drewnoakes/metadata-extractor-dotnet, Apache Version 2.0
using FolderSelect; // (C): https://www.lyquidity.com/devblog/?p=136, no license
using VPKSoft.Utils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using System.Reflection;
using System.Security.Cryptography;
using VPKSoft.Hashes; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3
using MetadataExtractor.Formats.Exif; // (C): https://github.com/drewnoakes/metadata-extractor-dotnet, Apache Version 2.0
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3
using VPKSoft.VisualUtils;

namespace vamp
{
    /// <summary>
    /// An editor for photo albums.
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormPhotoAlbumEditor : DBLangEngineWinforms
    {
        #region PrivateFields
        private SQLiteConnection conn; // database connection for the SQLite database

        private List<PHOTODATATAG> photoTags = null; // a current list of tags in the database..
        List<PHOTOALBUM> photoAlbums = null; // a current list of photo albums in the database..

        // a list of entries in the currently selected photo album..
        List<PhotoAlbumEntry> photoAlbumEntries = new List<PhotoAlbumEntry>();

        // a flag indicating whether the GUI should react to change events..
        private bool changeEventsSuspended = true;

        private void SetAlbumEditEnabled(bool albumEditEnabled)
        {
            dtpPhotoAlbumFirstDateValue.Enabled = albumEditEnabled;
            dtpPhotoAlbumFirstTimeValue.Enabled = albumEditEnabled;
            lbPhotoTagValues.Enabled = albumEditEnabled;
            btAddTag.Enabled = albumEditEnabled;
            pnTrash.Enabled = albumEditEnabled;
            btSetAlbumName.Enabled = albumEditEnabled;
            dtpTimeTakenValueDate.Enabled = albumEditEnabled;
            dtpTimeTakenValueTime.Enabled = albumEditEnabled;
            btPhotoDateTimeSet.Enabled = albumEditEnabled;
            tbTimeTakenTextValue.Enabled = albumEditEnabled;
            tbAddTag.Enabled = albumEditEnabled;
            tbPhotoAlbumNameValue.Enabled = albumEditEnabled;
            tbFilterTags.Enabled = albumEditEnabled;
            btPhotoAlbumFirstDateTimeSet.Enabled = albumEditEnabled;
            tbPhotoDescriptionValue.Enabled = albumEditEnabled;
            lbPhotoAlbumTagListValues.Enabled = albumEditEnabled;

            if (!albumEditEnabled)
            {
                tbFilterTags.Text = string.Empty;
                lbPhotoTagValues.Items.Clear();
                tbAddTag.Text = string.Empty;
                tbTimeTakenTextValue.Text = string.Empty;
                lbPhotosInAlbum.Items.Clear();
                tbPhotoAlbumNameValue.Text = string.Empty;
                tbPhotoDescriptionValue.Text = string.Empty;
                ivPhoto.Image = null;
            }

            // set the image of the trash bin button according to the flag's value..
            pnTrash.BackgroundImage = albumEditEnabled ?
                Properties.Resources.rbin : // enabled..
                UtilsMisc.MakeGrayscale3(Properties.Resources.rbin); // disabled..
        }

        // a field to save the CurrentAlbum property value..
        private PHOTOALBUM _CurrentAlbum = null;

        /// <summary>
        /// The currently selected album.
        /// </summary>
        private PHOTOALBUM CurrentAlbum
        {
            get
            {
                // return the value..
                return _CurrentAlbum;
            }

            set
            {
                // set the album editing enabled based on the value..
                SetAlbumEditEnabled(_CurrentAlbum != null);

                // save the value..
                _CurrentAlbum = value;

                // set the previous album to null as well in case of a null value..
                if (value == null)
                {
                    _PreviousAlbum = null;
                }
            }
        }

        // a field to save the PreviousAlbum property value..
        private PHOTOALBUM _PreviousAlbum = null;

        /// <summary>
        /// A copy instance of the CurrentAlbum property value. 
        /// </summary>
        private PHOTOALBUM PreviousAlbum
        {
            get => _PreviousAlbum;

            set
            {
                // in this case always make a copy..
                if (value != null) // ..except with null value..
                {
                    _PreviousAlbum = new PHOTOALBUM(value);
                }
                else
                {
                    // a null value just gets to be set..
                    _PreviousAlbum = value;
                }
            }
        }

        // the contents of the currently selected album..
        List<PhotoAlbumEntry> currentPhotoAlbumEntries;

        // the currently selected photo album entry..
        private PhotoAlbumEntry currentPhotoAlbumEntry;

        // current photo tags for the currently selected photo album entry..
        private List<PHOTODATATAG> currentPhotoTags = new List<PHOTODATATAG>();

        // the previous image to be saved so it can be disposed of..
        private Image lastImage = null;

        // a variable holding tags if they to be copied / pasted to some other photo entry..
        private string copyTags = string.Empty;
        #endregion

        #region MassiveConstructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FormPhotoAlbumEditor"/> class.
        /// </summary>
        public FormPhotoAlbumEditor()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            // initialize the database..
            conn = new SQLiteConnection("Data Source=" + DBLangEngine.DataDir + "vamp.sqlite;Pooling=true;FailIfMissing=false;Cache Size=10000;"); // PRAGMA synchronous=OFF;PRAGMA journal_mode=OFF
            conn.Open();

            // run the script to keep the database up to date..
            if (!ScriptRunner.RunScript(DBLangEngine.DataDir + "vamp.sqlite"))
            {
                MessageBox.Show(
                    DBLangEngine.GetMessage("msgErrorInScript",
                    "A script error occurred on the database update|Something failed during running the database update script"),
                    DBLangEngine.GetMessage("msgError", "Error|A message describing that some kind of error occurred."),
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // at this point there is no reason to continue the program's execution as the database might be in an invalid state..
                throw new Exception(DBLangEngine.GetMessage("msgErrorInScript",
                    "A script error occurred on the database update|Something failed during running the database update script"));
            }

            // initialize the DataBase class connection..
            Database.InitConnection(ref conn);

            // list the currently configured photo albums..
            ListAlbums();

            // get all tags distinct from the database..
            photoTags = Database.GetAllTags().ToList();

            // list the tags..
            ListTags();

            #region Localization
            // localization of the save and open file dialogs..
            odSQL.Filter = DBLangEngine.GetMessage("msgSQLFileFilter", "SQL Script Files|*.sql|A filter for SQL script files");
            sdSQL.Filter = DBLangEngine.GetMessage("msgSQLFileFilter", "SQL Script Files|*.sql|A filter for SQL script files");

            odXML.Filter = DBLangEngine.GetMessage("msgXMLFileFilter", "XML Files|*.xml|A filter for XML (Extensible Markup Language) files");
            sdXML.Filter = DBLangEngine.GetMessage("msgXMLFileFilter", "XML Files|*.xml|A filter for XML (Extensible Markup Language) files");

            sdSQL.Title = mnuExportSelectedSQL.Text;
            odSQL.Title = mnuImportSQL.Text;

            sdXML.Title = mnuExportSelectedXML.Text;
            odXML.Title = mnuImportXML.Text;
            // END: localization of the save and open file dialogs..
            #endregion
        }
        #endregion

        #region HelperLogic
        /// <summary>
        /// Lists the tags in the database with an optional search string.
        /// </summary>
        /// <param name="searchString">An optional search string to filter the tags.</param>
        private void ListTags(string searchString = "")
        {
            // clear the list box..
            lbPhotoAlbumTagListValues.Items.Clear();

            // loop through the tags..
            foreach (PHOTODATATAG tag in photoTags)
            {
                // if the optional search string was given..
                if (searchString != string.Empty)
                {
                    // continue if the tag's text doesn't match the search string..
                    if (tag.TAGTEXT.IndexOf(searchString, StringComparison.InvariantCultureIgnoreCase) == -1)
                    {
                        continue;
                    }
                }
                lbPhotoAlbumTagListValues.Items.Add(tag); // add the tag to the list box..
            }

            lbPhotoAlbumTagListValues.DisplayMember = "TAGTEXT"; // set the list box display member..
        }

        /// <summary>
        /// Lists the photo albums in the database.
        /// </summary>
        /// <param name="selectPhotoAlbum">An optional PHOTOALBUM instance to select from the list box.</param>
        private void ListAlbums(PHOTOALBUM selectPhotoAlbum = null)
        {
            // get a list of photo albums in the database..
            photoAlbums = Database.GetPhotoAlbums().ToList();

            lbPhotoAlbumList.Items.Clear(); // ..and add them to the list box..

            // clear the previous list of photoAlbumEntries as the will be re-enumerated..
            photoAlbumEntries.Clear(); 

            // loop through the photo albums..
            foreach (PHOTOALBUM photoAlbum in photoAlbums)
            {
                // add the entry to the list box..
                lbPhotoAlbumList.Items.Add(photoAlbum);

                // get the data for an album from the database..
                photoAlbumEntries.AddRange(Database.GetPhotoAlbum(photoAlbum.NAME));
            }

            lbPhotoAlbumList.DisplayMember = "NAME"; // set the list box display member..         

            // if the selectPhotoAlbum parameter was given then select it..
            if (selectPhotoAlbum != null)
            {
                // do the selection by the name as it is unique..
                string albumName = selectPhotoAlbum.NAME;

                // clear the selection from the photo album list box..
                lbPhotoAlbumList.ClearSelected();

                // loop through the items in the photo album list box..
                for (int i = 0; i < lbPhotoAlbumList.Items.Count; i++)
                {
                    // if found by a name..
                    if (((PHOTOALBUM)lbPhotoAlbumList.Items[i]).NAME == selectPhotoAlbum.NAME)
                    {
                        // select the album..
                        lbPhotoAlbumList.SelectedIndex = i;
                        // ..and exit the loop..
                        break;
                    }
                }
            }
            SetAlbumEditEnabled(selectPhotoAlbum != null);
        }

        /// <summary>
        /// Lists the photo album's contents to a list box with a given album name.
        /// </summary>
        /// <param name="albumName">The name of the photo album.</param>
        private void ListAlbumContents(string albumName)
        {
            // list it's contents to another list box..
            currentPhotoAlbumEntries = 
                photoAlbumEntries.Where(f => f.NAME == albumName).Distinct().ToList();
            
            lbPhotosInAlbum.Items.Clear(); // clear the contents from the list box..

            // loop through the entries..
            foreach (PhotoAlbumEntry photoAlbumEntry in currentPhotoAlbumEntries)
            {
                // add them to the list box..
                lbPhotosInAlbum.Items.Add(photoAlbumEntry);
            }

            // set the list box display member..
            lbPhotosInAlbum.DisplayMember = "DESCRIPTION";

            // select an item if there is anything to select..
            if (lbPhotosInAlbum.Items.Count > 0)
            {
                lbPhotosInAlbum.SelectedIndex = 0;
            }
        }

        private void DisplayPhoto(PhotoAlbumEntry photoAlbumEntry)
        {
            changeEventsSuspended = true; // indicate to discard all change event handlers..
            currentPhotoAlbumEntry = photoAlbumEntry; // set the current photo album entry..

            // dispose of the last image..
            lastImage?.Dispose();

            // set the form's title..
            Text = DBLangEngine.GetMessage("msgVampPhotoAlbumEditor",
                "vamp# photo album editor|A title for the photo album editor") +
                $" [{CurrentAlbum.NAME} / '{Path.Combine(photoAlbumEntry.BASEDIROVERRIDE, photoAlbumEntry.FILENAME)}']";

            // create a new image only if one exists in the file system..
            if (File.Exists(Path.Combine(photoAlbumEntry.BASEDIROVERRIDE, photoAlbumEntry.FILENAME)))
            {
                // the file exists so do create an Image class instance from it..
                lastImage = Image.FromFile(Path.Combine(photoAlbumEntry.BASEDIROVERRIDE, photoAlbumEntry.FILENAME));
                // display the new image..
                ivPhoto.Image = lastImage;
            }
            // indicate a missing image file..
            else
            {
                ivPhoto.Image = Properties.Resources.image_not_found;
            }

            // I DO HATE REGULAR EXPRESSIONS (?!), but anyhow this pattern will match:
            // a single carriage return character (\r) or a single line feed (\n) character not preceded or followed by
            // a single carriage return character (\r) or a single line feed character (\n)..
            // (HOW SIMPLE!!)..
            Regex regex = new Regex(@"(?<!(\n|\r))(\n|\r)(?!(\n|\r))");

            // hopefully this regular expression makes the new line suitable for all environments..
            string descriptionMultiline = regex.Replace(photoAlbumEntry.DESCRIPTION_REAL, Environment.NewLine);

            // replace the default new line with the Environment.NewLine value..
            descriptionMultiline = descriptionMultiline.Replace("\r\n", Environment.NewLine);

            // set the description to the text box..
            tbPhotoDescriptionValue.Text = descriptionMultiline;

            // set the time taken value..
            dtpTimeTakenValueDate.Value = photoAlbumEntry.DATETIME;

            // set the date taken value..
            dtpTimeTakenValueTime.Value = photoAlbumEntry.DATETIME;

            // set the optional description for the date and time..
            tbTimeTakenTextValue.Text = photoAlbumEntry.DATETIME_FREE;

            // list the tags assigned to the current entry..
            ListEntryTags(photoAlbumEntry);

            changeEventsSuspended = false; // indicate to enable all change event handlers..
        }

        /// <summary>
        /// Lists the tags assigned to the given photo album entry to the list box.
        /// </summary>
        /// <param name="photoAlbumEntry">The photo album entry of which tags to list.</param>
        private void ListEntryTags(PhotoAlbumEntry photoAlbumEntry)
        {
            // split the comma-delimited list to a list of strings..
            List<string> tagList = new List<string>(photoAlbumEntry.TAGTEXT.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));

            // clear the list box..
            lbPhotoTagValues.Items.Clear();

            // add the tags to the list box..
            lbPhotoTagValues.Items.AddRange(tagList.ToArray());

            // clear the list of current photo album entry's tags..
            currentPhotoTags.Clear();

            // unselect the items from the tags saved into the database..
            lbPhotoAlbumTagListValues.ClearSelected();

            // initialize the top index with an invalid value so it can be set..
            int topIndex = -1;

            // loop through the tags..
            foreach (string strTag in tagList)
            {
                // add the tag to the current tag list..
                currentPhotoTags.Add(new PHOTODATATAG() { TAGTEXT = strTag });

                // loop through the list box displaying all the tags in the database..
                for (int i = 0; i < lbPhotoAlbumTagListValues.Items.Count; i++)
                {
                    // compare the item to the tag..
                    PHOTODATATAG tag = (PHOTODATATAG)lbPhotoAlbumTagListValues.Items[i];

                    // if match..
                    if (tag.TAGTEXT == strTag) 
                    {
                        // ..select the item..
                        lbPhotoAlbumTagListValues.SetSelected(i, true);

                        // if the top index is not saved yet, set the top index to the first match's index..
                        if (topIndex == -1)
                        {
                            topIndex = i;
                        }
                    }
                }
            }

            // scroll the list box to the first match index..
            lbPhotoAlbumTagListValues.TopIndex = topIndex;
        }

        /// <summary>
        /// Removes the tag from a photo album entry (image/photo).
        /// </summary>
        /// <param name="tags">The list of current tags.</param>
        /// <param name="tagText">The text of the tag to remove.</param>
        private void RemoveTag(ref List<PHOTODATATAG> tags, string tagText)
        {
            // loop backwards as a list is in question..
            for (int i = tags.Count - 1; i >= 0; i--)
            {
                // if a match was found the remove the match..
                if (tags[i].TAGTEXT == tagText)
                {
                    tags.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Removes a given photo album entry from the given photo album.
        /// </summary>
        /// <param name="albumName">Name of the photo album.</param>
        /// <param name="photoAlbumEntry">The photo album entry to remove from the photo album.</param>
        /// <returns></returns>
        private bool RemovePhotoFromAlbum(string albumName, PhotoAlbumEntry photoAlbumEntry)
        {
            // delete from the database and return the success value..
            bool success = Database.DeletePhotoAlbumFile(albumName, photoAlbumEntry);            
            if (success)
            {
                lbPhotosInAlbum.Items.Remove(photoAlbumEntry);
            }
            return success;
        }

        /// <summary>
        /// Enumerates the folder's contents containing the photos to be added to the album and then adds a new photo album to the database.
        /// </summary>
        /// <param name="albumName">Name of the photo album to be added in to the database.</param>
        /// <param name="albumFolder">The folder to be enumerated into the photo album.</param>
        public void EnumerateFolder(string albumName, string albumFolder)
        {
            // create a new list of photo album entries..
            List<PhotoAlbumEntry> entries = new List<PhotoAlbumEntry>();

            // get the image files in the given folder..
            IEnumerable<FileEnumeratorFileEntry> files = FileEnumerator.GetFilesPath(albumFolder, FileEnumerator.FiltersImage);

            // set the first date to a ridiculous value - as I except this program not to be used at the year of 9999 :-) ..
            DateTime dateTimeMin = DateTime.MaxValue;

            // loop through the found image files..
            foreach (var file in files)
            {
                // hash the photo file's contents to identify the photo file..
                MD5 mD5 = MD5.Create(); // create a MD5 hash algorithm..

                // hash the contents of the photo file..
                IOHash.MD5AppendFile(file.FileNameWithPath, ref mD5);
                IOHash.MD5FinalizeBlock(ref mD5);

                // get the hash string value..
                string md5str = IOHash.MD5GetHashString(ref mD5);
                mD5.Dispose(); // dispose of the MD5 class instance..

                // a date and time for when the photo was taken..
                DateTime dateTime;

                try // preparing for everything..
                {
                    // get the meta data directories from the image file..
                    var directories = ImageMetadataReader.ReadMetadata(file.FileNameWithPath);

                    //gGet the original date time Exif tag value..
                    var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                    dateTime = subIfdDirectory !=
                        null ? // a null value makes it now..
                        subIfdDirectory.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal) : DateTime.Now;
                }
                catch (Exception ex) // something went wrong so do log the reason.. (ex avoids the EventArgs e in all cases!)..
                {
                    dateTime = DateTime.Now; // an exception makes it now..
                    ExceptionLogger.LogError(ex); // do note that this needs to be "bound" to the application..
                }

                // update the first photo time taken value..
                if (dateTime < dateTimeMin)
                {
                    dateTimeMin = dateTime; // set the minimum date as the album date..
                }

                // add a new photo album entry to the list..
                entries.Add(new PhotoAlbumEntry()
                {
                    DATETIME = dateTime, // the date and time the photo was taken..

                    // set the file name based on if the file is in the default directory or not..
                    FILENAME = file.FileNameWithPath.StartsWith(Settings.PhotoBaseDir, StringComparison.InvariantCultureIgnoreCase) ?
                                 file.FileNameWithPath.Substring(Settings.PhotoBaseDir.Length).TrimStart(Path.DirectorySeparatorChar) :
                                 file.FileNameWithPath,
                    BASEDIROVERRIDE = string.Empty, // kind of useless..

                    // the free description of date and time is empty at this time..
                    DATETIME_FREE = string.Empty,

                    // set the default description from the file name..
                    DESCRIPTION = file.FileNameNoExtension,

                    // set the MD5 hash value..
                    MD5HASH = md5str,

                    // set the photo album's name..
                    NAME = albumName,

                    // the tag text for a new entry can be empty..
                    TAGTEXT = string.Empty,
                });
            }

            // sort the entries be their dates and times..
            entries.Sort((x, y) => x.DATETIME.CompareTo(y.DATETIME));

            // add the PHOTOALBUM to the collections of photo albums..
            photoAlbums.Add(new PHOTOALBUM
            {
                // set the first date and time the photo was taken in the photo album..
                FIRSTDATE = dateTimeMin,
                BASEDIROVERRIDE = string.Empty, // kind of useless..
                NAME = albumName // set the album's name..
            });

            // save the photo album into the database..
            if (Database.InsertPhotoAlbum(photoAlbums.LastOrDefault(), entries))
            {
                // if success select the inserted album..
                ListAlbums(photoAlbums.LastOrDefault());
            }
        }

        /// <summary>
        /// Updates a given photo album entry to the list box.
        /// </summary>
        /// <param name="photoAlbumEntry">The photo album entry to update to the list box.</param>
        private void UpdatePhotoAlbumEntry(PhotoAlbumEntry photoAlbumEntry)
        {
            // avoid exceptions by disregarding null values..
            if (photoAlbumEntry == null)
            {
                return;
            }

            // find an index for the given photo album entry..
            int index = photoAlbumEntries.FindIndex(f => f.MD5HASH == photoAlbumEntry.MD5HASH && f.NAME == photoAlbumEntry.NAME);
            if (index != -1) // only allow non-negative indices..
            {
                photoAlbumEntries[index] = photoAlbumEntry; // set the value..
            }

            // find an index to the given photo album entry from the list box containing them..
            index = FindListBoxIndex(lbPhotosInAlbum, photoAlbumEntry, "MD5HASH"); // ..with an MD5HASH value..
            if (index != -1) // only allow non-negative indices..
            {
                changeEventsSuspended = true; // indicate to discard all change event handlers..
                lbPhotosInAlbum.Items[index] = photoAlbumEntry; // set the item..

                // refresh the display member values, as they don't automatically refresh if a same object is
                // re-assigned..
                lbPhotosInAlbum.RefreshItems();
                changeEventsSuspended = false; // indicate to enable all change event handlers..
            }
        }

        /// <summary>
        /// Updates the photo album into the internal list and into the list box.
        /// </summary>
        /// <param name="albumEntry">The album to update.</param>
        private void UpdatePhotoAlbum(PHOTOALBUM albumEntry)
        {
            // find an index for the given photo album..
            int index = photoAlbums.FindIndex(f => f.NAME == albumEntry.PreviousName);
            if (index != -1) // only allow non-negative indices..
            {
                photoAlbums[index] = albumEntry; // set the value..
            }

            // find an index to the given photo album from the list box containing them..
            index = FindListBoxIndex(lbPhotoAlbumList, albumEntry, "PreviousName");
            if (index != -1)
            {
                changeEventsSuspended = true; // indicate to discard all change event handlers..
                lbPhotoAlbumList.Items[index] = albumEntry; // set the item..

                // refresh the display member values, as they don't automatically refresh if a same object is
                // re-assigned..
                lbPhotoAlbumList.RefreshItems();
                changeEventsSuspended = false; // indicate to enable all change event handlers..
            }
        }
        #endregion

        #region ListBoxHelpers
        /// <summary>
        /// "Initialize" drag and drop operation from a list box.
        /// </summary>
        /// <param name="sender">The sender from an event. This will be cast into a ListBox class.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <param name="index">An index of a list box item at the mouse coordinates.</param>
        /// <param name="lb">The <paramref name="sender"/> casted into a ListBox.</param>
        /// <param name="item">An item of the list box at the mouse coordinates..</param>
        /// <returns>True if an item was found in the current mouse coordinates; otherwise false.</returns>
        private bool InitDragDropListBox(object sender, MouseEventArgs e, out int index, out ListBox lb, out object item)
        {
            // cast the sender parameter into a ListBox..
            lb = (ListBox)sender;

            // get an item's index at the current mouse coordinates..
            index = lb.IndexFromPoint(e.X, e.Y); 

            // if the index is invalid..
            if (index < 0 || index >= lb.Items.Count)
            {
                item = null; // ..set the item to null and..
                return false; // ..return false..
            }
            else // the index is valid..
            {
                item = lb.Items[index]; // ..set the item's value and..
                return true; // ..return true..
            }
        }

        /// <summary>
        /// Sorts the items in a ListBox by their string values.
        /// </summary>
        /// <param name="listBox">The list box of which items to sort.</param>
        private static void SortListBox(ListBox listBox)
        {
            SortListBox(listBox, "System.String", typeof(string));
        }

        /// <summary>
        /// Sorts the items in a ListBox by a given value type and the name of the member.
        /// </summary>
        /// <param name="listBox">The list box of which items to sort.</param>
        /// <param name="valueMemberName">The name of the field or a property to be used in the sort operation.</param>
        /// <param name="type">The type.</param>
        private static void SortListBox(ListBox listBox, string valueMemberName, Type type)
        {
            // list the list box's items to a list of objects..
            List<object> lbItems = new List<object>();
            foreach (object item in listBox.Items)
            {
                lbItems.Add(item);
            }

            // no idea if this method of ordering will actually work (!)..
            if (valueMemberName != "System.String")
            {
                lbItems = // order the items..
                    lbItems.
                    OrderBy(f => Convert.ChangeType(f.GetType().GetProperty(valueMemberName, 
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance), type)).ToList();
            }
            else // ..this one however works..
            {
                lbItems = // order the items..
                    lbItems.
                    OrderBy(f => (string)f).ToList();
            }

            // clear the items in the given list box..
            listBox.Items.Clear();

            // add the sorted items back to the given list box..
            listBox.Items.AddRange(lbItems.ToArray());
        }
        #endregion

        #region GUILogic
        private void mnuExit_Click(object sender, EventArgs e)
        {
            // exit menu was selected..
            Close();
        }

        private void FormPhotoAlbumEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // don't allow the form to close when the photo album has been changed..
            if (AlbumChanged)
            {
                // ..so just cancel and return..
                e.Cancel = true;
                return;
            }

            // close the database connection and "WACUUM" the database to ensure it's indexes remain non-fragmented..
            Database.CloseAndFinalizeDatabase();
        }

        private void lbPhotoAlbumList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (changeEventsSuspended) // no change events are allowed..
            {
                return; // ..so do return..
            }

            changeEventsSuspended = true; // indicate to discard all change event handlers..

            // set the form's title..
            Text = DBLangEngine.GetMessage("msgVampPhotoAlbumEditor",
                "vamp# photo album editor|A title for the photo album editor");

            // set the current album value..
            CurrentAlbum = (PHOTOALBUM)((ListBox)sender).SelectedItem;

            // save the current album's value so the change(s) may be undone..
            PreviousAlbum = CurrentAlbum;

            // avoid exceptions by disregarding null values..
            if (CurrentAlbum == null)
            {
                changeEventsSuspended = false; // indicate to enable all change event handlers..
                return;
            }

            // set the album name to the corresponding text box..
            tbPhotoAlbumNameValue.Text = CurrentAlbum.NAME;

            // set the date value of the date of when the first photo was taken..
            dtpPhotoAlbumFirstDateValue.Value = CurrentAlbum.FIRSTDATE;

            // set the date value of the time of when the first photo was taken..
            dtpPhotoAlbumFirstTimeValue.Value = CurrentAlbum.FIRSTDATE;

            // list the album's contents..
            ListAlbumContents(CurrentAlbum.NAME);

            changeEventsSuspended = false; // indicate to enable all change event handlers..
        }

        private void lbPhotosInAlbum_SelectedValueChanged(object sender, EventArgs e)
        {
            // get the selected photo from the selected album..
            PhotoAlbumEntry photoAlbumEntry = (PhotoAlbumEntry)((ListBox)sender).SelectedItem;

            // avoid exceptions by disregarding null values..
            if (photoAlbumEntry == null)
            {
                return;
            }

            // find a photo by it's MD5 hash algorithm's value..
            photoAlbumEntry = photoAlbumEntries.FirstOrDefault(f => f.MD5HASH == photoAlbumEntry.MD5HASH);

            // display the photo..
            DisplayPhoto(photoAlbumEntry);
        }

        // mouse was clicked on the current item's tag list box..
        private void lbPhotoTagValues_MouseDown(object sender, MouseEventArgs e)
        {
            if (!InitDragDropListBox(sender, e, out int index, out ListBox lb, out object dragDrop))
            {
                return; // the click was "invalid" so just return..
            }

            // create a move effect to allow dragging tags to the trash bin..
            if (lb.DoDragDrop(dragDrop, DragDropEffects.Move) == DragDropEffects.Move)
            {
                // if dropped to the trash bin, remove the item..
                lb.Items.RemoveAt(index);
            }
        }

        // mouse was clicked on the current item's photo album entry list box..
        private void lbPhotosInAlbum_MouseDown(object sender, MouseEventArgs e)
        {
            // this event seems to block the SelectedValueChanged event so call it manually..
            lbPhotosInAlbum_SelectedValueChanged(sender, new EventArgs());

            if (!InitDragDropListBox(sender, e, out int index, out ListBox lb, out object dragDrop))
            {
                return; // the click was "invalid" so just return..
            }

            // create a move effect to allow dragging photo album entries to the trash bin..
            if (lb.DoDragDrop(dragDrop, DragDropEffects.Move) == DragDropEffects.Move)
            {
                // if dropped to the trash bin, remove the item..
                lb.Items.RemoveAt(index);
            }
        }

        private void lbPhotoAlbumTagListValues_MouseDown(object sender, MouseEventArgs e)
        {
            if (!InitDragDropListBox(sender, e, out int index, out ListBox lb, out object dragDrop))
            {
                return; // the click was "invalid" so just return..
            }

            // create a copy effect to allow dragging tags from the list box containing all the
            // tags in the database to the current photo's tag list..
            lb.DoDragDrop(dragDrop, DragDropEffects.Copy);
        }

        // one handler for all the drop effects..
        private void common_DragDrop(object sender, DragEventArgs e)
        {
            if (changeEventsSuspended) // no change events are allowed..
            {
                return; // ..so do return..
            }

            // if the data is of type of string set the effect to move..
            if (e.Data.GetDataPresent(typeof(string)) &&
                sender.Equals(pnTrash)) // the sender must be the "trash bin"..
            {
                e.Effect = DragDropEffects.Move; // ensure a move effect..
                string tagText = (string)e.Data.GetData(typeof(string));
                RemoveTag(ref currentPhotoTags, tagText); // remove the tag dragged to the trash bin..

                // set the tag text of the current entry by joining the list into a comma delimited string..
                List<string> tags = currentPhotoTags.Select(f => f.TAGTEXT).ToList();
                currentPhotoAlbumEntry.TAGTEXT = string.Join(", ", tags); // ..so join the tags..

                lbPhotoTagValues.Items.Remove(tagText);

                // set the album changed value to true..
                AlbumChanged = true;
            }
            // if the data is of type of PhotoAlbumEntry set the effect to move..
            if (e.Data.GetDataPresent(typeof(PhotoAlbumEntry)) &&
                sender.Equals(pnTrash)) // the sender must be the "trash bin"..
            {
                e.Effect = DragDropEffects.Move; // ensure a move effect..
                PhotoAlbumEntry entry = (PhotoAlbumEntry)e.Data.GetData(typeof(PhotoAlbumEntry));

                // confirm the deletion of an entry from the current photo album..
                if (MessageBox.Show(
                    DBLangEngine.GetMessage("msgConfirmPhotoAlbumDeleteItemDelete",
                        "Are you sure you want to delete the photo '{0}' from the photo album named: '{1}'?|A confirmation question for a photo album item's delete request",
                        entry.DESCRIPTION, entry.NAME),
                    DBLangEngine.GetMessage("msgConfirm",
                        "Confirm|A short message indicating that a some action should be confirmed by the user"),
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // the user accepted the deletion so remove the entry from the current photo album..
                    RemovePhotoFromAlbum(entry.NAME, entry);
                }

                // this action is permanent so no reason to set the changed flag..
                //AlbumChanged = true;
            }
            // if the data is of type of PHOTODATATAG..
            else if (e.Data.GetDataPresent(typeof(PHOTODATATAG)) &&
                // and if the sender is either the list box containing the current photo tags or
                // the sender is the image viewer showing the current photo..
                (sender.Equals(lbPhotoTagValues) || sender.Equals(ivPhoto)))
            {
                e.Effect = DragDropEffects.Copy; // ensure a copy effect..

                // get the dragged data value..
                PHOTODATATAG tag = (PHOTODATATAG)e.Data.GetData(typeof(PHOTODATATAG));

                // don't add a tag if it already exists..
                if (!currentPhotoTags.Exists(f => f.TAGTEXT == tag.TAGTEXT))
                {
                    // add the tag to the currently selected photo's tag list..
                    currentPhotoTags.Add(tag);

                    // add the tag to the currently selected photo's tag list box..
                    lbPhotoTagValues.Items.Add(tag.TAGTEXT);

                    // order the list box with string comparison..
                    SortListBox(lbPhotoTagValues);

                    // set the tag text of the current entry by joining the list into a comma delimited string..
                    List<string> tags = currentPhotoTags.Select(f => f.TAGTEXT).ToList();
                    currentPhotoAlbumEntry.TAGTEXT = string.Join(", ", tags); // ..so join the tags..

                    // update the currently selected photo album entry with the new tags..
                    UpdatePhotoAlbumEntry(currentPhotoAlbumEntry);

                    // set the album changed value to true..
                    AlbumChanged = true;
                }
            }
            else
            {
                // indicate an "invalid" drag & drop operation..
                e.Effect = DragDropEffects.None;
            }
        }

        // one handler for all the drag over and drag enter events..
        private void common_DragOverDragEnter(object sender, DragEventArgs e)
        {
            // strings will be..
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move; // ..moved..
            }
            // and if the sender is either the list box containing the current photo tags or
            // the sender is the image viewer showing the current photo..
            else if (e.Data.GetDataPresent(typeof(PHOTODATATAG)) &&
                (sender.Equals(lbPhotoTagValues) || sender.Equals(ivPhoto)))
            {
                e.Effect = DragDropEffects.Copy; // ..the effect is copy..
            }
            // if the sender is the list box containing the current photos in the current photo album..
            else if (e.Data.GetDataPresent(typeof(PhotoAlbumEntry)) &&
                (sender.Equals(pnTrash)))
            {
                e.Effect = DragDropEffects.Move; // moved..
            }
            else
            {
                // indicate an "invalid" drag & drop operation..
                e.Effect = DragDropEffects.None;
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            // create a new FolderSelectDialog class instance..
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog
            {
                // set the title localized..
                Title = DBLangEngine.GetMessage("msgSelectFolder", "Select a folder|A dialog requests a user to select a folder"),
                InitialDirectory = Settings.PhotoBaseDir // set the base directory..
            };

            // get the localized default name for a new album..
            string albumName = FormDialogPhotoAlbumQueryName.Execute(photoAlbums,
                DBLangEngine.GetMessage("msgNewPhotoAlbum", "New photo album|A text describing a new photo album"));

            // the name query succeeded if the album name variable is not an empty string..
            if (albumName != string.Empty)
            {
                // if the folder select dialog succeeds..
                if (folderSelectDialog.ShowDialog())
                {
                    // ..enumerate the contents of the folder and add them to the database..
                    EnumerateFolder(albumName,
                        folderSelectDialog.FileName);
                }
            }
        }

        // set the date and time of either the photo album or a photo in the photo album..
        private void btSetDate_Click(object sender, EventArgs e)
        {
            if (changeEventsSuspended) // no change events are allowed..
            {
                return; // ..so do return..
            }

            // the year, month, day, hour, minute and second variables..
            int year, month, day, hour, minute, second;

            // if the button for photo album's first photo taken date and time button was clicked..
            if (sender.Equals(btPhotoAlbumFirstDateTimeSet))
            {
                // two separate controls are required (one for the date and one for the time) to
                // allow default localization of date and time formats..
                year = dtpPhotoAlbumFirstDateValue.Value.Year; // get the year..
                month = dtpPhotoAlbumFirstDateValue.Value.Month; // get the month..
                day = dtpPhotoAlbumFirstDateValue.Value.Day; // get the day..
                hour = dtpPhotoAlbumFirstTimeValue.Value.Hour; // get the hour..
                minute = dtpPhotoAlbumFirstTimeValue.Value.Minute; // get the minute..
                second = dtpPhotoAlbumFirstTimeValue.Value.Second; // get the second..

                // construct a date and time from the variables set before and set the value..
                CurrentAlbum.FIRSTDATE = new DateTime(year, month, day, hour, minute, second);

                // all the photos in the photo album with lesser date are to be updated to a new date and time value..
                for (int i = 0; i < currentPhotoAlbumEntries.Count; i++)
                {
                    // if the date the photo was taken is lesser than the photo album's date..
                    if (currentPhotoAlbumEntries[i].DATETIME < CurrentAlbum.FIRSTDATE)
                    {
                        // ..update the date..
                        currentPhotoAlbumEntries[i].DATETIME = CurrentAlbum.FIRSTDATE;

                        // update the current photo album entry..
                        UpdatePhotoAlbumEntry(currentPhotoAlbumEntries[i]);
                    }
                }

                // set the album changed value to true..
                AlbumChanged = true;
            }
            else if (sender.Equals(btPhotoDateTimeSet))
            {
                // two separate controls are required (one for the date and one for the time) to
                // allow default localization of date and time formats..
                year = dtpTimeTakenValueDate.Value.Year; // get the year..
                month = dtpTimeTakenValueDate.Value.Month; // get the month..
                day = dtpTimeTakenValueDate.Value.Day; // get the day..
                hour = dtpTimeTakenValueTime.Value.Hour; // get the hour..
                minute = dtpTimeTakenValueTime.Value.Minute; // get the minute..
                second = dtpTimeTakenValueTime.Value.Second; // get the second..

                // construct a date and time from the variables set before and set the value..
                currentPhotoAlbumEntry.DATETIME = new DateTime(year, month, day, hour, minute, second);

                // if to photo album's date is larger than a single photo album entry's value..
                if (CurrentAlbum.FIRSTDATE > currentPhotoAlbumEntry.DATETIME)
                {
                    // ..set the date to match the lower date..
                    CurrentAlbum.FIRSTDATE = currentPhotoAlbumEntry.DATETIME;
                }

                // update the current photo album entry..
                UpdatePhotoAlbumEntry(currentPhotoAlbumEntry);

                // set the album changed value to true..
                AlbumChanged = true;
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            // a flag indicating if any albums were actually deleted..
            bool albumsDeleted = false;

            // loop through the selected photo albums..
            foreach (PHOTOALBUM photoAlbum in lbPhotoAlbumList.SelectedItems)
            {
                // confirm for each deletion request of a photo album (precious memories)..
                if (MessageBox.Show(
                    DBLangEngine.GetMessage("msgConfirmPhotoAlbumDelete",
                        "Are you sure you want to delete the photo album named: '{0}'?|A confirmation question for a photo album delete request",
                        photoAlbum.NAME),
                    DBLangEngine.GetMessage("msgConfirm",
                        "Confirm|A short message indicating that a some action should be confirmed by the user"),
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // if yes then delete..
                    Database.DeletePhotoAlbum(photoAlbum.NAME);

                    // set the something deleted flag to true..
                    albumsDeleted = true;
                }
            }

            // some photo albums were deleted reload the album list..
            if (albumsDeleted)
            {
                ListAlbums();
            }
            AlbumChanged = false;
        }

        // a user requested the changes to be discarded..
        private void pnUndoSave_Click(object sender, EventArgs e)
        {
            // set the album changed value to false..
            AlbumChanged = false;

            photoAlbumEntries.RemoveAll(f => f.NAME == PreviousAlbum.NAME);

            //CurrentAlbum.NAME = CurrentAlbum.PreviousName;
            //CurrentAlbum = PreviousAlbum;

            // re-fetch the album from the database..
            List<PhotoAlbumEntry> entries = Database.GetPhotoAlbum(PreviousAlbum.NAME);

             photoAlbumEntries.AddRange(entries);         

            // some changes a in the "cache" so reload the list of albums..
            ListAlbums(CurrentAlbum);
        }

        private void FormPhotoAlbumEditor_Load(object sender, EventArgs e)
        {
            // set the album changed value to false..
            AlbumChanged = false;

            // disable the editors in the GUI at form's load..
            CurrentAlbum = null;

            // no need to be suspended at this moment..
            changeEventsSuspended = false;
        }


        /// <summary>
        /// Finds the index to an item in a ListBox.
        /// </summary>
        /// <param name="listBox">The list box to search for an item for.</param>
        /// <param name="item">An item to search for.</param>
        /// <param name="searchMember">The name of a field or a property of which value is to be used in the search.</param>
        /// <returns>An index if a requested item was found; otherwise -1.</returns>
        private int FindListBoxIndex(ListBox listBox, object item, string searchMember)
        {
            FieldInfo fi = item. // use reflection to first search through the fields of an object..
                GetType().GetField(searchMember, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (fi != null) // if a field exists..
            {
                object value = fi.GetValue(item); // ..get the field's value..
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    // get the value of the specified field..
                    FieldInfo tmpInfo = listBox.Items[i].
                        GetType().GetField(searchMember, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    object listValue = tmpInfo.GetValue(listBox.Items[i]);

                    if (listValue.Equals(value)) // compare it to the given item field's value..
                    {
                        return i; // ..if a match then return the index..
                    }
                }
            }
            
            PropertyInfo pi = item.GetType(). // use reflection to search through the properties of an object..
                GetProperty(searchMember, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (pi != null) // if a property exists..
            {
                object value = pi.GetValue(item); // ..get the property's value..
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    // get the value of the specified property..
                    PropertyInfo tmpInfo = listBox.Items[i].
                        GetType().GetProperty(searchMember, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    object listValue = tmpInfo.GetValue(listBox.Items[i]);

                    if (listValue.Equals(value)) // compare it to the given item property's value..
                    {
                        return i; // ..if a match then return the index..
                    }
                }
            }
            return -1; // no match, return an invalid index..
        }

        // "save" button was clicked..
        private void pnSave_Click(object sender, EventArgs e)
        {
            // ..so do reflect the possible changes into the database..
            Database.UpdatePhotoAlbum(CurrentAlbum, currentPhotoAlbumEntries);

            // set the album changed value to false..
            AlbumChanged = false;
        }

        // a new tag was requested to be added to a current photo album entry and 
        // possibly into the database if such tag doesn't exist yet..
        private void btAddTag_Click(object sender, EventArgs e)
        {
            if (changeEventsSuspended) // no change events are allowed..
            {
                return; // ..so do return..
            }

            if (tbAddTag.Text.Trim() != string.Empty && // an empty tag is not allowed..
                // and existing tag is not allowed..
                !currentPhotoTags.Exists(f => f.TAGTEXT.Equals(tbAddTag.Text, StringComparison.InvariantCultureIgnoreCase)))
            {
                // the test was passed so do add the new tag to the currently selected photo..
                currentPhotoTags.Add(new PHOTODATATAG() { TAGTEXT = tbAddTag.Text.Trim() });

                // construct a comma-delimited string of the tags..
                List<string> tags = currentPhotoTags.Select(f => f.TAGTEXT).ToList();

                // ..and update the current photo with the tag text..
                currentPhotoAlbumEntry.TAGTEXT = string.Join(", ", tags);

                // if the database doesn't yet contain the added tag, do add it to the database as well..
                if (!photoTags.Exists(f => f.TAGTEXT.EndsWith(tbAddTag.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)))
                {
                    // create a new tag instance..
                    photoTags.Add(new PHOTODATATAG() { TAGTEXT = tbAddTag.Text.Trim() });

                    // sort the tag list..
                    photoTags.Sort((x, y) => x.TAGTEXT.CompareTo(y.TAGTEXT));

                    // list the tags in the database to the list box..
                    ListTags();
                }

                // update the currently selected photo album entry with the new tag..
                UpdatePhotoAlbumEntry(currentPhotoAlbumEntry);

                // set the album changed value to true..
                AlbumChanged = true;
            }
        }

        // an indicator if the current photo album was changed..
        private bool _AlbumChanged = false;

        /// <summary>
        /// Gets or sets a value indicating whether the current photo album has changed. This flag also affects the state of the GUI.
        /// </summary>
        private bool AlbumChanged
        {
            get
            {
                // return the flag's value..
                return _AlbumChanged;
            }

            set
            {
                _AlbumChanged = value;

                // set the image of the save button according to the flag's value..
                pnSave.BackgroundImage = value ?
                    Properties.Resources.save_changes : // enabled..
                    UtilsMisc.MakeGrayscale3(Properties.Resources.save_changes); // disabled..

                // set the image of undo save button according to the flag's value..
                pnUndoSave.BackgroundImage = value ?
                    Properties.Resources.undo_save_changes : // enabled..
                    UtilsMisc.MakeGrayscale3(Properties.Resources.undo_save_changes); // disabled..


                // set some of the GUI controls to enabled/disabled state according to the flag's value..
                pnSave.Enabled = value;
                lbPhotoAlbumList.Enabled = !value; 
                mnuNew.Enabled = !value;
                mnuExportSelectedXML.Enabled = !value;
                mnuImportXML.Enabled = !value;
                mnuExportSelectedSQL.Enabled = !value;
                mnuImportSQL.Enabled = !value;
                mnuDelete.Enabled = !value;
                mnuSaveChanges.Enabled = value;
                pnUndoSave.Enabled = value;
                mnuUndoChanges.Enabled = value;
                // END: set some of the GUI controls to enabled/disabled state according to the flag's value..
            }
        }

        // a description of the currently selected photo was changed..
        private void tbPhotoDescriptionValue_TextChanged(object sender, EventArgs e)
        {
            if (changeEventsSuspended) // no change events are allowed..
            {
                return; // ..so do return..
            }

            // update the description..
            currentPhotoAlbumEntry.DESCRIPTION_REAL = ((TextBox)sender).Text;

            // update the currently selected photo album entry with the new description..
            UpdatePhotoAlbumEntry(currentPhotoAlbumEntry);

            // set the album changed value to true..
            AlbumChanged = true;
        }

        // a time taken free description value was changed..
        private void tbTimeTakenTextValue_TextChanged(object sender, EventArgs e)
        {
            if (changeEventsSuspended) // no change events are allowed..
            {
                return; // ..so do return..
            }

            // update the description of the time taken..
            currentPhotoAlbumEntry.DATETIME_FREE = ((TextBox)sender).Text;

            // update the currently selected photo album entry with the new description..
            UpdatePhotoAlbumEntry(currentPhotoAlbumEntry);

            // set the album changed value to true..
            AlbumChanged = true;
        }

        // the search string for the photo tags was changed..
        private void tbFilterTags_TextChanged(object sender, EventArgs e)
        {
            // ..so do filter the tag list with the search string..
            ListTags(((TextBox)sender).Text);
        }

        // copies the tags from a photo entry into the memory (not to the clipboard)..
        private void mnuCopyTags_Click(object sender, EventArgs e)
        {
            if (lbPhotosInAlbum.SelectedItem != null)
            {
                PhotoAlbumEntry photoAlbumEntry = (PhotoAlbumEntry)lbPhotosInAlbum.SelectedItem;
                copyTags = photoAlbumEntry.TAGTEXT;
            }
        }

        // the context menu which allows tags to be pasted to another photo entry is opening..
        private void cmsPasteTags_Opening(object sender, CancelEventArgs e)
        {
            // ..so make sure there is some reason for the menu item to be enabled..
            mnuPasteTags.Enabled = copyTags != string.Empty;
        }

        // pastes the tags from memory (not from the clipboard) to a currently selected photo entry..
        private void mnuPasteTags_Click(object sender, EventArgs e)
        {
            if (currentPhotoAlbumEntry != null) // only if a photo entry is selected..
            {
                currentPhotoAlbumEntry.TAGTEXT = copyTags; // set the tag text from the memory..

                // update the current photo entry's tag list..
                ListEntryTags(currentPhotoAlbumEntry);
            }
        }
        #endregion

        #region ImportExport        
        /// <summary>
        /// Gets a collection of ListBox's selected indices.
        /// </summary>
        /// <param name="lb">A ListBox of which selected indices to get.</param>
        /// <returns>A collection of ListBox's selected indices.</returns>
        private IEnumerable<int> GetListBoxSelectedIndices(ListBox lb)
        {
            // loop through the selected indices..
            for (int i = 0; i < lb.SelectedIndices.Count; i++)
            {
                // return the index..
                yield return lb.SelectedIndices[i];
            }
        }

        // exports selected items from the photo album list box into a XML file..
        private void mnuExportSelectedXML_Click(object sender, EventArgs e)
        {
            // check if the user has accepted the save file dialog..
            if (sdXML.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sdXML.FileName))
                {
                    File.Delete(sdXML.FileName);
                }

                // get the selected indices of the list box..
                IEnumerable<int> indices = GetListBoxSelectedIndices(lbPhotoAlbumList);

                // loop through the indices and append the photo album's contents into a XML file..
                foreach (int index in indices)
                {
                    PHOTOALBUM album =(PHOTOALBUM)(lbPhotoAlbumList.Items[index]);

                    // get the photo album's contents..
                    List<PhotoAlbumEntry> albumEntries =
                        photoAlbumEntries.Where(f => f.NAME == album.NAME).Distinct().ToList();

                    // append the album to a XML file..
                    Database.AppendPhotoAlbumXML(sdXML.FileName, album, albumEntries);
                }
            }
        }

        // exports selected items from the photo album list box into a SQL file..
        private void mnuExportSelectedSQL_Click(object sender, EventArgs e)
        {
            // check if the user has accepted the save file dialog..
            if (sdSQL.ShowDialog() == DialogResult.OK)
            {
                // get the selected indices of the list box..
                IEnumerable<int> indices = GetListBoxSelectedIndices(lbPhotoAlbumList);

                // initialize a string to hold the generated SQL.. 
                string sql = string.Empty;

                // loop through the indices and append the photo album's contents into a XML file..
                foreach (int index in indices)
                {
                    PHOTOALBUM album = (PHOTOALBUM)(lbPhotoAlbumList.Items[index]);

                    // get the photo album's contents..
                    List<PhotoAlbumEntry> albumEntries =
                        photoAlbumEntries.Where(f => f.NAME == album.NAME).Distinct().ToList();

                    // generate a SQL sentence for the photo album..
                    sql += Database.GenPhotoAlbumInsert(album, albumEntries);
                }

                // only save if something is to be saved..
                if (sql != string.Empty)
                {
                    // save the SQL to a file...
                    File.WriteAllText(sdSQL.FileName, sql);
                }
            }
        }

        private bool PathEquals(string path1, string path2)
        {
            return Path.GetFullPath(path1).CompareTo(Path.GetFullPath(path2)) == 0;
        }

        // imports a XML file contents describing photo albums into the database..
        private void mnuImportXML_Click(object sender, EventArgs e)
        {
            // check if the user has accepted the open file dialog..
            if (odXML.ShowDialog() == DialogResult.OK)
            {
                // get the names of the albums in the XML file..
                List<string> list = Database.GetAlbumsFromXML(odXML.FileName).ToList();

                // a flag indicating if any albums were actually inserted in to the database..
                bool albumsInserted = false;

                // loop through the photo albums..
                foreach (string item in list)
                {
                    string noOverrideSettingPath = Settings.PhotoBaseDir;

                    // read a photo album with a name from the XML file..
                    if (Database.GetPhotoAlbumFromXML(odXML.FileName, item, out PHOTOALBUM album, out IEnumerable<PhotoAlbumEntry> entries))
                    {
                        // to list for index iteration..
                        List<PhotoAlbumEntry> photoAlbumEntries = entries.ToList();

                        BaseRelativePath newPath = new BaseRelativePath();

                        for (int i = photoAlbumEntries.Count - 1; i >= 0; i--)
                        {
                            newPath =
                                FormDialogPhotoAlbumSelectBaseDirectory.
                                Execute(noOverrideSettingPath, photoAlbumEntries[i].FILENAME);

                            if (newPath.IsEmpty)
                            {
                                photoAlbumEntries.RemoveAt(i);
                            }

                            noOverrideSettingPath = newPath.BaseDir;

                            album.BASEDIROVERRIDE = newPath.BaseDir;
                            photoAlbumEntries[i].FILENAME = newPath.RelativePath;
                        }

                        // only try to insert if the XML read was successful..
                        if (Database.InsertPhotoAlbum(album, photoAlbumEntries))
                        {
                            // set the flag that an insert to the database was made successfully..
                            albumsInserted = true;
                        }
                    }
                }

                // if any photo album was actually inserted to the database..
                if (albumsInserted)
                {
                    // ..list the photo albums..
                    ListAlbums();
                }
            }
        }

        // the user wants to rename a photo album..
        private void btSetAlbumName_Click(object sender, EventArgs e)
        {
            // get the localized default name for a new album or use a previous name for the
            // selected album..
            string albumName = CurrentAlbum != null ?
                CurrentAlbum.NAME :
                FormDialogPhotoAlbumQueryName.Execute(photoAlbums,
                DBLangEngine.GetMessage("msgNewPhotoAlbum", "New photo album|A text describing a new photo album"));

            // get a name for the photo album..
            albumName = FormDialogPhotoAlbumQueryName.Execute(photoAlbums,
                albumName);

            // this indicates that the user canceled the dialog..
            if (albumName.Trim() == string.Empty)
            {
                return; // ..so do return..
            }

            tbPhotoAlbumNameValue.Text = albumName;

            if (changeEventsSuspended) // no change events are allowed..
            {
                return; // ..so do return..
            }

            // set the new name if valid..
            CurrentAlbum.NAME = albumName.Trim() == string.Empty ? CurrentAlbum.NAME : albumName.Trim();

            // update the name to the photo album's entries as well..
            for (int i = 0; i < currentPhotoAlbumEntries.Count; i++)
            {
                currentPhotoAlbumEntries[i].NAME = albumName; // ..update..
            }

            // set the value to the currently selected item..
            currentPhotoAlbumEntry.NAME = albumName;

            // update the currently selected photo album entry with the new tags..
            UpdatePhotoAlbumEntry(currentPhotoAlbumEntry);

            // update the photo album into the internal list and into the list box..
            UpdatePhotoAlbum(CurrentAlbum);

            // set the album changed value to true..
            AlbumChanged = true;
        }

        // imports a SQL file into the database..
        private void mnuImportSQL_Click(object sender, EventArgs e)
        {
            // check if the user has accepted the open file dialog..
            if (odSQL.ShowDialog() == DialogResult.OK)
            {
                // run the SQL against the database..
                if (!Database.ExecuteArbitrarySQL(File.ReadAllText(odSQL.FileName))) // if not successful..
                {
                    // ..do show an error message..                                     
                    MessageBox.Show(DBLangEngine.GetMessage("msgSQLSentenceError", "An error occurred while running a SQL transaction to the database.|As in a some kind of error occurred while running an arbitrary SQL against the SQLite database"),
                        DBLangEngine.GetMessage("msgError", "Error|A message describing that some kind of error occurred."),
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        #endregion
    }
}
