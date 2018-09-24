namespace vamp
{
    partial class FormSelectSubtitle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectSubtitle));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnListBoxHolder = new System.Windows.Forms.Panel();
            this.lbSubtitles = new System.Windows.Forms.ListBox();
            this.btCancel = new VPKSoft.ImageButton.ImageButton();
            this.btOK = new VPKSoft.ImageButton.ImageButton();
            this.tlpMain.SuspendLayout();
            this.pnListBoxHolder.SuspendLayout();
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
            this.tlpMain.Controls.Add(this.btCancel, 2, 1);
            this.tlpMain.Controls.Add(this.btOK, 0, 1);
            this.tlpMain.Controls.Add(this.pnListBoxHolder, 0, 0);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(547, 537);
            this.tlpMain.TabIndex = 0;
            // 
            // pnListBoxHolder
            // 
            this.tlpMain.SetColumnSpan(this.pnListBoxHolder, 3);
            this.pnListBoxHolder.Controls.Add(this.lbSubtitles);
            this.pnListBoxHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListBoxHolder.Location = new System.Drawing.Point(0, 0);
            this.pnListBoxHolder.Margin = new System.Windows.Forms.Padding(0);
            this.pnListBoxHolder.Name = "pnListBoxHolder";
            this.pnListBoxHolder.Size = new System.Drawing.Size(547, 483);
            this.pnListBoxHolder.TabIndex = 5;
            // 
            // lbSubtitles
            // 
            this.lbSubtitles.BackColor = System.Drawing.Color.Black;
            this.lbSubtitles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSubtitles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbSubtitles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lbSubtitles.ForeColor = System.Drawing.Color.White;
            this.lbSubtitles.FormattingEnabled = true;
            this.lbSubtitles.ItemHeight = 25;
            this.lbSubtitles.Location = new System.Drawing.Point(0, 0);
            this.lbSubtitles.Name = "lbSubtitles";
            this.lbSubtitles.Size = new System.Drawing.Size(547, 483);
            this.lbSubtitles.TabIndex = 2;
            this.lbSubtitles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbSubtitles_DrawItem);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.ButtonImage = global::vamp.Properties.Resources.Cancel;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btCancel.ForeColor = System.Drawing.Color.Red;
            this.btCancel.Location = new System.Drawing.Point(329, 485);
            this.btCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btCancel.Size = new System.Drawing.Size(216, 50);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.ButtonImage = global::vamp.Properties.Resources.OK;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(2, 485);
            this.btOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btOK.Size = new System.Drawing.Size(214, 50);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "OK";
            // 
            // SelectSubtitleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(571, 561);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormSelectSubtitle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelectSubtitle";
            this.Shown += new System.EventHandler(this.SelectSubtitleForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectSubtitleForm_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.pnListBoxHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private VPKSoft.ImageButton.ImageButton btCancel;
        private VPKSoft.ImageButton.ImageButton btOK;
        private System.Windows.Forms.Panel pnListBoxHolder;
        private System.Windows.Forms.ListBox lbSubtitles;
    }
}