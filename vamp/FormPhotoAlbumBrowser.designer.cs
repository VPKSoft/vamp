namespace vamp
{
    partial class FormPhotoAlbumBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhotoAlbumBrowser));
            this.tlpPopDown = new System.Windows.Forms.TableLayoutPanel();
            this.lbImageDesc = new System.Windows.Forms.Label();
            this.lbToolTip = new System.Windows.Forms.Label();
            this.pnButtons = new System.Windows.Forms.Panel();
            this.btnRotateClockwise = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Panel();
            this.btnPervious = new System.Windows.Forms.Panel();
            this.btnRotateCounterClockwise = new System.Windows.Forms.Panel();
            this.lbFullScreenDescription = new System.Windows.Forms.Label();
            this.pbPhoto = new VPKSoft.ImageViewer.ImageViewer();
            this.tlpPopDown.SuspendLayout();
            this.pnButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPopDown
            // 
            this.tlpPopDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPopDown.BackColor = System.Drawing.Color.Black;
            this.tlpPopDown.ColumnCount = 5;
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpPopDown.Controls.Add(this.lbImageDesc, 1, 0);
            this.tlpPopDown.Controls.Add(this.lbToolTip, 2, 2);
            this.tlpPopDown.Controls.Add(this.pnButtons, 0, 1);
            this.tlpPopDown.Location = new System.Drawing.Point(0, 491);
            this.tlpPopDown.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPopDown.Name = "tlpPopDown";
            this.tlpPopDown.RowCount = 3;
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpPopDown.Size = new System.Drawing.Size(903, 167);
            this.tlpPopDown.TabIndex = 3;
            // 
            // lbImageDesc
            // 
            this.lbImageDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbImageDesc.AutoSize = true;
            this.tlpPopDown.SetColumnSpan(this.lbImageDesc, 3);
            this.lbImageDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lbImageDesc.ForeColor = System.Drawing.Color.White;
            this.lbImageDesc.Location = new System.Drawing.Point(23, 0);
            this.lbImageDesc.Name = "lbImageDesc";
            this.lbImageDesc.Size = new System.Drawing.Size(854, 38);
            this.lbImageDesc.TabIndex = 23;
            this.lbImageDesc.Text = "http://www.vpksoft.net";
            this.lbImageDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbToolTip
            // 
            this.lbToolTip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToolTip.ForeColor = System.Drawing.Color.Yellow;
            this.lbToolTip.Location = new System.Drawing.Point(235, 143);
            this.lbToolTip.Margin = new System.Windows.Forms.Padding(0);
            this.lbToolTip.Name = "lbToolTip";
            this.lbToolTip.Size = new System.Drawing.Size(473, 24);
            this.lbToolTip.TabIndex = 21;
            this.lbToolTip.Text = "/* TOOL-TIP SHOWS HERE */";
            this.lbToolTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnButtons
            // 
            this.tlpPopDown.SetColumnSpan(this.pnButtons, 5);
            this.pnButtons.Controls.Add(this.btnRotateClockwise);
            this.pnButtons.Controls.Add(this.btnExit);
            this.pnButtons.Controls.Add(this.btnNext);
            this.pnButtons.Controls.Add(this.btnPervious);
            this.pnButtons.Controls.Add(this.btnRotateCounterClockwise);
            this.pnButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnButtons.Location = new System.Drawing.Point(0, 38);
            this.pnButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnButtons.Name = "pnButtons";
            this.pnButtons.Size = new System.Drawing.Size(903, 105);
            this.pnButtons.TabIndex = 3;
            // 
            // btnRotateClockwise
            // 
            this.btnRotateClockwise.BackgroundImage = global::vamp.Properties.Resources.rotate_cw;
            this.btnRotateClockwise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRotateClockwise.Location = new System.Drawing.Point(414, 5);
            this.btnRotateClockwise.Margin = new System.Windows.Forms.Padding(0);
            this.btnRotateClockwise.Name = "btnRotateClockwise";
            this.btnRotateClockwise.Size = new System.Drawing.Size(125, 80);
            this.btnRotateClockwise.TabIndex = 25;
            this.btnRotateClockwise.Tag = "2";
            this.btnRotateClockwise.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnRotateClockwise.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnRotateClockwise.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::vamp.Properties.Resources.Cancel;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Location = new System.Drawing.Point(769, 5);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(125, 80);
            this.btnExit.TabIndex = 24;
            this.btnExit.Tag = "4";
            this.btnExit.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnExit.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::vamp.Properties.Resources.forward;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.Location = new System.Drawing.Point(622, 5);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(125, 80);
            this.btnNext.TabIndex = 22;
            this.btnNext.Tag = "3";
            this.btnNext.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnNext.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnNext.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnPervious
            // 
            this.btnPervious.BackgroundImage = global::vamp.Properties.Resources.back;
            this.btnPervious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPervious.Location = new System.Drawing.Point(31, 5);
            this.btnPervious.Margin = new System.Windows.Forms.Padding(0);
            this.btnPervious.Name = "btnPervious";
            this.btnPervious.Size = new System.Drawing.Size(125, 80);
            this.btnPervious.TabIndex = 21;
            this.btnPervious.Tag = "0";
            this.btnPervious.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnPervious.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnPervious.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnRotateCounterClockwise
            // 
            this.btnRotateCounterClockwise.BackgroundImage = global::vamp.Properties.Resources.rotate_ccw;
            this.btnRotateCounterClockwise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRotateCounterClockwise.Location = new System.Drawing.Point(222, 5);
            this.btnRotateCounterClockwise.Margin = new System.Windows.Forms.Padding(0);
            this.btnRotateCounterClockwise.Name = "btnRotateCounterClockwise";
            this.btnRotateCounterClockwise.Size = new System.Drawing.Size(125, 80);
            this.btnRotateCounterClockwise.TabIndex = 17;
            this.btnRotateCounterClockwise.Tag = "1";
            this.btnRotateCounterClockwise.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnRotateCounterClockwise.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnRotateCounterClockwise.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // lbFullScreenDescription
            // 
            this.lbFullScreenDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFullScreenDescription.AutoSize = true;
            this.lbFullScreenDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullScreenDescription.ForeColor = System.Drawing.Color.White;
            this.lbFullScreenDescription.Location = new System.Drawing.Point(0, 0);
            this.lbFullScreenDescription.MaximumSize = new System.Drawing.Size(903, 69);
            this.lbFullScreenDescription.Name = "lbFullScreenDescription";
            this.lbFullScreenDescription.Size = new System.Drawing.Size(800, 33);
            this.lbFullScreenDescription.TabIndex = 6;
            this.lbFullScreenDescription.Text = "/* NO CONTROL BAR VISIBLE IMAGE DESCRIPTION */";
            this.lbFullScreenDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbFullScreenDescription.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbFullScreenDescription_MouseDown);
            this.lbFullScreenDescription.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbFullScreenDescription_MouseMove);
            this.lbFullScreenDescription.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbFullScreenDescription_MouseUp);
            // 
            // pbPhoto
            // 
            this.pbPhoto.BackColor = System.Drawing.Color.Black;
            this.pbPhoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPhoto.Image = null;
            this.pbPhoto.Location = new System.Drawing.Point(0, 0);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(903, 488);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 5;
            // 
            // PhotoAlbumBrowserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(903, 658);
            this.Controls.Add(this.lbFullScreenDescription);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.tlpPopDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "PhotoAlbumBrowserForm";
            this.ShowInTaskbar = false;
            this.Text = "WebBrowserForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhotoAlbumBrowserForm_FormClosing);
            this.Shown += new System.EventHandler(this.PhotoAlbumBrowserForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GlobalKeyDown);
            this.tlpPopDown.ResumeLayout(false);
            this.tlpPopDown.PerformLayout();
            this.pnButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPopDown;
        private System.Windows.Forms.Label lbToolTip;
        private System.Windows.Forms.Panel pnButtons;
        private System.Windows.Forms.Panel btnRotateCounterClockwise;
        private System.Windows.Forms.Panel btnNext;
        private System.Windows.Forms.Panel btnPervious;
        private System.Windows.Forms.Panel btnExit;
        private System.Windows.Forms.Panel btnRotateClockwise;
        private System.Windows.Forms.Label lbImageDesc;
        private VPKSoft.ImageViewer.ImageViewer pbPhoto;
        private System.Windows.Forms.Label lbFullScreenDescription;
    }
}