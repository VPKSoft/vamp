namespace vamp
{
    partial class FormDialogSelectLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogSelectLocation));
            this.pnBorder = new System.Windows.Forms.Panel();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btCancel = new VPKSoft.ImageButton.ImageButton();
            this.btOK = new VPKSoft.ImageButton.ImageButton();
            this.lbSelectLocation = new VPKSoft.ImageButton.ImageButton();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbLocationDesc = new System.Windows.Forms.Label();
            this.vtbLocation = new VPKSoft.VisualTextBox.VisualTextBox();
            this.vtbLocationText = new VPKSoft.VisualTextBox.VisualTextBox();
            this.pnBorder.SuspendLayout();
            this.pnContainer.SuspendLayout();
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
            this.pnBorder.Size = new System.Drawing.Size(846, 326);
            this.pnBorder.TabIndex = 2;
            // 
            // pnContainer
            // 
            this.pnContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnContainer.BackColor = System.Drawing.Color.Black;
            this.pnContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnContainer.Location = new System.Drawing.Point(16, 16);
            this.pnContainer.Margin = new System.Windows.Forms.Padding(1);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Padding = new System.Windows.Forms.Padding(1);
            this.pnContainer.Size = new System.Drawing.Size(816, 296);
            this.pnContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btCancel, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btOK, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbSelectLocation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbLocation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbLocationDesc, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.vtbLocation, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.vtbLocationText, 2, 2);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 294);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Black;
            this.btCancel.ButtonImage = global::vamp.Properties.Resources.Cancel;
            this.tableLayoutPanel1.SetColumnSpan(this.btCancel, 2);
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Red;
            this.btCancel.Location = new System.Drawing.Point(487, 220);
            this.btCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(1);
            this.btCancel.Size = new System.Drawing.Size(326, 73);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Black;
            this.btOK.ButtonImage = global::vamp.Properties.Resources.OK;
            this.tableLayoutPanel1.SetColumnSpan(this.btOK, 2);
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btOK.Enabled = false;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(1, 220);
            this.btOK.Margin = new System.Windows.Forms.Padding(1);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(1);
            this.btOK.Size = new System.Drawing.Size(322, 73);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "OK";
            // 
            // lbSelectLocation
            // 
            this.lbSelectLocation.BackColor = System.Drawing.Color.Black;
            this.lbSelectLocation.ButtonImage = global::vamp.Properties.Resources.folder_media;
            this.tableLayoutPanel1.SetColumnSpan(this.lbSelectLocation, 5);
            this.lbSelectLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelectLocation.ForeColor = System.Drawing.Color.White;
            this.lbSelectLocation.Location = new System.Drawing.Point(1, 1);
            this.lbSelectLocation.Margin = new System.Windows.Forms.Padding(1);
            this.lbSelectLocation.Name = "lbSelectLocation";
            this.lbSelectLocation.Padding = new System.Windows.Forms.Padding(3);
            this.lbSelectLocation.Size = new System.Drawing.Size(812, 71);
            this.lbSelectLocation.TabIndex = 2;
            this.lbSelectLocation.Text = "Select location";
            // 
            // lbLocation
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbLocation, 2);
            this.lbLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocation.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lbLocation.Location = new System.Drawing.Point(0, 73);
            this.lbLocation.Margin = new System.Windows.Forms.Padding(0);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(324, 73);
            this.lbLocation.TabIndex = 3;
            this.lbLocation.Text = "Enter URL:";
            this.lbLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLocationDesc
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbLocationDesc, 2);
            this.lbLocationDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLocationDesc.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbLocationDesc.Location = new System.Drawing.Point(0, 146);
            this.lbLocationDesc.Margin = new System.Windows.Forms.Padding(0);
            this.lbLocationDesc.Name = "lbLocationDesc";
            this.lbLocationDesc.Size = new System.Drawing.Size(324, 73);
            this.lbLocationDesc.TabIndex = 4;
            this.lbLocationDesc.Text = "Enter description:";
            this.lbLocationDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vtbLocation
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.vtbLocation, 3);
            this.vtbLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vtbLocation.Location = new System.Drawing.Point(324, 73);
            this.vtbLocation.Margin = new System.Windows.Forms.Padding(0);
            this.vtbLocation.Name = "vtbLocation";
            this.vtbLocation.Size = new System.Drawing.Size(490, 73);
            this.vtbLocation.TabIndex = 5;
            this.vtbLocation.Text = "http://";
            this.vtbLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vtbLocation.TextChanged += new System.EventHandler(this.vtbLocation_TextChanged);
            // 
            // vtbLocationText
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.vtbLocationText, 3);
            this.vtbLocationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vtbLocationText.Location = new System.Drawing.Point(324, 146);
            this.vtbLocationText.Margin = new System.Windows.Forms.Padding(0);
            this.vtbLocationText.Name = "vtbLocationText";
            this.vtbLocationText.Size = new System.Drawing.Size(490, 73);
            this.vtbLocationText.TabIndex = 6;
            this.vtbLocationText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SelectLocationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(856, 336);
            this.Controls.Add(this.pnBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormDialogSelectLocation";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectLocationDialog_KeyDown);
            this.pnBorder.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBorder;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private VPKSoft.ImageButton.ImageButton btCancel;
        private VPKSoft.ImageButton.ImageButton btOK;
        private VPKSoft.ImageButton.ImageButton lbSelectLocation;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbLocationDesc;
        private VPKSoft.VisualTextBox.VisualTextBox vtbLocation;
        private VPKSoft.VisualTextBox.VisualTextBox vtbLocationText;
    }
}