namespace vamp
{
    partial class FormWebBrowserChromium
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebBrowserChromium));
            this.tlpPopDown = new System.Windows.Forms.TableLayoutPanel();
            this.lbToolTip = new System.Windows.Forms.Label();
            this.pnButtons = new System.Windows.Forms.Panel();
            this.lbUrl = new System.Windows.Forms.Label();
            this.btnBrowserHome = new System.Windows.Forms.Panel();
            this.btnCloseBrowser = new System.Windows.Forms.Panel();
            this.btnForward = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Panel();
            this.tlpPopDown.SuspendLayout();
            this.pnButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPopDown
            // 
            this.tlpPopDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPopDown.BackColor = System.Drawing.Color.Black;
            this.tlpPopDown.ColumnCount = 5;
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPopDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpPopDown.Controls.Add(this.lbToolTip, 2, 2);
            this.tlpPopDown.Controls.Add(this.pnButtons, 0, 1);
            this.tlpPopDown.Controls.Add(this.lbUrl, 1, 0);
            this.tlpPopDown.Location = new System.Drawing.Point(0, 491);
            this.tlpPopDown.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPopDown.Name = "tlpPopDown";
            this.tlpPopDown.RowCount = 3;
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpPopDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPopDown.Size = new System.Drawing.Size(903, 167);
            this.tlpPopDown.TabIndex = 3;
            // 
            // lbToolTip
            // 
            this.lbToolTip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToolTip.ForeColor = System.Drawing.Color.Yellow;
            this.lbToolTip.Location = new System.Drawing.Point(235, 143);
            this.lbToolTip.Margin = new System.Windows.Forms.Padding(0);
            this.lbToolTip.Name = "lbToolTip";
            this.lbToolTip.Size = new System.Drawing.Size(473, 24);
            this.lbToolTip.TabIndex = 21;
            this.lbToolTip.Text = "/* TOOL-TIP SHOWS HERE */";
            this.lbToolTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnButtons
            // 
            this.pnButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPopDown.SetColumnSpan(this.pnButtons, 5);
            this.pnButtons.Controls.Add(this.btnBrowserHome);
            this.pnButtons.Controls.Add(this.btnCloseBrowser);
            this.pnButtons.Controls.Add(this.btnForward);
            this.pnButtons.Controls.Add(this.btnBack);
            this.pnButtons.Controls.Add(this.btnRefresh);
            this.pnButtons.Location = new System.Drawing.Point(0, 38);
            this.pnButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnButtons.Name = "pnButtons";
            this.pnButtons.Size = new System.Drawing.Size(903, 105);
            this.pnButtons.TabIndex = 3;
            // 
            // lbUrl
            // 
            this.lbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUrl.AutoSize = true;
            this.tlpPopDown.SetColumnSpan(this.lbUrl, 3);
            this.lbUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lbUrl.ForeColor = System.Drawing.Color.White;
            this.lbUrl.Location = new System.Drawing.Point(23, 0);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(854, 38);
            this.lbUrl.TabIndex = 22;
            this.lbUrl.Text = "http://www.vpksoft.net";
            this.lbUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUrl.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.lbUrl.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnYoutubeHome
            // 
            this.btnBrowserHome.BackgroundImage = global::vamp.Properties.Resources.browser_home;
            this.btnBrowserHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBrowserHome.Location = new System.Drawing.Point(491, 12);
            this.btnBrowserHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnBrowserHome.Name = "btnBrowserHome";
            this.btnBrowserHome.Size = new System.Drawing.Size(125, 80);
            this.btnBrowserHome.TabIndex = 25;
            this.btnBrowserHome.Tag = "3";
            this.btnBrowserHome.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnBrowserHome.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnBrowserHome.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnCloseBrowser
            // 
            this.btnCloseBrowser.BackgroundImage = global::vamp.Properties.Resources.web_button_exit;
            this.btnCloseBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCloseBrowser.Location = new System.Drawing.Point(652, 12);
            this.btnCloseBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.btnCloseBrowser.Name = "btnCloseBrowser";
            this.btnCloseBrowser.Size = new System.Drawing.Size(125, 80);
            this.btnCloseBrowser.TabIndex = 24;
            this.btnCloseBrowser.Tag = "4";
            this.btnCloseBrowser.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnCloseBrowser.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnCloseBrowser.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnForward
            // 
            this.btnForward.BackgroundImage = global::vamp.Properties.Resources.forward;
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnForward.Enabled = false;
            this.btnForward.Location = new System.Drawing.Point(182, 5);
            this.btnForward.Margin = new System.Windows.Forms.Padding(0);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(125, 80);
            this.btnForward.TabIndex = 22;
            this.btnForward.Tag = "1";
            this.btnForward.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnForward.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnForward.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::vamp.Properties.Resources.back;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.Enabled = false;
            this.btnBack.Location = new System.Drawing.Point(31, 5);
            this.btnBack.Margin = new System.Windows.Forms.Padding(0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 80);
            this.btnBack.TabIndex = 21;
            this.btnBack.Tag = "0";
            this.btnBack.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnBack.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnBack.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::vamp.Properties.Resources.web_refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Location = new System.Drawing.Point(326, 5);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 80);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Tag = "2";
            this.btnRefresh.Click += new System.EventHandler(this.CommonClickHandler);
            this.btnRefresh.MouseEnter += new System.EventHandler(this.ToolTipEnter);
            this.btnRefresh.MouseLeave += new System.EventHandler(this.ToolTipLeave);
            // 
            // FormWebBrowserChromium
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(903, 658);
            this.Controls.Add(this.tlpPopDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormWebBrowserChromium";
            this.ShowInTaskbar = false;
            this.Text = "WebBrowserForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebBrowserForm_FormClosing);
            this.Shown += new System.EventHandler(this.WebBrowserForm_Shown);
            this.tlpPopDown.ResumeLayout(false);
            this.tlpPopDown.PerformLayout();
            this.pnButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPopDown;
        private System.Windows.Forms.Label lbToolTip;
        private System.Windows.Forms.Panel pnButtons;
        private System.Windows.Forms.Panel btnRefresh;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.Panel btnForward;
        private System.Windows.Forms.Panel btnBack;
        private System.Windows.Forms.Panel btnCloseBrowser;
        private System.Windows.Forms.Panel btnBrowserHome;
    }
}