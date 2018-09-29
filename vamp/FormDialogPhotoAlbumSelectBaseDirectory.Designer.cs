namespace vamp
{
    partial class FormDialogPhotoAlbumSelectBaseDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogPhotoAlbumSelectBaseDirectory));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btOK = new VPKSoft.ImageButton.ImageButton();
            this.lbBaseDirPhotosDescription = new System.Windows.Forms.Label();
            this.tbBaseDirPhotosValue = new System.Windows.Forms.TextBox();
            this.btSelectPhotoFolder = new System.Windows.Forms.Button();
            this.lbPhotoAlbumRelativeDirectoryDescription = new System.Windows.Forms.Label();
            this.tbPhotoAlbumRelativeDirectoryValue = new System.Windows.Forms.TextBox();
            this.btCancel = new VPKSoft.ImageButton.ImageButton();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.btOK, 0, 3);
            this.tlpMain.Controls.Add(this.lbBaseDirPhotosDescription, 0, 0);
            this.tlpMain.Controls.Add(this.tbBaseDirPhotosValue, 1, 0);
            this.tlpMain.Controls.Add(this.btSelectPhotoFolder, 2, 0);
            this.tlpMain.Controls.Add(this.lbPhotoAlbumRelativeDirectoryDescription, 0, 1);
            this.tlpMain.Controls.Add(this.tbPhotoAlbumRelativeDirectoryValue, 1, 1);
            this.tlpMain.Controls.Add(this.btCancel, 1, 3);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(626, 127);
            this.tlpMain.TabIndex = 0;
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.SystemColors.Control;
            this.btOK.ButtonImage = global::vamp.Properties.Resources.OK;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btOK.Location = new System.Drawing.Point(2, 90);
            this.btOK.Margin = new System.Windows.Forms.Padding(2);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(2);
            this.btOK.Size = new System.Drawing.Size(190, 35);
            this.btOK.TabIndex = 18;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // lbBaseDirPhotosDescription
            // 
            this.lbBaseDirPhotosDescription.AutoSize = true;
            this.lbBaseDirPhotosDescription.Location = new System.Drawing.Point(10, 10);
            this.lbBaseDirPhotosDescription.Margin = new System.Windows.Forms.Padding(10);
            this.lbBaseDirPhotosDescription.Name = "lbBaseDirPhotosDescription";
            this.lbBaseDirPhotosDescription.Size = new System.Drawing.Size(182, 13);
            this.lbBaseDirPhotosDescription.TabIndex = 3;
            this.lbBaseDirPhotosDescription.Text = "Base dicrectory for image/photo files:";
            this.lbBaseDirPhotosDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBaseDirPhotosValue
            // 
            this.tbBaseDirPhotosValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBaseDirPhotosValue.Location = new System.Drawing.Point(208, 6);
            this.tbBaseDirPhotosValue.Margin = new System.Windows.Forms.Padding(6);
            this.tbBaseDirPhotosValue.Name = "tbBaseDirPhotosValue";
            this.tbBaseDirPhotosValue.Size = new System.Drawing.Size(354, 20);
            this.tbBaseDirPhotosValue.TabIndex = 8;
            this.tbBaseDirPhotosValue.Text = "-";
            this.tbBaseDirPhotosValue.TextChanged += new System.EventHandler(this.tbBaseDirPhotosValue_TextChanged);
            // 
            // btSelectPhotoFolder
            // 
            this.btSelectPhotoFolder.Location = new System.Drawing.Point(574, 6);
            this.btSelectPhotoFolder.Margin = new System.Windows.Forms.Padding(6);
            this.btSelectPhotoFolder.Name = "btSelectPhotoFolder";
            this.btSelectPhotoFolder.Size = new System.Drawing.Size(46, 20);
            this.btSelectPhotoFolder.TabIndex = 15;
            this.btSelectPhotoFolder.Text = "...";
            this.btSelectPhotoFolder.UseVisualStyleBackColor = true;
            this.btSelectPhotoFolder.Click += new System.EventHandler(this.btSelectPhotoFolder_Click);
            // 
            // lbPhotoAlbumRelativeDirectoryDescription
            // 
            this.lbPhotoAlbumRelativeDirectoryDescription.AutoSize = true;
            this.lbPhotoAlbumRelativeDirectoryDescription.Location = new System.Drawing.Point(10, 43);
            this.lbPhotoAlbumRelativeDirectoryDescription.Margin = new System.Windows.Forms.Padding(10);
            this.lbPhotoAlbumRelativeDirectoryDescription.Name = "lbPhotoAlbumRelativeDirectoryDescription";
            this.lbPhotoAlbumRelativeDirectoryDescription.Size = new System.Drawing.Size(158, 13);
            this.lbPhotoAlbumRelativeDirectoryDescription.TabIndex = 16;
            this.lbPhotoAlbumRelativeDirectoryDescription.Text = "Relative photo file sub-directory:";
            this.lbPhotoAlbumRelativeDirectoryDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPhotoAlbumRelativeDirectoryValue
            // 
            this.tbPhotoAlbumRelativeDirectoryValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhotoAlbumRelativeDirectoryValue.Location = new System.Drawing.Point(208, 39);
            this.tbPhotoAlbumRelativeDirectoryValue.Margin = new System.Windows.Forms.Padding(6);
            this.tbPhotoAlbumRelativeDirectoryValue.Name = "tbPhotoAlbumRelativeDirectoryValue";
            this.tbPhotoAlbumRelativeDirectoryValue.Size = new System.Drawing.Size(354, 20);
            this.tbPhotoAlbumRelativeDirectoryValue.TabIndex = 17;
            this.tbPhotoAlbumRelativeDirectoryValue.Text = "-";
            this.tbPhotoAlbumRelativeDirectoryValue.TextChanged += new System.EventHandler(this.tbBaseDirPhotosValue_TextChanged);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.ButtonImage = global::vamp.Properties.Resources.Cancel;
            this.tlpMain.SetColumnSpan(this.btCancel, 2);
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCancel.Location = new System.Drawing.Point(434, 90);
            this.btCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(2);
            this.btCancel.Size = new System.Drawing.Size(190, 35);
            this.btCancel.TabIndex = 19;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // FormDialogPhotoAlbumSelectBaseDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 151);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormDialogPhotoAlbumSelectBaseDirectory";
            this.ShowInTaskbar = false;
            this.Text = "Select a directory containing the photo album";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDialogPhotoAlbumSelectBaseDirectory_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lbBaseDirPhotosDescription;
        private System.Windows.Forms.TextBox tbBaseDirPhotosValue;
        private System.Windows.Forms.Button btSelectPhotoFolder;
        private System.Windows.Forms.Label lbPhotoAlbumRelativeDirectoryDescription;
        private System.Windows.Forms.TextBox tbPhotoAlbumRelativeDirectoryValue;
        private VPKSoft.ImageButton.ImageButton btOK;
        private VPKSoft.ImageButton.ImageButton btCancel;
    }
}