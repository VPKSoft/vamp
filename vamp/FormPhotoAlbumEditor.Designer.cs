namespace vamp
{
    partial class FormPhotoAlbumEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhotoAlbumEditor));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnUndoSave = new System.Windows.Forms.Panel();
            this.tlpPhotosInAlbum = new System.Windows.Forms.TableLayoutPanel();
            this.lbTimeTakenDescription = new System.Windows.Forms.Label();
            this.lbPhotoTagDescription = new System.Windows.Forms.Label();
            this.lbPhotosInAlbum = new VPKSoft.VisualListBox.ListBoxExtension();
            this.cmsCopyTags = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyTags = new System.Windows.Forms.ToolStripMenuItem();
            this.lbPhotosInAlbumDescription = new System.Windows.Forms.Label();
            this.lbPhotoDescriptionDescription = new System.Windows.Forms.Label();
            this.tbPhotoDescriptionValue = new System.Windows.Forms.TextBox();
            this.tlpTimeTakenValue = new System.Windows.Forms.TableLayoutPanel();
            this.dtpTimeTakenValueTime = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeTakenValueDate = new System.Windows.Forms.DateTimePicker();
            this.btPhotoDateTimeSet = new System.Windows.Forms.Button();
            this.lbTimeTakenTextDescription = new System.Windows.Forms.Label();
            this.tbTimeTakenTextValue = new System.Windows.Forms.TextBox();
            this.btAddTag = new System.Windows.Forms.Button();
            this.tbAddTag = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbPhotoTagValues = new VPKSoft.VisualListBox.ListBoxExtension();
            this.cmsPasteTags = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPasteTags = new System.Windows.Forms.ToolStripMenuItem();
            this.ivPhoto = new VPKSoft.ImageViewer.ImageViewer();
            this.tlpPhotoAlbumList = new System.Windows.Forms.TableLayoutPanel();
            this.lbPhotoAlbumList = new VPKSoft.VisualListBox.ListBoxExtension();
            this.lbPhotoAlbumListDescription = new System.Windows.Forms.Label();
            this.lbPhotoAlbumNameDescription = new System.Windows.Forms.Label();
            this.tbHidden1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPhotoAlbumNameValue = new System.Windows.Forms.TextBox();
            this.btSetAlbumName = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPhotoAlbumFirstDateValue = new System.Windows.Forms.TableLayoutPanel();
            this.btPhotoAlbumFirstDateTimeSet = new System.Windows.Forms.Button();
            this.dtpPhotoAlbumFirstTimeValue = new System.Windows.Forms.DateTimePicker();
            this.dtpPhotoAlbumFirstDateValue = new System.Windows.Forms.DateTimePicker();
            this.lbPhotoAlbumTagListDescription = new System.Windows.Forms.Label();
            this.lbPhotoAlbumTagListValues = new VPKSoft.VisualListBox.ListBoxExtension();
            this.lbPhotoAlbumFirstDateDescription = new System.Windows.Forms.Label();
            this.tbFilterTags = new System.Windows.Forms.TextBox();
            this.pnTrash = new System.Windows.Forms.Panel();
            this.pnSave = new System.Windows.Forms.Panel();
            this.lbItemDragDescription = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUndoChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExportSelectedXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExportSelectedSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sdSQL = new System.Windows.Forms.SaveFileDialog();
            this.odSQL = new System.Windows.Forms.OpenFileDialog();
            this.sdXML = new System.Windows.Forms.SaveFileDialog();
            this.odXML = new System.Windows.Forms.OpenFileDialog();
            this.tlpMain.SuspendLayout();
            this.tlpPhotosInAlbum.SuspendLayout();
            this.cmsCopyTags.SuspendLayout();
            this.tlpTimeTakenValue.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.cmsPasteTags.SuspendLayout();
            this.tlpPhotoAlbumList.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpPhotoAlbumFirstDateValue.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 15;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpMain.Controls.Add(this.pnUndoSave, 0, 8);
            this.tlpMain.Controls.Add(this.tlpPhotosInAlbum, 0, 3);
            this.tlpMain.Controls.Add(this.ivPhoto, 9, 0);
            this.tlpMain.Controls.Add(this.tlpPhotoAlbumList, 0, 0);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 4, 0);
            this.tlpMain.Controls.Add(this.pnTrash, 5, 8);
            this.tlpMain.Controls.Add(this.pnSave, 0, 8);
            this.tlpMain.Controls.Add(this.lbItemDragDescription, 3, 8);
            this.tlpMain.Location = new System.Drawing.Point(12, 27);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 9;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1225, 611);
            this.tlpMain.TabIndex = 0;
            // 
            // pnUndoSave
            // 
            this.pnUndoSave.AllowDrop = true;
            this.pnUndoSave.BackgroundImage = global::vamp.Properties.Resources.undo_save_changes;
            this.pnUndoSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnUndoSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnUndoSave.Location = new System.Drawing.Point(84, 539);
            this.pnUndoSave.Name = "pnUndoSave";
            this.pnUndoSave.Size = new System.Drawing.Size(75, 69);
            this.pnUndoSave.TabIndex = 8;
            this.pnUndoSave.Click += new System.EventHandler(this.pnUndoSave_Click);
            // 
            // tlpPhotosInAlbum
            // 
            this.tlpPhotosInAlbum.ColumnCount = 4;
            this.tlpMain.SetColumnSpan(this.tlpPhotosInAlbum, 9);
            this.tlpPhotosInAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpPhotosInAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpPhotosInAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpPhotosInAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpPhotosInAlbum.Controls.Add(this.lbTimeTakenDescription, 0, 4);
            this.tlpPhotosInAlbum.Controls.Add(this.lbPhotoTagDescription, 2, 0);
            this.tlpPhotosInAlbum.Controls.Add(this.lbPhotosInAlbum, 0, 1);
            this.tlpPhotosInAlbum.Controls.Add(this.lbPhotosInAlbumDescription, 0, 0);
            this.tlpPhotosInAlbum.Controls.Add(this.lbPhotoDescriptionDescription, 0, 2);
            this.tlpPhotosInAlbum.Controls.Add(this.tbPhotoDescriptionValue, 0, 3);
            this.tlpPhotosInAlbum.Controls.Add(this.tlpTimeTakenValue, 1, 4);
            this.tlpPhotosInAlbum.Controls.Add(this.lbTimeTakenTextDescription, 0, 5);
            this.tlpPhotosInAlbum.Controls.Add(this.tbTimeTakenTextValue, 0, 6);
            this.tlpPhotosInAlbum.Controls.Add(this.btAddTag, 2, 5);
            this.tlpPhotosInAlbum.Controls.Add(this.tbAddTag, 2, 6);
            this.tlpPhotosInAlbum.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tlpPhotosInAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPhotosInAlbum.Location = new System.Drawing.Point(3, 204);
            this.tlpPhotosInAlbum.Name = "tlpPhotosInAlbum";
            this.tlpPhotosInAlbum.RowCount = 7;
            this.tlpMain.SetRowSpan(this.tlpPhotosInAlbum, 5);
            this.tlpPhotosInAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhotosInAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhotosInAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhotosInAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhotosInAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhotosInAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhotosInAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhotosInAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPhotosInAlbum.Size = new System.Drawing.Size(723, 329);
            this.tlpPhotosInAlbum.TabIndex = 3;
            // 
            // lbTimeTakenDescription
            // 
            this.lbTimeTakenDescription.AutoSize = true;
            this.lbTimeTakenDescription.Location = new System.Drawing.Point(0, 254);
            this.lbTimeTakenDescription.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.lbTimeTakenDescription.Name = "lbTimeTakenDescription";
            this.lbTimeTakenDescription.Size = new System.Drawing.Size(63, 13);
            this.lbTimeTakenDescription.TabIndex = 5;
            this.lbTimeTakenDescription.Text = "Time taken:";
            // 
            // lbPhotoTagDescription
            // 
            this.lbPhotoTagDescription.AutoSize = true;
            this.lbPhotoTagDescription.Location = new System.Drawing.Point(361, 6);
            this.lbPhotoTagDescription.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.lbPhotoTagDescription.Name = "lbPhotoTagDescription";
            this.lbPhotoTagDescription.Size = new System.Drawing.Size(142, 13);
            this.lbPhotoTagDescription.TabIndex = 3;
            this.lbPhotoTagDescription.Text = "Tags assigned for the photo:";
            // 
            // lbPhotosInAlbum
            // 
            this.tlpPhotosInAlbum.SetColumnSpan(this.lbPhotosInAlbum, 2);
            this.lbPhotosInAlbum.ContextMenuStrip = this.cmsCopyTags;
            this.lbPhotosInAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPhotosInAlbum.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbPhotosInAlbum.FormattingEnabled = true;
            this.lbPhotosInAlbum.ItemHeight = 25;
            this.lbPhotosInAlbum.Location = new System.Drawing.Point(3, 28);
            this.lbPhotosInAlbum.Name = "lbPhotosInAlbum";
            this.lbPhotosInAlbum.ScrollAlwaysVisible = true;
            this.lbPhotosInAlbum.Size = new System.Drawing.Size(355, 117);
            this.lbPhotosInAlbum.TabIndex = 2;
            this.lbPhotosInAlbum.VScrollPosition = 0;
            this.lbPhotosInAlbum.VScrollPositionNoEvent = 0;
            this.lbPhotosInAlbum.SelectedValueChanged += new System.EventHandler(this.lbPhotosInAlbum_SelectedValueChanged);
            this.lbPhotosInAlbum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPhotosInAlbum_MouseDown);
            // 
            // cmsCopyTags
            // 
            this.cmsCopyTags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyTags});
            this.cmsCopyTags.Name = "cmsCopyPasteTags";
            this.cmsCopyTags.Size = new System.Drawing.Size(128, 26);
            // 
            // mnuCopyTags
            // 
            this.mnuCopyTags.Name = "mnuCopyTags";
            this.mnuCopyTags.Size = new System.Drawing.Size(127, 22);
            this.mnuCopyTags.Text = "Copy tags";
            this.mnuCopyTags.Click += new System.EventHandler(this.mnuCopyTags_Click);
            // 
            // lbPhotosInAlbumDescription
            // 
            this.lbPhotosInAlbumDescription.AutoSize = true;
            this.lbPhotosInAlbumDescription.Location = new System.Drawing.Point(3, 0);
            this.lbPhotosInAlbumDescription.Name = "lbPhotosInAlbumDescription";
            this.lbPhotosInAlbumDescription.Size = new System.Drawing.Size(100, 13);
            this.lbPhotosInAlbumDescription.TabIndex = 0;
            this.lbPhotosInAlbumDescription.Text = "Photos in the album";
            // 
            // lbPhotoDescriptionDescription
            // 
            this.lbPhotoDescriptionDescription.AutoSize = true;
            this.lbPhotoDescriptionDescription.Location = new System.Drawing.Point(0, 154);
            this.lbPhotoDescriptionDescription.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.lbPhotoDescriptionDescription.Name = "lbPhotoDescriptionDescription";
            this.lbPhotoDescriptionDescription.Size = new System.Drawing.Size(92, 13);
            this.lbPhotoDescriptionDescription.TabIndex = 3;
            this.lbPhotoDescriptionDescription.Text = "Photo description:";
            // 
            // tbPhotoDescriptionValue
            // 
            this.tbPhotoDescriptionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPhotosInAlbum.SetColumnSpan(this.tbPhotoDescriptionValue, 2);
            this.tbPhotoDescriptionValue.Location = new System.Drawing.Point(3, 176);
            this.tbPhotoDescriptionValue.Multiline = true;
            this.tbPhotoDescriptionValue.Name = "tbPhotoDescriptionValue";
            this.tbPhotoDescriptionValue.Size = new System.Drawing.Size(355, 69);
            this.tbPhotoDescriptionValue.TabIndex = 4;
            this.tbPhotoDescriptionValue.TextChanged += new System.EventHandler(this.tbPhotoDescriptionValue_TextChanged);
            // 
            // tlpTimeTakenValue
            // 
            this.tlpTimeTakenValue.ColumnCount = 3;
            this.tlpTimeTakenValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTimeTakenValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTimeTakenValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTimeTakenValue.Controls.Add(this.dtpTimeTakenValueTime, 0, 0);
            this.tlpTimeTakenValue.Controls.Add(this.dtpTimeTakenValueDate, 0, 0);
            this.tlpTimeTakenValue.Controls.Add(this.btPhotoDateTimeSet, 2, 0);
            this.tlpTimeTakenValue.Location = new System.Drawing.Point(159, 248);
            this.tlpTimeTakenValue.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTimeTakenValue.Name = "tlpTimeTakenValue";
            this.tlpTimeTakenValue.RowCount = 1;
            this.tlpTimeTakenValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimeTakenValue.Size = new System.Drawing.Size(202, 26);
            this.tlpTimeTakenValue.TabIndex = 6;
            // 
            // dtpTimeTakenValueTime
            // 
            this.dtpTimeTakenValueTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTimeTakenValueTime.CustomFormat = "";
            this.dtpTimeTakenValueTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeTakenValueTime.Location = new System.Drawing.Point(88, 3);
            this.dtpTimeTakenValueTime.Name = "dtpTimeTakenValueTime";
            this.dtpTimeTakenValueTime.Size = new System.Drawing.Size(79, 20);
            this.dtpTimeTakenValueTime.TabIndex = 8;
            // 
            // dtpTimeTakenValueDate
            // 
            this.dtpTimeTakenValueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTimeTakenValueDate.CustomFormat = "";
            this.dtpTimeTakenValueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimeTakenValueDate.Location = new System.Drawing.Point(3, 3);
            this.dtpTimeTakenValueDate.Name = "dtpTimeTakenValueDate";
            this.dtpTimeTakenValueDate.Size = new System.Drawing.Size(79, 20);
            this.dtpTimeTakenValueDate.TabIndex = 7;
            // 
            // btPhotoDateTimeSet
            // 
            this.btPhotoDateTimeSet.AutoSize = true;
            this.btPhotoDateTimeSet.Image = global::vamp.Properties.Resources.OK1;
            this.btPhotoDateTimeSet.Location = new System.Drawing.Point(170, 0);
            this.btPhotoDateTimeSet.Margin = new System.Windows.Forms.Padding(0);
            this.btPhotoDateTimeSet.Name = "btPhotoDateTimeSet";
            this.btPhotoDateTimeSet.Size = new System.Drawing.Size(31, 23);
            this.btPhotoDateTimeSet.TabIndex = 9;
            this.btPhotoDateTimeSet.UseVisualStyleBackColor = true;
            this.btPhotoDateTimeSet.Click += new System.EventHandler(this.btSetDate_Click);
            // 
            // lbTimeTakenTextDescription
            // 
            this.lbTimeTakenTextDescription.AutoSize = true;
            this.lbTimeTakenTextDescription.Location = new System.Drawing.Point(0, 280);
            this.lbTimeTakenTextDescription.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.lbTimeTakenTextDescription.Name = "lbTimeTakenTextDescription";
            this.lbTimeTakenTextDescription.Size = new System.Drawing.Size(143, 13);
            this.lbTimeTakenTextDescription.TabIndex = 7;
            this.lbTimeTakenTextDescription.Text = "Time taken (text description):";
            // 
            // tbTimeTakenTextValue
            // 
            this.tbTimeTakenTextValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPhotosInAlbum.SetColumnSpan(this.tbTimeTakenTextValue, 2);
            this.tbTimeTakenTextValue.Location = new System.Drawing.Point(3, 306);
            this.tbTimeTakenTextValue.Name = "tbTimeTakenTextValue";
            this.tbTimeTakenTextValue.Size = new System.Drawing.Size(355, 20);
            this.tbTimeTakenTextValue.TabIndex = 8;
            this.tbTimeTakenTextValue.TextChanged += new System.EventHandler(this.tbTimeTakenTextValue_TextChanged);
            // 
            // btAddTag
            // 
            this.tlpPhotosInAlbum.SetColumnSpan(this.btAddTag, 2);
            this.btAddTag.Image = global::vamp.Properties.Resources.Yellow_tag;
            this.btAddTag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddTag.Location = new System.Drawing.Point(364, 277);
            this.btAddTag.Name = "btAddTag";
            this.btAddTag.Size = new System.Drawing.Size(170, 23);
            this.btAddTag.TabIndex = 10;
            this.btAddTag.Text = "Add tag <--";
            this.btAddTag.UseVisualStyleBackColor = true;
            this.btAddTag.Click += new System.EventHandler(this.btAddTag_Click);
            // 
            // tbAddTag
            // 
            this.tbAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPhotosInAlbum.SetColumnSpan(this.tbAddTag, 2);
            this.tbAddTag.Location = new System.Drawing.Point(364, 306);
            this.tbAddTag.Name = "tbAddTag";
            this.tbAddTag.Size = new System.Drawing.Size(356, 20);
            this.tbAddTag.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tlpPhotosInAlbum.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lbPhotoTagValues, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(361, 25);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tlpPhotosInAlbum.SetRowSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(362, 249);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // lbPhotoTagValues
            // 
            this.lbPhotoTagValues.AllowDrop = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbPhotoTagValues, 2);
            this.lbPhotoTagValues.ContextMenuStrip = this.cmsPasteTags;
            this.lbPhotoTagValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPhotoTagValues.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbPhotoTagValues.FormattingEnabled = true;
            this.lbPhotoTagValues.ItemHeight = 25;
            this.lbPhotoTagValues.Location = new System.Drawing.Point(3, 3);
            this.lbPhotoTagValues.Name = "lbPhotoTagValues";
            this.lbPhotoTagValues.ScrollAlwaysVisible = true;
            this.lbPhotoTagValues.Size = new System.Drawing.Size(356, 243);
            this.lbPhotoTagValues.TabIndex = 9;
            this.lbPhotoTagValues.VScrollPosition = 0;
            this.lbPhotoTagValues.VScrollPositionNoEvent = 0;
            this.lbPhotoTagValues.DragDrop += new System.Windows.Forms.DragEventHandler(this.common_DragDrop);
            this.lbPhotoTagValues.DragEnter += new System.Windows.Forms.DragEventHandler(this.common_DragOverDragEnter);
            this.lbPhotoTagValues.DragOver += new System.Windows.Forms.DragEventHandler(this.common_DragOverDragEnter);
            this.lbPhotoTagValues.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPhotoTagValues_MouseDown);
            // 
            // cmsPasteTags
            // 
            this.cmsPasteTags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPasteTags});
            this.cmsPasteTags.Name = "cmsCopyPasteTags";
            this.cmsPasteTags.Size = new System.Drawing.Size(128, 26);
            this.cmsPasteTags.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPasteTags_Opening);
            // 
            // mnuPasteTags
            // 
            this.mnuPasteTags.Name = "mnuPasteTags";
            this.mnuPasteTags.Size = new System.Drawing.Size(127, 22);
            this.mnuPasteTags.Text = "Paste tags";
            this.mnuPasteTags.Click += new System.EventHandler(this.mnuPasteTags_Click);
            // 
            // ivPhoto
            // 
            this.ivPhoto.AllowDrop = true;
            this.tlpMain.SetColumnSpan(this.ivPhoto, 6);
            this.ivPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivPhoto.Image = null;
            this.ivPhoto.Location = new System.Drawing.Point(732, 3);
            this.ivPhoto.Name = "ivPhoto";
            this.tlpMain.SetRowSpan(this.ivPhoto, 9);
            this.ivPhoto.Size = new System.Drawing.Size(490, 605);
            this.ivPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ivPhoto.TabIndex = 0;
            this.ivPhoto.DragDrop += new System.Windows.Forms.DragEventHandler(this.common_DragDrop);
            this.ivPhoto.DragEnter += new System.Windows.Forms.DragEventHandler(this.common_DragOverDragEnter);
            this.ivPhoto.DragOver += new System.Windows.Forms.DragEventHandler(this.common_DragOverDragEnter);
            // 
            // tlpPhotoAlbumList
            // 
            this.tlpPhotoAlbumList.ColumnCount = 2;
            this.tlpMain.SetColumnSpan(this.tlpPhotoAlbumList, 4);
            this.tlpPhotoAlbumList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPhotoAlbumList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhotoAlbumList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPhotoAlbumList.Controls.Add(this.lbPhotoAlbumList, 0, 1);
            this.tlpPhotoAlbumList.Controls.Add(this.lbPhotoAlbumListDescription, 0, 0);
            this.tlpPhotoAlbumList.Controls.Add(this.lbPhotoAlbumNameDescription, 0, 2);
            this.tlpPhotoAlbumList.Controls.Add(this.tbHidden1, 1, 0);
            this.tlpPhotoAlbumList.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tlpPhotoAlbumList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPhotoAlbumList.Location = new System.Drawing.Point(3, 3);
            this.tlpPhotoAlbumList.Name = "tlpPhotoAlbumList";
            this.tlpPhotoAlbumList.RowCount = 3;
            this.tlpMain.SetRowSpan(this.tlpPhotoAlbumList, 3);
            this.tlpPhotoAlbumList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhotoAlbumList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhotoAlbumList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhotoAlbumList.Size = new System.Drawing.Size(318, 195);
            this.tlpPhotoAlbumList.TabIndex = 2;
            // 
            // lbPhotoAlbumList
            // 
            this.tlpPhotoAlbumList.SetColumnSpan(this.lbPhotoAlbumList, 2);
            this.lbPhotoAlbumList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPhotoAlbumList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbPhotoAlbumList.FormattingEnabled = true;
            this.lbPhotoAlbumList.ItemHeight = 25;
            this.lbPhotoAlbumList.Location = new System.Drawing.Point(3, 29);
            this.lbPhotoAlbumList.Name = "lbPhotoAlbumList";
            this.lbPhotoAlbumList.ScrollAlwaysVisible = true;
            this.lbPhotoAlbumList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbPhotoAlbumList.Size = new System.Drawing.Size(312, 135);
            this.lbPhotoAlbumList.TabIndex = 2;
            this.lbPhotoAlbumList.VScrollPosition = 0;
            this.lbPhotoAlbumList.VScrollPositionNoEvent = 0;
            this.lbPhotoAlbumList.SelectedIndexChanged += new System.EventHandler(this.lbPhotoAlbumList_SelectedValueChanged);
            this.lbPhotoAlbumList.SelectedValueChanged += new System.EventHandler(this.lbPhotoAlbumList_SelectedValueChanged);
            // 
            // lbPhotoAlbumListDescription
            // 
            this.lbPhotoAlbumListDescription.AutoSize = true;
            this.lbPhotoAlbumListDescription.Location = new System.Drawing.Point(3, 0);
            this.lbPhotoAlbumListDescription.Name = "lbPhotoAlbumListDescription";
            this.lbPhotoAlbumListDescription.Size = new System.Drawing.Size(74, 13);
            this.lbPhotoAlbumListDescription.TabIndex = 0;
            this.lbPhotoAlbumListDescription.Text = "Photo albums:";
            // 
            // lbPhotoAlbumNameDescription
            // 
            this.lbPhotoAlbumNameDescription.AutoSize = true;
            this.lbPhotoAlbumNameDescription.Location = new System.Drawing.Point(0, 173);
            this.lbPhotoAlbumNameDescription.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.lbPhotoAlbumNameDescription.Name = "lbPhotoAlbumNameDescription";
            this.lbPhotoAlbumNameDescription.Size = new System.Drawing.Size(98, 13);
            this.lbPhotoAlbumNameDescription.TabIndex = 3;
            this.lbPhotoAlbumNameDescription.Text = "Photo album name:";
            // 
            // tbHidden1
            // 
            this.tbHidden1.Location = new System.Drawing.Point(107, 3);
            this.tbHidden1.Name = "tbHidden1";
            this.tbHidden1.Size = new System.Drawing.Size(100, 20);
            this.tbHidden1.TabIndex = 5;
            this.tbHidden1.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.tbPhotoAlbumNameValue, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btSetAlbumName, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(104, 167);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(214, 28);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // tbPhotoAlbumNameValue
            // 
            this.tbPhotoAlbumNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhotoAlbumNameValue.Location = new System.Drawing.Point(3, 3);
            this.tbPhotoAlbumNameValue.Name = "tbPhotoAlbumNameValue";
            this.tbPhotoAlbumNameValue.ReadOnly = true;
            this.tbPhotoAlbumNameValue.Size = new System.Drawing.Size(171, 20);
            this.tbPhotoAlbumNameValue.TabIndex = 4;
            // 
            // btSetAlbumName
            // 
            this.btSetAlbumName.AutoSize = true;
            this.btSetAlbumName.Image = global::vamp.Properties.Resources.Modify;
            this.btSetAlbumName.Location = new System.Drawing.Point(180, 3);
            this.btSetAlbumName.Name = "btSetAlbumName";
            this.btSetAlbumName.Size = new System.Drawing.Size(31, 22);
            this.btSetAlbumName.TabIndex = 5;
            this.btSetAlbumName.UseVisualStyleBackColor = true;
            this.btSetAlbumName.Click += new System.EventHandler(this.btSetAlbumName_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tlpMain.SetColumnSpan(this.tableLayoutPanel1, 5);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tlpPhotoAlbumFirstDateValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPhotoAlbumTagListDescription, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPhotoAlbumTagListValues, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbPhotoAlbumFirstDateDescription, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbFilterTags, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(327, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tlpMain.SetRowSpan(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(399, 195);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tlpPhotoAlbumFirstDateValue
            // 
            this.tlpPhotoAlbumFirstDateValue.ColumnCount = 3;
            this.tlpPhotoAlbumFirstDateValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPhotoAlbumFirstDateValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPhotoAlbumFirstDateValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPhotoAlbumFirstDateValue.Controls.Add(this.btPhotoAlbumFirstDateTimeSet, 2, 0);
            this.tlpPhotoAlbumFirstDateValue.Controls.Add(this.dtpPhotoAlbumFirstTimeValue, 0, 0);
            this.tlpPhotoAlbumFirstDateValue.Controls.Add(this.dtpPhotoAlbumFirstDateValue, 0, 0);
            this.tlpPhotoAlbumFirstDateValue.Location = new System.Drawing.Point(116, 170);
            this.tlpPhotoAlbumFirstDateValue.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPhotoAlbumFirstDateValue.Name = "tlpPhotoAlbumFirstDateValue";
            this.tlpPhotoAlbumFirstDateValue.RowCount = 1;
            this.tlpPhotoAlbumFirstDateValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhotoAlbumFirstDateValue.Size = new System.Drawing.Size(280, 20);
            this.tlpPhotoAlbumFirstDateValue.TabIndex = 12;
            // 
            // btPhotoAlbumFirstDateTimeSet
            // 
            this.btPhotoAlbumFirstDateTimeSet.AutoSize = true;
            this.btPhotoAlbumFirstDateTimeSet.Image = global::vamp.Properties.Resources.OK1;
            this.btPhotoAlbumFirstDateTimeSet.Location = new System.Drawing.Point(248, 0);
            this.btPhotoAlbumFirstDateTimeSet.Margin = new System.Windows.Forms.Padding(0);
            this.btPhotoAlbumFirstDateTimeSet.Name = "btPhotoAlbumFirstDateTimeSet";
            this.btPhotoAlbumFirstDateTimeSet.Size = new System.Drawing.Size(31, 20);
            this.btPhotoAlbumFirstDateTimeSet.TabIndex = 10;
            this.btPhotoAlbumFirstDateTimeSet.UseVisualStyleBackColor = true;
            this.btPhotoAlbumFirstDateTimeSet.Click += new System.EventHandler(this.btSetDate_Click);
            // 
            // dtpPhotoAlbumFirstTimeValue
            // 
            this.dtpPhotoAlbumFirstTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPhotoAlbumFirstTimeValue.CustomFormat = "";
            this.dtpPhotoAlbumFirstTimeValue.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpPhotoAlbumFirstTimeValue.Location = new System.Drawing.Point(127, 3);
            this.dtpPhotoAlbumFirstTimeValue.Name = "dtpPhotoAlbumFirstTimeValue";
            this.dtpPhotoAlbumFirstTimeValue.Size = new System.Drawing.Size(118, 20);
            this.dtpPhotoAlbumFirstTimeValue.TabIndex = 8;
            // 
            // dtpPhotoAlbumFirstDateValue
            // 
            this.dtpPhotoAlbumFirstDateValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPhotoAlbumFirstDateValue.CustomFormat = "";
            this.dtpPhotoAlbumFirstDateValue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPhotoAlbumFirstDateValue.Location = new System.Drawing.Point(3, 3);
            this.dtpPhotoAlbumFirstDateValue.Name = "dtpPhotoAlbumFirstDateValue";
            this.dtpPhotoAlbumFirstDateValue.Size = new System.Drawing.Size(118, 20);
            this.dtpPhotoAlbumFirstDateValue.TabIndex = 7;
            // 
            // lbPhotoAlbumTagListDescription
            // 
            this.lbPhotoAlbumTagListDescription.AutoSize = true;
            this.lbPhotoAlbumTagListDescription.Location = new System.Drawing.Point(3, 0);
            this.lbPhotoAlbumTagListDescription.Name = "lbPhotoAlbumTagListDescription";
            this.lbPhotoAlbumTagListDescription.Size = new System.Drawing.Size(110, 13);
            this.lbPhotoAlbumTagListDescription.TabIndex = 1;
            this.lbPhotoAlbumTagListDescription.Text = "Tags in the database:";
            // 
            // lbPhotoAlbumTagListValues
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbPhotoAlbumTagListValues, 2);
            this.lbPhotoAlbumTagListValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPhotoAlbumTagListValues.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbPhotoAlbumTagListValues.FormattingEnabled = true;
            this.lbPhotoAlbumTagListValues.ItemHeight = 25;
            this.lbPhotoAlbumTagListValues.Location = new System.Drawing.Point(3, 29);
            this.lbPhotoAlbumTagListValues.Name = "lbPhotoAlbumTagListValues";
            this.lbPhotoAlbumTagListValues.ScrollAlwaysVisible = true;
            this.lbPhotoAlbumTagListValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbPhotoAlbumTagListValues.Size = new System.Drawing.Size(393, 138);
            this.lbPhotoAlbumTagListValues.TabIndex = 2;
            this.lbPhotoAlbumTagListValues.VScrollPosition = 0;
            this.lbPhotoAlbumTagListValues.VScrollPositionNoEvent = 0;
            this.lbPhotoAlbumTagListValues.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPhotoAlbumTagListValues_MouseDown);
            // 
            // lbPhotoAlbumFirstDateDescription
            // 
            this.lbPhotoAlbumFirstDateDescription.AutoSize = true;
            this.lbPhotoAlbumFirstDateDescription.Location = new System.Drawing.Point(0, 176);
            this.lbPhotoAlbumFirstDateDescription.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.lbPhotoAlbumFirstDateDescription.Name = "lbPhotoAlbumFirstDateDescription";
            this.lbPhotoAlbumFirstDateDescription.Size = new System.Drawing.Size(63, 13);
            this.lbPhotoAlbumFirstDateDescription.TabIndex = 11;
            this.lbPhotoAlbumFirstDateDescription.Text = "Album date:";
            // 
            // tbFilterTags
            // 
            this.tbFilterTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilterTags.Location = new System.Drawing.Point(119, 3);
            this.tbFilterTags.Name = "tbFilterTags";
            this.tbFilterTags.Size = new System.Drawing.Size(277, 20);
            this.tbFilterTags.TabIndex = 13;
            this.tbFilterTags.TextChanged += new System.EventHandler(this.tbFilterTags_TextChanged);
            // 
            // pnTrash
            // 
            this.pnTrash.AllowDrop = true;
            this.pnTrash.BackgroundImage = global::vamp.Properties.Resources.rbin;
            this.pnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnTrash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTrash.Location = new System.Drawing.Point(408, 539);
            this.pnTrash.Name = "pnTrash";
            this.pnTrash.Size = new System.Drawing.Size(75, 69);
            this.pnTrash.TabIndex = 6;
            this.pnTrash.DragDrop += new System.Windows.Forms.DragEventHandler(this.common_DragDrop);
            this.pnTrash.DragEnter += new System.Windows.Forms.DragEventHandler(this.common_DragOverDragEnter);
            this.pnTrash.DragOver += new System.Windows.Forms.DragEventHandler(this.common_DragOverDragEnter);
            // 
            // pnSave
            // 
            this.pnSave.AllowDrop = true;
            this.pnSave.BackgroundImage = global::vamp.Properties.Resources.save_changes;
            this.pnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSave.Location = new System.Drawing.Point(3, 539);
            this.pnSave.Name = "pnSave";
            this.pnSave.Size = new System.Drawing.Size(75, 69);
            this.pnSave.TabIndex = 7;
            this.pnSave.Click += new System.EventHandler(this.pnSave_Click);
            // 
            // lbItemDragDescription
            // 
            this.tlpMain.SetColumnSpan(this.lbItemDragDescription, 2);
            this.lbItemDragDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbItemDragDescription.Location = new System.Drawing.Point(246, 536);
            this.lbItemDragDescription.Name = "lbItemDragDescription";
            this.lbItemDragDescription.Size = new System.Drawing.Size(156, 75);
            this.lbItemDragDescription.TabIndex = 9;
            this.lbItemDragDescription.Text = "Drag photo files or photo file tags here to delete them from the database -->";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1249, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.toolStripMenuItem3,
            this.mnuSaveChanges,
            this.mnuUndoChanges,
            this.toolStripMenuItem5,
            this.mnuExportSelectedXML,
            this.mnuImportXML,
            this.toolStripMenuItem4,
            this.mnuExportSelectedSQL,
            this.mnuImportSQL,
            this.toolStripMenuItem2,
            this.mnuDelete,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.mnuFile.Image = global::vamp.Properties.Resources.List;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(53, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Image = global::vamp.Properties.Resources.New_document;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(230, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(227, 6);
            // 
            // mnuSaveChanges
            // 
            this.mnuSaveChanges.Image = global::vamp.Properties.Resources.Save;
            this.mnuSaveChanges.Name = "mnuSaveChanges";
            this.mnuSaveChanges.Size = new System.Drawing.Size(230, 22);
            this.mnuSaveChanges.Text = "Save changes";
            this.mnuSaveChanges.Click += new System.EventHandler(this.pnSave_Click);
            // 
            // mnuUndoChanges
            // 
            this.mnuUndoChanges.Image = global::vamp.Properties.Resources.undo_save;
            this.mnuUndoChanges.Name = "mnuUndoChanges";
            this.mnuUndoChanges.Size = new System.Drawing.Size(230, 22);
            this.mnuUndoChanges.Text = "Undo changes";
            this.mnuUndoChanges.Click += new System.EventHandler(this.pnUndoSave_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(227, 6);
            // 
            // mnuExportSelectedXML
            // 
            this.mnuExportSelectedXML.Image = global::vamp.Properties.Resources.Download;
            this.mnuExportSelectedXML.Name = "mnuExportSelectedXML";
            this.mnuExportSelectedXML.Size = new System.Drawing.Size(230, 22);
            this.mnuExportSelectedXML.Text = "Export selected albums (XML)";
            this.mnuExportSelectedXML.Click += new System.EventHandler(this.mnuExportSelectedXML_Click);
            // 
            // mnuImportXML
            // 
            this.mnuImportXML.Image = global::vamp.Properties.Resources.Upload;
            this.mnuImportXML.Name = "mnuImportXML";
            this.mnuImportXML.Size = new System.Drawing.Size(230, 22);
            this.mnuImportXML.Text = "Import (XML)";
            this.mnuImportXML.Click += new System.EventHandler(this.mnuImportXML_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(227, 6);
            // 
            // mnuExportSelectedSQL
            // 
            this.mnuExportSelectedSQL.Image = global::vamp.Properties.Resources.database_down;
            this.mnuExportSelectedSQL.Name = "mnuExportSelectedSQL";
            this.mnuExportSelectedSQL.Size = new System.Drawing.Size(230, 22);
            this.mnuExportSelectedSQL.Text = "Export selected albums (SQL)";
            this.mnuExportSelectedSQL.Click += new System.EventHandler(this.mnuExportSelectedSQL_Click);
            // 
            // mnuImportSQL
            // 
            this.mnuImportSQL.Image = global::vamp.Properties.Resources.database_up;
            this.mnuImportSQL.Name = "mnuImportSQL";
            this.mnuImportSQL.Size = new System.Drawing.Size(230, 22);
            this.mnuImportSQL.Text = "Import (SQL)";
            this.mnuImportSQL.Visible = false;
            this.mnuImportSQL.Click += new System.EventHandler(this.mnuImportSQL_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(227, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::vamp.Properties.Resources.Delete;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(230, 22);
            this.mnuDelete.Text = "Delete selected albums";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(227, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::vamp.Properties.Resources.Exit;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(230, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // sdSQL
            // 
            this.sdSQL.DefaultExt = "*.sql";
            this.sdSQL.Filter = "SQL Script Files|*.sql";
            // 
            // odSQL
            // 
            this.odSQL.DefaultExt = "*.sql";
            this.odSQL.Filter = "SQL Script Files|*.sql";
            // 
            // sdXML
            // 
            this.sdXML.DefaultExt = "*.xml";
            this.sdXML.Filter = "XML Files|*.xml";
            // 
            // odXML
            // 
            this.odXML.DefaultExt = "*.xml";
            this.odXML.Filter = "XML Files|*.xml";
            // 
            // FormPhotoAlbumEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 650);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPhotoAlbumEditor";
            this.Text = "vamp# photo album editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPhotoAlbumEditor_FormClosing);
            this.Load += new System.EventHandler(this.FormPhotoAlbumEditor_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpPhotosInAlbum.ResumeLayout(false);
            this.tlpPhotosInAlbum.PerformLayout();
            this.cmsCopyTags.ResumeLayout(false);
            this.tlpTimeTakenValue.ResumeLayout(false);
            this.tlpTimeTakenValue.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.cmsPasteTags.ResumeLayout(false);
            this.tlpPhotoAlbumList.ResumeLayout(false);
            this.tlpPhotoAlbumList.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpPhotoAlbumFirstDateValue.ResumeLayout(false);
            this.tlpPhotoAlbumFirstDateValue.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuImportXML;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.TableLayoutPanel tlpPhotosInAlbum;
        private VPKSoft.VisualListBox.ListBoxExtension lbPhotosInAlbum;
        private System.Windows.Forms.Label lbPhotosInAlbumDescription;
        private VPKSoft.ImageViewer.ImageViewer ivPhoto;
        private System.Windows.Forms.TableLayoutPanel tlpPhotoAlbumList;
        private VPKSoft.VisualListBox.ListBoxExtension lbPhotoAlbumList;
        private System.Windows.Forms.Label lbPhotoAlbumListDescription;
        private System.Windows.Forms.Label lbPhotoAlbumNameDescription;
        private System.Windows.Forms.TextBox tbPhotoAlbumNameValue;
        private System.Windows.Forms.Label lbPhotoDescriptionDescription;
        private System.Windows.Forms.TextBox tbPhotoDescriptionValue;
        private System.Windows.Forms.Label lbTimeTakenDescription;
        private System.Windows.Forms.TableLayoutPanel tlpTimeTakenValue;
        private System.Windows.Forms.DateTimePicker dtpTimeTakenValueTime;
        private System.Windows.Forms.DateTimePicker dtpTimeTakenValueDate;
        private System.Windows.Forms.Label lbTimeTakenTextDescription;
        private System.Windows.Forms.TextBox tbTimeTakenTextValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbPhotoAlbumTagListDescription;
        private VPKSoft.VisualListBox.ListBoxExtension lbPhotoAlbumTagListValues;
        private VPKSoft.VisualListBox.ListBoxExtension lbPhotoTagValues;
        private System.Windows.Forms.Label lbPhotoTagDescription;
        private System.Windows.Forms.Panel pnTrash;
        private System.Windows.Forms.TableLayoutPanel tlpPhotoAlbumFirstDateValue;
        private System.Windows.Forms.DateTimePicker dtpPhotoAlbumFirstTimeValue;
        private System.Windows.Forms.DateTimePicker dtpPhotoAlbumFirstDateValue;
        private System.Windows.Forms.Label lbPhotoAlbumFirstDateDescription;
        private System.Windows.Forms.Button btAddTag;
        private System.Windows.Forms.TextBox tbAddTag;
        private System.Windows.Forms.Panel pnSave;
        private System.Windows.Forms.Button btPhotoDateTimeSet;
        private System.Windows.Forms.Button btPhotoAlbumFirstDateTimeSet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbFilterTags;
        private System.Windows.Forms.TextBox tbHidden1;
        private System.Windows.Forms.ContextMenuStrip cmsCopyTags;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyTags;
        private System.Windows.Forms.ContextMenuStrip cmsPasteTags;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteTags;
        private System.Windows.Forms.SaveFileDialog sdSQL;
        private System.Windows.Forms.OpenFileDialog odSQL;
        private System.Windows.Forms.SaveFileDialog sdXML;
        private System.Windows.Forms.OpenFileDialog odXML;
        private System.Windows.Forms.ToolStripMenuItem mnuExportSelectedSQL;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuImportSQL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btSetAlbumName;
        private System.Windows.Forms.Panel pnUndoSave;
        private System.Windows.Forms.ToolStripMenuItem mnuExportSelectedXML;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveChanges;
        private System.Windows.Forms.ToolStripMenuItem mnuUndoChanges;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.Label lbItemDragDescription;
    }
}

