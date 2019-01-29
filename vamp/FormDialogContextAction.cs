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

using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A dialog to react to a context request such as a right mouse button click.
    /// <note type="note">TODO:: Make the context action changeable!</note>
    /// </summary>
    public partial class FormDialogContextAction : DBLangEngineWinforms
    {
        /// <summary>
        /// A dialog to replace a context menu of a control..
        /// </summary>
        public FormDialogContextAction()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            // this dialog doesn't require much localization..
            // localize the three controls.. as the VPKSoft.LangLib seems to have a bug with localizing custom controls (TODO: fix it some day)..
            btOK.Text = DBLangEngine.GetMessage("msgOK", "OK|As in an OK button");
            btCancel.Text = DBLangEngine.GetMessage("msgCancel", "Cancel|As in a Cancel button");
            lbMarkAsWatched.Text = DBLangEngine.GetMessage("msgMarkItemAsWatched", "Mark as watched?|A short (in text length) question whether or not to mark a file or a directory as watched");
        }

        // react to a possible keyboard use
        private void ContextActionDialog_KeyDown(object sender, KeyEventArgs e)
        {
            // Escape button is interpreted as a choice to cancel an action..
            if (e.KeyCode == Keys.Escape) // if the Escape button was pressed..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                DialogResult = DialogResult.Cancel; // in this case the DialogResult is DialogResult.Cancel..
            }
            // Return and Space buttons are interpreted as a choice to continue the playback from a previously saved position..
            else if (e.KeyCode == Keys.Return) // if the Return or the Space button was pressed..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                DialogResult = DialogResult.OK; // in this case the DialogResult is DialogResult.OK..
            }
        }
    }
}
