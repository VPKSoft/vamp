namespace vamp
{
    partial class FormDialogContextAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogContextAction));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btCancel = new VPKSoft.ImageButton.ImageButton();
            this.btOK = new VPKSoft.ImageButton.ImageButton();
            this.lbMarkAsWatched = new VPKSoft.ImageButton.ImageButton();
            this.pnBorder = new System.Windows.Forms.Panel();
            this.tlpMain.SuspendLayout();
            this.pnBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Black;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.Controls.Add(this.btCancel, 2, 1);
            this.tlpMain.Controls.Add(this.btOK, 0, 1);
            this.tlpMain.Controls.Add(this.lbMarkAsWatched, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(13, 13);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(586, 138);
            this.tlpMain.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Black;
            this.btCancel.ButtonImage = global::vamp.Properties.Resources.Cancel;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Red;
            this.btCancel.Location = new System.Drawing.Point(322, 70);
            this.btCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(1);
            this.btCancel.Size = new System.Drawing.Size(263, 67);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Black;
            this.btOK.ButtonImage = global::vamp.Properties.Resources.OK;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(1, 70);
            this.btOK.Margin = new System.Windows.Forms.Padding(1);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(1);
            this.btOK.Size = new System.Drawing.Size(261, 67);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "OK";
            // 
            // lbMarkAsWatched
            // 
            this.lbMarkAsWatched.BackColor = System.Drawing.Color.Black;
            this.lbMarkAsWatched.ButtonImage = global::vamp.Properties.Resources.tick;
            this.tlpMain.SetColumnSpan(this.lbMarkAsWatched, 3);
            this.lbMarkAsWatched.ForeColor = System.Drawing.Color.White;
            this.lbMarkAsWatched.Label = true;
            this.lbMarkAsWatched.Location = new System.Drawing.Point(1, 1);
            this.lbMarkAsWatched.Margin = new System.Windows.Forms.Padding(1);
            this.lbMarkAsWatched.Name = "lbMarkAsWatched";
            this.lbMarkAsWatched.Padding = new System.Windows.Forms.Padding(1);
            this.lbMarkAsWatched.Size = new System.Drawing.Size(584, 67);
            this.lbMarkAsWatched.TabIndex = 4;
            this.lbMarkAsWatched.Text = "Mark as watched?";
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
            this.pnBorder.Size = new System.Drawing.Size(612, 164);
            this.pnBorder.TabIndex = 2;
            // 
            // ContextActionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(622, 174);
            this.Controls.Add(this.pnBorder);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ContextActionDialog";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarkAsWatchedDialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContextActionDialog_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.pnBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private VPKSoft.ImageButton.ImageButton lbMarkAsWatched;
        private VPKSoft.ImageButton.ImageButton btOK;
        private VPKSoft.ImageButton.ImageButton btCancel;
        private System.Windows.Forms.Panel pnBorder;
    }
}