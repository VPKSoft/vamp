namespace vamp
{
    partial class FormViewPDF
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
            this.pnMain = new System.Windows.Forms.Panel();
            this.tlpPopDown = new System.Windows.Forms.TableLayoutPanel();
            this.pnButtons = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Panel();
            this.tlpPopDown.SuspendLayout();
            this.pnButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMain.Location = new System.Drawing.Point(12, 12);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(836, 524);
            this.pnMain.TabIndex = 1;
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
            this.tlpPopDown.Controls.Add(this.pnButtons, 0, 1);
            this.tlpPopDown.Location = new System.Drawing.Point(0, 393);
            this.tlpPopDown.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPopDown.Name = "tlpPopDown";
            this.tlpPopDown.RowCount = 3;
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPopDown.Size = new System.Drawing.Size(860, 167);
            this.tlpPopDown.TabIndex = 4;
            // 
            // pnButtons
            // 
            this.pnButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPopDown.SetColumnSpan(this.pnButtons, 5);
            this.pnButtons.Controls.Add(this.btnExit);
            this.pnButtons.Location = new System.Drawing.Point(0, 38);
            this.pnButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnButtons.Name = "pnButtons";
            this.pnButtons.Size = new System.Drawing.Size(860, 105);
            this.pnButtons.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::vamp.Properties.Resources.Cancel;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(860, 105);
            this.btnExit.TabIndex = 24;
            this.btnExit.Tag = "3";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormViewPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.tlpPopDown);
            this.Controls.Add(this.pnMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormViewPDF";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormViewPDF_FormClosing);
            this.Shown += new System.EventHandler(this.FormViewPDF_Shown);
            this.tlpPopDown.ResumeLayout(false);
            this.pnButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.TableLayoutPanel tlpPopDown;
        private System.Windows.Forms.Panel pnButtons;
        private System.Windows.Forms.Panel btnExit;
    }
}

