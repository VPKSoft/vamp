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
using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A dialog to choose a playback position of a video file between a saved position and from the beginning.
    /// </summary>
    public partial class FormDialogSelectPlaybackPosition : DBLangEngineWinforms
    {
        /// <summary>
        /// The constructor of the SelectPlaybackPositionDialog Form.
        /// </summary>
        public FormDialogSelectPlaybackPosition()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            // localize the three controls.. as the VPKSoft.LangLib seems to have a bug with localizing custom controls (TODO: fix it some day)..
            lbContext.Text = DBLangEngine.GetMessage("msgPlayBackThreeDots", "Playback...|A message describing if something should be done for the playback");
            btFromStart.Text = DBLangEngine.GetMessage("msgPlaybackFromThebeginng", "The beginning|A message describing that the playback should be started from the beginning");
            btContinue.Tag = DBLangEngine.GetMessage("msgSavedPlaybackPositionContinue", "Continue from {0}|A message describing a saved playback position to continue the playback from");
        }

        /// <summary>
        /// Shows the dialog if necessary and returns a new playback position in milliseconds.
        /// </summary>
        /// <param name="videoFileStatistic">A VideoFileStatistic class instance to be used to initialize the dialog from.</param>
        /// <returns>A playback position in milliseconds.</returns>
        public static long Execute(VideoFileStatistic videoFileStatistic)
        {
            // if the saved playback position is zero or more than 99 percent was played last time just return 0..
            // decrease 5 seconds from the position for "a human/a media consuming entity" to catch/remember something of the previous moment..
            if (videoFileStatistic.Position - 5000 <= 0 || videoFileStatistic.PlayBackPercentage >= 99.0)
            {
                return 0;
            }

            // the given VideoFileStatistic class instance requires the dialog to be shown.. so create a SelectPlaybackPositionDialog..
            FormDialogSelectPlaybackPosition selectPlaybackPositionDialog = new FormDialogSelectPlaybackPosition();

            // a N value of a milliseconds to ticks (100-nanosecond units) = multiply by 100 * 100..
            TimeSpan timeSpan = new TimeSpan(videoFileStatistic.Position * 100 * 100);

            // give the statistics for the form..
            // .. and decrease 5 seconds from the position for "a human/a media consuming entity" to catch/remember something of the previous moment..
            selectPlaybackPositionDialog.Tag = videoFileStatistic.Position - 5000;

            // set the playback position for to the button "Continue playback from position N"..
            selectPlaybackPositionDialog.btContinue.Text =
                string.Format(selectPlaybackPositionDialog.btContinue.Tag.ToString(), timeSpan.ToString(@"hh\:mm\:ss"));

            // show the dialog..
            selectPlaybackPositionDialog.ShowDialog();

            // return the playback position the user selected by 
            return selectPlaybackPositionDialog.returnPlaybackPosition;
        }

        // this is the playback position the dialog Execute method will return..
        internal long returnPlaybackPosition = 0;

        // one of the two buttons were selected..
        private void GlobalClickHandler(object sender, EventArgs e)
        {
            if (sender.Equals(btContinue)) // user decided to continue the playback..
            {
                returnPlaybackPosition = (long)(Tag); // return the saved playback position..
                DialogResult = DialogResult.OK; // in the case of this dialog the DialogResult is always DialogResult.OK..
            }
            else if (sender.Equals(btFromStart)) // the user decided to start the playback from the beginning..
            {
                returnPlaybackPosition = 0; // .. so return value will be 0..
                DialogResult = DialogResult.OK; // in the case of this dialog the DialogResult is always DialogResult.OK..
            }
        }

        // react to a possible keyboard use
        private void SelectPlaybackPositionDialog_KeyDown(object sender, KeyEventArgs e)
        {
            // Escape and Back buttons are interpreted as a choice to start the playback from the start..
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back) // if the Escape button or the Back button was pressed..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                returnPlaybackPosition = 0; // give the return value a value of zero..
                DialogResult = DialogResult.OK; // in the case of this dialog the DialogResult is always DialogResult.OK..
            }
            // Return and Space buttons are interpreted as a choice to continue the playback from a previously saved position..
            else if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space) // if the Return or the Space button was pressed..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                returnPlaybackPosition = (long)(Tag); // give the return value an actual value..
                DialogResult = DialogResult.OK; // in the case of this dialog the DialogResult is always DialogResult.OK..
            }
        }
    }
}
