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
using System.Windows.Forms;
using System.Data.SQLite; // (C): https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki, Public Domain
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using System.IO;
using VPKSoft.VisualUtils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using TMdbEasy; // (C): https://github.com/tonykaralis/TMdbEasy, GNU General Public License Version 3
using VPKSoft.Utils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.TMDbFileUtils; // (C): https://www.vpksoft.net/2015-03-31-13-33-28/libraries/vpksoft-tmdbfileutils, GNU General Public License Version 3
using TMdbEasy.TmdbObjects.Configuration; // (C): https://github.com/tonykaralis/TMdbEasy, GNU General Public License Version 3
using System.Diagnostics;
using System.Linq;
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3
using System.Threading;

namespace vamp
{
    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class FormMain : DBLangEngineWinforms
    {
        #region PrivateProperties
        private EasyClient easy;
        private Configurations configurations;

        private SQLiteConnection conn; // database connection for the SQLite database

        /// <summary>
        /// String containing multiple characters which can be used to measure maximum text height.
        /// </summary>
        internal const string measureText = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖabcdefghijklmnopqrstuvwxyzåäö£€%[]$@ÂÊÎÔÛâêîôûÄËÏÖÜäëïöüÀÈÌÒÙàèìòùÁÉÍÓÚáéíóúÃÕãõ '|?+\\/{}½§01234567890+<>_-:;*&¤#\"!";

        // a list of "buttons" used in the main form..
        internal List<KeyValuePair<TableLayoutPanel, Panel>> buttonList = new List<KeyValuePair<TableLayoutPanel, Panel>>();
        #endregion

        #region MassiveConstructor
        /// <summary>
        /// A constructor for the MainForm class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            FormSplash.SetStatus("Localization", 0);
            DBLangEngine.InitalizeLanguage("vamp.Messages");
            FormSplash.SetStatus("Localization", 100);
            // List the "buttons", so the image column resize is easier..
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpPlayFileBase, pnPlayFile));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpMoviesBase, pnMovies));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpMoviesBase, pnMovies));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpTVSeriesBase, pnTVSeries));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpMusicAmpBase, pnMusicAmp));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpPlayDiscBase, pnPlayDisc));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpPlayYoutubeBase, pnPlayYoutube));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpInternetBase, pnInternet));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpPhotosBase, pnPhotos));
            buttonList.Add(new KeyValuePair<TableLayoutPanel, Panel>(tlpExitBase, pnExit));
            // END: List the "buttons", so the image column resize is easier..

            FormSplash.SetStatus(FormSplash.MsgInitDatabase, 0);
            // initialize the database..
            conn = new SQLiteConnection("Data Source=" + DBLangEngine.DataDir + "vamp.sqlite;Pooling=true;FailIfMissing=false;Cache Size=10000;"); // PRAGMA synchronous=OFF;PRAGMA journal_mode=OFF
            conn.Open();
            FormSplash.SetStatus(FormSplash.MsgInitDatabase, 100);

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

            Database.DatabaseLoading += DataBase_DatabaseLoading;

            // initialize the DataBase class connection..
            Database.InitConnection(ref conn);

            FormSplash.SetStatus(FormSplash.MsgConfigureTMDbClient, 0);
            InitEasyClient();
            FormSplash.SetStatus(FormSplash.MsgConfigureTMDbClient, 100);


            FormSplash.SetStatus(FormSplash.MsgInitializeVLCDotNet, 0);
            FormPlayer.InitPlayerForm(); // "pseudo" initialization..
            FormSplash.SetStatus(FormSplash.MsgInitializeVLCDotNet, 100);
        }
        #endregion

        #region TMdbEasy
        // an indicator of the TMdbEasy client is configured (i.e. initialized)..
        private bool easyClientConfigured = false;

        // configures / initializes the TMdbEasy client..
        private void InitEasyClient()
        {
            try
            {
                // only if enabled in the settings..
                if (!Settings.TMDBEnabled)
                {
                    // set the flag to false..
                    easyClientConfigured = false;
                    return;
                }

                easy = new EasyClient(Database.APIKey); // please don't misuse this key, please.. (!)..
                configurations = TMDbConfigCache.GetConfigurations(easy, TMDbConfigCache.ConfigPathWinforms);
                easyClientConfigured = true; //only set the flag to true on success..
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogError(ex);
                easyClientConfigured = false; // indicate a failure..
            }
        }
        #endregion

        #region NonSettings
        /// <summary>
        /// Gets or sets the previous playback folder..
        /// </summary>
        private string PlayFolder
        {
            get => Settings.PlayFolder; set => Settings.PlayFolder = value;
        }

        /// <summary>
        /// Gets or sets the previous folder which was browsed for a video file playback. The value is saved to a vnml file.
        /// </summary>
        private string LastBrowseFolder
        {
            get => Settings.LastBrowseFolder; set => Settings.LastBrowseFolder = value;
        }
        #endregion

        #region GUILogic
        private void DataBase_DatabaseLoading(object sender, DatabaseLoadingEventArgs e)
        {
            if (e.DatabaseLoadingType == DatabaseLoadingType.Caching)
            {
                FormSplash.SetStatus(FormSplash.MsgDatabaseCacheLoading, e.CurrentValue, e.EndValue);
            }
            else if (e.DatabaseLoadingType == DatabaseLoadingType.CachingMediaLocations)
            {
                FormSplash.SetStatus(FormSplash.MsgDatabaseMediaLocationCacheLoading, e.CurrentValue, e.EndValue);
            }
            else if (e.DatabaseLoadingType == DatabaseLoadingType.CachingPhotoFileLocations)
            {
                FormSplash.SetStatus(FormSplash.MsgDatabasePhotoCacheLoading, e.CurrentValue, e.EndValue);
            }
        }

        // Handle the clicks to the "buttons" and few labels..
        private void GlobalClickHandler(object sender, EventArgs e)
        {
            // cast the sender to a Control as an object doesn't have tags.. (NOTE: DO REMEMBER NOT TO LOCALIZE THE TAGS!)
            Control control = (Control)sender;

            // the copyright label was clicked..
            if (sender.Equals(lbCopyright))
            {
                // ..so just go to web site of the current "developer"..
                new FormWebBrowserGecko("http://www.vpksoft.net").Show();
                return; // .. and return..
            }
            // the credits (thanks to) label was clicked..
            else if (sender.Equals(lbCredits))
            {
                // .. so just display the PDF file with them..
                FormViewPDF.Execute(Path.Combine(VPKSoft.Utils.Paths.AppInstallDir, "thanks_to.pdf"));
                return; // .. and return..
            }
            // the exit "button" was clicked, so make it possible..
            else if (sender.Equals(pnExit) ||
                    sender.Equals(lbExit) ||
                    ((control.Equals(pnActionImage) && control.Tag.ToString() == "EXIT")))
            {
                Close(); // this will cause a call to the static method: DataBase.CloseAndFinalizeDatabase();
                return; // nothing to do here..
            } // the actual UI "buttons" start from here..
            // the play video file "button" was clicked..
            else if (sender.Equals(pnPlayFile) || sender.Equals(lbPlayFile))
            {
                // display a select file dialog for the previously saved PlayFolder folder and if user selects a file,
                // play the file..
                RunPlayFile(PlayFolder);
            }
            // a YouTube (TV) "button" was clicked..
            else if (sender.Equals(pnPlayYoutube) ||
                     sender.Equals(lbPlayYoutube) ||
                     ((control.Equals(pnActionImage) && control.Tag.ToString() == "YOUTUBE")))
            {
                // just start a Chromium based web browser to show the YouTube..
                new FormWebBrowserChromium("http://www.youtube.com/tv/").Show();
            }
            // a DVD or some other format disc playback was requested..
            else if (sender.Equals(pnPlayDisc) || sender.Equals(lbPlayDisc))
            {
                // a drive for a disc playback is required, only allow drives to be listed with the SelectFileOrDirectoryDialog..
                string drive = FormDialogSelectFileOrDirectory.ExecuteDirectory(":DRIVES:", false, false);

                // replace the escape characters with those that a VLC library may understand..
                drive = drive.Replace('\\', '/');

                // if a drive was actually selected, assume it is a DVD and start a playback..
                if (drive != string.Empty)
                {
                    drive = "dvd:///" + drive;
                    FormPlayer.InitPlayerForm(drive, out _);
                }
            }
            // a music player was requested so start that.. (using amp# remote WCF API)
            else if (sender.Equals(pnMusicAmp) ||
                     sender.Equals(lbMusicAmp) ||
                     sender.Equals(lbMusicAmp) ||
                     ((control.Equals(pnActionImage) && control.Tag.ToString() == "MUSIC")))
            {
                // show the amp# remote control music player form..
                new FormAmpMusicPlayer().Show();
            }
            // a request to add something to a list box based on context was clicked..
            else if (sender.Equals(pnListboxAdd))
            {
                // an URL was requested to be added..
                if (locationContext == "WWW")
                {
                    // execute the SelectLocationDialog instance with an URL query..
                    KeyValuePair<string, string> keyValuePair = FormDialogSelectLocation.ExecuteURL();
                    if (keyValuePair.Key != string.Empty) // ..if something was returned, add the location to the database..
                    {
                        Database.AddLocation(MediaLocationType.MediaLocationURL, keyValuePair.Key, string.Empty, keyValuePair.Value, locationContext);
                    }
                }
                // a TV series location was requested to be added..
                else if (locationContext == "SERIES")
                {
                    // execute the SelectFileOrDirectoryDialog instance with parameters only allowing directories..
                    string item = FormDialogSelectFileOrDirectory.ExecuteDirectory(Settings.TVShowBaseDir, true, true);
                    if (item != string.Empty) // ..if something was returned, add the location to the database..
                    {
                        Database.AddLocation(MediaLocationType.MediaLocationSeries, item, string.Empty, new DirectoryInfo(item).Name, locationContext);
                        LastBrowseFolder = item; // save the latest browsed folder if any..
                        IEnumerable<FileEnumeratorFileEntry> files = FileEnumerator.RecurseFiles(item, FileEnumerator.FiltersVideoVlcNoBinNoIso);

                        int current = 0;
                        int max = files.Count();

                        FormTMDBLoadProgress.ShowProgress(current, max, easyClientConfigured);
                        foreach (FileEnumeratorFileEntry file in files)
                        {
                            Database.SetTMDbInfo(file.FileNameWithPath, easy, easyClientConfigured);
                            FormTMDBLoadProgress.ShowProgress(++current, max, easyClientConfigured);
                        }
                        FormTMDBLoadProgress.EndProgress();
                    }
                }
                // a movie location was requested to be added..
                else if (locationContext == "MOVIE")
                {
                    // execute the SelectFileOrDirectoryDialog instance with parameters only allowing directories..
                    string item = FormDialogSelectFileOrDirectory.ExecuteDirectory(Settings.MovieBaseDir, true, true);
                    if (item != string.Empty) // ..if something was returned, add the location to the database..
                    {
                        Database.AddLocation(MediaLocationType.MediaLocationMovie, item, string.Empty, new DirectoryInfo(item).Name, locationContext);
                        LastBrowseFolder = item; // save the latest browsed folder if any..
                        IEnumerable<FileEnumeratorFileEntry> files = FileEnumerator.RecurseFiles(item, FileEnumerator.FiltersVideoVlcNoBinNoIso);

                        int current = 0;
                        int max = files.Count();

                        FormTMDBLoadProgress.ShowProgress(current, max, easyClientConfigured);
                        foreach (FileEnumeratorFileEntry file in files)
                        {
                            Database.SetTMDbInfo(file.FileNameWithPath, easy, easyClientConfigured);
                            FormTMDBLoadProgress.ShowProgress(++current, max, easyClientConfigured);
                        }
                        FormTMDBLoadProgress.EndProgress();
                    }
                }
            }
            else if (sender.Equals(pnSettings))
            {
                Process process = Process.Start(Path.Combine(VPKSoft.Utils.Paths.AppInstallDir, "vamp#.exe"), "--configure");
            }
        }

        /// <summary>
        /// Disable or enable the tool bar under the location list box.
        /// </summary>
        /// <param name="enabled">If true the tool bar will be visible.</param>
        private void ToggleListboxPanel(bool enabled)
        {
            if (enabled) // to tool bar was set to be enabled..
            {
                // so make the TableLayoutPanel holding the buttons visible..
                tlpListBoxActionHolder.Visible = true;

                // run some "weird" calculations to make it the same size as the left action button panel..
                tlpListBoxHolder.RowStyles[1] = // ..so a row style is required..
                    new RowStyle(SizeType.Absolute,
                    tlpExitBase.Height + 1 + (int)(buttonList.Count * 0.5));
            }
            else // the tool bar was set to be disabled..
            {
                // so make the TableLayoutPanel holding the buttons invisible..
                tlpListBoxActionHolder.Visible = false;

                // no height is required for an invisible tool bar..
                tlpListBoxHolder.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
            }
        }

        // if the main form is activated and there are other forms open with the application,
        // make the other form top-most..
        private void MainForm_Activated(object sender, EventArgs e)
        {
            // check the open form count of the application..
            if (Application.OpenForms.Count > 1)
            {
                // ..and loop through them..
                foreach (Form form in Application.OpenForms)
                {
                    // ..and if the form is not this (the main form)..
                    if (!form.Equals(this))
                    {
                        // bring the other form to the top and leave the iteration loop..
                        Invoke( // invocation might be required..
                            new MethodInvoker(
                                delegate
                                {
                                    form.BringToFront(); // bring the form to the top..
                                    SetGUIEnabled(false); // disable the main form's "GUI"..
                                }));
                        return; // break the loop..
                    }
                }
            }
            // the other case that the only open form is the main form..
            else if (Application.OpenForms.Count == 1 && Application.OpenForms[0].Equals(this))
            {
                // there is no other forms to bring to the front..
                Invoke( // invocation might be required..
                    new MethodInvoker(
                        delegate
                        {
                            SetGUIEnabled(true); // ..so just enable the main form's "GUI"..
                            BringToFront(); // bring the form to the top..
                        }));
            }
        }

        // this is the context which is saved to the "button's" tag when either mouse hovers over them or 
        // they are otherwise being interacted with..
        private string locationContext = "DEFAULT";

        // Handle the mouse enter events for the "buttons" and few labels..
        private void GlobalMouseEnter(object sender, EventArgs e)
        {
            // the sender is most definitely a control..
            Control control = (Control)sender;

            // if the control is the zoomed "action image", e.g. a large YouTube image then the cursor should be a "hand"..
            if (control.Equals(pnActionImage))
            {
                pnActionImage.Cursor = Cursors.Hand;
            }

            // if the control has no tag property, i.e. it's not "usable"..
            if (control.Tag == null)
            {
                return; // ..then just return..
            }

            // save the tag to the "action" image.. there is no matter if the image will be visible or not..
            pnActionImage.Tag = control.Tag;

            // a single file playback is required..
            if (control.Tag.ToString() == "PLAYFILE")
            {
                tlpListBoxHolder.Visible = true; // show the list box..

                // show the container panel showing different contents for different type of items..
                pnMouseHower.Visible = true;
                pnActionImage.Visible = false; // hide the "action" image..
                locationContext = control.Tag.ToString(); // save the location context..

                // get a list of recently browsed paths..
                List<MEDIALOCATION> locations = Database.GetLocations(MediaLocationType.MediaLocationBrowsedPath, locationContext);
                vlbMain.Items.Clear(); // ..and add them to the list box..
                foreach (MEDIALOCATION location in locations)
                {
                    vlbMain.Items.Add(new KeyValuePair<string, string>(location.LOCATION, location.DESCRIPTION));
                }
                vlbMain.DisplayMember = "Value"; // set the list box display member..
                ToggleListboxPanel(false); // hide the "tool bar" under the list box..
            }
            // a photo album "browser" was requested..
            else if (control.Tag.ToString() == "PHOTOS")
            {
                // show the container panel showing different contents for different type of items..
                tlpListBoxHolder.Visible = true;
                pnMouseHower.Visible = true;
                pnActionImage.Visible = false; // hide the "action" image..
                locationContext = control.Tag.ToString(); // save to location context..

                // get a list of photo albums in the database..
                List<MEDIALOCATION> locations = Database.GetLocations(MediaLocationType.MediaLocationPhotoAlbum, locationContext);
                vlbMain.Items.Clear(); // ..and add them to the list box..
                foreach (MEDIALOCATION location in locations)
                {
                    vlbMain.Items.Add(new KeyValuePair<string, string>(location.LOCATION, location.DESCRIPTION));
                }
                vlbMain.DisplayMember = "Value"; // set the list box display member..
                ToggleListboxPanel(false); // hide the "tool bar" under the list box..
            }
            else if (control.Tag.ToString() == "SERIES")
            {
                tlpListBoxHolder.Visible = true;
                pnMouseHower.Visible = true;
                pnActionImage.Visible = false;
                locationContext = control.Tag.ToString();

                // get a list of TV show season directories in the database..
                List<MEDIALOCATION> locations = Database.GetLocations(MediaLocationType.MediaLocationSeries, locationContext);
                vlbMain.Items.Clear(); // ..and add them to the list box..
                foreach (MEDIALOCATION location in locations)
                {
                    vlbMain.Items.Add(new KeyValuePair<string, string>(location.LOCATION, location.DESCRIPTION));
                }
                vlbMain.DisplayMember = "Value"; // set the list box display member..

                ToggleListboxPanel(true); // show the "tool bar" under the list box..
            }
            // a Youtube TV interface was requested..
            else if (control.Tag.ToString() == "YOUTUBE")
            {
                // show the container panel showing different contents for different type of items..
                // set the "action" image button to indicate Youtube..
                pnActionImage.BackgroundImage = Properties.Resources.play_youtube;
                pnMouseHower.Visible = true; // show the panel containing the "action" image..
                pnActionImage.Visible = true; // show the "action" image..
                tlpListBoxHolder.Visible = false; // hide the content list box..

                locationContext = control.Tag.ToString(); // save to location context..
            }
            // a web browser was requested..
            else if (control.Tag.ToString() == "WWW")
            {
                // show the container panel showing different contents for different type of items..
                pnMouseHower.Visible = true; // hide the panel containing the "action" image..
                pnActionImage.Visible = false; // hide the "action" image..
                tlpListBoxHolder.Visible = true; // show the table layout panel containing the list of locations..
                locationContext = control.Tag.ToString(); // save to location context..

                // get a list of saved WWW sites....
                List<MEDIALOCATION> locations = Database.GetLocations(MediaLocationType.MediaLocationURL, locationContext);
                vlbMain.Items.Clear(); // ..and add them to the list box..
                foreach (MEDIALOCATION location in locations)
                {
                    vlbMain.Items.Add(new KeyValuePair<string, string>(location.LOCATION, location.DESCRIPTION));
                }

                vlbMain.DisplayMember = "Value"; // set the list box display member..
                ToggleListboxPanel(true); // show the "tool bar" under the list box..
            }
            // music player was requested..
            else if (control.Tag.ToString() == "MUSIC")
            {
                // show the container panel showing different contents for different type of items..
                // set the "action" image button to indicate music..
                pnActionImage.BackgroundImage = Properties.Resources.music;
                pnMouseHower.Visible = true; // show the panel containing the "action" image..
                pnActionImage.Visible = true; // show the "action" image..
                tlpListBoxHolder.Visible = false; // hide the content list box..
                ToggleListboxPanel(false); // hide the "tool bar" under the list box..
            }
            // an exit "button" was requested..
            else if (control.Tag.ToString() == "EXIT")
            {
                // show the container panel showing different contents for different type of items..
                // set the "action" image button to indicate power off..
                pnActionImage.BackgroundImage = Properties.Resources.power2;
                pnMouseHower.Visible = true; // show the panel containing the "action" image..
                pnActionImage.Visible = true; // show the "action" image..
                tlpListBoxHolder.Visible = false; // hide the content list box..
                ToggleListboxPanel(false); // hide the "tool bar" under the list box..
            }
            else if (control.Tag.ToString() == "MOVIE")
            {
                tlpListBoxHolder.Visible = true;
                pnMouseHower.Visible = true;
                pnActionImage.Visible = false;
                locationContext = control.Tag.ToString();

                // get a list of TV show season directories in the database..
                List<MEDIALOCATION> locations = Database.GetLocations(MediaLocationType.MediaLocationMovie, locationContext);
                vlbMain.Items.Clear(); // ..and add them to the list box..
                foreach (MEDIALOCATION location in locations)
                {
                    vlbMain.Items.Add(new KeyValuePair<string, string>(location.LOCATION, location.DESCRIPTION));
                }
                vlbMain.DisplayMember = "Value"; // set the list box display member..

                ToggleListboxPanel(true); // show the "tool bar" under the list box..
            }
        }

        // this field is used as a ref parameter with the FormSelectMovie.Execute method..
        private int previousVideoIndex = -1;

        // this field is used as a ref parameter with the FormSelectMovie.Execute method..
        private int previousVideoDetailIndex = -1;

        // this is the click handler for the content list box "action" filling the right side area of this form..
        private void listBoxContentClick(object sender, VPKSoft.VisualListBox.ListBoxButtonClickEventArgs e)
        {
            // an item was select from the content list box with a context of "PLAYFILE"..
            if (locationContext == "PLAYFILE")
            {
                // display a select file dialog for the selected item for the selected folder in the list box and if user selects a file,
                // play the file..
                RunPlayFile(((KeyValuePair<string, string>)e.Item).Key);
            }
            // an item was select from the content list box with a context of "PHOTOS"..
            else if (locationContext == "PHOTOS")
            {
                // get the selected item and..
                KeyValuePair<string, string> album = (KeyValuePair<string, string>)e.Item;

                // ..run the photo album "browser" for the selected photo album from the content list box.. 
                FormPhotoAlbumBrowser.Execute(album.Key, Database.GetPhotoAlbum(album.Value));
            }
            // an item was select from the content list box with a context of "WWW"..
            else if (locationContext == "WWW")
            {
                // get the selected item and..
                KeyValuePair<string, string> album = (KeyValuePair<string, string>)e.Item;

                // ..run the web browser for the selected URL from the content list box.. 
                new FormWebBrowserGecko(album.Key).Show();
            }
            // an item was select from the content list box with a context of "SERIES"..
            else if (locationContext == "SERIES")
            {
                VideoFileStatistic statistic = null;
                string filterDirectory = string.Empty;

                // a time consuming operation should be run in the background..
                RunInBackground(() =>
                {
                    // get the selected item and..
                    KeyValuePair<string, string> series = (KeyValuePair<string, string>)e.Item;

                    // set the filter directory for the enumeration of movie files..
                    filterDirectory = series.Key;

                    // get the video file statistics from the database..
                    IEnumerable<VideoFileStatistic> statistics =
                        Database.GetStatistic(FileType.TVSeasonEpisode, MediaLocationType.MediaLocationSeries, "SERIES", filterDirectory);

                    // execute the FormSelectMovie to get the statistic of a video file the users wishes to watch..
                    statistic = FormSelectMovie.Execute(statistics, Settings.TVShowEpisodeFileNameTitle, 
                        ref previousVideoDetailIndex, ref previousVideoIndex);
                },
                () => // a time consuming operation has finished..
                {
                    // if the user selected anything, initialize a playback for the user's selection..
                    if (statistic != null)
                    {
                        // save the statistics used to execute the FormSelectMovie form..
                        PreviousPlaybackStatistics = new PlaybackStatistics()
                        {
                            // just save the values..
                            FileType = FileType.TVSeasonEpisode,
                            MediaLocationType = MediaLocationType.MediaLocationSeries,
                            MediaLocationContext = "SERIES",
                            FilterDirectory = filterDirectory
                        };

                        // save the FormPlayer's instance to subscribe the PlaybackClosed event..
                        FormPlayer.InitPlayerForm(new FileInfo(statistic.FileNameFull), out FormPlayer formPlayer);

                        // subscribe the PlaybackClosed event..
                        formPlayer.PlaybackClosed += FormPlayer_PlaybackClosed;
                    }
                }, true); // disable the GUI..
            }
            // an item was select from the content list box with a context of "MOVIE"..
            else if (locationContext == "MOVIE")
            {
                VideoFileStatistic statistic = null;
                string filterDirectory = string.Empty;

                // a time consuming operation should be run in the background..
                RunInBackground(() =>
                {
                    // get the selected item and..
                    KeyValuePair<string, string> movies = (KeyValuePair<string, string>)e.Item;

                    // set the filter directory for the enumeration of movie files..
                    filterDirectory = movies.Key;

                    // get the video file statistics from the database..
                    IEnumerable<VideoFileStatistic> statistics =
                        Database.GetStatistic(FileType.Movie, MediaLocationType.MediaLocationMovie, "MOVIE", filterDirectory);

                    // execute the FormSelectMovie to get the statistic of a video file the users wishes to watch..
                    statistic = FormSelectMovie.Execute(statistics, false,
                        ref previousVideoDetailIndex, ref previousVideoIndex);
                },
                () => // a time consuming operation has finished..
                {
                    // if the user selected anything, initialize a playback for the user's selection..
                    if (statistic != null)
                    {
                        // save the statistics used to execute the FormSelectMovie form..
                        PreviousPlaybackStatistics = new PlaybackStatistics()
                        {
                            // just save the values..
                            FileType = FileType.Movie,
                            MediaLocationType = MediaLocationType.MediaLocationMovie,
                            MediaLocationContext = "MOVIE",
                            FilterDirectory = filterDirectory
                        };

                        // save the FormPlayer's instance to subscribe the PlaybackClosed event..
                        FormPlayer.InitPlayerForm(new FileInfo(statistic.FileNameFull), out FormPlayer formPlayer);

                        // subscribe the PlaybackClosed event..
                        formPlayer.PlaybackClosed += FormPlayer_PlaybackClosed;
                    }
                }, true); // disable the GUI..
            }
        }

        // this event is raised as the FormPlayer instance is closed and the playback has been stopped..
        private void FormPlayer_PlaybackClosed(object sender, FormPlayerCloseEventArgs e)
        {
            VideoFileStatistic statistic = null;
            // get the previous video playback statistics..
            PlaybackStatistics playbackStatistics = PreviousPlaybackStatistics;

            // a time consuming operation should be run in the background..
            RunInBackground(() =>
            {
                // get the sender to unsubscribe the event..
                FormPlayer previousformPlayer = (FormPlayer)sender;
                previousformPlayer.PlaybackClosed -= FormPlayer_PlaybackClosed;

                // if there are previous playback statistics..
                if (playbackStatistics != null)
                {
                    // get the video file statistics from the database..
                    IEnumerable<VideoFileStatistic> statistics =
                        Database.GetStatistic(playbackStatistics.FileType,
                        playbackStatistics.MediaLocationType,
                        playbackStatistics.MediaLocationContext,
                        playbackStatistics.FilterDirectory);

                    // execute the FormSelectMovie to get the statistic of a video file the users wishes to watch..
                    statistic = FormSelectMovie.Execute(statistics, false,
                        ref previousVideoDetailIndex, ref previousVideoIndex);
                }
            },
            () => // a time consuming operation has finished..
            {

                // if the user selected anything, initialize a playback for the user's selection..
                if (statistic != null)
                {
                    // save the statistics used to execute the FormSelectMovie form..
                    PreviousPlaybackStatistics = playbackStatistics;

                    // save the FormPlayer's instance to subscribe the PlaybackClosed event..
                    FormPlayer.InitPlayerForm(new FileInfo(statistic.FileNameFull), out FormPlayer formPlayer);

                    // subscribe the PlaybackClosed event..
                    formPlayer.PlaybackClosed += FormPlayer_PlaybackClosed;
                }
                else
                {
                    previousVideoIndex = -1;
                    previousVideoDetailIndex = -1;
                }
            }, true); // disable the GUI..
        }

        // this will occur when the form is closing..
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the database connection and "WACUUM" the database to ensure it's indexes remain non-fragmented..
            Database.CloseAndFinalizeDatabase();
        }

        /// <summary>
        /// Runs a select file dialog on a given folder to play a user selected file.
        /// </summary>
        /// <param name="folder">A folder to show the select file dialog from.</param>
        private void RunPlayFile(string folder)
        {
            string file = string.Empty; // this would be the video file to play if one gets selected..            

            // a time consuming operation should be run in the background..
            RunInBackground(() =>
            {
                // execute a SelectFileOrDirectoryDialog to select a video file for playback and save it to the file variable..
                file = FormDialogSelectFileOrDirectory.ExecuteFiles(
                    Directory.Exists(folder) ? folder : PlayFolder,
                    FormDialogSelectFileOrDirectory.FiltersVideo, true);
            },
            () => // a time consuming operation has finished..
            {
                // if a file was selected for playback..
                if (file != string.Empty)
                {
                    // enable the animated GIF to indicate that the main form is waiting for an interaction..
                    pbWait.Visible = true;
                    PlayFolder = Path.GetDirectoryName(file); // save the previous folder which was browsed..

                    // save the selected location of the file to the database..
                    Database.AddLocation(MediaLocationType.MediaLocationBrowsedPath, folder, string.Empty, string.Empty, "PLAYFILE");

                    // run the VLC based video playback form with the given file..
                    FormPlayer.InitPlayerForm(new FileInfo(file), out _);
                }

            }, true); // disable the GUI..
        }

        // resize the "button" images to fit their "buttons"..
        private void ResizeImages()
        {
            foreach (KeyValuePair<TableLayoutPanel, Panel> button in buttonList)
            {
                // make the underlying table layout panel's column style as absolute with a size of the
                // button's height..
                button.Key.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, button.Value.Height);
            }
        }

        // show the current time in a timer..
        private void tmClock_Tick(object sender, EventArgs e)
        {
            // ..as a short time string..
            lbClock.Text = DateTime.Now.ToShortTimeString();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SuspendLayout(); // suspend the layout for fonts of the labels to be resized..
            UtilsMisc.ResizeFontWidthHeight(lbVamp, string.Empty, 15.0f); // resize the fonts for the labels..
            UtilsMisc.ResizeFontWidthHeight(lbClock);
            UtilsMisc.ResizeFontHeight(lbCopyright, true);
            lbCredits.Font = lbCopyright.Font;


            UtilsMisc.ResizeFontWidthHeight(lbPlayYoutube, "Play media", 7.0f);
            lbExit.Font = lbPlayYoutube.Font;
            lbPlayFile.Font = lbPlayYoutube.Font;
            lbMovies.Font = lbPlayYoutube.Font;
            lbTVSeries.Font = lbPlayYoutube.Font;
            lbPlayDisc.Font = lbPlayYoutube.Font;
            lbMusicAmp.Font = lbPlayYoutube.Font;
            lbPhotos.Font = lbPlayYoutube.Font;
            lbInternet.Font = lbPlayYoutube.Font;
            // END: resize the fonts for the labels..

            // resize the "button" images to fit their "buttons"..
            ResizeImages();

            ResumeLayout(); // resume the layout after label fonts and "buttons" are resized..

            tmClock.Enabled = true; // enabled the timer for the clock display on the main form..
            if (Form.ActiveForm == null) // ensure this form gets active..
            {
                TopMost = true;
                BringToFront(); // ensure the form is not behind anything..
                Activate();
                TopMost = false;
            }
        }

        /// <summary>
        /// Sets the GUI enabled or disabled.
        /// </summary>
        /// <param name="enabled">Enable or disable the GUI depending on the value.</param>
        private void SetGUIEnabled(bool enabled)
        {
            tlpMenu.Enabled = enabled; // enable/disable the left side menu bar..
            pnActionImage.Enabled = enabled; // enabled/disable the "action" image..
            tlpListBoxHolder.Enabled = enabled; // enable/disable the table layout panel holding the list box of contents..
            pbWait.Visible = !enabled; // enable/disable inversely the panel holding the a GIF animation with a wait image..
            lbCopyright.Enabled = enabled; // enable/disable the "(C) VPKSoft" label from the right top corner as it is click-able..
            lbCredits.Enabled = enabled; // enable/disable the credits ("Thanks to") label as it's also click-able..
            pnActionImage.Enabled = enabled; // enable/disable the "action" image..
            pnSettings.Enabled = enabled; // enable/disable the settings "button"..

            #region ButtonGrayScaling
            pnSettings.BackgroundImage =
                enabled ? Properties.Resources.settings :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.settings);

            pnPlayFile.BackgroundImage =
                enabled ? Properties.Resources.play : 
                          UtilsMisc.MakeGrayscale3(Properties.Resources.play);

            pnMovies.BackgroundImage =
                enabled ? Properties.Resources.play_movies :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.play_movies);

            pnTVSeries.BackgroundImage =
                enabled ? Properties.Resources.tv_series_mod :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.tv_series_mod);

            pnMusicAmp.BackgroundImage =
                enabled ? Properties.Resources.music :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.music);

            pnPlayDisc.BackgroundImage =
                enabled ? Properties.Resources.play_disc :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.play_disc);

            pnPlayYoutube.BackgroundImage =
                enabled ? Properties.Resources.play_youtube :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.play_youtube);

            pnInternet.BackgroundImage =
                enabled ? Properties.Resources.www_button :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.www_button);

            pnPhotos.BackgroundImage =
                enabled ? Properties.Resources.photos :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.photos);

            pnExit.BackgroundImage =
                enabled ? Properties.Resources.power2 :
                          UtilsMisc.MakeGrayscale3(Properties.Resources.power2);
            #endregion
        }
        #endregion

        #region PlaybackStatistics
        /// <summary>
        /// A class to contain data of the previous FormSelectMovie's statistics to 
        /// enable the form to be shown again with the same statistics after the playback of an item has stopped.
        /// </summary>
        private class PlaybackStatistics
        {
            /// <summary>
            /// Gets or sets the type of the file.
            /// </summary>
            public FileType FileType { get; set; }

            /// <summary>
            /// Gets or sets the type of the media location.
            /// </summary>
            public MediaLocationType MediaLocationType { get; set; }

            /// <summary>
            /// Gets or sets the media location context.
            /// </summary>
            public string MediaLocationContext { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the filter directory.
            /// </summary>
            public string FilterDirectory { get; set; } = string.Empty;
        }

        // previous playback statistics used with the FormSelectMovie form..
        private PlaybackStatistics _PreviousPlaybackStatistics;

        /// <summary>
        /// Gets or sets the previous playback statistics used with the FormSelectMovie form.
        /// </summary>
        private PlaybackStatistics PreviousPlaybackStatistics
        {          
            set
            {
                _PreviousPlaybackStatistics = value;
            }

            get
            {
                // auto null property on query..
                PlaybackStatistics result = _PreviousPlaybackStatistics;
                _PreviousPlaybackStatistics = null;
                return result;
            }            
        }
        #endregion

        #region TMDbRefresh
        private void pnTMDbRefresh_Click(object sender, EventArgs e)
        {
            if (!Settings.TMDBEnabled || !easyClientConfigured)
            {
                return;
            }

            // a TV series location was requested to be added..
            if (locationContext == "SERIES" || locationContext == "MOVIE")
            {
                IEnumerable<VideoFileStatistic> statistics =
                    Database.GetStatistic(
                        locationContext == "SERIES" ? FileType.TVSeasonEpisode : FileType.Movie,
                        locationContext == "SERIES" ? MediaLocationType.MediaLocationSeries : MediaLocationType.MediaLocationMovie,
                        locationContext);

                int current = 0;
                int max = statistics.Count();

                FormTMDBLoadProgress.ShowProgress(current, max, easyClientConfigured);
                foreach (VideoFileStatistic statistic in statistics)
                {
                    // only get statistics for files where the TMDb fetch hasn't been done and
                    // no TMDb ID has been given to a file..
                    if (statistic.TMDbFetched && statistic.TMDbDetails.ID > 0)
                    {
                        FormTMDBLoadProgress.ShowProgress(current++, max, easyClientConfigured);
                        continue;
                    }
                    Database.SetTMDbInfo(statistic.FileNameFull, easy, easyClientConfigured);
                }
                FormTMDBLoadProgress.EndProgress();
            }
        }
        #endregion

        #region BackgroundAction
        /// <summary>
        /// Runs an action in the background and the executes another action after completion.
        /// </summary>
        /// <param name="action">The action to run in the background.</param>
        /// <param name="completed">The action to run after the background action is completed.</param>
        /// <param name="disableGui">An indicator if the GUI should be disabled on the background action execution.</param>
        private void RunInBackground(Action action, Action completed, bool disableGui)
        {
            // a BackgroundWorker is IDisposable so that's why the using..
            using (BackgroundWorker backgroundWorker = new BackgroundWorker())
            {
                // construct an action with the given background action and few GUI invokes..
                Action threadAction = new Action(new Action(() =>
                {
                    if (disableGui) // if the GUI is to be disabled then disable the GUI..
                    {
                        // invocation is required in a "thread"..
                        Invoke(new MethodInvoker(delegate { SetGUIEnabled(false); }));
                    }

                    // invocation is required in a "thread"..
                    Invoke(new MethodInvoker(delegate { pbWait.Visible = true; }));

                    // run the background action inside a new action..
                    action();

                    // invocation is required in a "thread"..
                    Invoke(new MethodInvoker(delegate { pbWait.Visible = false; }));

                    if (disableGui) // if the GUI was to be disabled then enable the GUI..
                    {
                        // invocation is required in a "thread"..
                        Invoke(new MethodInvoker(delegate { SetGUIEnabled(true); }));
                    }
                }));

                // the DoWork event must be subscribed..
                backgroundWorker.DoWork += (sender, e) =>
                {
                    threadAction();
                };

                // the RunWorkerCompleted event must also be subscribed..
                backgroundWorker.RunWorkerCompleted += (sender, e) =>
                {
                    completed?.Invoke(); // only run if not null..
                };

                // after the DoWork event and RunWorkerCompleted event subscriptions the BackgroundWorker must be run..
                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Runs an action in the background and the executes another action after completion.
        /// </summary>
        /// <param name="action">The action to run in the background.</param>
        /// <param name="completed">The action to run after the background action is completed.</param>
        private void RunInBackground(Action action, Action completed)
        {
            RunInBackground(action, completed, false);
        }

        /// <summary>
        /// Runs an action in the background.
        /// </summary>
        /// <param name="action">The action to run in the background.</param>
        private void RunInBackground(Action action)
        {
            RunInBackground(action, null, false);
        }
        #endregion

        private void vlbMain_ButtonClicked(object sender, VPKSoft.VisualListBox.ListBoxButtonClickEventArgs e)
        {
            // TODO:: delete from the database..
        }
    }
}
