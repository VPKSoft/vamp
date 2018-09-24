namespace vamp
{
    partial class AmpMusicPlayerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmpMusicPlayerForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPopDown = new System.Windows.Forms.TableLayoutPanel();
            this.lbToolTip = new System.Windows.Forms.Label();
            this.sliderPosition = new MB.Controls.ColorSlider();
            this.tlpVolume = new System.Windows.Forms.TableLayoutPanel();
            this.btnVolume = new System.Windows.Forms.Panel();
            this.sliderVolume = new MB.Controls.ColorSlider();
            this.pnButtons = new System.Windows.Forms.Panel();
            this.btnContextMenuBase = new System.Windows.Forms.Panel();
            this.btnContextMenu = new System.Windows.Forms.Panel();
            this.btnQueueBase = new System.Windows.Forms.Panel();
            this.btnQueue = new System.Windows.Forms.Panel();
            this.btnNextSongBase = new System.Windows.Forms.Panel();
            this.btnNextSong = new System.Windows.Forms.Panel();
            this.pnPlayPauseBase = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Panel();
            this.pnPlayPause = new System.Windows.Forms.Panel();
            this.btnPause = new System.Windows.Forms.Panel();
            this.btnPreviousSongBase = new System.Windows.Forms.Panel();
            this.btnPreviousSong = new System.Windows.Forms.Panel();
            this.btnRepeatBase = new System.Windows.Forms.Panel();
            this.btnRepeat = new System.Windows.Forms.Panel();
            this.btnExitBase = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Panel();
            this.btnRandomBase = new System.Windows.Forms.Panel();
            this.btnRandom = new System.Windows.Forms.Panel();
            this.tlpTime = new System.Windows.Forms.TableLayoutPanel();
            this.lbTimeText = new System.Windows.Forms.Label();
            this.lbTimeValue = new System.Windows.Forms.Label();
            this.tlpQueueCount = new System.Windows.Forms.TableLayoutPanel();
            this.lbInQueueCount = new System.Windows.Forms.Label();
            this.lbInQueue = new System.Windows.Forms.Label();
            this.lbCurrentSong = new VPKSoft.ImageButton.ImageButton();
            this.tlpFind = new System.Windows.Forms.TableLayoutPanel();
            this.lbFind = new System.Windows.Forms.Label();
            this.tlpSideMargin = new System.Windows.Forms.TableLayoutPanel();
            this.pnListBoxBase = new System.Windows.Forms.Panel();
            this.lbError = new System.Windows.Forms.Label();
            this.tmSongState = new System.Windows.Forms.Timer(this.components);
            this.mnuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSelectAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadSavedQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAppendToQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderRating = new VPKSoft.ImageSlider.ImageSlider();
            this.tbFind = new VPKSoft.VisualTextBox.VisualTextBox();
            this.lbMusic = new VPKSoft.VisualListBox.VisualListBox();
            this.tlpMain.SuspendLayout();
            this.tlpPopDown.SuspendLayout();
            this.tlpVolume.SuspendLayout();
            this.pnButtons.SuspendLayout();
            this.btnContextMenuBase.SuspendLayout();
            this.btnQueueBase.SuspendLayout();
            this.btnNextSongBase.SuspendLayout();
            this.pnPlayPauseBase.SuspendLayout();
            this.pnPlayPause.SuspendLayout();
            this.btnPreviousSongBase.SuspendLayout();
            this.btnRepeatBase.SuspendLayout();
            this.btnExitBase.SuspendLayout();
            this.btnRandomBase.SuspendLayout();
            this.tlpTime.SuspendLayout();
            this.tlpQueueCount.SuspendLayout();
            this.tlpFind.SuspendLayout();
            this.tlpSideMargin.SuspendLayout();
            this.pnListBoxBase.SuspendLayout();
            this.mnuContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.BackColor = System.Drawing.Color.Black;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpPopDown, 0, 3);
            this.tlpMain.Controls.Add(this.lbCurrentSong, 0, 0);
            this.tlpMain.Controls.Add(this.tlpFind, 0, 1);
            this.tlpMain.Controls.Add(this.tlpSideMargin, 0, 2);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMain.Size = new System.Drawing.Size(1252, 657);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpPopDown
            // 
            this.tlpPopDown.BackColor = System.Drawing.Color.Black;
            this.tlpPopDown.ColumnCount = 5;
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpPopDown.Controls.Add(this.lbToolTip, 2, 2);
            this.tlpPopDown.Controls.Add(this.sliderPosition, 2, 0);
            this.tlpPopDown.Controls.Add(this.tlpVolume, 3, 0);
            this.tlpPopDown.Controls.Add(this.pnButtons, 0, 1);
            this.tlpPopDown.Controls.Add(this.tlpTime, 1, 0);
            this.tlpPopDown.Controls.Add(this.tlpQueueCount, 3, 2);
            this.tlpPopDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPopDown.Location = new System.Drawing.Point(0, 458);
            this.tlpPopDown.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPopDown.Name = "tlpPopDown";
            this.tlpPopDown.RowCount = 3;
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpPopDown.Size = new System.Drawing.Size(1252, 199);
            this.tlpPopDown.TabIndex = 3;
            // 
            // lbToolTip
            // 
            this.lbToolTip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToolTip.ForeColor = System.Drawing.Color.Yellow;
            this.lbToolTip.Location = new System.Drawing.Point(380, 170);
            this.lbToolTip.Margin = new System.Windows.Forms.Padding(0);
            this.lbToolTip.Name = "lbToolTip";
            this.lbToolTip.Size = new System.Drawing.Size(420, 29);
            this.lbToolTip.TabIndex = 21;
            this.lbToolTip.Text = "/* TOOL-TIP SHOWS HERE */";
            this.lbToolTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sliderPosition
            // 
            this.sliderPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderPosition.BackColor = System.Drawing.Color.Black;
            this.sliderPosition.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderPosition.Focusable = false;
            this.sliderPosition.LargeChange = ((uint)(5u));
            this.sliderPosition.Location = new System.Drawing.Point(383, 3);
            this.sliderPosition.Name = "sliderPosition";
            this.sliderPosition.Size = new System.Drawing.Size(414, 39);
            this.sliderPosition.SmallChange = ((uint)(1u));
            this.sliderPosition.TabIndex = 6;
            this.sliderPosition.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderPosition.ValueChanged += new System.EventHandler(this.sliderPosition_ValueChanged);
            this.sliderPosition.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.sliderPosition.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // tlpVolume
            // 
            this.tlpVolume.ColumnCount = 3;
            this.tlpVolume.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpVolume.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpVolume.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpVolume.Controls.Add(this.btnVolume, 0, 0);
            this.tlpVolume.Controls.Add(this.sliderVolume, 1, 0);
            this.tlpVolume.Controls.Add(this.sliderRating, 2, 0);
            this.tlpVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVolume.Location = new System.Drawing.Point(800, 0);
            this.tlpVolume.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVolume.Name = "tlpVolume";
            this.tlpVolume.RowCount = 1;
            this.tlpVolume.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVolume.Size = new System.Drawing.Size(420, 45);
            this.tlpVolume.TabIndex = 4;
            // 
            // btnVolume
            // 
            this.btnVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolume.BackgroundImage = global::vamp.Properties.Resources.volume;
            this.btnVolume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolume.Location = new System.Drawing.Point(0, 0);
            this.btnVolume.Margin = new System.Windows.Forms.Padding(0);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(42, 45);
            this.btnVolume.TabIndex = 0;
            this.btnVolume.Tag = "100";
            this.btnVolume.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnVolume.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // sliderVolume
            // 
            this.sliderVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderVolume.BackColor = System.Drawing.Color.Black;
            this.sliderVolume.BarInnerColor = System.Drawing.Color.Orange;
            this.sliderVolume.BarOuterColor = System.Drawing.Color.OrangeRed;
            this.sliderVolume.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderVolume.ElapsedInnerColor = System.Drawing.Color.Gold;
            this.sliderVolume.ElapsedOuterColor = System.Drawing.Color.Yellow;
            this.sliderVolume.Focusable = false;
            this.sliderVolume.LargeChange = ((uint)(5u));
            this.sliderVolume.Location = new System.Drawing.Point(42, 0);
            this.sliderVolume.Margin = new System.Windows.Forms.Padding(0);
            this.sliderVolume.Maximum = 200;
            this.sliderVolume.Name = "sliderVolume";
            this.sliderVolume.Size = new System.Drawing.Size(189, 45);
            this.sliderVolume.SmallChange = ((uint)(1u));
            this.sliderVolume.TabIndex = 1;
            this.sliderVolume.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderVolume.Value = 100;
            this.sliderVolume.ValueChanged += new System.EventHandler(this.sliderVolume_ValueChanged);
            this.sliderVolume.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.sliderVolume.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // pnButtons
            // 
            this.pnButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnButtons.BackColor = System.Drawing.Color.Black;
            this.tlpPopDown.SetColumnSpan(this.pnButtons, 5);
            this.pnButtons.Controls.Add(this.btnContextMenuBase);
            this.pnButtons.Controls.Add(this.btnQueueBase);
            this.pnButtons.Controls.Add(this.btnNextSongBase);
            this.pnButtons.Controls.Add(this.pnPlayPauseBase);
            this.pnButtons.Controls.Add(this.btnPreviousSongBase);
            this.pnButtons.Controls.Add(this.btnRepeatBase);
            this.pnButtons.Controls.Add(this.btnExitBase);
            this.pnButtons.Controls.Add(this.btnRandomBase);
            this.pnButtons.Location = new System.Drawing.Point(0, 45);
            this.pnButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnButtons.Name = "pnButtons";
            this.pnButtons.Size = new System.Drawing.Size(1252, 125);
            this.pnButtons.TabIndex = 3;
            // 
            // btnContextMenuBase
            // 
            this.btnContextMenuBase.BackColor = System.Drawing.Color.White;
            this.btnContextMenuBase.Controls.Add(this.btnContextMenu);
            this.btnContextMenuBase.Location = new System.Drawing.Point(842, 20);
            this.btnContextMenuBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnContextMenuBase.Name = "btnContextMenuBase";
            this.btnContextMenuBase.Padding = new System.Windows.Forms.Padding(5);
            this.btnContextMenuBase.Size = new System.Drawing.Size(130, 86);
            this.btnContextMenuBase.TabIndex = 30;
            this.btnContextMenuBase.Tag = "6";
            // 
            // btnContextMenu
            // 
            this.btnContextMenu.BackColor = System.Drawing.Color.White;
            this.btnContextMenu.BackgroundImage = global::vamp.Properties.Resources.menu;
            this.btnContextMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnContextMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnContextMenu.Location = new System.Drawing.Point(5, 5);
            this.btnContextMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnContextMenu.Name = "btnContextMenu";
            this.btnContextMenu.Size = new System.Drawing.Size(120, 76);
            this.btnContextMenu.TabIndex = 22;
            this.btnContextMenu.Tag = "6";
            this.btnContextMenu.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnContextMenu.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnContextMenu.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnQueueBase
            // 
            this.btnQueueBase.BackColor = System.Drawing.Color.White;
            this.btnQueueBase.Controls.Add(this.btnQueue);
            this.btnQueueBase.Location = new System.Drawing.Point(702, 20);
            this.btnQueueBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnQueueBase.Name = "btnQueueBase";
            this.btnQueueBase.Padding = new System.Windows.Forms.Padding(5);
            this.btnQueueBase.Size = new System.Drawing.Size(130, 86);
            this.btnQueueBase.TabIndex = 29;
            this.btnQueueBase.Tag = "5";
            // 
            // btnQueue
            // 
            this.btnQueue.BackColor = System.Drawing.Color.White;
            this.btnQueue.BackgroundImage = global::vamp.Properties.Resources.queue;
            this.btnQueue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQueue.Location = new System.Drawing.Point(5, 5);
            this.btnQueue.Margin = new System.Windows.Forms.Padding(0);
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.Size = new System.Drawing.Size(120, 76);
            this.btnQueue.TabIndex = 21;
            this.btnQueue.Tag = "5";
            this.btnQueue.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnQueue.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnQueue.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnNextSongBase
            // 
            this.btnNextSongBase.BackColor = System.Drawing.Color.White;
            this.btnNextSongBase.Controls.Add(this.btnNextSong);
            this.btnNextSongBase.Location = new System.Drawing.Point(563, 20);
            this.btnNextSongBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextSongBase.Name = "btnNextSongBase";
            this.btnNextSongBase.Padding = new System.Windows.Forms.Padding(5);
            this.btnNextSongBase.Size = new System.Drawing.Size(130, 86);
            this.btnNextSongBase.TabIndex = 28;
            this.btnNextSongBase.Tag = "4";
            // 
            // btnNextSong
            // 
            this.btnNextSong.BackColor = System.Drawing.Color.White;
            this.btnNextSong.BackgroundImage = global::vamp.Properties.Resources.next;
            this.btnNextSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNextSong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextSong.Location = new System.Drawing.Point(5, 5);
            this.btnNextSong.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextSong.Name = "btnNextSong";
            this.btnNextSong.Size = new System.Drawing.Size(120, 76);
            this.btnNextSong.TabIndex = 19;
            this.btnNextSong.Tag = "4";
            this.btnNextSong.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnNextSong.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnNextSong.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // pnPlayPauseBase
            // 
            this.pnPlayPauseBase.BackColor = System.Drawing.Color.White;
            this.pnPlayPauseBase.Controls.Add(this.btnPlay);
            this.pnPlayPauseBase.Controls.Add(this.pnPlayPause);
            this.pnPlayPauseBase.Location = new System.Drawing.Point(424, 20);
            this.pnPlayPauseBase.Margin = new System.Windows.Forms.Padding(0);
            this.pnPlayPauseBase.Name = "pnPlayPauseBase";
            this.pnPlayPauseBase.Padding = new System.Windows.Forms.Padding(5);
            this.pnPlayPauseBase.Size = new System.Drawing.Size(130, 86);
            this.pnPlayPauseBase.TabIndex = 27;
            this.pnPlayPauseBase.Tag = "3";
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.White;
            this.btnPlay.BackgroundImage = global::vamp.Properties.Resources.play;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlay.Location = new System.Drawing.Point(5, 5);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(120, 76);
            this.btnPlay.TabIndex = 17;
            this.btnPlay.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnPlay.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // pnPlayPause
            // 
            this.pnPlayPause.BackColor = System.Drawing.Color.Black;
            this.pnPlayPause.Controls.Add(this.btnPause);
            this.pnPlayPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPlayPause.Location = new System.Drawing.Point(5, 5);
            this.pnPlayPause.Name = "pnPlayPause";
            this.pnPlayPause.Size = new System.Drawing.Size(120, 76);
            this.pnPlayPause.TabIndex = 16;
            this.pnPlayPause.Tag = "3";
            // 
            // btnPause
            // 
            this.btnPause.BackgroundImage = global::vamp.Properties.Resources.pause;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Location = new System.Drawing.Point(0, 0);
            this.btnPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(120, 76);
            this.btnPause.TabIndex = 15;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnPause.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnPause.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnPreviousSongBase
            // 
            this.btnPreviousSongBase.BackColor = System.Drawing.Color.White;
            this.btnPreviousSongBase.Controls.Add(this.btnPreviousSong);
            this.btnPreviousSongBase.Location = new System.Drawing.Point(289, 20);
            this.btnPreviousSongBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreviousSongBase.Name = "btnPreviousSongBase";
            this.btnPreviousSongBase.Padding = new System.Windows.Forms.Padding(5);
            this.btnPreviousSongBase.Size = new System.Drawing.Size(130, 86);
            this.btnPreviousSongBase.TabIndex = 26;
            this.btnPreviousSongBase.Tag = "2";
            // 
            // btnPreviousSong
            // 
            this.btnPreviousSong.BackColor = System.Drawing.Color.White;
            this.btnPreviousSong.BackgroundImage = global::vamp.Properties.Resources.previous;
            this.btnPreviousSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPreviousSong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPreviousSong.Enabled = false;
            this.btnPreviousSong.Location = new System.Drawing.Point(5, 5);
            this.btnPreviousSong.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreviousSong.Name = "btnPreviousSong";
            this.btnPreviousSong.Size = new System.Drawing.Size(120, 76);
            this.btnPreviousSong.TabIndex = 14;
            this.btnPreviousSong.Tag = "2";
            this.btnPreviousSong.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnPreviousSong.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnPreviousSong.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnRepeatBase
            // 
            this.btnRepeatBase.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRepeatBase.Controls.Add(this.btnRepeat);
            this.btnRepeatBase.Location = new System.Drawing.Point(148, 15);
            this.btnRepeatBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnRepeatBase.Name = "btnRepeatBase";
            this.btnRepeatBase.Padding = new System.Windows.Forms.Padding(5);
            this.btnRepeatBase.Size = new System.Drawing.Size(130, 86);
            this.btnRepeatBase.TabIndex = 25;
            this.btnRepeatBase.Tag = "1";
            // 
            // btnRepeat
            // 
            this.btnRepeat.BackColor = System.Drawing.Color.White;
            this.btnRepeat.BackgroundImage = global::vamp.Properties.Resources.repeat;
            this.btnRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRepeat.Location = new System.Drawing.Point(5, 5);
            this.btnRepeat.Margin = new System.Windows.Forms.Padding(0);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(120, 76);
            this.btnRepeat.TabIndex = 20;
            this.btnRepeat.Tag = "1";
            this.btnRepeat.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnRepeat.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnRepeat.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnExitBase
            // 
            this.btnExitBase.BackColor = System.Drawing.Color.White;
            this.btnExitBase.Controls.Add(this.btnExit);
            this.btnExitBase.Location = new System.Drawing.Point(985, 20);
            this.btnExitBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnExitBase.Name = "btnExitBase";
            this.btnExitBase.Padding = new System.Windows.Forms.Padding(5);
            this.btnExitBase.Size = new System.Drawing.Size(130, 86);
            this.btnExitBase.TabIndex = 24;
            this.btnExitBase.Tag = "7";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.BackgroundImage = global::vamp.Properties.Resources.Cancel;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(5, 5);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 76);
            this.btnExit.TabIndex = 22;
            this.btnExit.Tag = "7";
            this.btnExit.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnExit.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnRandomBase
            // 
            this.btnRandomBase.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRandomBase.Controls.Add(this.btnRandom);
            this.btnRandomBase.Location = new System.Drawing.Point(8, 6);
            this.btnRandomBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnRandomBase.Name = "btnRandomBase";
            this.btnRandomBase.Padding = new System.Windows.Forms.Padding(5);
            this.btnRandomBase.Size = new System.Drawing.Size(130, 86);
            this.btnRandomBase.TabIndex = 23;
            this.btnRandomBase.Tag = "0";
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.Color.White;
            this.btnRandom.BackgroundImage = global::vamp.Properties.Resources.shuffle;
            this.btnRandom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRandom.Location = new System.Drawing.Point(5, 5);
            this.btnRandom.Margin = new System.Windows.Forms.Padding(0);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(120, 76);
            this.btnRandom.TabIndex = 13;
            this.btnRandom.Tag = "0";
            this.btnRandom.Click += new System.EventHandler(this.GlobalClickHandler);
            this.btnRandom.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnRandom.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // tlpTime
            // 
            this.tlpTime.ColumnCount = 2;
            this.tlpTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpTime.Controls.Add(this.lbTimeText, 0, 0);
            this.tlpTime.Controls.Add(this.lbTimeValue, 1, 0);
            this.tlpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTime.Location = new System.Drawing.Point(20, 0);
            this.tlpTime.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTime.Name = "tlpTime";
            this.tlpTime.RowCount = 1;
            this.tlpTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTime.Size = new System.Drawing.Size(360, 45);
            this.tlpTime.TabIndex = 5;
            // 
            // lbTimeText
            // 
            this.lbTimeText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeText.ForeColor = System.Drawing.Color.White;
            this.lbTimeText.Location = new System.Drawing.Point(0, 0);
            this.lbTimeText.Margin = new System.Windows.Forms.Padding(0);
            this.lbTimeText.Name = "lbTimeText";
            this.lbTimeText.Size = new System.Drawing.Size(108, 45);
            this.lbTimeText.TabIndex = 0;
            this.lbTimeText.Text = "Time:";
            this.lbTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTimeValue
            // 
            this.lbTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeValue.ForeColor = System.Drawing.Color.White;
            this.lbTimeValue.Location = new System.Drawing.Point(108, 0);
            this.lbTimeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lbTimeValue.Name = "lbTimeValue";
            this.lbTimeValue.Size = new System.Drawing.Size(252, 45);
            this.lbTimeValue.TabIndex = 1;
            this.lbTimeValue.Text = "-00:00";
            this.lbTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpQueueCount
            // 
            this.tlpQueueCount.ColumnCount = 2;
            this.tlpQueueCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpQueueCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpQueueCount.Controls.Add(this.lbInQueueCount, 0, 0);
            this.tlpQueueCount.Controls.Add(this.lbInQueue, 0, 0);
            this.tlpQueueCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQueueCount.Location = new System.Drawing.Point(800, 170);
            this.tlpQueueCount.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQueueCount.Name = "tlpQueueCount";
            this.tlpQueueCount.RowCount = 1;
            this.tlpQueueCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQueueCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpQueueCount.Size = new System.Drawing.Size(420, 29);
            this.tlpQueueCount.TabIndex = 22;
            // 
            // lbInQueueCount
            // 
            this.lbInQueueCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInQueueCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInQueueCount.ForeColor = System.Drawing.Color.SkyBlue;
            this.lbInQueueCount.Location = new System.Drawing.Point(336, 0);
            this.lbInQueueCount.Margin = new System.Windows.Forms.Padding(0);
            this.lbInQueueCount.Name = "lbInQueueCount";
            this.lbInQueueCount.Size = new System.Drawing.Size(84, 29);
            this.lbInQueueCount.TabIndex = 23;
            this.lbInQueueCount.Text = "0";
            this.lbInQueueCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbInQueue
            // 
            this.lbInQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInQueue.ForeColor = System.Drawing.Color.White;
            this.lbInQueue.Location = new System.Drawing.Point(0, 0);
            this.lbInQueue.Margin = new System.Windows.Forms.Padding(0);
            this.lbInQueue.Name = "lbInQueue";
            this.lbInQueue.Size = new System.Drawing.Size(336, 29);
            this.lbInQueue.TabIndex = 22;
            this.lbInQueue.Text = "In queue:";
            this.lbInQueue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCurrentSong
            // 
            this.lbCurrentSong.BackColor = System.Drawing.Color.Black;
            this.lbCurrentSong.ButtonImage = global::vamp.Properties.Resources.music;
            this.lbCurrentSong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCurrentSong.ForeColor = System.Drawing.Color.SkyBlue;
            this.lbCurrentSong.Location = new System.Drawing.Point(1, 1);
            this.lbCurrentSong.Margin = new System.Windows.Forms.Padding(1);
            this.lbCurrentSong.Name = "lbCurrentSong";
            this.lbCurrentSong.Padding = new System.Windows.Forms.Padding(1);
            this.lbCurrentSong.Size = new System.Drawing.Size(1250, 63);
            this.lbCurrentSong.TabIndex = 5;
            this.lbCurrentSong.Text = "-";
            // 
            // tlpFind
            // 
            this.tlpFind.ColumnCount = 2;
            this.tlpFind.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFind.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpFind.Controls.Add(this.tbFind, 1, 0);
            this.tlpFind.Controls.Add(this.lbFind, 0, 0);
            this.tlpFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFind.Location = new System.Drawing.Point(0, 65);
            this.tlpFind.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFind.Name = "tlpFind";
            this.tlpFind.RowCount = 1;
            this.tlpFind.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFind.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpFind.Size = new System.Drawing.Size(1252, 65);
            this.tlpFind.TabIndex = 6;
            // 
            // lbFind
            // 
            this.lbFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFind.ForeColor = System.Drawing.Color.White;
            this.lbFind.Location = new System.Drawing.Point(3, 0);
            this.lbFind.Name = "lbFind";
            this.lbFind.Size = new System.Drawing.Size(119, 65);
            this.lbFind.TabIndex = 1;
            this.lbFind.Text = "Find:";
            this.lbFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSideMargin
            // 
            this.tlpSideMargin.ColumnCount = 2;
            this.tlpSideMargin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tlpSideMargin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSideMargin.Controls.Add(this.pnListBoxBase, 1, 0);
            this.tlpSideMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSideMargin.Location = new System.Drawing.Point(0, 130);
            this.tlpSideMargin.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSideMargin.Name = "tlpSideMargin";
            this.tlpSideMargin.RowCount = 1;
            this.tlpSideMargin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSideMargin.Size = new System.Drawing.Size(1252, 328);
            this.tlpSideMargin.TabIndex = 7;
            // 
            // pnListBoxBase
            // 
            this.pnListBoxBase.Controls.Add(this.lbMusic);
            this.pnListBoxBase.Controls.Add(this.lbError);
            this.pnListBoxBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListBoxBase.Location = new System.Drawing.Point(0, 0);
            this.pnListBoxBase.Margin = new System.Windows.Forms.Padding(0);
            this.pnListBoxBase.Name = "pnListBoxBase";
            this.pnListBoxBase.Size = new System.Drawing.Size(1252, 328);
            this.pnListBoxBase.TabIndex = 0;
            // 
            // lbError
            // 
            this.lbError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(0, 0);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(1252, 328);
            this.lbError.TabIndex = 1;
            this.lbError.Text = "amp# ERROR MESSAGE";
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmSongState
            // 
            this.tmSongState.Interval = 1000;
            this.tmSongState.Tick += new System.EventHandler(this.tmSongState_Tick);
            // 
            // mnuContext
            // 
            this.mnuContext.BackColor = System.Drawing.Color.SteelBlue;
            this.mnuContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.mnuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelectAlbum,
            this.mnuLoadSavedQueue,
            this.toolStripMenuItem1,
            this.mnuAppendToQueue});
            this.mnuContext.Name = "mnuContext";
            this.mnuContext.Size = new System.Drawing.Size(366, 118);
            // 
            // mnuSelectAlbum
            // 
            this.mnuSelectAlbum.ForeColor = System.Drawing.Color.White;
            this.mnuSelectAlbum.Image = global::vamp.Properties.Resources.record_album;
            this.mnuSelectAlbum.Name = "mnuSelectAlbum";
            this.mnuSelectAlbum.Size = new System.Drawing.Size(365, 36);
            this.mnuSelectAlbum.Text = "Select Album";
            this.mnuSelectAlbum.Click += new System.EventHandler(this.mnuSelectAlbum_Click);
            // 
            // mnuLoadSavedQueue
            // 
            this.mnuLoadSavedQueue.ForeColor = System.Drawing.Color.White;
            this.mnuLoadSavedQueue.Image = global::vamp.Properties.Resources.load_queue;
            this.mnuLoadSavedQueue.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuLoadSavedQueue.Name = "mnuLoadSavedQueue";
            this.mnuLoadSavedQueue.Size = new System.Drawing.Size(365, 36);
            this.mnuLoadSavedQueue.Text = "Load a saved queue";
            this.mnuLoadSavedQueue.Click += new System.EventHandler(this.mnuLoadSavedQueue_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(362, 6);
            // 
            // mnuAppendToQueue
            // 
            this.mnuAppendToQueue.ForeColor = System.Drawing.Color.White;
            this.mnuAppendToQueue.Image = global::vamp.Properties.Resources.append_queue;
            this.mnuAppendToQueue.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuAppendToQueue.Name = "mnuAppendToQueue";
            this.mnuAppendToQueue.Size = new System.Drawing.Size(365, 36);
            this.mnuAppendToQueue.Text = "Append a saved queue";
            this.mnuAppendToQueue.Click += new System.EventHandler(this.mnuLoadSavedQueue_Click);
            // 
            // sliderRating
            // 
            this.sliderRating.Enabled = false;
            this.sliderRating.ImageOffValue = ((System.Drawing.Image)(resources.GetObject("sliderRating.ImageOffValue")));
            this.sliderRating.ImageOnValue = global::vamp.Properties.Resources.orange_star;
            this.sliderRating.Location = new System.Drawing.Point(234, 3);
            this.sliderRating.Maximum = 500;
            this.sliderRating.Name = "sliderRating";
            this.sliderRating.Size = new System.Drawing.Size(183, 39);
            this.sliderRating.SliderImage = ((System.Drawing.Image)(resources.GetObject("sliderRating.SliderImage")));
            this.sliderRating.TabIndex = 2;
            this.sliderRating.ValueChanged += new System.EventHandler(this.sliderRating_ValueChanged);
            this.sliderRating.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.sliderRating.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // tbFind
            // 
            this.tbFind.BorderColor = System.Drawing.Color.SkyBlue;
            this.tbFind.BorderWidth = 1;
            this.tbFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.ForeColor = System.Drawing.Color.White;
            this.tbFind.Location = new System.Drawing.Point(125, 0);
            this.tbFind.Margin = new System.Windows.Forms.Padding(0);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(1127, 65);
            this.tbFind.TabIndex = 0;
            this.tbFind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
            this.tbFind.Click += new System.EventHandler(this.tbFind_Enter);
            this.tbFind.Enter += new System.EventHandler(this.tbFind_Enter);
            this.tbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFind_KeyDown);
            // 
            // lbMusic
            // 
            this.lbMusic.BackColor = System.Drawing.Color.Black;
            this.lbMusic.BackColorAlternative = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbMusic.DisplayMember = "";
            this.lbMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMusic.ForeColor = System.Drawing.Color.White;
            this.lbMusic.ForeColorAlternative = System.Drawing.Color.Gainsboro;
            this.lbMusic.HoverBackColor = System.Drawing.Color.Black;
            this.lbMusic.HoverBackColorAlternative = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbMusic.HoverEnabled = false;
            this.lbMusic.HoverForeColor = System.Drawing.Color.White;
            this.lbMusic.HoverForeColorAlternative = System.Drawing.Color.Gainsboro;
            this.lbMusic.Items.AddRange(new object[] {
            "testing 0...",
            "testing 1...",
            "testing 2...",
            "testing 3...",
            "testing 4...",
            "testing 5...",
            "testing 6...",
            "testing 7...",
            "testing 8...",
            "testing 9...",
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
            this.lbMusic.Location = new System.Drawing.Point(0, 0);
            this.lbMusic.Margin = new System.Windows.Forms.Padding(0);
            this.lbMusic.Name = "lbMusic";
            this.lbMusic.RightImage = global::vamp.Properties.Resources.Cancel;
            this.lbMusic.SelectedIndex = -1;
            this.lbMusic.SelectedItem = null;
            this.lbMusic.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.lbMusic.SelectionColorAlternative = System.Drawing.SystemColors.Highlight;
            this.lbMusic.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMusic.Size = new System.Drawing.Size(1252, 328);
            this.lbMusic.TabIndex = 0;
            this.lbMusic.ValueMember = "";
            this.lbMusic.DoubleClick += new System.EventHandler(this.lbMusic_DoubleClick);
            // 
            // AmpMusicPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1276, 681);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "AmpMusicPlayerForm";
            this.ShowInTaskbar = false;
            this.Text = "AmpMusicPlayerForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AmpMusicPlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.AmpMusicPlayerForm_Load);
            this.Shown += new System.EventHandler(this.AmpMusicPlayerForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AmpMusicPlayerForm_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpPopDown.ResumeLayout(false);
            this.tlpVolume.ResumeLayout(false);
            this.pnButtons.ResumeLayout(false);
            this.btnContextMenuBase.ResumeLayout(false);
            this.btnQueueBase.ResumeLayout(false);
            this.btnNextSongBase.ResumeLayout(false);
            this.pnPlayPauseBase.ResumeLayout(false);
            this.pnPlayPause.ResumeLayout(false);
            this.btnPreviousSongBase.ResumeLayout(false);
            this.btnRepeatBase.ResumeLayout(false);
            this.btnExitBase.ResumeLayout(false);
            this.btnRandomBase.ResumeLayout(false);
            this.tlpTime.ResumeLayout(false);
            this.tlpQueueCount.ResumeLayout(false);
            this.tlpFind.ResumeLayout(false);
            this.tlpSideMargin.ResumeLayout(false);
            this.pnListBoxBase.ResumeLayout(false);
            this.mnuContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpPopDown;
        private System.Windows.Forms.Label lbToolTip;
        private MB.Controls.ColorSlider sliderPosition;
        private System.Windows.Forms.TableLayoutPanel tlpVolume;
        private System.Windows.Forms.Panel btnVolume;
        private MB.Controls.ColorSlider sliderVolume;
        private System.Windows.Forms.Panel pnButtons;
        private System.Windows.Forms.Panel btnNextSong;
        private System.Windows.Forms.Panel btnPreviousSong;
        private System.Windows.Forms.Panel btnRandom;
        private System.Windows.Forms.TableLayoutPanel tlpTime;
        private System.Windows.Forms.Label lbTimeText;
        private System.Windows.Forms.Label lbTimeValue;
        private System.Windows.Forms.Panel btnRepeat;
        private System.Windows.Forms.Panel btnQueue;
        private System.Windows.Forms.Panel btnExit;
        private System.Windows.Forms.Panel btnRandomBase;
        private System.Windows.Forms.Panel btnQueueBase;
        private System.Windows.Forms.Panel btnNextSongBase;
        private System.Windows.Forms.Panel pnPlayPauseBase;
        private System.Windows.Forms.Panel btnPreviousSongBase;
        private System.Windows.Forms.Panel btnRepeatBase;
        private System.Windows.Forms.Panel btnExitBase;
        private System.Windows.Forms.Timer tmSongState;
        private VPKSoft.ImageButton.ImageButton lbCurrentSong;
        private System.Windows.Forms.TableLayoutPanel tlpFind;
        private VPKSoft.VisualTextBox.VisualTextBox tbFind;
        private System.Windows.Forms.Label lbFind;
        private System.Windows.Forms.TableLayoutPanel tlpSideMargin;
        private System.Windows.Forms.Panel pnListBoxBase;
        private System.Windows.Forms.Panel btnPlay;
        private System.Windows.Forms.Panel pnPlayPause;
        private System.Windows.Forms.Panel btnPause;
        private VPKSoft.ImageSlider.ImageSlider sliderRating;
        private System.Windows.Forms.TableLayoutPanel tlpQueueCount;
        private System.Windows.Forms.Label lbInQueueCount;
        private System.Windows.Forms.Label lbInQueue;
        private VPKSoft.VisualListBox.VisualListBox lbMusic;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Panel btnContextMenuBase;
        private System.Windows.Forms.Panel btnContextMenu;
        private System.Windows.Forms.ContextMenuStrip mnuContext;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAlbum;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadSavedQueue;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuAppendToQueue;
    }
}