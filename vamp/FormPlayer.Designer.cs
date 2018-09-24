namespace vamp
{
    partial class FormPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayer));
            this.tlpPopDown = new System.Windows.Forms.TableLayoutPanel();
            this.lbToolTip = new System.Windows.Forms.Label();
            this.sliderPosition = new MB.Controls.ColorSlider();
            this.tlpVolume = new System.Windows.Forms.TableLayoutPanel();
            this.btnVolume = new System.Windows.Forms.Panel();
            this.sliderVolume = new MB.Controls.ColorSlider();
            this.btnSelectSubtitle = new System.Windows.Forms.Panel();
            this.pnButtons = new System.Windows.Forms.Panel();
            this.btnSeekEnd = new System.Windows.Forms.Panel();
            this.btnWindForward = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Panel();
            this.pnPlayPause = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Panel();
            this.btnPause = new System.Windows.Forms.Panel();
            this.btnWindBackward = new System.Windows.Forms.Panel();
            this.btnSeekStart = new System.Windows.Forms.Panel();
            this.tlpTime = new System.Windows.Forms.TableLayoutPanel();
            this.lbTimeText = new System.Windows.Forms.Label();
            this.lbTimeValue = new System.Windows.Forms.Label();
            this.tmMain = new System.Windows.Forms.Timer(this.components);
            this.tmWindRewind = new System.Windows.Forms.Timer(this.components);
            this.tlpPopDown.SuspendLayout();
            this.tlpVolume.SuspendLayout();
            this.pnButtons.SuspendLayout();
            this.pnPlayPause.SuspendLayout();
            this.tlpTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPopDown
            // 
            this.tlpPopDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPopDown.BackColor = System.Drawing.Color.Black;
            this.tlpPopDown.ColumnCount = 5;
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPopDown.Controls.Add(this.lbToolTip, 2, 2);
            this.tlpPopDown.Controls.Add(this.sliderPosition, 2, 0);
            this.tlpPopDown.Controls.Add(this.tlpVolume, 3, 0);
            this.tlpPopDown.Controls.Add(this.pnButtons, 0, 1);
            this.tlpPopDown.Controls.Add(this.tlpTime, 1, 0);
            this.tlpPopDown.Location = new System.Drawing.Point(0, 491);
            this.tlpPopDown.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPopDown.Name = "tlpPopDown";
            this.tlpPopDown.RowCount = 3;
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpPopDown.Size = new System.Drawing.Size(903, 167);
            this.tlpPopDown.TabIndex = 2;
            // 
            // lbToolTip
            // 
            this.lbToolTip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToolTip.ForeColor = System.Drawing.Color.Yellow;
            this.lbToolTip.Location = new System.Drawing.Point(278, 143);
            this.lbToolTip.Margin = new System.Windows.Forms.Padding(0);
            this.lbToolTip.Name = "lbToolTip";
            this.lbToolTip.Size = new System.Drawing.Size(345, 24);
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
            this.sliderPosition.Enabled = false;
            this.sliderPosition.Focusable = false;
            this.sliderPosition.LargeChange = ((uint)(5u));
            this.sliderPosition.Location = new System.Drawing.Point(281, 3);
            this.sliderPosition.Name = "sliderPosition";
            this.sliderPosition.Size = new System.Drawing.Size(339, 32);
            this.sliderPosition.SmallChange = ((uint)(1u));
            this.sliderPosition.TabIndex = 6;
            this.sliderPosition.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderPosition.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderPosition_Scroll);
            this.sliderPosition.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.sliderPosition.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // tlpVolume
            // 
            this.tlpVolume.ColumnCount = 4;
            this.tlpVolume.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpVolume.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpVolume.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpVolume.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpVolume.Controls.Add(this.btnVolume, 2, 0);
            this.tlpVolume.Controls.Add(this.sliderVolume, 3, 0);
            this.tlpVolume.Controls.Add(this.btnSelectSubtitle, 1, 0);
            this.tlpVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVolume.Location = new System.Drawing.Point(623, 0);
            this.tlpVolume.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVolume.Name = "tlpVolume";
            this.tlpVolume.RowCount = 1;
            this.tlpVolume.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVolume.Size = new System.Drawing.Size(258, 38);
            this.tlpVolume.TabIndex = 4;
            // 
            // btnVolume
            // 
            this.btnVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolume.BackgroundImage = global::vamp.Properties.Resources.volume;
            this.btnVolume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolume.Enabled = false;
            this.btnVolume.Location = new System.Drawing.Point(50, 0);
            this.btnVolume.Margin = new System.Windows.Forms.Padding(0);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(25, 38);
            this.btnVolume.TabIndex = 0;
            this.btnVolume.Tag = "100";
            this.btnVolume.Click += new System.EventHandler(this.CommonClickHandler);
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
            this.sliderVolume.Enabled = false;
            this.sliderVolume.Focusable = false;
            this.sliderVolume.LargeChange = ((uint)(5u));
            this.sliderVolume.Location = new System.Drawing.Point(75, 0);
            this.sliderVolume.Margin = new System.Windows.Forms.Padding(0);
            this.sliderVolume.Maximum = 300;
            this.sliderVolume.Name = "sliderVolume";
            this.sliderVolume.Size = new System.Drawing.Size(183, 38);
            this.sliderVolume.SmallChange = ((uint)(1u));
            this.sliderVolume.TabIndex = 1;
            this.sliderVolume.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderVolume.Value = 100;
            this.sliderVolume.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderVolume_Scroll);
            this.sliderVolume.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.sliderVolume.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnSelectSubtitle
            // 
            this.btnSelectSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSubtitle.BackgroundImage = global::vamp.Properties.Resources.subtitle;
            this.btnSelectSubtitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectSubtitle.Enabled = false;
            this.btnSelectSubtitle.Location = new System.Drawing.Point(25, 0);
            this.btnSelectSubtitle.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectSubtitle.Name = "btnSelectSubtitle";
            this.btnSelectSubtitle.Size = new System.Drawing.Size(25, 38);
            this.btnSelectSubtitle.TabIndex = 2;
            this.btnSelectSubtitle.Tag = "";
            this.btnSelectSubtitle.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnSelectSubtitle.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnSelectSubtitle.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // pnButtons
            // 
            this.pnButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPopDown.SetColumnSpan(this.pnButtons, 5);
            this.pnButtons.Controls.Add(this.btnSeekEnd);
            this.pnButtons.Controls.Add(this.btnWindForward);
            this.pnButtons.Controls.Add(this.btnStop);
            this.pnButtons.Controls.Add(this.pnPlayPause);
            this.pnButtons.Controls.Add(this.btnWindBackward);
            this.pnButtons.Controls.Add(this.btnSeekStart);
            this.pnButtons.Location = new System.Drawing.Point(0, 38);
            this.pnButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnButtons.Name = "pnButtons";
            this.pnButtons.Size = new System.Drawing.Size(903, 105);
            this.pnButtons.TabIndex = 3;
            // 
            // btnSeekEnd
            // 
            this.btnSeekEnd.BackgroundImage = global::vamp.Properties.Resources.next;
            this.btnSeekEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSeekEnd.Enabled = false;
            this.btnSeekEnd.Location = new System.Drawing.Point(636, 3);
            this.btnSeekEnd.Margin = new System.Windows.Forms.Padding(0);
            this.btnSeekEnd.Name = "btnSeekEnd";
            this.btnSeekEnd.Size = new System.Drawing.Size(128, 80);
            this.btnSeekEnd.TabIndex = 19;
            this.btnSeekEnd.Tag = "5";
            this.btnSeekEnd.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnSeekEnd.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnSeekEnd.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnWindForward
            // 
            this.btnWindForward.BackgroundImage = global::vamp.Properties.Resources.wind_forward;
            this.btnWindForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWindForward.Enabled = false;
            this.btnWindForward.Location = new System.Drawing.Point(528, 3);
            this.btnWindForward.Margin = new System.Windows.Forms.Padding(0);
            this.btnWindForward.Name = "btnWindForward";
            this.btnWindForward.Size = new System.Drawing.Size(125, 80);
            this.btnWindForward.TabIndex = 18;
            this.btnWindForward.Tag = "4";
            this.btnWindForward.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnWindForward.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnWindForward.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::vamp.Properties.Resources.stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.Location = new System.Drawing.Point(403, 3);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(125, 80);
            this.btnStop.TabIndex = 17;
            this.btnStop.Tag = "3";
            this.btnStop.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnStop.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnStop.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // pnPlayPause
            // 
            this.pnPlayPause.Controls.Add(this.btnPlay);
            this.pnPlayPause.Controls.Add(this.btnPause);
            this.pnPlayPause.Location = new System.Drawing.Point(281, 3);
            this.pnPlayPause.Name = "pnPlayPause";
            this.pnPlayPause.Size = new System.Drawing.Size(119, 83);
            this.pnPlayPause.TabIndex = 16;
            this.pnPlayPause.Tag = "2";
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = global::vamp.Properties.Resources.play;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlay.Location = new System.Drawing.Point(0, 0);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(119, 83);
            this.btnPlay.TabIndex = 16;
            this.btnPlay.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnPlay.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnPause
            // 
            this.btnPause.BackgroundImage = global::vamp.Properties.Resources.pause;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPause.Location = new System.Drawing.Point(0, 0);
            this.btnPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(119, 83);
            this.btnPause.TabIndex = 15;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnPause.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnPause.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnWindBackward
            // 
            this.btnWindBackward.BackgroundImage = global::vamp.Properties.Resources.wind_back;
            this.btnWindBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWindBackward.Enabled = false;
            this.btnWindBackward.Location = new System.Drawing.Point(153, 0);
            this.btnWindBackward.Margin = new System.Windows.Forms.Padding(0);
            this.btnWindBackward.Name = "btnWindBackward";
            this.btnWindBackward.Size = new System.Drawing.Size(125, 80);
            this.btnWindBackward.TabIndex = 14;
            this.btnWindBackward.Tag = "1";
            this.btnWindBackward.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnWindBackward.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnWindBackward.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnSeekStart
            // 
            this.btnSeekStart.BackgroundImage = global::vamp.Properties.Resources.previous;
            this.btnSeekStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSeekStart.Enabled = false;
            this.btnSeekStart.Location = new System.Drawing.Point(18, 0);
            this.btnSeekStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnSeekStart.Name = "btnSeekStart";
            this.btnSeekStart.Size = new System.Drawing.Size(125, 80);
            this.btnSeekStart.TabIndex = 13;
            this.btnSeekStart.Tag = "0";
            this.btnSeekStart.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnSeekStart.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnSeekStart.MouseLeave += new System.EventHandler(this.ToolTipLeave);
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
            this.tlpTime.Size = new System.Drawing.Size(258, 38);
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
            this.lbTimeText.Size = new System.Drawing.Size(77, 38);
            this.lbTimeText.TabIndex = 0;
            this.lbTimeText.Text = "Time:";
            this.lbTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTimeText.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.lbTimeText.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // lbTimeValue
            // 
            this.lbTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeValue.ForeColor = System.Drawing.Color.White;
            this.lbTimeValue.Location = new System.Drawing.Point(77, 0);
            this.lbTimeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lbTimeValue.Name = "lbTimeValue";
            this.lbTimeValue.Size = new System.Drawing.Size(181, 38);
            this.lbTimeValue.TabIndex = 1;
            this.lbTimeValue.Text = "00:00:00/00:00:00";
            this.lbTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTimeValue.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.lbTimeValue.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // tmMain
            // 
            this.tmMain.Enabled = true;
            this.tmMain.Interval = 1000;
            this.tmMain.Tick += new System.EventHandler(this.tmMain_Tick);
            // 
            // tmWindRewind
            // 
            this.tmWindRewind.Enabled = true;
            this.tmWindRewind.Tick += new System.EventHandler(this.tmWindRewind_Tick);
            // 
            // PlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(903, 658);
            this.Controls.Add(this.tlpPopDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPlayer";
            this.Text = "vamp#";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            this.Shown += new System.EventHandler(this.PlayerForm_Shown);
            this.SizeChanged += new System.EventHandler(this.PlayerForm_SizeChanged);
            this.tlpPopDown.ResumeLayout(false);
            this.tlpVolume.ResumeLayout(false);
            this.pnButtons.ResumeLayout(false);
            this.pnPlayPause.ResumeLayout(false);
            this.tlpTime.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPopDown;
        private System.Windows.Forms.Panel pnButtons;
        private System.Windows.Forms.Panel btnSeekEnd;
        private System.Windows.Forms.Panel btnWindForward;
        private System.Windows.Forms.Panel btnStop;
        private System.Windows.Forms.Panel pnPlayPause;
        private System.Windows.Forms.Panel btnPlay;
        private System.Windows.Forms.Panel btnPause;
        private System.Windows.Forms.Panel btnWindBackward;
        private System.Windows.Forms.Panel btnSeekStart;
        private System.Windows.Forms.Timer tmMain;
        private System.Windows.Forms.TableLayoutPanel tlpVolume;
        private System.Windows.Forms.Panel btnVolume;
        private MB.Controls.ColorSlider sliderVolume;
        private System.Windows.Forms.TableLayoutPanel tlpTime;
        private System.Windows.Forms.Label lbTimeValue;
        private System.Windows.Forms.Label lbTimeText;
        private System.Windows.Forms.Panel btnSelectSubtitle;
        private MB.Controls.ColorSlider sliderPosition;
        private System.Windows.Forms.Timer tmWindRewind;
        private System.Windows.Forms.Label lbToolTip;
    }
}

