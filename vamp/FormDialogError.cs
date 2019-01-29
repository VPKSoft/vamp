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

using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A dialog which displays an error message with an OK button.
    /// </summary>
    public partial class FormDialogError : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogError"/> class.
        /// </summary>
        public FormDialogError()
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
        /// Initializes a new instance of the <see cref="FormDialogError"/> class and displays it with a given error message.
        /// </summary>
        /// <param name="dialogMessage">The caption of the error message..</param>
        /// <param name="errorMessage">The error message to display within the dialog.</param>
        public static void Execute(string dialogMessage, string errorMessage)
        {
            FormDialogError dialogError = new FormDialogError(); // create a new instance of the DialogError class..
            dialogError.lbDialogCaption.Text = dialogMessage; // set the given "caption"..
            dialogError.tbErrorDesc.Text = errorMessage; // set the given message..
            dialogError.ShowDialog(); // display the dialog..
        }
    }
}
