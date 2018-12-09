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
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using FolderSelect; // (C): https://www.lyquidity.com/devblog/?p=136, no license
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;

namespace vamp
{
    /// <summary>
    /// A simple configuration form for the software.
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormSettings : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormSettings"/> class.
        /// </summary>
        public FormSettings()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..

            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..

            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }
            DBLangEngine.InitalizeLanguage("vamp.Messages");

            // prevent the form from growing larger than the size of the screen..
            //MaximumSize = Screen.PrimaryScreen.Bounds.Size;

            // load the settings..
            LoadSettings();
        }

        /// <summary>
        /// Loads the settings from the Settings class to be shown on the form.
        /// </summary>
        public void LoadSettings()
        {
            // just load the settings..
            tbAmpRemoteValue.Text = Settings.AmpRemoteURL;
            tbBaseDirMoviesValue.Text = Settings.MovieBaseDir;
            tbBaseDirTVShowsValue.Text = Settings.TVShowBaseDir;
            tbBaseDirPhotosValue.Text = Settings.PhotoBaseDir;
            cbCacheDatabaseIntoMemoryValue.Checked = Settings.UseDatabaseMemoryCache;
            cbCacheTMDbImagesIntoMemoryValue.Checked = Settings.UseMemoryForTMDbImagesCache;
            tbTMDbImagesCacheDirValue.Text = Settings.TMDbImagesCacheDir;
            cdTMDbEnabledValue.Checked = Settings.TMDBEnabled;
            cbUseFileNameForTVShowEpisodeNamingValue.Checked = Settings.TVShowEpisodeFileNameTitle;
            cbAutoDatabaseUpdateValue.Checked = Settings.AutoDBUpdate;

            List<CultureInfo> cultures = DBLangEngine.GetLocalizedCultures();

            cmbSelectLanguageValue.Items.AddRange(cultures.ToArray());
            cmbSelectLanguageValue.SelectedItem = Settings.Culture;

            // END: just load the settings..
        }

        /// <summary>
        /// Saves the settings made on the form.
        /// </summary>
        public void SaveSettings()
        {
            // just save the settings..
            Settings.AmpRemoteURL = tbAmpRemoteValue.Text;
            Settings.MovieBaseDir = tbBaseDirMoviesValue.Text;
            Settings.TVShowBaseDir = tbBaseDirTVShowsValue.Text;
            Settings.PhotoBaseDir = tbBaseDirPhotosValue.Text;
            Settings.UseDatabaseMemoryCache = cbCacheDatabaseIntoMemoryValue.Checked;
            Settings.UseMemoryForTMDbImagesCache = cbCacheTMDbImagesIntoMemoryValue.Checked;
            Settings.TMDbImagesCacheDir = tbTMDbImagesCacheDirValue.Text;
            Settings.TMDBEnabled = cdTMDbEnabledValue.Checked;
            Settings.TVShowEpisodeFileNameTitle = cbUseFileNameForTVShowEpisodeNamingValue.Checked;
            Settings.Culture = (CultureInfo)cmbSelectLanguageValue.SelectedItem;
            Settings.AutoDBUpdate = cbAutoDatabaseUpdateValue.Checked;
            // END: just save the settings..
        }

        /// <summary>
        /// Selects the folder based on the sending button to an accurate text box.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void selectFolderClick(object sender, EventArgs e)
        {
            // create a new FolderSelectDialog class instance..
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog
            {
                // set the title localized..
                Title = DBLangEngine.GetMessage("msgSelectFolder", "Select a folder|A dialog requests a user to select a folder")
            };

            if (sender.Equals(btSelectMovieFolder)) // a movie folder was requested..
            {
                // set the initial directory to the current setting..
                folderSelectDialog.InitialDirectory = tbBaseDirMoviesValue.Text; 
                if (folderSelectDialog.ShowDialog()) // if a folder was selected..
                {
                    tbBaseDirMoviesValue.Text = folderSelectDialog.FileName; // set the text to indicate the folder..
                }
            }
            else if (sender.Equals(btSelectTVShowFolder)) // a TV show series folder was requested..
            {
                // set the initial directory to the current setting..
                folderSelectDialog.InitialDirectory = tbBaseDirTVShowsValue.Text;
                if (folderSelectDialog.ShowDialog()) // if a folder was selected..
                {
                    tbBaseDirTVShowsValue.Text = folderSelectDialog.FileName; // set the text to indicate the folder..
                }
            }
            else if (sender.Equals(btSelectPhotoFolder)) // a photo folder was requested..
            {
                // set the initial directory to the current setting..
                folderSelectDialog.InitialDirectory = tbBaseDirPhotosValue.Text;
                if (folderSelectDialog.ShowDialog()) // if a folder was selected..
                {
                    tbBaseDirPhotosValue.Text = folderSelectDialog.FileName; // set the text to indicate the folder..
                }
            }
            // a cache directory for the TMDb (The Movie Database) poster/still images was requested..
            else if (sender.Equals(btSelectTMDbImagesCacheDir)) 
            {
                // set the initial directory to the current setting..
                folderSelectDialog.InitialDirectory = tbTMDbImagesCacheDirValue.Text;
                if (folderSelectDialog.ShowDialog()) // if a folder was selected..
                {
                    tbTMDbImagesCacheDirValue.Text = folderSelectDialog.FileName; // set the text to indicate the folder..
                }
            }
        }

        // the user clicked the cancel button..
        private void btCancel_Click(object sender, EventArgs e)
        {
            Close(); // ..so just close..
        }

        // the user clicked the OK button..
        private void btOK_Click(object sender, EventArgs e)
        {
            SaveSettings(); // ..so save the settings..
            Close(); // ..and close..
        }

        // handle the key down event to "simulate" a dialog..
        private void FormSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) // the return key means the user accepted the settings..
            {
                SaveSettings(); // ..so save the settings..
                Close(); // ..and close..

                // prevent the handled key data from "leaking" to another control..
                e.SuppressKeyPress = true;
                e.Handled = true; // the event was handled..
            }
            else if (e.KeyCode == Keys.Escape) // the escape key means the user didn't accept the settings..
            {
                Close(); // ..so just close..

                // prevent the handled key data from "leaking" to another control..
                e.SuppressKeyPress = true;
                e.Handled = true; // the event was handled..
            }
        }
    }
}
