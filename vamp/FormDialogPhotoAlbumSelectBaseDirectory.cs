using FolderSelect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPKSoft.LangLib;

namespace vamp
{
    /// <summary>
    /// A dialog to query a new directory and a relative path for a file in a photo album if the photo file doesn't exist in the given directory.
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogPhotoAlbumSelectBaseDirectory : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogPhotoAlbumSelectBaseDirectory"/> class.
        /// </summary>
        public FormDialogPhotoAlbumSelectBaseDirectory()
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
        }

        /// <summary>
        /// Displays the dialog with a given base directory and a relative path.
        /// </summary>
        /// <param name="baseDir">The base directory to display.</param>
        /// <param name="relativePath">The relative path of the photo file.</param>
        /// <returns>A BaseRelativePath class instance containing the user selected base directory and relative path. 
        /// If the dialog is canceled an empty instance of the BaseRelativePath class is returned.</returns>
        public static BaseRelativePath Execute(string baseDir, string relativePath)
        {
            // a relative path shouldn't contain the directory separator character at the beginning,
            // so away it goes..
            relativePath = relativePath.TrimStart(Path.DirectorySeparatorChar);

            // if the combined base directory and relative path file already
            // exists there is no reason to display the dialog..
            if (File.Exists(Path.Combine(baseDir, relativePath)))
            {
                // ..so just return the given parameters..
                return new BaseRelativePath()
                {
                    BaseDir = baseDir, // the base directory..
                    RelativePath = relativePath // the relative path..
                };
            }

            // create a new instance of the FormDialogPhotoAlbumSelectBaseDirectory form..
            FormDialogPhotoAlbumSelectBaseDirectory formDialogPhotoAlbumSelectBaseDirectory =
                new FormDialogPhotoAlbumSelectBaseDirectory();

            // set given base directory parameter to the text box of the form..
            formDialogPhotoAlbumSelectBaseDirectory.tbBaseDirPhotosValue.Text = baseDir;

            // set given relative path base directory parameter to the text box of the form without the file name..
            formDialogPhotoAlbumSelectBaseDirectory.tbPhotoAlbumRelativeDirectoryValue.Text = 
                Path.GetDirectoryName(relativePath);

            // save the file name to the form's field..
            formDialogPhotoAlbumSelectBaseDirectory.fileName = Path.GetFileName(relativePath);

            // display the dialog..
            if (formDialogPhotoAlbumSelectBaseDirectory.ShowDialog() == DialogResult.OK)
            {
                // if the user accepted the dialog, return a nonempty instance of the BaseRelativePath class..
                return new BaseRelativePath() { BaseDir = formDialogPhotoAlbumSelectBaseDirectory.returnDir, RelativePath = formDialogPhotoAlbumSelectBaseDirectory.relativePath };
            }

            // the user didn't accept the dialog, so return an empty instance of the BaseRelativePath class..
            return BaseRelativePath.Empty;
        }

        // the user want's to browse for a folder..
        private void btSelectPhotoFolder_Click(object sender, EventArgs e)
        {
            // create a new FolderSelectDialog class instance..
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog
            {
                // set the title localized..
                Title = DBLangEngine.GetMessage("msgSelectFolder", "Select a folder|A dialog requests a user to select a folder")
            };

            if (sender.Equals(btSelectPhotoFolder)) // a photo folder was requested..
            {
                // set the initial directory to the current setting..
                folderSelectDialog.InitialDirectory = tbBaseDirPhotosValue.Text;
                if (folderSelectDialog.ShowDialog()) // if a folder was selected..
                {
                    tbBaseDirPhotosValue.Text = folderSelectDialog.FileName; // set the text to indicate the folder..
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            // the user canceled..
            DialogResult = DialogResult.Cancel;
        }

        // the user accepted the dialog..
        private void btOK_Click(object sender, EventArgs e)
        {
            // set the return field values..
            returnDir = tbBaseDirPhotosValue.Text;
            relativePath = Path.Combine(tbPhotoAlbumRelativeDirectoryValue.Text, fileName);

            // and close the dialog with a DialogResult.OK value..
            DialogResult = DialogResult.OK;
        }

        // a field to hold the return directory value..
        private string returnDir = string.Empty;

        // a field to hold the relative path value..
        private string relativePath = string.Empty;

        // a field to hold the file name..
        private string fileName = string.Empty;

        private void FormDialogPhotoAlbumSelectBaseDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) // the return key means the user accepted the dialog..
            {
                // the OK button might not be enabled..
                if (!btOK.Enabled)
                {
                    // prevent the handled key data from "leaking" to another control..
                    e.SuppressKeyPress = true;
                    e.Handled = true; // the event was handled..
                    return; // return from the accept button (Return) press if the OK button wasn't enabled..
                }
                // set the return field values..
                returnDir = tbBaseDirPhotosValue.Text;
                relativePath = Path.Combine(tbPhotoAlbumRelativeDirectoryValue.Text, fileName);

                // ..and close the dialog with a DialogResult.OK value..
                DialogResult = DialogResult.OK;

                // prevent the handled key data from "leaking" to another control..
                e.SuppressKeyPress = true;
                e.Handled = true; // the event was handled..
            }
            // the user canceled the dialog..
            else if (e.KeyCode == Keys.Escape) // the escape key means the user didn't accept the settings..
            {
                DialogResult = DialogResult.Cancel; // ..so just close..

                // prevent the handled key data from "leaking" to another control..
                e.SuppressKeyPress = true;
                e.Handled = true; // the event was handled..
            }
        }

        private void tbBaseDirPhotosValue_TextChanged(object sender, EventArgs e)
        {
            // enable or disabled the OK button based on the input value given by the user..
            returnDir = tbBaseDirPhotosValue.Text; // set the return directory field's value..

            // set the relative path's value..
            relativePath = Path.Combine(tbPhotoAlbumRelativeDirectoryValue.Text, fileName);

            btOK.Enabled =
                // verify that a file exists with the combined values of the base directory and the relative path..
                File.Exists(Path.Combine(returnDir, relativePath)) &&
                // and the user given relative path doesn't start with the directory separator character..
                tbPhotoAlbumRelativeDirectoryValue.Text.IndexOf(Path.DirectorySeparatorChar) != 0;
        }
    }

    /// <summary>
    /// A class for a return value for the FormDialogPhotoAlbumSelectBaseDirectory.Execute method.
    /// </summary>
    public class BaseRelativePath
    {
        /// <summary>
        /// Gets or sets the base directory.
        /// </summary>
        public string BaseDir { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the relative path.
        /// </summary>
        public string RelativePath { get; set; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                // compare the two properties and return a value indicating whether this class instance is empty..
                return BaseDir.Trim() == string.Empty && RelativePath.Trim() == string.Empty;
            }
        }

        /// <summary>
        /// Gets an empty BaseRelativePath class instance.
        /// </summary>
        public static BaseRelativePath Empty
        {
            get
            {
                // by default the class is empty..
                return new BaseRelativePath();
            }
        }
    }
}
