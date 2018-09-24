namespace vamp
{
    partial class FormDialogSelectCustomContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogSelectCustomContent));
            this.pnBorder = new System.Windows.Forms.Panel();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.pnContentContainer = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btOK = new VPKSoft.ImageButton.ImageButton();
            this.btCancel = new VPKSoft.ImageButton.ImageButton();
            this.lbCaption = new System.Windows.Forms.Label();
            this.lbCustomContent = new VPKSoft.VisualListBox.VisualListBox();
            this.pnBorder.SuspendLayout();
            this.pnContainer.SuspendLayout();
            this.pnContentContainer.SuspendLayout();
            this.tlpMain.SuspendLayout();
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
            this.pnBorder.Size = new System.Drawing.Size(661, 633);
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
            this.pnContainer.Size = new System.Drawing.Size(631, 603);
            this.pnContainer.TabIndex = 0;
            // 
            // pnContentContainer
            // 
            this.pnContentContainer.Controls.Add(this.tlpMain);
            this.pnContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContentContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContentContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnContentContainer.Name = "pnContentContainer";
            this.pnContentContainer.Padding = new System.Windows.Forms.Padding(1);
            this.pnContentContainer.Size = new System.Drawing.Size(631, 603);
            this.pnContentContainer.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Black;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Controls.Add(this.lbCaption, 0, 0);
            this.tlpMain.Controls.Add(this.lbCustomContent, 0, 1);
            this.tlpMain.Controls.Add(this.btOK, 0, 2);
            this.tlpMain.Controls.Add(this.btCancel, 2, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 1);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.Size = new System.Drawing.Size(629, 601);
            this.tlpMain.TabIndex = 2;
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Black;
            this.btOK.ButtonImage = global::vamp.Properties.Resources.OK;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(1, 541);
            this.btOK.Margin = new System.Windows.Forms.Padding(1);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(1);
            this.btOK.Size = new System.Drawing.Size(249, 59);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Black;
            this.btCancel.ButtonImage = global::vamp.Properties.Resources.Cancel;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Red;
            this.btCancel.Location = new System.Drawing.Point(377, 541);
            this.btCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(1);
            this.btCancel.Size = new System.Drawing.Size(251, 59);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            // 
            // lbCaption
            // 
            this.tlpMain.SetColumnSpan(this.lbCaption, 3);
            this.lbCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaption.ForeColor = System.Drawing.Color.White;
            this.lbCaption.Location = new System.Drawing.Point(3, 0);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(623, 60);
            this.lbCaption.TabIndex = 8;
            this.lbCaption.Text = "/* OPTIONAL CAPTION GOES HERE */";
            this.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCustomContent
            // 
            this.lbCustomContent.BackColor = System.Drawing.Color.Black;
            this.lbCustomContent.BackColorAlternative = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.tlpMain.SetColumnSpan(this.lbCustomContent, 3);
            this.lbCustomContent.DisplayMember = "";
            this.lbCustomContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCustomContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomContent.ForeColor = System.Drawing.Color.White;
            this.lbCustomContent.ForeColorAlternative = System.Drawing.Color.Gainsboro;
            this.lbCustomContent.Items.AddRange(new object[] {
            "testing 0...",
            "testing 1...",
            "testing 2...",
            "testing 3...",
            "testing 4...",
            "testing 5...",
            "testing 6...",
            "testing 7...",
            "testing 8...",
            "testing 9..."});
            this.lbCustomContent.Location = new System.Drawing.Point(0, 65);
            this.lbCustomContent.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.lbCustomContent.Name = "lbCustomContent";
            this.lbCustomContent.SelectedIndex = -1;
            this.lbCustomContent.SelectedItem = null;
            this.lbCustomContent.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.lbCustomContent.SelectionColorAlternative = System.Drawing.SystemColors.Highlight;
            this.lbCustomContent.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.lbCustomContent.Size = new System.Drawing.Size(624, 475);
            this.lbCustomContent.TabIndex = 7;
            this.lbCustomContent.ValueMember = "";
            // 
            // SelectCustomContentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(671, 643);
            this.Controls.Add(this.pnBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormDialogSelectCustomContent";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDialogSelectCustomContent";
            this.Shown += new System.EventHandler(this.SelectCustomContentDialog_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectCustomContentDialog_KeyDown);
            this.pnBorder.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.pnContentContainer.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBorder;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnContentContainer;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private VPKSoft.ImageButton.ImageButton btOK;
        private VPKSoft.ImageButton.ImageButton btCancel;
        private VPKSoft.VisualListBox.VisualListBox lbCustomContent;
        private System.Windows.Forms.Label lbCaption;
    }
}