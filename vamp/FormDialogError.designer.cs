namespace vamp
{
    partial class FormDialogError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogError));
            this.pnBorder = new System.Windows.Forms.Panel();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.pnContentContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btOK = new VPKSoft.ImageButton.ImageButton();
            this.lbDialogCaption = new VPKSoft.ImageButton.ImageButton();
            this.tbErrorDesc = new System.Windows.Forms.TextBox();
            this.pnBorder.SuspendLayout();
            this.pnContainer.SuspendLayout();
            this.pnContentContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.pnBorder.Size = new System.Drawing.Size(689, 279);
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
            this.pnContainer.Size = new System.Drawing.Size(659, 249);
            this.pnContainer.TabIndex = 0;
            // 
            // pnContentContainer
            // 
            this.pnContentContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContentContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContentContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnContentContainer.Name = "pnContentContainer";
            this.pnContentContainer.Padding = new System.Windows.Forms.Padding(1);
            this.pnContentContainer.Size = new System.Drawing.Size(659, 249);
            this.pnContentContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btOK, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbDialogCaption, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbErrorDesc, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 247);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Black;
            this.btOK.ButtonImage = global::vamp.Properties.Resources.OK;
            this.tableLayoutPanel1.SetColumnSpan(this.btOK, 3);
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btOK.Enabled = false;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(132, 184);
            this.btOK.Margin = new System.Windows.Forms.Padding(1);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(1);
            this.btOK.Size = new System.Drawing.Size(391, 62);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "OK";
            // 
            // lbDialogCaption
            // 
            this.lbDialogCaption.BackColor = System.Drawing.Color.Black;
            this.lbDialogCaption.ButtonImage = global::vamp.Properties.Resources.error;
            this.tableLayoutPanel1.SetColumnSpan(this.lbDialogCaption, 5);
            this.lbDialogCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDialogCaption.ForeColor = System.Drawing.Color.White;
            this.lbDialogCaption.Location = new System.Drawing.Point(1, 1);
            this.lbDialogCaption.Margin = new System.Windows.Forms.Padding(1);
            this.lbDialogCaption.Name = "lbDialogCaption";
            this.lbDialogCaption.Padding = new System.Windows.Forms.Padding(3);
            this.lbDialogCaption.Size = new System.Drawing.Size(655, 59);
            this.lbDialogCaption.TabIndex = 2;
            this.lbDialogCaption.Text = "**ERROR MESSAGE**";
            // 
            // tbErrorDesc
            // 
            this.tbErrorDesc.BackColor = System.Drawing.Color.Black;
            this.tbErrorDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.tbErrorDesc, 5);
            this.tbErrorDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbErrorDesc.ForeColor = System.Drawing.Color.Red;
            this.tbErrorDesc.Location = new System.Drawing.Point(0, 61);
            this.tbErrorDesc.Margin = new System.Windows.Forms.Padding(0);
            this.tbErrorDesc.Multiline = true;
            this.tbErrorDesc.Name = "tbErrorDesc";
            this.tbErrorDesc.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.tbErrorDesc, 2);
            this.tbErrorDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbErrorDesc.Size = new System.Drawing.Size(657, 122);
            this.tbErrorDesc.TabIndex = 9;
            this.tbErrorDesc.Text = "** DETAILED ERROR MESSAGE TEXT **\r\n** CAN BE MULTI-LINE **";
            // 
            // DialogError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(699, 289);
            this.Controls.Add(this.pnBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDialogError";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogEndPointError";
            this.pnBorder.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.pnContentContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBorder;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnContentContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private VPKSoft.ImageButton.ImageButton btOK;
        private VPKSoft.ImageButton.ImageButton lbDialogCaption;
        private System.Windows.Forms.TextBox tbErrorDesc;
    }
}