namespace vamp
{
    partial class FormTMDBLoadProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTMDBLoadProgress));
            this.pnBorder = new System.Windows.Forms.Panel();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.pnContentContainer = new System.Windows.Forms.Panel();
            this.tlpContentContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lbPercentage = new System.Windows.Forms.Label();
            this.btLoading = new VPKSoft.ImageButton.ImageButton();
            this.pnBorder.SuspendLayout();
            this.pnContainer.SuspendLayout();
            this.pnContentContainer.SuspendLayout();
            this.tlpContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBorder
            // 
            this.pnBorder.BackColor = System.Drawing.Color.SteelBlue;
            this.pnBorder.Controls.Add(this.pnContainer);
            this.pnBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBorder.Location = new System.Drawing.Point(5, 5);
            this.pnBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pnBorder.Name = "pnBorder";
            this.pnBorder.Padding = new System.Windows.Forms.Padding(13);
            this.pnBorder.Size = new System.Drawing.Size(734, 275);
            this.pnBorder.TabIndex = 2;
            // 
            // pnContainer
            // 
            this.pnContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnContainer.BackColor = System.Drawing.Color.Black;
            this.pnContainer.Controls.Add(this.pnContentContainer);
            this.pnContainer.Location = new System.Drawing.Point(16, 16);
            this.pnContainer.Margin = new System.Windows.Forms.Padding(1);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(704, 245);
            this.pnContainer.TabIndex = 0;
            // 
            // pnContentContainer
            // 
            this.pnContentContainer.Controls.Add(this.tlpContentContainer);
            this.pnContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContentContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContentContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnContentContainer.Name = "pnContentContainer";
            this.pnContentContainer.Padding = new System.Windows.Forms.Padding(1);
            this.pnContentContainer.Size = new System.Drawing.Size(704, 245);
            this.pnContentContainer.TabIndex = 0;
            // 
            // tlpContentContainer
            // 
            this.tlpContentContainer.ColumnCount = 5;
            this.tlpContentContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContentContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpContentContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpContentContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpContentContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpContentContainer.Controls.Add(this.lbPercentage, 2, 1);
            this.tlpContentContainer.Controls.Add(this.btLoading, 1, 0);
            this.tlpContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContentContainer.Location = new System.Drawing.Point(1, 1);
            this.tlpContentContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpContentContainer.Name = "tlpContentContainer";
            this.tlpContentContainer.RowCount = 2;
            this.tlpContentContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContentContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContentContainer.Size = new System.Drawing.Size(702, 243);
            this.tlpContentContainer.TabIndex = 0;
            // 
            // lbPercentage
            // 
            this.lbPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPercentage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPercentage.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbPercentage.Location = new System.Drawing.Point(242, 121);
            this.lbPercentage.Name = "lbPercentage";
            this.lbPercentage.Size = new System.Drawing.Size(214, 122);
            this.lbPercentage.TabIndex = 12;
            this.lbPercentage.Text = "0 %";
            this.lbPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btLoading
            // 
            this.btLoading.BackColor = System.Drawing.Color.Black;
            this.btLoading.ButtonImage = global::vamp.Properties.Resources.tmdb_primary_light_green;
            this.tlpContentContainer.SetColumnSpan(this.btLoading, 3);
            this.btLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btLoading.ForeColor = System.Drawing.Color.White;
            this.btLoading.Location = new System.Drawing.Point(21, 1);
            this.btLoading.Margin = new System.Windows.Forms.Padding(1);
            this.btLoading.Name = "btLoading";
            this.btLoading.Padding = new System.Windows.Forms.Padding(1);
            this.btLoading.Size = new System.Drawing.Size(657, 119);
            this.btLoading.TabIndex = 0;
            this.btLoading.Text = "loading...";
            // 
            // FormTMDBLoadProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(744, 285);
            this.Controls.Add(this.pnBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTMDBLoadProgress";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogBaseForm";
            this.TopMost = true;
            this.pnBorder.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.pnContentContainer.ResumeLayout(false);
            this.tlpContentContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBorder;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnContentContainer;
        private System.Windows.Forms.TableLayoutPanel tlpContentContainer;
        private VPKSoft.ImageButton.ImageButton btLoading;
        private System.Windows.Forms.Label lbPercentage;
    }
}