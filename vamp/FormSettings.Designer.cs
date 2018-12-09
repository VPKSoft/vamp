namespace vamp
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lbSelectLanguageDescription = new System.Windows.Forms.Label();
            this.cbUseFileNameForTVShowEpisodeNamingValue = new System.Windows.Forms.CheckBox();
            this.lbUseFileNameForTVShowEpisodeNamingDescription = new System.Windows.Forms.Label();
            this.btSelectTMDbImagesCacheDir = new System.Windows.Forms.Button();
            this.tbTMDbImagesCacheDirValue = new System.Windows.Forms.TextBox();
            this.lbTMDbImagesCacheDirDescription = new System.Windows.Forms.Label();
            this.cdTMDbEnabledValue = new System.Windows.Forms.CheckBox();
            this.lbTMDbEnabledDescription = new System.Windows.Forms.Label();
            this.cbCacheTMDbImagesIntoMemoryValue = new System.Windows.Forms.CheckBox();
            this.lbCacheTMDbImagesIntoMemoryDescription = new System.Windows.Forms.Label();
            this.lbCacheDatabaseIntoMemoryDescription = new System.Windows.Forms.Label();
            this.tbBaseDirPhotosValue = new System.Windows.Forms.TextBox();
            this.lbBaseDirPhotosDescription = new System.Windows.Forms.Label();
            this.tbBaseDirTVShowsValue = new System.Windows.Forms.TextBox();
            this.lbBaseDirTVShowsDescription = new System.Windows.Forms.Label();
            this.tbBaseDirMoviesValue = new System.Windows.Forms.TextBox();
            this.lbBaseDirMoviesDescription = new System.Windows.Forms.Label();
            this.lbAmpRemoteDescription = new System.Windows.Forms.Label();
            this.tbAmpRemoteValue = new System.Windows.Forms.TextBox();
            this.cbCacheDatabaseIntoMemoryValue = new System.Windows.Forms.CheckBox();
            this.btSelectMovieFolder = new System.Windows.Forms.Button();
            this.btSelectTVShowFolder = new System.Windows.Forms.Button();
            this.btSelectPhotoFolder = new System.Windows.Forms.Button();
            this.btOK = new VPKSoft.ImageButton.ImageButton();
            this.btCancel = new VPKSoft.ImageButton.ImageButton();
            this.cmbSelectLanguageValue = new System.Windows.Forms.ComboBox();
            this.lbAutoDatabaseUpdateDescription = new System.Windows.Forms.Label();
            this.cbAutoDatabaseUpdateValue = new System.Windows.Forms.CheckBox();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.cbAutoDatabaseUpdateValue, 1, 10);
            this.tlpMain.Controls.Add(this.lbAutoDatabaseUpdateDescription, 0, 10);
            this.tlpMain.Controls.Add(this.lbSelectLanguageDescription, 0, 9);
            this.tlpMain.Controls.Add(this.cbUseFileNameForTVShowEpisodeNamingValue, 1, 8);
            this.tlpMain.Controls.Add(this.lbUseFileNameForTVShowEpisodeNamingDescription, 0, 8);
            this.tlpMain.Controls.Add(this.btSelectTMDbImagesCacheDir, 2, 7);
            this.tlpMain.Controls.Add(this.tbTMDbImagesCacheDirValue, 1, 7);
            this.tlpMain.Controls.Add(this.lbTMDbImagesCacheDirDescription, 0, 7);
            this.tlpMain.Controls.Add(this.cdTMDbEnabledValue, 1, 6);
            this.tlpMain.Controls.Add(this.lbTMDbEnabledDescription, 0, 6);
            this.tlpMain.Controls.Add(this.cbCacheTMDbImagesIntoMemoryValue, 1, 5);
            this.tlpMain.Controls.Add(this.lbCacheTMDbImagesIntoMemoryDescription, 0, 5);
            this.tlpMain.Controls.Add(this.lbCacheDatabaseIntoMemoryDescription, 0, 4);
            this.tlpMain.Controls.Add(this.tbBaseDirPhotosValue, 1, 3);
            this.tlpMain.Controls.Add(this.lbBaseDirPhotosDescription, 0, 3);
            this.tlpMain.Controls.Add(this.tbBaseDirTVShowsValue, 1, 2);
            this.tlpMain.Controls.Add(this.lbBaseDirTVShowsDescription, 0, 2);
            this.tlpMain.Controls.Add(this.tbBaseDirMoviesValue, 1, 1);
            this.tlpMain.Controls.Add(this.lbBaseDirMoviesDescription, 0, 1);
            this.tlpMain.Controls.Add(this.lbAmpRemoteDescription, 0, 0);
            this.tlpMain.Controls.Add(this.tbAmpRemoteValue, 1, 0);
            this.tlpMain.Controls.Add(this.cbCacheDatabaseIntoMemoryValue, 1, 4);
            this.tlpMain.Controls.Add(this.btSelectMovieFolder, 2, 1);
            this.tlpMain.Controls.Add(this.btSelectTVShowFolder, 2, 2);
            this.tlpMain.Controls.Add(this.btSelectPhotoFolder, 2, 3);
            this.tlpMain.Controls.Add(this.btOK, 0, 12);
            this.tlpMain.Controls.Add(this.btCancel, 1, 12);
            this.tlpMain.Controls.Add(this.cmbSelectLanguageValue, 1, 9);
            this.tlpMain.Location = new System.Drawing.Point(16, 15);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 13;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(1316, 755);
            this.tlpMain.TabIndex = 0;
            // 
            // lbSelectLanguageDescription
            // 
            this.lbSelectLanguageDescription.AutoSize = true;
            this.lbSelectLanguageDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectLanguageDescription.Location = new System.Drawing.Point(17, 510);
            this.lbSelectLanguageDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbSelectLanguageDescription.Name = "lbSelectLanguageDescription";
            this.lbSelectLanguageDescription.Size = new System.Drawing.Size(353, 25);
            this.lbSelectLanguageDescription.TabIndex = 24;
            this.lbSelectLanguageDescription.Text = "Language (a restart is required):";
            this.lbSelectLanguageDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbUseFileNameForTVShowEpisodeNamingValue
            // 
            this.cbUseFileNameForTVShowEpisodeNamingValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUseFileNameForTVShowEpisodeNamingValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.cbUseFileNameForTVShowEpisodeNamingValue.Location = new System.Drawing.Point(620, 455);
            this.cbUseFileNameForTVShowEpisodeNamingValue.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.cbUseFileNameForTVShowEpisodeNamingValue.Name = "cbUseFileNameForTVShowEpisodeNamingValue";
            this.cbUseFileNameForTVShowEpisodeNamingValue.Size = new System.Drawing.Size(578, 25);
            this.cbUseFileNameForTVShowEpisodeNamingValue.TabIndex = 23;
            this.cbUseFileNameForTVShowEpisodeNamingValue.UseVisualStyleBackColor = true;
            // 
            // lbUseFileNameForTVShowEpisodeNamingDescription
            // 
            this.lbUseFileNameForTVShowEpisodeNamingDescription.AutoSize = true;
            this.lbUseFileNameForTVShowEpisodeNamingDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUseFileNameForTVShowEpisodeNamingDescription.Location = new System.Drawing.Point(17, 455);
            this.lbUseFileNameForTVShowEpisodeNamingDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbUseFileNameForTVShowEpisodeNamingDescription.Name = "lbUseFileNameForTVShowEpisodeNamingDescription";
            this.lbUseFileNameForTVShowEpisodeNamingDescription.Size = new System.Drawing.Size(468, 25);
            this.lbUseFileNameForTVShowEpisodeNamingDescription.TabIndex = 22;
            this.lbUseFileNameForTVShowEpisodeNamingDescription.Text = "Use file name for TV show episode naming:";
            this.lbUseFileNameForTVShowEpisodeNamingDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSelectTMDbImagesCacheDir
            // 
            this.btSelectTMDbImagesCacheDir.Location = new System.Drawing.Point(1228, 397);
            this.btSelectTMDbImagesCacheDir.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btSelectTMDbImagesCacheDir.Name = "btSelectTMDbImagesCacheDir";
            this.btSelectTMDbImagesCacheDir.Size = new System.Drawing.Size(75, 31);
            this.btSelectTMDbImagesCacheDir.TabIndex = 21;
            this.btSelectTMDbImagesCacheDir.Text = "...";
            this.btSelectTMDbImagesCacheDir.UseVisualStyleBackColor = true;
            this.btSelectTMDbImagesCacheDir.Click += new System.EventHandler(this.selectFolderClick);
            // 
            // tbTMDbImagesCacheDirValue
            // 
            this.tbTMDbImagesCacheDirValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTMDbImagesCacheDirValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTMDbImagesCacheDirValue.Location = new System.Drawing.Point(616, 397);
            this.tbTMDbImagesCacheDirValue.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tbTMDbImagesCacheDirValue.Name = "tbTMDbImagesCacheDirValue";
            this.tbTMDbImagesCacheDirValue.Size = new System.Drawing.Size(586, 31);
            this.tbTMDbImagesCacheDirValue.TabIndex = 20;
            this.tbTMDbImagesCacheDirValue.Text = "-";
            // 
            // lbTMDbImagesCacheDirDescription
            // 
            this.lbTMDbImagesCacheDirDescription.AutoSize = true;
            this.lbTMDbImagesCacheDirDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTMDbImagesCacheDirDescription.Location = new System.Drawing.Point(17, 400);
            this.lbTMDbImagesCacheDirDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbTMDbImagesCacheDirDescription.Name = "lbTMDbImagesCacheDirDescription";
            this.lbTMDbImagesCacheDirDescription.Size = new System.Drawing.Size(511, 25);
            this.lbTMDbImagesCacheDirDescription.TabIndex = 19;
            this.lbTMDbImagesCacheDirDescription.Text = "TMDb poster/still image file system cache path:";
            this.lbTMDbImagesCacheDirDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdTMDbEnabledValue
            // 
            this.cdTMDbEnabledValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdTMDbEnabledValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.cdTMDbEnabledValue.Location = new System.Drawing.Point(620, 345);
            this.cdTMDbEnabledValue.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.cdTMDbEnabledValue.Name = "cdTMDbEnabledValue";
            this.cdTMDbEnabledValue.Size = new System.Drawing.Size(578, 25);
            this.cdTMDbEnabledValue.TabIndex = 13;
            this.cdTMDbEnabledValue.UseVisualStyleBackColor = true;
            // 
            // lbTMDbEnabledDescription
            // 
            this.lbTMDbEnabledDescription.AutoSize = true;
            this.lbTMDbEnabledDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTMDbEnabledDescription.Location = new System.Drawing.Point(17, 345);
            this.lbTMDbEnabledDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbTMDbEnabledDescription.Name = "lbTMDbEnabledDescription";
            this.lbTMDbEnabledDescription.Size = new System.Drawing.Size(412, 25);
            this.lbTMDbEnabledDescription.TabIndex = 12;
            this.lbTMDbEnabledDescription.Text = "TMDb (The Movie Database) enabled:";
            this.lbTMDbEnabledDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCacheTMDbImagesIntoMemoryValue
            // 
            this.cbCacheTMDbImagesIntoMemoryValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCacheTMDbImagesIntoMemoryValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.cbCacheTMDbImagesIntoMemoryValue.Location = new System.Drawing.Point(620, 290);
            this.cbCacheTMDbImagesIntoMemoryValue.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.cbCacheTMDbImagesIntoMemoryValue.Name = "cbCacheTMDbImagesIntoMemoryValue";
            this.cbCacheTMDbImagesIntoMemoryValue.Size = new System.Drawing.Size(578, 25);
            this.cbCacheTMDbImagesIntoMemoryValue.TabIndex = 11;
            this.cbCacheTMDbImagesIntoMemoryValue.UseVisualStyleBackColor = true;
            // 
            // lbCacheTMDbImagesIntoMemoryDescription
            // 
            this.lbCacheTMDbImagesIntoMemoryDescription.AutoSize = true;
            this.lbCacheTMDbImagesIntoMemoryDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCacheTMDbImagesIntoMemoryDescription.Location = new System.Drawing.Point(17, 290);
            this.lbCacheTMDbImagesIntoMemoryDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbCacheTMDbImagesIntoMemoryDescription.Name = "lbCacheTMDbImagesIntoMemoryDescription";
            this.lbCacheTMDbImagesIntoMemoryDescription.Size = new System.Drawing.Size(569, 25);
            this.lbCacheTMDbImagesIntoMemoryDescription.TabIndex = 10;
            this.lbCacheTMDbImagesIntoMemoryDescription.Text = "Cache the TMDb poster/still images into the memory:";
            this.lbCacheTMDbImagesIntoMemoryDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCacheDatabaseIntoMemoryDescription
            // 
            this.lbCacheDatabaseIntoMemoryDescription.AutoSize = true;
            this.lbCacheDatabaseIntoMemoryDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCacheDatabaseIntoMemoryDescription.Location = new System.Drawing.Point(17, 235);
            this.lbCacheDatabaseIntoMemoryDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbCacheDatabaseIntoMemoryDescription.Name = "lbCacheDatabaseIntoMemoryDescription";
            this.lbCacheDatabaseIntoMemoryDescription.Size = new System.Drawing.Size(405, 25);
            this.lbCacheDatabaseIntoMemoryDescription.TabIndex = 8;
            this.lbCacheDatabaseIntoMemoryDescription.Text = "Cache the database into the memory:";
            this.lbCacheDatabaseIntoMemoryDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBaseDirPhotosValue
            // 
            this.tbBaseDirPhotosValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBaseDirPhotosValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBaseDirPhotosValue.Location = new System.Drawing.Point(616, 177);
            this.tbBaseDirPhotosValue.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tbBaseDirPhotosValue.Name = "tbBaseDirPhotosValue";
            this.tbBaseDirPhotosValue.Size = new System.Drawing.Size(586, 31);
            this.tbBaseDirPhotosValue.TabIndex = 7;
            this.tbBaseDirPhotosValue.Text = "-";
            // 
            // lbBaseDirPhotosDescription
            // 
            this.lbBaseDirPhotosDescription.AutoSize = true;
            this.lbBaseDirPhotosDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBaseDirPhotosDescription.Location = new System.Drawing.Point(17, 180);
            this.lbBaseDirPhotosDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbBaseDirPhotosDescription.Name = "lbBaseDirPhotosDescription";
            this.lbBaseDirPhotosDescription.Size = new System.Drawing.Size(405, 25);
            this.lbBaseDirPhotosDescription.TabIndex = 6;
            this.lbBaseDirPhotosDescription.Text = "Base dicrectory for image/photo files:";
            this.lbBaseDirPhotosDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBaseDirTVShowsValue
            // 
            this.tbBaseDirTVShowsValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBaseDirTVShowsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBaseDirTVShowsValue.Location = new System.Drawing.Point(616, 122);
            this.tbBaseDirTVShowsValue.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tbBaseDirTVShowsValue.Name = "tbBaseDirTVShowsValue";
            this.tbBaseDirTVShowsValue.Size = new System.Drawing.Size(586, 31);
            this.tbBaseDirTVShowsValue.TabIndex = 5;
            this.tbBaseDirTVShowsValue.Text = "-";
            // 
            // lbBaseDirTVShowsDescription
            // 
            this.lbBaseDirTVShowsDescription.AutoSize = true;
            this.lbBaseDirTVShowsDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBaseDirTVShowsDescription.Location = new System.Drawing.Point(17, 125);
            this.lbBaseDirTVShowsDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbBaseDirTVShowsDescription.Name = "lbBaseDirTVShowsDescription";
            this.lbBaseDirTVShowsDescription.Size = new System.Drawing.Size(437, 25);
            this.lbBaseDirTVShowsDescription.TabIndex = 4;
            this.lbBaseDirTVShowsDescription.Text = "Base dicrectory for TV show series files:";
            this.lbBaseDirTVShowsDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBaseDirMoviesValue
            // 
            this.tbBaseDirMoviesValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBaseDirMoviesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBaseDirMoviesValue.Location = new System.Drawing.Point(616, 67);
            this.tbBaseDirMoviesValue.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tbBaseDirMoviesValue.Name = "tbBaseDirMoviesValue";
            this.tbBaseDirMoviesValue.Size = new System.Drawing.Size(586, 31);
            this.tbBaseDirMoviesValue.TabIndex = 3;
            this.tbBaseDirMoviesValue.Text = "-";
            // 
            // lbBaseDirMoviesDescription
            // 
            this.lbBaseDirMoviesDescription.AutoSize = true;
            this.lbBaseDirMoviesDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBaseDirMoviesDescription.Location = new System.Drawing.Point(17, 70);
            this.lbBaseDirMoviesDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbBaseDirMoviesDescription.Name = "lbBaseDirMoviesDescription";
            this.lbBaseDirMoviesDescription.Size = new System.Drawing.Size(338, 25);
            this.lbBaseDirMoviesDescription.TabIndex = 2;
            this.lbBaseDirMoviesDescription.Text = "Base dicrectory for movie files:";
            this.lbBaseDirMoviesDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbAmpRemoteDescription
            // 
            this.lbAmpRemoteDescription.AutoSize = true;
            this.lbAmpRemoteDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmpRemoteDescription.Location = new System.Drawing.Point(17, 15);
            this.lbAmpRemoteDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbAmpRemoteDescription.Name = "lbAmpRemoteDescription";
            this.lbAmpRemoteDescription.Size = new System.Drawing.Size(436, 25);
            this.lbAmpRemoteDescription.TabIndex = 0;
            this.lbAmpRemoteDescription.Text = "amp# remote control API (Music Player):";
            this.lbAmpRemoteDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAmpRemoteValue
            // 
            this.tbAmpRemoteValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAmpRemoteValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmpRemoteValue.Location = new System.Drawing.Point(616, 12);
            this.tbAmpRemoteValue.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tbAmpRemoteValue.Name = "tbAmpRemoteValue";
            this.tbAmpRemoteValue.Size = new System.Drawing.Size(586, 31);
            this.tbAmpRemoteValue.TabIndex = 1;
            this.tbAmpRemoteValue.Text = "-";
            // 
            // cbCacheDatabaseIntoMemoryValue
            // 
            this.cbCacheDatabaseIntoMemoryValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCacheDatabaseIntoMemoryValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.cbCacheDatabaseIntoMemoryValue.Location = new System.Drawing.Point(620, 235);
            this.cbCacheDatabaseIntoMemoryValue.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.cbCacheDatabaseIntoMemoryValue.Name = "cbCacheDatabaseIntoMemoryValue";
            this.cbCacheDatabaseIntoMemoryValue.Size = new System.Drawing.Size(578, 25);
            this.cbCacheDatabaseIntoMemoryValue.TabIndex = 9;
            this.cbCacheDatabaseIntoMemoryValue.UseVisualStyleBackColor = true;
            // 
            // btSelectMovieFolder
            // 
            this.btSelectMovieFolder.Location = new System.Drawing.Point(1228, 67);
            this.btSelectMovieFolder.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btSelectMovieFolder.Name = "btSelectMovieFolder";
            this.btSelectMovieFolder.Size = new System.Drawing.Size(75, 31);
            this.btSelectMovieFolder.TabIndex = 14;
            this.btSelectMovieFolder.Text = "...";
            this.btSelectMovieFolder.UseVisualStyleBackColor = true;
            this.btSelectMovieFolder.Click += new System.EventHandler(this.selectFolderClick);
            // 
            // btSelectTVShowFolder
            // 
            this.btSelectTVShowFolder.Location = new System.Drawing.Point(1228, 122);
            this.btSelectTVShowFolder.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btSelectTVShowFolder.Name = "btSelectTVShowFolder";
            this.btSelectTVShowFolder.Size = new System.Drawing.Size(75, 31);
            this.btSelectTVShowFolder.TabIndex = 15;
            this.btSelectTVShowFolder.Text = "...";
            this.btSelectTVShowFolder.UseVisualStyleBackColor = true;
            this.btSelectTVShowFolder.Click += new System.EventHandler(this.selectFolderClick);
            // 
            // btSelectPhotoFolder
            // 
            this.btSelectPhotoFolder.Location = new System.Drawing.Point(1228, 177);
            this.btSelectPhotoFolder.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btSelectPhotoFolder.Name = "btSelectPhotoFolder";
            this.btSelectPhotoFolder.Size = new System.Drawing.Size(75, 31);
            this.btSelectPhotoFolder.TabIndex = 16;
            this.btSelectPhotoFolder.Text = "...";
            this.btSelectPhotoFolder.UseVisualStyleBackColor = true;
            this.btSelectPhotoFolder.Click += new System.EventHandler(this.selectFolderClick);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.SystemColors.Control;
            this.btOK.ButtonImage = global::vamp.Properties.Resources.OK;
            this.btOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btOK.Location = new System.Drawing.Point(2, 661);
            this.btOK.Margin = new System.Windows.Forms.Padding(2);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(2);
            this.btOK.Size = new System.Drawing.Size(500, 92);
            this.btOK.TabIndex = 17;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.ButtonImage = global::vamp.Properties.Resources.Cancel;
            this.tlpMain.SetColumnSpan(this.btCancel, 2);
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCancel.Location = new System.Drawing.Point(814, 661);
            this.btCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(2);
            this.btCancel.Size = new System.Drawing.Size(500, 92);
            this.btCancel.TabIndex = 18;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cmbSelectLanguageValue
            // 
            this.cmbSelectLanguageValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelectLanguageValue.DisplayMember = "DisplayName";
            this.cmbSelectLanguageValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectLanguageValue.FormattingEnabled = true;
            this.cmbSelectLanguageValue.Location = new System.Drawing.Point(616, 507);
            this.cmbSelectLanguageValue.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.cmbSelectLanguageValue.Name = "cmbSelectLanguageValue";
            this.cmbSelectLanguageValue.Size = new System.Drawing.Size(586, 33);
            this.cmbSelectLanguageValue.TabIndex = 25;
            // 
            // lbAutoDatabaseUpdateDescription
            // 
            this.lbAutoDatabaseUpdateDescription.AutoSize = true;
            this.lbAutoDatabaseUpdateDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAutoDatabaseUpdateDescription.Location = new System.Drawing.Point(17, 567);
            this.lbAutoDatabaseUpdateDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbAutoDatabaseUpdateDescription.Name = "lbAutoDatabaseUpdateDescription";
            this.lbAutoDatabaseUpdateDescription.Size = new System.Drawing.Size(419, 25);
            this.lbAutoDatabaseUpdateDescription.TabIndex = 26;
            this.lbAutoDatabaseUpdateDescription.Text = "Automatic database update on startup:";
            this.lbAutoDatabaseUpdateDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAutoDatabaseUpdateValue
            // 
            this.cbAutoDatabaseUpdateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAutoDatabaseUpdateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.cbAutoDatabaseUpdateValue.Location = new System.Drawing.Point(620, 567);
            this.cbAutoDatabaseUpdateValue.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.cbAutoDatabaseUpdateValue.Name = "cbAutoDatabaseUpdateValue";
            this.cbAutoDatabaseUpdateValue.Size = new System.Drawing.Size(578, 25);
            this.cbAutoDatabaseUpdateValue.TabIndex = 27;
            this.cbAutoDatabaseUpdateValue.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 785);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Text = "vamp# settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSettings_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lbAmpRemoteDescription;
        private System.Windows.Forms.TextBox tbAmpRemoteValue;
        private System.Windows.Forms.TextBox tbBaseDirMoviesValue;
        private System.Windows.Forms.Label lbBaseDirMoviesDescription;
        private System.Windows.Forms.TextBox tbBaseDirTVShowsValue;
        private System.Windows.Forms.Label lbBaseDirTVShowsDescription;
        private System.Windows.Forms.CheckBox cbCacheTMDbImagesIntoMemoryValue;
        private System.Windows.Forms.Label lbCacheTMDbImagesIntoMemoryDescription;
        private System.Windows.Forms.Label lbCacheDatabaseIntoMemoryDescription;
        private System.Windows.Forms.TextBox tbBaseDirPhotosValue;
        private System.Windows.Forms.Label lbBaseDirPhotosDescription;
        private System.Windows.Forms.CheckBox cbCacheDatabaseIntoMemoryValue;
        private System.Windows.Forms.CheckBox cdTMDbEnabledValue;
        private System.Windows.Forms.Label lbTMDbEnabledDescription;
        private System.Windows.Forms.Button btSelectMovieFolder;
        private System.Windows.Forms.Button btSelectTVShowFolder;
        private System.Windows.Forms.Button btSelectPhotoFolder;
        private VPKSoft.ImageButton.ImageButton btOK;
        private VPKSoft.ImageButton.ImageButton btCancel;
        private System.Windows.Forms.Button btSelectTMDbImagesCacheDir;
        private System.Windows.Forms.TextBox tbTMDbImagesCacheDirValue;
        private System.Windows.Forms.Label lbTMDbImagesCacheDirDescription;
        private System.Windows.Forms.Label lbUseFileNameForTVShowEpisodeNamingDescription;
        private System.Windows.Forms.CheckBox cbUseFileNameForTVShowEpisodeNamingValue;
        private System.Windows.Forms.Label lbSelectLanguageDescription;
        private System.Windows.Forms.ComboBox cmbSelectLanguageValue;
        private System.Windows.Forms.CheckBox cbAutoDatabaseUpdateValue;
        private System.Windows.Forms.Label lbAutoDatabaseUpdateDescription;
    }
}