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

namespace vamp
{
    /// <summary>
    /// A dialog to query a name for a photo album.
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogPhotoAlbumQueryName : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogPhotoAlbumQueryName"/> class.
        /// </summary>
        public FormDialogPhotoAlbumQueryName()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");
        }

        // list of previous photo albums to prevent the name being the same as before..
        private List<PHOTOALBUM> photoAlbums = new List<PHOTOALBUM>();

        /// <summary>
        /// Displays the dialog to query a name for a photo album.
        /// </summary>
        /// <param name="photoAlbums">A list of previous photo albums to prevent the name being the same as before.</param>
        /// <param name="name">The suggested name for a photo album.</param>
        /// <returns></returns>
        public static string Execute(List<PHOTOALBUM> photoAlbums, string name)
        {
            // create a new instance of the dialog..
            FormDialogPhotoAlbumQueryName
                formDialogPhotoAlbumQueryName = 
                new FormDialogPhotoAlbumQueryName();

            // set the name suggestion..
            formDialogPhotoAlbumQueryName.tbPhotoAlbumName.Text = name;

            // set the previous photo album list..
            formDialogPhotoAlbumQueryName.photoAlbums = photoAlbums;

            // validate the name of the photo album..
            formDialogPhotoAlbumQueryName.ValidatePhotoAlbumName();

            if (formDialogPhotoAlbumQueryName.ShowDialog() == DialogResult.OK)
            {
                // return the name for a photo album..
                return formDialogPhotoAlbumQueryName.tbPhotoAlbumName.Text;
            }
            else
            {
                // user canceled, so return an empty string..
                return string.Empty;
            }
        }

        // validate the name of the photo album..
        private void ValidatePhotoAlbumName()
        {
            btOK.Enabled =
                tbPhotoAlbumName.Text.Trim() != string.Empty && // empty strings a not accepted..
                                                                // existing names are not accepted..
                !photoAlbums.Exists(f => f.NAME.Equals(tbPhotoAlbumName.Text.Trim(), StringComparison.InvariantCultureIgnoreCase));

            // set the error text to an empty string..
            lbErrorText.Text = string.Empty;

            // if the name already exists in the previous photo albums..
            if (photoAlbums.Exists(f => f.NAME.Equals(tbPhotoAlbumName.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)))
            {
                // ..give an error message..
                lbErrorText.Text = DBLangEngine.GetMessage("msgPhotoAlbumExists", "Photo album with the given name already exists|As in a photo album with the given name already exists");
            }
        }

        // this event is subscribed just to validate the photo album's name..
        private void tbPhotoAlbumName_TextChanged(object sender, EventArgs e)
        {
            // validate the name of the photo album..
            ValidatePhotoAlbumName();
        }
    }
}
