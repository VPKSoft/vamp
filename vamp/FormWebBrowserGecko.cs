#region License
/*
vamp#

A software for video audio and photo playback.
Copyright © 2018 VPKSoft, Petteri Kautonen

Contact: vpksoft@vpksoft.net

This file is part of vamp#.

vamp# is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

vamp# is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with vamp#.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Windows.Forms;
using Gma.System.MouseKeyHook; // (C): https://github.com/gmamaladze/globalmousekeyhook, MIT license
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.VisualUtils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using Gecko; // (C): https://bitbucket.org/geckofx/geckofx-45.0, Mozilla Public License
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A full screen web browser window (Gecko based).
    /// </summary>
    public partial class FormWebBrowserGecko : DBLangEngineWinforms
    {
        // Useless code: private read-only ChromiumWebBrowser browser = null; // A ChromiumWebBrowser class..
        GeckoWebBrowser browser = new GeckoWebBrowser { Dock = DockStyle.Fill };

        private string startURL = null; // the starting URL the browser was displayed with..

        #region MassiveConstructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="FormWebBrowserGecko"/> class.
        /// </summary>
        /// <param name="URL">The URL to show in the Gecko-based web browser control as string.</param>
        /// <param name="homeButton">An indicator whether to show the home button on the browser bar.</param>
        public FormWebBrowserGecko(string URL, bool homeButton = true)
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            Controls.Add(browser); // add the Gecko Web Browser to the form's controls
            browser.Navigate(URL);
            startURL = URL;

            browser.Navigated += Browser_Navigated; // subscribe to an event to a browser URL changed..
            browser.NavigationError += Browser_NavigationError; // subscribe to an event to a browser "error"..
            browser.CanGoBackChanged += Browser_CanGoBackwardFormardChanged; // the state if navigation backwards has changed..
            browser.CanGoForwardChanged += Browser_CanGoBackwardFormardChanged; // the state if navigation forwards has changed..

            m_GlobalHook = Hook.GlobalEvents(); // The Gecko Web Browser prevents the Form from getting mouse signals, so we add this (Gma.System.MouseKeyHook) event handler..
                                                // (C): https://github.com/gmamaladze/globalmousekeyhook, MIT license

            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove; // Add a global MouseMove event..
            m_GlobalHook.MouseDown += M_GlobalHook_MouseDown; // Add a global MouseDown event..
            m_GlobalHook.KeyDown += GlobalKeyDown; // Add a global KeyDown event..

            lbToolTip.Text = string.Empty; // No too-tip as there is nothing to show at this time..

            if (!homeButton) // if home button is disabled..
            {
                // ..set the indices accordingly..
                btnCloseBrowser.Tag = 3;
                btnBrowserHome.Tag = -1;
            }

            SetButtonImages(); // Set the control buttons states to match the browser's state..
        }
        #endregion

        #region GeckoWebBrowserEvents
        // the browser navigated to an URL..
        private void Browser_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
            // set the button states..
            SetButtons();
        }

        // the browsers state of whether backwards or forwards navigation has changed..
        private void Browser_CanGoBackwardFormardChanged(object sender, EventArgs e)
        {
            // set the button states..
            SetButtons();
        }

        /// <summary>
        /// Sets the button states depending on the browser's state.
        /// </summary>
        private void SetButtons()
        {
            if (this.IsHandleCreated) // an exception might occur: "Invoke or BeginInvoke cannot be called on a control until the window handle has been created."
            {
                this.Invoke(new MethodInvoker(delegate () // Set the button states with an invoke call as the browser runs in a different thread..
                {
                    SetButtonStates(); // sets the button states to enabled / disabled depending on the browser component's state..
                }
                ));
            }
            else
            {
                SetButtonStates(); // sets the button states to enabled / disabled depending on the browser component's state..
            }
        }

        private void Browser_NavigationError(object sender, Gecko.Events.GeckoNavigationErrorEventArgs e)
        {
            VPKSoft.ErrorLogger.ExceptionLogger.LogMessage("Invalid URL: " + e.Uri); // Log the browser's invalid URL..

            if (this.IsHandleCreated) // an exception might occur: "Invoke or BeginInvoke cannot be called on a control until the window handle has been created."
            {
                this.Invoke(new MethodInvoker(delegate () // Set the button states with an invoke call as the browser runs in a different thread..
                {
                    lbUrl.Text = // show a message int the URL label that the navigation failed..
                        string.Format(
                            DBLangEngine.GetMessage(
                                "msgInvalidURL", "The given URL is invalid: '{0}'.|A navigation error occurred in a web browser form."),
                            e.Uri);
                }
                ));
            }
        }
        #endregion

        #region Misc
        private void WebBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (browser) // Dispose..
            {
                browser.Navigated -= Browser_Navigated; // release the event handlers..
                browser.NavigationError -= Browser_NavigationError;
                browser.CanGoBackChanged -= Browser_CanGoBackwardFormardChanged;
                browser.CanGoForwardChanged -= Browser_CanGoBackwardFormardChanged;
            }

            try
            {
                using (m_GlobalHook) // dispose more..
                {
                    m_GlobalHook.MouseMove -= M_GlobalHook_MouseMove; // release the event handlers..
                    m_GlobalHook.MouseDown -= M_GlobalHook_MouseDown;
                    m_GlobalHook.KeyDown -= GlobalKeyDown;
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);

                // And again: I don't have the time to care about this..more..
            }
        }

        private void WebBrowserForm_Shown(object sender, EventArgs e)
        {
            // create a "suitable" size for the pop-up "tool bar"..
            tlpPopDown.Height = (int)(((double)Height) * 0.14);
            ResizeButtons(); // Do resize and align the browser related buttons to a "right" size..
            HidePopDown(); // Hide the browser control button bar..
        }
        #endregion

        #region Layout
        // remove s the "buttons" from the parent panel if their index (Tag) equals -1..
        void RemoveHiddenButtons()
        {
            for (int i = pnButtons.Controls.Count - 1; i >= 0; i--)
            {
                if (pnButtons.Controls[i].GetType() != typeof(Panel)) // We use Panel class instances as buttons..
                {
                    continue; // So, if not panel then do nothing..
                }

                // remove the hidden "button"..
                if (pnButtons.Controls[i].Tag.ToString() == "-1")
                {
                    pnButtons.Controls.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Does to resizing of the browser control buttons to scale for the current screen resolution (full screen).
        /// </summary>
        private void ResizeButtons()
        {
            RemoveHiddenButtons(); // remove the "disabled" buttons from their parent panel..

            int spacing = 1920 / 100 + 1; // my screen width.. voodoo and/or hoodoo magic :-)
            int leftStart = Width - (pnButtons.Height * pnButtons.Controls.Count) - (pnButtons.Controls.Count * spacing); // Calculate the most left position for the browser control buttons
            leftStart /= 2; // some division for some reason
            foreach (Control ctrl in pnButtons.Controls) // Go thought the browser control buttons
            {
                if (ctrl.GetType() != typeof(Panel)) // We use Panel class instances as buttons..
                {
                    continue; // So, if not panel then do nothing..
                }

                (ctrl as Panel).Top = 0;
                (ctrl as Panel).Width = pnButtons.Height; // The height is the correct value for width and height to make a square button (Panel)
                (ctrl as Panel).Height = pnButtons.Height;
                (ctrl as Panel).Left = leftStart +
                    Convert.ToInt32((ctrl as Panel).Tag.ToString()) * pnButtons.Height + // pnButtons is anchored, so it will give us the correct height for the buttons
                    Convert.ToInt32((ctrl as Panel).Tag.ToString()) * spacing; // add some space between the browser control buttons..
                                                                               // The ordering of the buttons is indicated by their Tag value, so use it for calculation too..
            }

            tlpPopDown.ColumnStyles[0].Width = leftStart / 2; // Span the right and left outer-most columns of the TableLayoutPanel..
            tlpPopDown.ColumnStyles[tlpPopDown.ColumnCount - 1].Width = leftStart / 2; // ..
            UtilsMisc.ResizeFontWidthHeight(lbUrl); // Resize the labels fonts
            UtilsMisc.ResizeFontHeight(lbToolTip, true); // END: Resize the labels fonts
        }
        #endregion

        #region ToolTips
        // Messages for the translated tool-tips
        private void ToolTipEnter(object sender, EventArgs e)
        {
            string toolTip = string.Empty;
            if (sender.Equals(btnBack))
            {
                toolTip = DBLangEngine.GetMessage("msgBrowserBack", "Back|A tool-tip for a browser back button");
            }
            else if (sender.Equals(btnForward))
            {
                toolTip = DBLangEngine.GetMessage("msgBrowserForward", "Forward|A tool-tip for a browser forward button");
            }
            else if (sender.Equals(btnRefresh))
            {
                toolTip = DBLangEngine.GetMessage("msgBrowserRefresh", "Refresh|A tool-tip for a browser refresh button");
            }
            else if (sender.Equals(btnCloseBrowser))
            {
                toolTip = DBLangEngine.GetMessage("msgBrowserExit", "Exit|A tool-tip for a browser exit button");
            }
            else if (sender.Equals(lbUrl))
            {
                toolTip = DBLangEngine.GetMessage("msgUrl", "URL|A tool-tip for a browser URL address");
            }
            else if (sender.Equals(btnBrowserHome))
            {
                toolTip = DBLangEngine.GetMessage("msgBrowserHome", "Home|A tool tip to indicate that the browser navigates to the page it was started from");
            }

            lbToolTip.Text = toolTip;
        }

        // when no tool-tip should be shown
        private void ToolTipLeave(object sender, EventArgs e)
        {
            lbToolTip.Text = string.Empty;
        }
        #endregion

        #region GUILogic
        /// <summary>
        /// Sets the button images (Panel) to indicate their enabled/disabled state..
        /// </summary>
        private void SetButtonImages()
        {
            btnBack.BackgroundImage = // browser back button image..
                btnBack.Enabled ? Properties.Resources.back :
                UtilsMisc.MakeGrayscale3(Properties.Resources.back);

            btnForward.BackgroundImage =  // browser forward button image..
                btnForward.Enabled ? Properties.Resources.forward :
                UtilsMisc.MakeGrayscale3(Properties.Resources.forward);
        }

        // Handle all the button clicks (Panel).
        private void CommonClickHandler(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Panel)) // only accept panels..
            {
                return;
            }

            Panel btn = (sender as Panel);

            if (btn.Equals(btnCloseBrowser)) // if the close button was clicked..
            {
                Close(); // .. do close the form
            }
            else if (btn.Equals(btnRefresh)) // if the wind forward was clicked..
            {
                browser.Reload();
            }
            else if (btn.Equals(btnBack))
            {
                browser.GoBack();
            }
            else if (btn.Equals(btnForward))
            {
                browser.GoForward();
            }
            else if (btn.Equals(btnBrowserHome))
            {
                browser.Navigate(startURL);
            }
        }

        /// <summary>
        /// Sets the button states to enabled / disabled depending on the browser state.
        /// </summary>
        private void SetButtonStates()
        {
            btnForward.Enabled = browser.CanGoForward; // if forward navigation is possible in the browser..
            btnBack.Enabled = browser.CanGoBack; // if backward navigation is possible in the browser..
            lbUrl.Text = browser.Url.ToString();

            SetButtonImages(); // set the button images..
        }

        private void GlobalKeyDown(object sender, KeyEventArgs e)
        {
            if (ActiveForm == null) // do nothing if the application is inactive..
            {
                return;
            }

            if (e.KeyCode == Keys.Escape) // The form needs to be closed..
            {
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
                Close();
            }
            else if (
                (e.KeyCode == Keys.Back && (!e.Alt && !e.Shift && !e.Control)) ||
                (e.KeyCode == Keys.Left && (e.Alt && !e.Shift && !e.Control)) ||
                (e.KeyCode == Keys.BrowserBack && !e.Alt && !e.Control && !e.Shift))
            {
              browser.GoBack();
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
            }
            else if ((e.KeyCode == Keys.Back && (!e.Alt && e.Shift && !e.Control)) ||
                    (e.KeyCode == Keys.Right && (e.Alt && !e.Shift && !e.Control)) ||
                    (e.KeyCode == Keys.BrowserForward && !e.Alt && !e.Control && !e.Shift))
            {
               browser.GoForward();
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
            }
            else if (e.KeyCode == Keys.F5 && !e.Alt && !e.Shift)
            {
                if (e.Control)
                {
                    browser.Reload(GeckoLoadFlags.BypassCache);
                }
                else
                {
                    browser.Reload();
                }
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
            }
            else if ((e.KeyCode == Keys.Home && (!e.Control && !e.Shift && e.Alt)) ||
                     (e.KeyCode == Keys.BrowserHome && (!e.Control && !e.Shift && !e.Alt)))
            {
                browser.Navigate(startURL);
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
            }
        }
        #endregion

        #region BrowserBar
        private IKeyboardMouseEvents m_GlobalHook = null;

        // Mouse button was clicked over the form..
        private void M_GlobalHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActiveForm == null) // do nothing if the application is inactive..
            {
                return;
            }

            if (!popupHidden) // If the bottom browser control bar is visible..
            {
                return; // .. then we do nothing..
            }
        }

        // Handle mouse moving over the form.
        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (ActiveForm == null) // do nothing if the application is inactive..
            {
                return;
            }

            if (!popupHidden && e.Y >= tlpPopDown.Top) // If the pop-up browser control bar is not hidden and the cursor hovers over it..
            {
                return; // .. we can return
            }

            if (e.Y >= Height - 20) // Show the pop-up browser control bar, if the mouse cursor is less than 20 pixels from the bottom of the screen..
            {
                ShowPopDown(); // Show the pop-up browser control bar..
            }
            else
            {
                HidePopDown(); // Hide the pop-up browser control bar..
            }
        }

        private bool popupHidden = false; // This will be set to indicate if the browser control bar is visible or not.

        /// <summary>
        /// Hides the "pop-up" browser control bar..
        /// </summary>
        private void HidePopDown()
        {
            if (popupHidden) // If already hidden, there is no need to hide it
            {
                return;
            }

            popupHidden = true; // We need to know if the browser control bar is hidden or not..

            tlpPopDown.Anchor = AnchorStyles.None; // Set its position of the screen
            tlpPopDown.Left = 0;
            tlpPopDown.Width = Width;
            tlpPopDown.Top = Height;
            ResizeButtons(); // Do resize and align the browser related buttons to a "right" size..
            tlpPopDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        /// <summary>
        /// Shows the "pop-up" browser control bar..
        /// </summary>
        private void ShowPopDown()
        {
            if (!popupHidden) // If already visible, there is no need to show it
            {
                return;
            }

            SetButtonStates(); // sets the button states to enabled / disabled depending on the browser component's state..

            popupHidden = false; // We need to know if the browser control bar is hidden or not..


            tlpPopDown.Anchor = AnchorStyles.None; // Set its position on the screen
            tlpPopDown.Left = 0;
            tlpPopDown.Width = Width;
            tlpPopDown.Top = Height - tlpPopDown.Height;
            ResizeButtons(); // Do resize and align the browser related buttons to a "right" size..
            tlpPopDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }
        #endregion
    }
}
