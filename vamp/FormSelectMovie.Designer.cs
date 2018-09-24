namespace vamp
{
    partial class FormSelectMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectMovie));
            this.videoBrowser = new VPKSoft.VideoBrowser.VideoBrowser();
            this.SuspendLayout();
            // 
            // videoBrowser
            // 
            this.videoBrowser.BackColor = System.Drawing.Color.DimGray;
            this.videoBrowser.Context = "";
            this.videoBrowser.DeleteButtonVisible = false;
            this.videoBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoBrowser.FontLarge = new System.Drawing.Font("Microsoft Sans Serif", 31.5F);
            this.videoBrowser.FontMedium = new System.Drawing.Font("Microsoft Sans Serif", 23.625F);
            this.videoBrowser.FontSmall = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoBrowser.ImageAddButton = ((System.Drawing.Image)(resources.GetObject("videoBrowser.ImageAddButton")));
            this.videoBrowser.ImageCloseButton = ((System.Drawing.Image)(resources.GetObject("videoBrowser.ImageCloseButton")));
            this.videoBrowser.ImageDeleteButton = ((System.Drawing.Image)(resources.GetObject("videoBrowser.ImageDeleteButton")));
            this.videoBrowser.ImageNextButton = ((System.Drawing.Image)(resources.GetObject("videoBrowser.ImageNextButton")));
            this.videoBrowser.ImagePreviousButton = ((System.Drawing.Image)(resources.GetObject("videoBrowser.ImagePreviousButton")));
            this.videoBrowser.Location = new System.Drawing.Point(0, 0);
            this.videoBrowser.Name = "videoBrowser";
            this.videoBrowser.Size = new System.Drawing.Size(1117, 626);
            this.videoBrowser.TabIndex = 0;
            this.videoBrowser.VideoDetailIndex = -1;
            this.videoBrowser.VideoIndex = -1;
            this.videoBrowser.PlaybackRequested += new VPKSoft.VideoBrowser.VideoBrowser.OnPlaybackRequested(this.videoBrowser_PlaybackRequested);
            // 
            // FormSelectMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 626);
            this.Controls.Add(this.videoBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectMovie";
            this.ShowInTaskbar = false;
            this.Text = "SelectMovieForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private VPKSoft.VideoBrowser.VideoBrowser videoBrowser;
    }
}