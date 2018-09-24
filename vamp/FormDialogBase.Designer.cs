namespace vamp
{
    partial class FormDialogBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogBase));
            this.pnBorder = new System.Windows.Forms.Panel();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.pnContentContainer = new System.Windows.Forms.Panel();
            this.pnBorder.SuspendLayout();
            this.pnContainer.SuspendLayout();
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
            this.pnBorder.Size = new System.Drawing.Size(475, 258);
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
            this.pnContainer.Size = new System.Drawing.Size(445, 228);
            this.pnContainer.TabIndex = 0;
            // 
            // pnContentContainer
            // 
            this.pnContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContentContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContentContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnContentContainer.Name = "pnContentContainer";
            this.pnContentContainer.Padding = new System.Windows.Forms.Padding(1);
            this.pnContentContainer.Size = new System.Drawing.Size(445, 228);
            this.pnContentContainer.TabIndex = 0;
            // 
            // DialogBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(485, 268);
            this.Controls.Add(this.pnBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogBaseForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogBaseForm";
            this.pnBorder.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBorder;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnContentContainer;
    }
}