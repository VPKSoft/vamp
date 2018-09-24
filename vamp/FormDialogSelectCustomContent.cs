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
using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.VisualUtils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A dialog which allows a user to select any type of items from a list box and then return the selected item.
    /// </summary>
    public partial class FormDialogSelectCustomContent : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogSelectCustomContent"/> class.
        /// </summary>
        public FormDialogSelectCustomContent()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..            
            DBLangEngine.AddNameSpace("VPKSoft.VisualListBox"); // no localization from a foreign name space..

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

        // the caption of this dialog..
        private string textCaption = string.Empty;

        /// <summary>
        /// Creates a new instance of <see cref="FormDialogSelectCustomContent"/> and displays it with given parameters.
        /// </summary>
        /// <typeparam name="T">An any type of object.</typeparam>
        /// <param name="items">A list of items to be shown in the list box of this dialog.</param>
        /// <param name="textCaption">The caption text to be shown in this dialog. This can be an empty string.</param>
        /// <param name="displayMember">The display member for the list box of this dialog.</param>
        /// <returns>The selected item T from the list box if any, otherwise default(T) is returned.</returns>
        public static T Execute<T>(List<T> items, string textCaption, string displayMember = "")
        {
            // create a new instance of this SelectCustomContentDialog class..
            FormDialogSelectCustomContent selectCustomContentDialog = new FormDialogSelectCustomContent();

            // clear the sample items from the list box..
            selectCustomContentDialog.lbCustomContent.Items.Clear();

            // set the display member if any..
            selectCustomContentDialog.lbCustomContent.DisplayMember = displayMember;

            // give the SelectCustomContentDialog class instance the caption as it is measured to fit a label..
            selectCustomContentDialog.textCaption = textCaption;

            // set the caption..
            selectCustomContentDialog.lbCaption.Text = textCaption;

            // add the given items to the list box..
            foreach (var item in items)
            {
                selectCustomContentDialog.lbCustomContent.Items.Add(item);
            }

            // display the dialog.,.
            if (selectCustomContentDialog.ShowDialog() == DialogResult.OK)
            {
                // check if an item was selected when OK button was pressed..
                if (selectCustomContentDialog.lbCustomContent.SelectedItem != null)
                {
                    // return the selected item casted to typeof(T)..
                    return (T)selectCustomContentDialog.lbCustomContent.SelectedItem;
                }
            }

            // cancel button was pressed or no items were selected from the list box in the dialog,
            // so return default(T)..
            return default(T);
        }

        // resize/layout some content in the dialog when shown..
        private void SelectCustomContentDialog_Shown(object sender, EventArgs e)
        {
            // if there is no given caption, resize the table layout panel accordingly..
            if (textCaption == string.Empty)
            {
                lbCaption.Visible = false;
                tlpMain.RowStyles[0] = new RowStyle(SizeType.Percent, 0);
                tlpMain.RowStyles[1] = new RowStyle(SizeType.Percent, 90);
                tlpMain.RowStyles[2] = new RowStyle(SizeType.Percent, 10);
            }
            // if there is a given caption, resize the table layout panel accordingly..
            else
            {
                lbCaption.Visible = true;
                tlpMain.RowStyles[0] = new RowStyle(SizeType.Percent, 10);
                tlpMain.RowStyles[1] = new RowStyle(SizeType.Percent, 80);
                tlpMain.RowStyles[2] = new RowStyle(SizeType.Percent, 10);
                UtilsMisc.ResizeFontHeight(lbCaption, true); // Resize the labels fonts
            }
            // END: Resize the labels fonts
        }

        // check if the Return or the Escape key was pressed..
        private void SelectCustomContentDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                DialogResult = DialogResult.OK;
                e.SuppressKeyPress = true; // suppress the key presses on valid keys..
                e.Handled = true; // set the Handled property to true..
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                e.SuppressKeyPress = true; // suppress the key presses on valid keys..
                e.Handled = true; // set the Handled property to true..
            }
        }
    }
}
