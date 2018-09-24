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
using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.VisualUtils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A dialog to select files or directories. Designed to be suitable for larger screens, i.e. television.
    /// </summary>
    public partial class FormDialogSelectFileOrDirectory : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogSelectFileOrDirectory"/> class.
        /// </summary>
        public FormDialogSelectFileOrDirectory()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..
            DBLangEngine.AddNameSpace("VPKSoft.VisualFileBrowser"); // no localization from a foreign name space..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            UtilsMisc.ScaleToFitScreen(this);

            // this dialog doesn't require much localization..
            btOK.Text = DBLangEngine.GetMessage("msgOK", "OK|As in an OK button");
            btCancel.Text = DBLangEngine.GetMessage("msgCancel", "Cancel|As in a Cancel button");
        }

        // a string holding a value of a selected file from the VisualFileBrowser control.
        private string selectedFile = string.Empty;

        // a string holding a value of a selected directory from the VisualFileBrowser control.
        private string selectedDirectory = string.Empty;

        /// <summary>
        /// A property to reflect the VisualFileBrowser's property OnlySelectDirectories value to this class.
        /// </summary>
        private bool SelectFile
        {
            set
            {
                // inverted value..
                vfbSelectFileOrDir.OnlySelectDirectories = !value;
            }

            get
            {
                // inverted value..
                return !vfbSelectFileOrDir.OnlySelectDirectories;
            }
        }

        /// <summary>
        /// Video file extensions.
        /// </summary>
        public static readonly string[] FiltersVideo =
            { "*.3g2", "*.3gp", "*.3gp2", "*.3gpp", "*.amv", "*.asf", "*.avi", "*.bik", "*.bin", "*.divx", "*.drc",
              "*.dv", "*.f4v", "*.flv", "*.gvi", "*.gfx", "*.iso", "*.m1v", "*.m2v", "*.m2t", "*.m2ts", "*.m4v", "*.mkv",
              "*.mov", "*.mp2", "*.mp2v", "*.mp4", "*.mp4v", "*.mpe", "*.mpeg", "*.mpeg1", "*.mpeg2", "*.mpeg4", "*.mpg",
              "*.mpv2", "*.mts", "*.mtv", "*.mxf", "*.mxg", "*.nsv", "*.nuv", "*.ogm", "*.ogv", "*.ogx", "*.ps", "*.rec",
              "*.rm", "*.rmvb", "*.rpl", "*.thp", "*.tod", "*.ts", "*.tts", "*.txd", "*.vob", "*.vro", "*.webm", "*.wm",
              "*.wmv", "*.wtv", "*.xesc" };

        /// <summary>
        /// Audio file extensions.
        /// </summary>
        public static readonly string[] FiltersAudio =
            { "*.mp3", "*.ogg", "*.wav", "*.flac", "*.wma", "*.m4a", "*.aac", "*.aif", "*.aiff" };

        /// <summary>
        /// Image file extensions.
        /// </summary>
        public static readonly string[] FiltersImage =
            { ".gif", "*.jpg", "*.jpeg", "*.exif", "*.png", "*.tiff", "*.tif" };

        /// <summary>
        /// All file extensions.
        /// </summary>
        public static readonly string[] FiltersAll =
            { "*.*", "*" };


        /// <summary>
        /// Execute the dialog in a file browser mode.
        /// </summary>
        /// <param name="basePath">A path from where to start the navigation from.</param>
        /// <param name="visibleFileExtensions">An array of file extensions to show in the list.</param>
        /// <param name="allowBackwardNavigation">A value indicating if the user can navigate upwards of the given <paramref name="basePath"/>.</param>
        /// <returns>A file if one was selected or a string.Empty if nothing was selected.</returns>
        public static string ExecuteFiles(string basePath, string[] visibleFileExtensions, bool allowBackwardNavigation)
        {
            // Create a new instance of SelectFileOrDirectoryDialog class.. 
            FormDialogSelectFileOrDirectory selectFileOrDirectoryDialog = new FormDialogSelectFileOrDirectory();

            // .. assign it the given parameter values to control's behavior..
            selectFileOrDirectoryDialog.vfbSelectFileOrDir.AllowBackwardNavigation = allowBackwardNavigation;
            selectFileOrDirectoryDialog.vfbSelectFileOrDir.BasePath = basePath;
            selectFileOrDirectoryDialog.vfbSelectFileOrDir.VisibleFileExtensions = visibleFileExtensions;
            selectFileOrDirectoryDialog.SelectFile = true;

            // return the selected file if the DialogResult is DialogResult.OK, otherwise return string.Empty.
            return selectFileOrDirectoryDialog.ShowDialog() == DialogResult.OK ? selectFileOrDirectoryDialog.selectedFile : string.Empty;
        }

        /// <summary>
        /// Execute the dialog in a directory browser mode.
        /// </summary>
        /// <param name="basePath">A path from where to start the navigation from.</param>
        /// <param name="allowBackwardNavigation">A value indicating if the user can navigate upwards of the given <paramref name="basePath"/>.</param>
        /// <param name="allowNavigation">A value indicating if navigation is allowed at all in the directory structure.</param>
        /// <returns>A path if one was selected or s string.Empty if nothing was selected.</returns>
        public static string ExecuteDirectory(string basePath, bool allowBackwardNavigation, bool allowNavigation)
        {
            // Create a new instance of SelectFileOrDirectoryDialog class.. 
            FormDialogSelectFileOrDirectory selectFileOrDirectoryDialog = new FormDialogSelectFileOrDirectory();

            // .. assign it the given parameter values to control's behavior..
            selectFileOrDirectoryDialog.vfbSelectFileOrDir.AllowBackwardNavigation = allowBackwardNavigation;
            selectFileOrDirectoryDialog.vfbSelectFileOrDir.AllowNavigation = allowNavigation;
            selectFileOrDirectoryDialog.vfbSelectFileOrDir.BasePath = basePath;
            selectFileOrDirectoryDialog.SelectFile = false;

            // return the selected file if the DialogResult is DialogResult.OK, otherwise return string.Empty.
            return 
                selectFileOrDirectoryDialog.ShowDialog() == DialogResult.OK ? selectFileOrDirectoryDialog.selectedDirectory : string.Empty;
        }

        /// <summary>
        /// An event that is raised by the VisualFileBrowser control when a user selects a file from the list.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A VisualFileBrowser.FileOrDirectorySelectedEventArgs class instance.</param>
        private void vfbSelectFileOrDir_FileSelected(object sender, VPKSoft.VisualFileBrowser.VisualFileBrowser.FileOrDirectorySelectedEventArgs e)
        {
            if (!SelectFile) // if files are not instructed to be selected..
            {
                return; // .. ignore the event.
            }
            selectedFile = e.Path; // Assign the selected file..
            DialogResult = DialogResult.OK; // .. and return with an OK value from this dialog.
        }

        /// <summary>
        /// An event that is raised by the VisualFileBrowser control when a user selects a directory from the list.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A VisualFileBrowser.FileOrDirectorySelectedEventArgs class instance.</param>
        private void vfbSelectFileOrDir_DirectorySelected(object sender, VPKSoft.VisualFileBrowser.VisualFileBrowser.FileOrDirectorySelectedEventArgs e)
        {
            if (SelectFile) // if files are instructed to be selected..
            {
                return; // .. ignore the event.
            }
            selectedDirectory = e.Path; // Assign the selected directory..
            DialogResult = DialogResult.OK; // .. and return with an OK value from this dialog.
        }

        /// <summary>
        /// An event that is raised by the VisualFileBrowser control when a custom image describing an item in the list.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A VisualFileBrowser.FileOrDirectorySelectedEventArgs class instance.</param>
        private void vfbSelectFileOrDir_GetCustomItemImage(object sender, VPKSoft.VisualFileBrowser.VisualFileBrowser.FileOrDirectorySelectedEventArgs e)
        {
            if (e.IsFile) // if a custom image for a file is requested..
            {
                Database.SetFile(e.Path); // first ensure the file is added to the database..

                // Get statistics for the file from the database.. 
                VideoFileStatistic statistic = Database.GetStatistic(e.Path);
                if (statistic.Played) // A video file is watched so give an image which indicates a tick or check..
                {
                    e.Image = Properties.Resources.tick;
                }
                else if (statistic.Position > 0) // A part of the video file is watched so give it an image of a quarter of a ball..
                {
                    e.Image = Properties.Resources.not_whole;
                }
                else // no reasonable images to give so give it nothing..
                {
                    e.Image = null;
                }

            }
        }

        /// <summary>
        /// Handle the cancel and the OK button clicks.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs class instance.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btCancel)) // Cancel button was clicked..
            {
                DialogResult = DialogResult.Cancel; // so return from the dialog with DialogResult.Cancel..
            }
            else if (sender.Equals(btOK)) // OK button was clicked..
            {
                // set the selected directory to also change on OK button click..
                if (selectedDirectory == string.Empty)
                {
                    selectedDirectory = vfbSelectFileOrDir.BasePath == ":DRIVES:" ? string.Empty : vfbSelectFileOrDir.BasePath;
                }
                DialogResult = DialogResult.OK; // so return from the dialog with DialogResult.OK..
            }
        }

        /// <summary>
        /// Handle the Escape and Return buttons via an event as the ImageButton class it self doesn't cause dialog result to change..
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A KeyEventArgs class instance.</param>
        private void SelectFileOrDirectoryDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // if the Escape button was pressed..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                DialogResult = DialogResult.Cancel;
            }
            else if (e.KeyCode == Keys.Return) // if the Return button was pressed..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                DialogResult = DialogResult.OK;
            }
        }
    }
}
