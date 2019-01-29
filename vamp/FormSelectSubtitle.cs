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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vlc.DotNet.Core; // (C): https://github.com/ZeBobo5/Vlc.DotNet, MIT license
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.VisualUtils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A dialog to select a subtitle from the VclControl.SubTitles
    /// </summary>
    public partial class FormSelectSubtitle : DBLangEngineWinforms
    {
        /// <summary>
        /// Shows the dialog to subtitle track.
        /// </summary>
        /// <param name="subTitles">A VclControl class instance's SubTitles.All collection.</param>
        /// <param name="trackDescription">A VclControl class instance's SubTitles.Current member.</param>
        /// <returns>A Vlc.DotNet.Core.TrackDescription class instance or null, if no subtitle was selected.</returns>
        public static TrackDescription Execute(IEnumerable<TrackDescription> subTitles, TrackDescription trackDescription)
        {
            if (subTitles == null || subTitles.Count() == 0) // Nothing to select from so return null
            {
                return null;
            }

            FormSelectSubtitle selectSubtitleForm = new FormSelectSubtitle(); // Create the form

            int subID = -1; // Id if a VclControl class instance's SubTitles.Current member was null.

            if (trackDescription != null) // Get the current subtitles ID..
            {
                subID = trackDescription.ID;
            }

            foreach (TrackDescription desc in subTitles) // List the subtitle tracks..
            {
                selectSubtitleForm.lbSubtitles.Items.Add(desc);
            }

            for (int i = 0; i < selectSubtitleForm.lbSubtitles.Items.Count; i++) // if a subtitle with and ID is found on the list, select it..
            {
                if (((TrackDescription)selectSubtitleForm.lbSubtitles.Items[i]).ID == subID)
                {
                    selectSubtitleForm.lbSubtitles.SelectedIndex = i;
                    break; // no reason to iterate them all..
                }
            }

            if (selectSubtitleForm.ShowDialog() == DialogResult.OK) // If user selects OK, then return the selected TrackDescription class instance..
            {
                return selectSubtitleForm.lbSubtitles.SelectedItem as TrackDescription;
            }
            else // Otherwise, return null
            {
                return null;
            }
        }

        /// <summary>
        /// The constructor of the SelectSubtitleForm class.
        /// </summary>
        public FormSelectSubtitle()
        {
            InitializeComponent();
            Controls.Add(tlpMain);


            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            DBLangEngine.AddNameSpace("VPKSoft.VisualFileBrowser"); // no localization from a foreign name space..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            UtilsMisc.ScaleToFitScreen(this);

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            btOK.Text = DBLangEngine.GetMessage("msgOK", "OK|As in an OK button");
            btCancel.Text = DBLangEngine.GetMessage("msgCancel", "Cancel|As in a Cancel button");
        }

        // The ListBox is owner-drawn, so draw the items
        private void lbSubtitles_DrawItem(object sender, DrawItemEventArgs e)
        {            
            if (e.Index < 0) // An exception may occur..
            {
                return;
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) // (C): https://stackoverflow.com/questions/3663704/how-to-change-listbox-selection-background-color
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          BackColor); //Choose the color (e.DrawFocusRectangle())

            e.DrawBackground(); // Draw background

            ListBox lb = (ListBox)sender; // Get the ListBox class instance

            // Draw the item
            e.Graphics.DrawString(((TrackDescription)lb.Items[e.Index]).Name, e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);

            // Draw the selection
            e.DrawFocusRectangle();
        }

        // Prevent OK result from the dialog if there are no items selected..
        private void SelectSubtitleForm_Shown(object sender, EventArgs e)
        {
            btOK.Enabled = lbSubtitles.SelectedIndex != -1; // no okay if nothing is selected..
        }

        // If the keyboard was used.. set the DialogResult accordingly..
        private void SelectSubtitleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                DialogResult = DialogResult.Cancel;
            }
            else if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                DialogResult = DialogResult.OK;
            }
        }
    }
}
