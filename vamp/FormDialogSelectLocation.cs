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
using System.Windows.Forms;
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A dialog which currently allows user to enter an URL.
    /// </summary>
    public partial class FormDialogSelectLocation : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogSelectLocation"/> class.
        /// </summary>
        public FormDialogSelectLocation()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            DBLangEngine.AddNameSpace("VPKSoft.VisualTextBox"); // no localization from a foreign name space..
            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");
        }

        /// <summary>
        /// The dialog will be run as a add a new web address (URL) dialog.
        /// </summary>
        /// <returns>A KeyValuePair class instance with strings containing the entered URL and it's description.</returns>
        public static KeyValuePair<string, string> ExecuteURL()
        {
            // TODO::Localize this - meaning if the dialog ever gets another context than adding new URLs to the software..
            FormDialogSelectLocation selectLocationDialog = new FormDialogSelectLocation(); // create an instance of "this"..

            // check the return status of the dialog..
            if (selectLocationDialog.ShowDialog() == DialogResult.OK) // a user has successfully entered a valid URL..
            {
                return new KeyValuePair<string, string>(selectLocationDialog.vtbLocation.Text, selectLocationDialog.vtbLocationText.Text);
            }
            else // a user canceled the operation..
            {
                // ..still no null return values..
                return new KeyValuePair<string, string>(string.Empty, string.Empty);
            }
        }

        private void vtbLocation_TextChanged(object sender, EventArgs e)
        {
            // the input given by a user needs to be validated.. the actual existence of a valid URL will not be checked..
            try
            {
                Uri uri = new Uri(vtbLocation.Text); // try to create an Uri from the given input..
                vtbLocationText.Text = uri.Host; // suggest a description for a given web address..
                btOK.Enabled = true; // in this case OK means that an Uri class instance was successfully create from the input..
                lbSelectLocation.ForeColor = Color.White; // use colors to indicate if the given input was correct..
            }
            catch (Exception ex) // an Uri class instance wasn't successfully created..
            {
                // log the exception..
                ExceptionLogger.LogError(ex);

                btOK.Enabled = false; // .. so disable the OK button..
                lbSelectLocation.ForeColor = Color.Red; // .. and indicate an invalid input with red color..
            }
        }

        // If the keyboard was used.. set the DialogResult accordingly..
        private void SelectLocationDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // a user can always cancel..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                DialogResult = DialogResult.Cancel;
            }
            else if (e.KeyCode == Keys.Return && btOK.Enabled) // ..only allow OK if the input was valid..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                DialogResult = DialogResult.OK;
            }
        }
    }
}
