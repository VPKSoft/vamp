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
using VPKSoft.LangLib;

namespace vamp
{
    /// <summary>
    /// A dialog for a basic confirmation query.
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogConfirmQuery : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogConfirmQuery"/> class.
        /// </summary>
        public FormDialogConfirmQuery()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..
            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");
        }

        /// <summary>
        /// Shows the FormDialogConfirmQuery form and returns either true or false depending on the user's selection.
        /// </summary>
        /// <param name="message">A message to show on the dialog.</param>
        /// <returns>True if the user selected Yes; otherwise false.</returns>
        public static bool Execute(string message)
        {
            using (FormDialogConfirmQuery formDialogConfirmQuery = new FormDialogConfirmQuery())
            {
                formDialogConfirmQuery.lbQueryText.Text = message;
                return formDialogConfirmQuery.ShowDialog() == DialogResult.Yes;
            }
        }

        // handle the key down event..
        private void FormDialogConfirmQuery_KeyDown(object sender, KeyEventArgs e)
        {
            // a user selected yes..
            if (e.KeyCode == Keys.Return)
            {
                // ..so return yes..
                DialogResult = DialogResult.Yes;
                e.SuppressKeyPress = true; // suppress the key presses on valid keys..
                e.Handled = true; // set the Handled property to true..
            }
            // the user selected no..
            else if (e.KeyCode == Keys.Escape)
            {
                // so return no..
                DialogResult = DialogResult.No;
                e.SuppressKeyPress = true; // suppress the key presses on valid keys..
                e.Handled = true; // set the Handled property to true..
            }
        }
    }
}
