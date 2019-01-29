namespace vamp
{
    partial class FormSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSplash));
            this.pnSplash = new System.Windows.Forms.Panel();
            this.tlpSplash = new System.Windows.Forms.TableLayoutPanel();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbLoading = new System.Windows.Forms.Label();
            this.pbWait = new System.Windows.Forms.PictureBox();
            this.lbVamp = new System.Windows.Forms.Label();
            this.pnTMDb = new System.Windows.Forms.Panel();
            this.tlpSlashSub = new System.Windows.Forms.TableLayoutPanel();
            this.lbLoadingItemValueDone = new System.Windows.Forms.Label();
            this.lbLoadingItemValue = new System.Windows.Forms.Label();
            this.lbLoadingItem = new System.Windows.Forms.Label();
            this.lbPercentage = new System.Windows.Forms.Label();
            this.pnSplash.SuspendLayout();
            this.tlpSplash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).BeginInit();
            this.tlpSlashSub.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSplash
            // 
            this.pnSplash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnSplash.BackColor = System.Drawing.Color.Black;
            this.pnSplash.Controls.Add(this.tlpSplash);
            this.pnSplash.Location = new System.Drawing.Point(12, 12);
            this.pnSplash.Name = "pnSplash";
            this.pnSplash.Size = new System.Drawing.Size(725, 506);
            this.pnSplash.TabIndex = 0;
            // 
            // tlpSplash
            // 
            this.tlpSplash.ColumnCount = 3;
            this.tlpSplash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSplash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpSplash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpSplash.Controls.Add(this.lbVersion, 1, 3);
            this.tlpSplash.Controls.Add(this.lbCopyright, 0, 3);
            this.tlpSplash.Controls.Add(this.lbLoading, 1, 0);
            this.tlpSplash.Controls.Add(this.pbWait, 2, 0);
            this.tlpSplash.Controls.Add(this.lbVamp, 0, 0);
            this.tlpSplash.Controls.Add(this.pnTMDb, 2, 3);
            this.tlpSplash.Controls.Add(this.tlpSlashSub, 0, 1);
            this.tlpSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSplash.Location = new System.Drawing.Point(0, 0);
            this.tlpSplash.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSplash.Name = "tlpSplash";
            this.tlpSplash.RowCount = 4;
            this.tlpSplash.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSplash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSplash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSplash.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSplash.Size = new System.Drawing.Size(725, 506);
            this.tlpSplash.TabIndex = 0;
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVersion.AutoSize = true;
            this.lbVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbVersion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.ForeColor = System.Drawing.Color.White;
            this.lbVersion.Location = new System.Drawing.Point(241, 400);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(241, 106);
            this.lbVersion.TabIndex = 9;
            this.lbVersion.Text = "© VPKSoft 2019  ";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCopyright
            // 
            this.lbCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCopyright.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbCopyright.Location = new System.Drawing.Point(0, 400);
            this.lbCopyright.Margin = new System.Windows.Forms.Padding(0);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(241, 106);
            this.lbCopyright.TabIndex = 8;
            this.lbCopyright.Text = "© VPKSoft 2019  ";
            this.lbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLoading
            // 
            this.lbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoading.AutoSize = true;
            this.lbLoading.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoading.ForeColor = System.Drawing.Color.DeepPink;
            this.lbLoading.Location = new System.Drawing.Point(241, 0);
            this.lbLoading.Margin = new System.Windows.Forms.Padding(0);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(241, 82);
            this.lbLoading.TabIndex = 7;
            this.lbLoading.Text = "...loading...";
            this.lbLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbWait
            // 
            this.pbWait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbWait.Image = global::vamp.Properties.Resources.Dual_Ring_1s_200px;
            this.pbWait.Location = new System.Drawing.Point(485, 3);
            this.pbWait.Name = "pbWait";
            this.pbWait.Size = new System.Drawing.Size(237, 76);
            this.pbWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWait.TabIndex = 6;
            this.pbWait.TabStop = false;
            // 
            // lbVamp
            // 
            this.lbVamp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVamp.AutoSize = true;
            this.lbVamp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVamp.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lbVamp.Location = new System.Drawing.Point(0, 0);
            this.lbVamp.Margin = new System.Windows.Forms.Padding(0);
            this.lbVamp.Name = "lbVamp";
            this.lbVamp.Size = new System.Drawing.Size(241, 82);
            this.lbVamp.TabIndex = 3;
            this.lbVamp.Text = "vamp#";
            this.lbVamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnTMDb
            // 
            this.pnTMDb.BackgroundImage = global::vamp.Properties.Resources.powered_by_rectangle_green_the_movie_db;
            this.pnTMDb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnTMDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTMDb.Location = new System.Drawing.Point(485, 403);
            this.pnTMDb.Name = "pnTMDb";
            this.pnTMDb.Size = new System.Drawing.Size(237, 100);
            this.pnTMDb.TabIndex = 10;
            // 
            // tlpSlashSub
            // 
            this.tlpSlashSub.ColumnCount = 4;
            this.tlpSplash.SetColumnSpan(this.tlpSlashSub, 3);
            this.tlpSlashSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSlashSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tlpSlashSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tlpSlashSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSlashSub.Controls.Add(this.lbLoadingItemValueDone, 1, 2);
            this.tlpSlashSub.Controls.Add(this.lbLoadingItemValue, 1, 1);
            this.tlpSlashSub.Controls.Add(this.lbLoadingItem, 0, 1);
            this.tlpSlashSub.Controls.Add(this.lbPercentage, 3, 1);
            this.tlpSlashSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSlashSub.Location = new System.Drawing.Point(3, 85);
            this.tlpSlashSub.Name = "tlpSlashSub";
            this.tlpSlashSub.RowCount = 3;
            this.tlpSplash.SetRowSpan(this.tlpSlashSub, 2);
            this.tlpSlashSub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSlashSub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSlashSub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSlashSub.Size = new System.Drawing.Size(719, 312);
            this.tlpSlashSub.TabIndex = 11;
            // 
            // lbLoadingItemValueDone
            // 
            this.lbLoadingItemValueDone.AutoSize = true;
            this.tlpSlashSub.SetColumnSpan(this.lbLoadingItemValueDone, 2);
            this.lbLoadingItemValueDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLoadingItemValueDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoadingItemValueDone.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoadingItemValueDone.ForeColor = System.Drawing.Color.DarkGray;
            this.lbLoadingItemValueDone.Location = new System.Drawing.Point(192, 208);
            this.lbLoadingItemValueDone.Margin = new System.Windows.Forms.Padding(0);
            this.lbLoadingItemValueDone.Name = "lbLoadingItemValueDone";
            this.lbLoadingItemValueDone.Size = new System.Drawing.Size(446, 104);
            this.lbLoadingItemValueDone.TabIndex = 12;
            this.lbLoadingItemValueDone.Text = "-";
            // 
            // lbLoadingItemValue
            // 
            this.lbLoadingItemValue.AutoSize = true;
            this.tlpSlashSub.SetColumnSpan(this.lbLoadingItemValue, 2);
            this.lbLoadingItemValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLoadingItemValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoadingItemValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoadingItemValue.ForeColor = System.Drawing.Color.White;
            this.lbLoadingItemValue.Location = new System.Drawing.Point(192, 104);
            this.lbLoadingItemValue.Margin = new System.Windows.Forms.Padding(0);
            this.lbLoadingItemValue.Name = "lbLoadingItemValue";
            this.lbLoadingItemValue.Size = new System.Drawing.Size(446, 104);
            this.lbLoadingItemValue.TabIndex = 10;
            this.lbLoadingItemValue.Text = "-";
            // 
            // lbLoadingItem
            // 
            this.lbLoadingItem.AutoSize = true;
            this.lbLoadingItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLoadingItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoadingItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoadingItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbLoadingItem.Location = new System.Drawing.Point(0, 104);
            this.lbLoadingItem.Margin = new System.Windows.Forms.Padding(0);
            this.lbLoadingItem.Name = "lbLoadingItem";
            this.lbLoadingItem.Size = new System.Drawing.Size(192, 104);
            this.lbLoadingItem.TabIndex = 9;
            this.lbLoadingItem.Text = "Loading item:";
            this.lbLoadingItem.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbPercentage
            // 
            this.lbPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPercentage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F);
            this.lbPercentage.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbPercentage.Location = new System.Drawing.Point(641, 104);
            this.lbPercentage.Name = "lbPercentage";
            this.lbPercentage.Size = new System.Drawing.Size(75, 104);
            this.lbPercentage.TabIndex = 11;
            this.lbPercentage.Text = "0 %";
            this.lbPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(749, 530);
            this.Controls.Add(this.pnSplash);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSplash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSplash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSplash_FormClosing);
            this.pnSplash.ResumeLayout(false);
            this.tlpSplash.ResumeLayout(false);
            this.tlpSplash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).EndInit();
            this.tlpSlashSub.ResumeLayout(false);
            this.tlpSlashSub.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSplash;
        private System.Windows.Forms.TableLayoutPanel tlpSplash;
        private System.Windows.Forms.Label lbVamp;
        private System.Windows.Forms.Label lbLoading;
        private System.Windows.Forms.PictureBox pbWait;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Panel pnTMDb;
        private System.Windows.Forms.TableLayoutPanel tlpSlashSub;
        private System.Windows.Forms.Label lbLoadingItem;
        private System.Windows.Forms.Label lbLoadingItemValue;
        private System.Windows.Forms.Label lbPercentage;
        private System.Windows.Forms.Label lbLoadingItemValueDone;
    }
}