namespace vamp
{
    partial class FormDialogSelectFileOrDirectory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogSelectFileOrDirectory));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btOK = new VPKSoft.ImageButton.ImageButton();
            this.vfbSelectFileOrDir = new VPKSoft.VisualFileBrowser.VisualFileBrowser();
            this.btCancel = new VPKSoft.ImageButton.ImageButton();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.BackColor = System.Drawing.Color.Black;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Controls.Add(this.btOK, 0, 1);
            this.tlpMain.Controls.Add(this.vfbSelectFileOrDir, 0, 0);
            this.tlpMain.Controls.Add(this.btCancel, 2, 1);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.Size = new System.Drawing.Size(910, 897);
            this.tlpMain.TabIndex = 1;
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Black;
            this.btOK.ButtonImage = global::vamp.Properties.Resources.OK;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(1, 808);
            this.btOK.Margin = new System.Windows.Forms.Padding(1);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(1);
            this.btOK.Size = new System.Drawing.Size(362, 88);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.Button_Click);
            // 
            // vfbSelectFileOrDir
            // 
            this.tlpMain.SetColumnSpan(this.vfbSelectFileOrDir, 3);
            this.vfbSelectFileOrDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vfbSelectFileOrDir.FileImage = ((System.Drawing.Image)(resources.GetObject("vfbSelectFileOrDir.FileImage")));
            this.vfbSelectFileOrDir.FolderImage = ((System.Drawing.Image)(resources.GetObject("vfbSelectFileOrDir.FolderImage")));
            this.vfbSelectFileOrDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vfbSelectFileOrDir.Location = new System.Drawing.Point(11, 10);
            this.vfbSelectFileOrDir.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.vfbSelectFileOrDir.Name = "vfbSelectFileOrDir";
            this.vfbSelectFileOrDir.SelectedFolderImage = ((System.Drawing.Image)(resources.GetObject("vfbSelectFileOrDir.SelectedFolderImage")));
            this.vfbSelectFileOrDir.Size = new System.Drawing.Size(888, 787);
            this.vfbSelectFileOrDir.TabIndex = 4;
            this.vfbSelectFileOrDir.UseCustomImage = true;
            this.vfbSelectFileOrDir.VisibleFileExtensions = new string[] {
        "*.*"};
            this.vfbSelectFileOrDir.FileSelected += new VPKSoft.VisualFileBrowser.VisualFileBrowser.OnFileSelected(this.vfbSelectFileOrDir_FileSelected);
            this.vfbSelectFileOrDir.DirectorySelected += new VPKSoft.VisualFileBrowser.VisualFileBrowser.OnDirectorySelected(this.vfbSelectFileOrDir_DirectorySelected);
            this.vfbSelectFileOrDir.GetCustomItemImage += new VPKSoft.VisualFileBrowser.VisualFileBrowser.OnGetCustomItemImage(this.vfbSelectFileOrDir_GetCustomItemImage);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Black;
            this.btCancel.ButtonImage = global::vamp.Properties.Resources.Cancel;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Red;
            this.btCancel.Location = new System.Drawing.Point(547, 808);
            this.btCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(1);
            this.btCancel.Size = new System.Drawing.Size(362, 88);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.Button_Click);
            // 
            // FormDialogSelectFileOrDirectory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(934, 921);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormDialogSelectFileOrDirectory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SelectDirectoryDialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectFileOrDirectoryDialog_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private VPKSoft.VisualFileBrowser.VisualFileBrowser vfbSelectFileOrDir;
        private VPKSoft.ImageButton.ImageButton btCancel;
        private VPKSoft.ImageButton.ImageButton btOK;
    }
}