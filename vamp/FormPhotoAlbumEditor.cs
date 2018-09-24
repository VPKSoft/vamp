#region License
/*
vamp#

A software for video audio and photo playback.
Copyright © 2018 VPKSoft, Petteri Kautonen

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

namespace vamp
{
    /// <summary>
    /// An editor for photo albums.
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormPhotoAlbumEditor : DBLangEngineWinforms
    {
        private SQLiteConnection conn; // database connection for the SQLite database

        private List<PHOTODATATAG> photoTags = null; // a current list of tags in the database..
        List<PHOTOALBUM> photoAlbums = null; // a current list of photo albums in the database..

        // a list of entries in the currently selected photo album..
        List<PhotoAlbumEntry> photoAlbumEntries = new List<PhotoAlbumEntry>();

        // a flag indicating whether the GUI should react to change events..
        private bool changeEventsSuspended = true; 

        private PHOTOALBUM currentAlbum; // the currently selected album..

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
                MessageBox.Show(DBLangEngine.GetMessage("msgErrorInScript", "?"));
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
        private void ListAlbums()
        {
            // get a list of photo albums in the database..
            photoAlbums = Database.GetPhotoAlbums().ToList();

            lbPhotoAlbumList.Items.Clear(); // ..and add them to the list box..

            // loop through the photo albums..
            foreach (PHOTOALBUM photoAlbum in photoAlbums)
            {
                // add the entry to the list box..
                lbPhotoAlbumList.Items.Add(photoAlbum);

                // get the data for an album from the database..
                photoAlbumEntries.AddRange(Database.GetPhotoAlbum(photoAlbum.NAME));
            }

            lbPhotoAlbumList.DisplayMember = "NAME"; // set the list box display member..
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

            // create a new image..
            lastImage = Image.FromFile(Path.Combine(photoAlbumEntry.BASEDIROVERRIDE, photoAlbumEntry.FILENAME));

            // display the new image..
            ivPhoto.Image = lastImage;

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

        private void mnuExit_Click(object sender, EventArgs e)
        {
            // exit menu was selected..
            Close();
        }

        private void FormPhotoAlbumEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the database connection and "WACUUM" the database to ensure it's indexes remain non-fragmented..
            Database.CloseAndFinalizeDatabase();
        }

        private void lbPhotoAlbumList_SelectedValueChanged(object sender, EventArgs e)
        {
            changeEventsSuspended = true; // indicate to discard all change event handlers..

            // set the current album value..
            currentAlbum = (PHOTOALBUM)((ListBox)sender).SelectedItem;

            // avoid exceptions by disregarding null values..
            if (currentAlbum == null)
            {
                changeEventsSuspended = false; // indicate to enable all change event handlers..
                return;
            }

            // set the album name to the corresponding text box..
            tbPhotoAlbumNameValue.Text = currentAlbum.NAME;

            // set the date value of the date of when the first photo was taken..
            dtpPhotoAlbumFirstDateValue.Value = currentAlbum.FIRSTDATE;

            // set the date value of the time of when the first photo was taken..
            dtpPhotoAlbumFirstTimeValue.Value = currentAlbum.FIRSTDATE;

            // list the album's contents..
            ListAlbumContents(currentAlbum.NAME);

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
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move; // ensure a move effect..
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
                }
            }
            else
            {
                // indicate an "invalid" drag & drop operation..
                e.Effect = DragDropEffects.None;
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
            foreach(var file in files)
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
            Database.InsertPhotoAlbum(photoAlbums.LastOrDefault(), entries);
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
                currentAlbum.FIRSTDATE = new DateTime(year, month, day, hour, minute, second);

                // all the photos in the photo album with lesser date are to be updated to a new date and time value..
                for (int i = 0; i < currentPhotoAlbumEntries.Count; i++)
                {
                    // if the date the photo was taken is lesser than the photo album's date..
                    if (currentPhotoAlbumEntries[i].DATETIME < currentAlbum.FIRSTDATE)
                    {
                        // ..update the date..
                        currentPhotoAlbumEntries[i].DATETIME = currentAlbum.FIRSTDATE;

                        // update the current photo album entry..
                        UpdatePhotoAlbumEntry(currentPhotoAlbumEntries[i]);
                    }
                }
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
                if (currentAlbum.FIRSTDATE > currentPhotoAlbumEntry.DATETIME)
                {
                    // ..set the date to match the lower date..
                    currentAlbum.FIRSTDATE = currentPhotoAlbumEntry.DATETIME;
                }

                // update the current photo album entry..
                UpdatePhotoAlbumEntry(currentPhotoAlbumEntry);
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
            int index = photoAlbumEntries.FindIndex(f => f.MD5HASH == photoAlbumEntry.MD5HASH);
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
            index = FindListBoxIndex(lbPhotoAlbumList, albumEntry, "NAME");
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

        // the photo album's name was changed..
        private void tbPhotoAlbumNameValue_TextChanged(object sender, EventArgs e)
        {
            if (changeEventsSuspended) // no change events are allowed..
            {
                return; // ..so do return..
            }

            string newName = ((TextBox)sender).Text; // get the new name for the photo album..

            // set the new name if valid..
            currentAlbum.NAME = newName.Trim() == string.Empty ? currentAlbum.NAME : newName.Trim();

            // update the name to the photo album's entries as well..
            for (int i = 0; i < currentPhotoAlbumEntries.Count; i++)
            {
                currentPhotoAlbumEntries[i].NAME = newName; // ..update..
            }

            // set the value to the currently selected item..
            currentPhotoAlbumEntry.NAME = newName;

            // update the currently selected photo album entry with the new tags..
            UpdatePhotoAlbumEntry(currentPhotoAlbumEntry);

            // update the photo album into the internal list and into the list box..
            UpdatePhotoAlbum(currentAlbum);
        }

        // "save" button was clicked..
        private void pnSave_Click(object sender, EventArgs e)
        {
            // ..so do reflect the possible changes into the database..
            Database.UpdatePhotoAlbum(currentAlbum, currentPhotoAlbumEntries);
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

        // imports a XML file contents describing photo albums into the database..
        private void mnuImportXML_Click(object sender, EventArgs e)
        {
            // check if the user has accepted the open file dialog..
            if (odXML.ShowDialog() == DialogResult.OK)
            {
                // get the names of the albums in the XML file..
                List<string> list = Database.GetAlbumsFromXML(odXML.FileName).ToList();

                // loop through the photo albums..
                foreach (string item in list)
                {
                    // read a photo album with a name from the XML file..
                    if (Database.GetPhotoAlbumFromXML(odXML.FileName, item, out PHOTOALBUM album, out IEnumerable<PhotoAlbumEntry> entries))
                    {
                        // only try to insert if the XML read was successful..
                        Database.InsertPhotoAlbum(album, entries);
                    }
                }
            }
        }

        // the user wants to rename a photo album..
        private void btSetAlbumName_Click(object sender, EventArgs e)
        {
            // get the localized default name for a new album..
            string albumName = FormDialogPhotoAlbumQueryName.Execute(photoAlbums,
                DBLangEngine.GetMessage("msgNewPhotoAlbum", "New photo album|A text describing a new photo album"));

            tbPhotoAlbumNameValue.Text = albumName;
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
