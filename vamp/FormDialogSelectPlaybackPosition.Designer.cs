namespace vamp
{
    partial class FormDialogSelectPlaybackPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogSelectPlaybackPosition));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btFromStart = new VPKSoft.ImageButton.ImageButton();
            this.btContinue = new VPKSoft.ImageButton.ImageButton();
            this.lbContext = new VPKSoft.ImageButton.ImageButton();
            this.pnBorder = new System.Windows.Forms.Panel();
            this.tlpMain.SuspendLayout();
            this.pnBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Black;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Controls.Add(this.btFromStart, 1, 1);
            this.tlpMain.Controls.Add(this.btContinue, 0, 1);
            this.tlpMain.Controls.Add(this.lbContext, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(13, 13);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMain.Size = new System.Drawing.Size(624, 125);
            this.tlpMain.TabIndex = 0;
            // 
            // btFromStart
            // 
            this.btFromStart.BackColor = System.Drawing.Color.Black;
            this.btFromStart.ButtonImage = global::vamp.Properties.Resources.previous;
            this.btFromStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btFromStart.ForeColor = System.Drawing.Color.Lime;
            this.btFromStart.Location = new System.Drawing.Point(375, 88);
            this.btFromStart.Margin = new System.Windows.Forms.Padding(1);
            this.btFromStart.Name = "btFromStart";
            this.btFromStart.Padding = new System.Windows.Forms.Padding(1);
            this.btFromStart.Size = new System.Drawing.Size(248, 36);
            this.btFromStart.TabIndex = 2;
            this.btFromStart.Tag = "";
            this.btFromStart.Text = "The beginning";
            this.btFromStart.Click += new System.EventHandler(this.GlobalClickHandler);
            // 
            // btContinue
            // 
            this.btContinue.BackColor = System.Drawing.Color.Black;
            this.btContinue.ButtonImage = global::vamp.Properties.Resources.wind_forward;
            this.btContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btContinue.ForeColor = System.Drawing.Color.Orange;
            this.btContinue.Location = new System.Drawing.Point(1, 88);
            this.btContinue.Margin = new System.Windows.Forms.Padding(1);
            this.btContinue.Name = "btContinue";
            this.btContinue.Padding = new System.Windows.Forms.Padding(1);
            this.btContinue.Size = new System.Drawing.Size(372, 36);
            this.btContinue.TabIndex = 1;
            this.btContinue.Tag = "Continue from {0}";
            this.btContinue.Text = "Continue from 00:00:00";
            this.btContinue.Click += new System.EventHandler(this.GlobalClickHandler);
            // 
            // lbContext
            // 
            this.lbContext.BackColor = System.Drawing.Color.Black;
            this.lbContext.ButtonImage = global::vamp.Properties.Resources.play;
            this.tlpMain.SetColumnSpan(this.lbContext, 2);
            this.lbContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbContext.ForeColor = System.Drawing.Color.White;
            this.lbContext.Label = true;
            this.lbContext.Location = new System.Drawing.Point(1, 1);
            this.lbContext.Margin = new System.Windows.Forms.Padding(1);
            this.lbContext.Name = "lbContext";
            this.lbContext.Padding = new System.Windows.Forms.Padding(1);
            this.lbContext.Size = new System.Drawing.Size(622, 85);
            this.lbContext.TabIndex = 3;
            this.lbContext.Text = "Playback...";
            // 
            // pnBorder
            // 
            this.pnBorder.BackColor = System.Drawing.Color.SteelBlue;
            this.pnBorder.Controls.Add(this.tlpMain);
            this.pnBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBorder.Location = new System.Drawing.Point(5, 5);
            this.pnBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pnBorder.Name = "pnBorder";
            this.pnBorder.Padding = new System.Windows.Forms.Padding(13);
            this.pnBorder.Size = new System.Drawing.Size(650, 151);
            this.pnBorder.TabIndex = 1;
            // 
            // SelectPlaybackPositionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(660, 161);
            this.Controls.Add(this.pnBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormDialogSelectPlaybackPosition";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDialogSelectPlaybackPosition";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectPlaybackPositionDialog_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.pnBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private VPKSoft.ImageButton.ImageButton btContinue;
        private VPKSoft.ImageButton.ImageButton btFromStart;
        private VPKSoft.ImageButton.ImageButton lbContext;
        private System.Windows.Forms.Panel pnBorder;
    }
}