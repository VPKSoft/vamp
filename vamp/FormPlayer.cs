#region License
/*
vamp#

A software for video audio and photo playback.
Copyright © 2019 VPKSoft, Petteri Kautonen

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
using Vlc.DotNet.Core; // (C): https://github.com/ZeBobo5/Vlc.DotNet, MIT license
using Vlc.DotNet.Forms; // (C): https://github.com/ZeBobo5/Vlc.DotNet, MIT license
using System.IO;
using Gma.System.MouseKeyHook; // (C): https://github.com/gmamaladze/globalmousekeyhook, MIT license
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.VisualUtils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A form using Vlc.DotNet which plays video files, streams and other video media formats.
    /// </summary>
    public partial class FormPlayer : DBLangEngineWinforms
    {
        #region Initialization
        VlcControl vlcControl; // The actual VLC media playback control

        // These are valid parameters for the VlcControl.SetMedia() method overloads..
        FileInfo file = null;
        Stream stream = null;
        string mrl = null;
        Uri uri = null;
        string[] options = null;
        volatile VideoFileStatistic statistic = null; // video file statistics from the database (position, volume value, etc..)
        volatile bool statisticsLoaded = false; // to indicate that the video statistics were loaded from the database
                                                // END: These are valid parameters for the VlcControl.SetMedia() method overloads..


        /// <summary>
        /// Initialize the VlcControl with a FileInfo class instance.
        /// </summary>
        /// <param name="file">A FileInfo class instance to initialize the VlcControl with.</param>
        /// <param name="formPlayer">An instance of the FormPlayer class if one was created.</param>
        /// <param name="options">These are "command line arguments" given to the VlcControl as with the VLC Media Player.</param>
        /// <returns>True if the VlcControl.SetMedia() call was successful, otherwise false (an exception occurred).</returns>
        public static bool InitPlayerForm(FileInfo file, out FormPlayer formPlayer, params string[] options)
        {
            try
            {
                // create a new instance of the FormPlayer form..
                FormPlayer frm = new FormPlayer
                {
                    // set the form's statistic field's value with value gotten
                    // from the database with the file's full name..
                    statistic = Database.GetStatistic(file.FullName)
                };

                // execute a playback dialog if the video was not watched to the end..
                long position = FormDialogSelectPlaybackPosition.Execute(frm.statistic); 
                frm.statistic.Position = position; // give a playback position to the video playback form..
                frm.statisticsLoaded = true; // indicate to the form that the video file statistics have been loaded..

                frm.options = options;
                frm.file = file;
                formPlayer = frm; // set the out parameter's value..
                frm.Show();
                return true;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);

                formPlayer = null; // set the out parameter's value..
                return false;
            }
        }

        /// <summary>
        /// Initialize the VlcControl for the first time to avoid load delay.
        /// </summary>
        /// <returns>True if the form initialization was successful, otherwise false (an exception occurred).</returns>
        public static bool InitPlayerForm()
        {
            try
            {
                // create a new instance of the FormPlayer form..
                FormPlayer frm = new FormPlayer
                {
                    options = new string[] { }
                };
                frm.tmMain.Enabled = false; // no timers this time..
                frm.tmWindRewind.Enabled = false; // .. again no timers this time..
                frm.DoDispose(); // dispose..
                return true;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);

                return false;
            }
        }

        /// <summary>
        /// Initialize the VlcControl with a Stream class instance.
        /// </summary>
        /// <param name="stream">A Stream class instance to initialize the VlcControl with.</param>
        /// <param name="formPlayer">An instance of the FormPlayer class if one was created.</param>
        /// <param name="options">These are "command line arguments" given to the VlcControl as with the VLC Media Player.</param>
        /// <returns>True if the VlcControl.SetMedia() call was successful, otherwise false (an exception occurred).</returns>
        public static bool InitPlayerForm(Stream stream, out FormPlayer formPlayer, params string[] options)
        {
            try
            {
                // create a new instance of the FormPlayer form..
                FormPlayer frm = new FormPlayer
                {
                    options = options,
                    stream = stream
                };
                formPlayer = frm; // set the out parameter's value..
                frm.Show();
                return true;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);

                formPlayer = null; // set the out parameter's value..
                return false;
            }
        }

        /// <summary>
        /// Initialize the VlcControl with a mrl string.
        /// </summary>
        /// <param name="mrl">A mrl string to initialize the VlcControl with.</param>
        /// <param name="formPlayer">An instance of the FormPlayer class if one was created.</param>
        /// <param name="options">These are "command line arguments" given to the VlcControl as with the VLC Media Player.</param>
        /// <returns>True if the VlcControl.SetMedia() call was successful, otherwise false (an exception occurred).</returns>
        public static bool InitPlayerForm(string mrl, out FormPlayer formPlayer, params string[] options)
        {
            try
            {
                // create a new instance of the FormPlayer form..
                FormPlayer frm = new FormPlayer
                {
                    options = options,
                    mrl = mrl
                };
                formPlayer = frm; // set the out parameter's value..
                frm.Show();
                return true;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);

                formPlayer = null; // set the out parameter's value..
                return false;
            }
        }

        /// <summary>
        /// Initialize the VlcControl with an Uri class instance.
        /// </summary>
        /// <param name="uri">An Uri class instance to initialize the VlcControl with.</param>
        /// <param name="formPlayer">An instance of the FormPlayer class if one was created.</param>
        /// <param name="options">These are "command line arguments" given to the VlcControl as with the VLC Media Player.</param>
        /// <returns>True if the VlcControl.SetMedia() call was successful, otherwise false (an exception occurred).</returns>
        public static bool InitPlayerForm(Uri uri, out FormPlayer formPlayer, params string[] options)
        {
            try
            {
                // create a new instance of the FormPlayer form..
                FormPlayer frm = new FormPlayer
                {
                    options = options,
                    uri = uri
                };
                formPlayer = frm; // set the out parameter's value..
                frm.Show();
                return true;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);

                formPlayer = null; // set the out parameter's value..
                return false;
            }
        }

        private bool startPlay = false; // If no media was set a file dialog is shown instead when the play button is clicked..

        /// <summary>
        /// Calls the VlcControl.SetMedia() method with the proper internal parameter collection given with the PlayerForm.InitPlayerForm() method's overload.
        /// <para/>If no media was set (PlayerForm.InitPlayerForm() was not called), the play button justs shows a file dialog to select a file to play.
        /// </summary>
        private void SetMedia()
        {
            if (file != null) // If the FileInfo overload of the PlayerForm.InitPlayerForm() was called, call the proper VlcControl.SetMedia() method overload..
            {
                vlcControl.SetMedia(file, options);
                startPlay = true; // indicates that the playback can be started..
            }
            else if (stream != null) // If the Stream overload of the PlayerForm.InitPlayerForm() was called, call the proper VlcControl.SetMedia() method overload..
            {
                vlcControl.SetMedia(stream, options);
                startPlay = true; // indicates that the playback can be started..
            }
            else if (uri != null) // If the Uri overload of the PlayerForm.InitPlayerForm() was called, call the proper VlcControl.SetMedia() method overload..
            {
                vlcControl.SetMedia(uri, options);
                startPlay = true; // indicates that the playback can be started..
            }
            else if (mrl != null) // If the mrl string overload of the PlayerForm.InitPlayerForm() was called, call the proper VlcControl.SetMedia() method overload..
            {
                vlcControl.SetMedia(mrl, options);
                startPlay = true; // indicates that the playback can be started..
            }

            if (startPlay) // If some call to the overloaded PlayerForm.InitPlayerForm() method was made, the playback can be started..
            {
                vlcControl.Play();
                SetPlayBackControlsEnabled(); // set the playback controls as enabled after the playback is started..
                SetButtonImages(); // set the button images..

                vlcControl.Playing += VlcControl_Playing;
            }
        }

        private void VlcControl_Playing(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            if (file != null && !statisticsLoaded)
            {
                statisticsLoaded = true;
                statistic = Database.GetStatistic(file.FullName);
            }
        }
        #endregion

        #region MassiveConstructor
        /// <summary>
        /// The PlayerForm class constructor.
        /// </summary>
        public FormPlayer()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            vlcControl = new VlcControl(); // Create the actual VLC Player control..
            this.Controls.Add(vlcControl); // Add the control to the form..
            vlcControl.Dock = DockStyle.Fill; // ..dock it to fill the form

            if (Environment.Is64BitProcess) // Depending on the processor architecture (a 64 or 32 bits of this process) a library path needs to be chosen
            {
                vlcControl.VlcLibDirectory = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath) + @"\libvlc_x64\");
            }
            else
            {
                vlcControl.VlcLibDirectory = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath) + @"\libvlc_x86\");
            }

            if (!vlcControl.VlcLibDirectory.Exists) // Check, if the VLC library path exists and complain, if it doesn't..
            {
                MessageBox.Show(DBLangEngine.GetMessage("msgVLCLibMissing", "The VLC Library is missing. The playback will be aborted.|As in the VLC library (dll's and stuff) is missing, so no video playback will occur!"), DBLangEngine.GetMessage("msgError", "Error|A message describing that some kind of error occurred."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (vlcControl) // Dispose the VLC control and return.. there is nothing more to do here..
                {
                    return;
                }
            }

            vlcControl.EncounteredError += VlcControl_EncounteredError;

            vlcControl.EndInit(); // This must be called, otherwise exceptions will get thrown..

            SetButtonImages(); // set the button images..

            lbToolTip.Text = string.Empty; // Hide the useless design time tool-tip..

            vlcControl.Stopped += VlcControl_Stopped; // The playback stopped.. this indicates that the media was watched to the end, so the form will close.

            SetMedia(); // Set the playback source with options for the VLCControl..
        }
        #endregion

        #region PlaybackBar
        private IKeyboardMouseEvents m_GlobalHook = null;

        // Mouse button was clicked over the form..
        private void M_GlobalHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActiveForm == null) // do nothing if the application is inactive..
            {
                return;
            }

            if (!popupHidden) // If the bottom playback bar is visible..
            {
                return; // .. then we do nothing..
            }

            if (e.Button == MouseButtons.Left) // Toggle the pause state of the playback if the Form was clicked..
            {
                TogglePause();
            }
        }

        // Handle mouse moving over the form.
        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (ActiveForm == null) // do nothing if the application is inactive..
            {
                return;
            }

            secondsCount = 0; // Zero the mouse hide (seconds) counter.. and also the playback bar hiding..
            if (cursorHidden) // If the mouse cursor is hidden, then make it visible again..
            {
                cursorHidden = false; // We should no if the mouse cursor is visible or not..
                Cursor.Show(); // Show the mouse cursor..
            }

            if (!popupHidden && e.Y >= tlpPopDown.Top) // If the pop-up playback bar is not hidden and the cursor hovers over it..
            {
                return; // .. we can return
            }

            if (e.Y >= Height - 20) // Show the pop-up playback bar, if the mouse cursor is less than 20 pixels from the bottom of the screen..
            {
                ShowPopDown(); // Show the pop-up playback bar..
            }
            else
            {
                HidePopDown(); // Hide the pop-up playback bar..
            }
        }

        private bool popupHidden = false; // This will be set to indicate if the playback bar is visible or not.

        /// <summary>
        /// Hides the "pop-up" playback bar..
        /// </summary>
        private void HidePopDown()
        {
            if (popupHidden) // If already hidden, there is no need to hide it
            {
                return;
            }

            popupHidden = true; // We need to know if the playback bar is hidden or not..

            tlpPopDown.Anchor = AnchorStyles.None; // Set its position of the screen
            tlpPopDown.Left = 0;
            tlpPopDown.Width = Width;
            tlpPopDown.Top = Height;
            ResizeButtons(); // Do resize and align the playback related buttons to a "right" size..
            tlpPopDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        /// <summary>
        /// Shows the "pop-up" playback bar..
        /// </summary>
        private void ShowPopDown()
        {
            if (!popupHidden) // If already visible, there is no need to show it
            {
                return;
            }

            popupHidden = false; // We need to know if the playback bar is hidden or not..


            tlpPopDown.Anchor = AnchorStyles.None; // Set its position on the screen
            tlpPopDown.Left = 0;
            tlpPopDown.Width = Width;
            tlpPopDown.Top = Height - tlpPopDown.Height;
            ResizeButtons(); // Do resize and align the playback related buttons to a "right" size..
            tlpPopDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        /// <summary>
        /// Sets the slider position to match the playback position.
        /// </summary>
        private void SetTimeSliderPosition()
        {
            if (vlcControl.Length < 0) // no media.. so an exception would be thrown if the sliders maximum would be smaller than it's value..
            {
                return; // .. so do nothing
            }

            sliderPosition.Scroll -= sliderPosition_Scroll; // detach the event handler, so the slider does not launch the scroll event..
            try // We try if invalid values have been coming..
            {
                sliderPosition.Value = 0;
                sliderPosition.Minimum = -1;
                sliderPosition.Maximum = (int)(vlcControl.Length / 1000); // use seconds instead of milliseconds..
                sliderPosition.Value = (int)(vlcControl.Time / 1000); // .. here too
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);
            }
            sliderPosition.Scroll += sliderPosition_Scroll; // re-attach the event handler back..
        }
        #endregion

        #region Layout
        /// <summary>
        /// Does to resizing of the playback buttons to scale for the current screen resolution (full screen).
        /// </summary>
        private void ResizeButtons()
        {
            int spacing = 1920 / 100 + 1; // my screen width.. voodoo and/or hoodoo magic :-)
            int leftStart = Width - (pnButtons.Height * pnButtons.Controls.Count) - (pnButtons.Controls.Count * spacing); // Calculate the most left position for the playback buttons
            leftStart /= 2; // some division for some reason
            foreach (Control ctrl in pnButtons.Controls) // Go thought the playback buttons
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
                    Convert.ToInt32((ctrl as Panel).Tag.ToString()) * spacing; // add some space between the playback buttons..
                                                                               // The ordering of the buttons is indicated by their Tag value, so use it for calculation too..
            }

            tlpPopDown.ColumnStyles[0].Width = leftStart / 2; // Span the right and left outer-most columns of the TableLayoutPanel..
            tlpPopDown.ColumnStyles[tlpPopDown.ColumnCount - 1].Width = leftStart / 2; // ..
            UtilsMisc.ResizeFontWidthHeight(lbTimeText); // Resize the labels fonts
            UtilsMisc.ResizeFontWidthHeight(lbTimeValue);
            UtilsMisc.ResizeFontHeight(lbToolTip, true); // END: Resize the labels fonts
        }

        // As the form is laid out, do some more layout..
        private void PlayerForm_Shown(object sender, EventArgs e)
        {
            // create a "suitable" size for the pop-up "tool bar"..
            tlpPopDown.Height = (int)(((double)Height) * 0.14);
            SetMedia();
            ResizeButtons(); // Do resize and align the playback related buttons to a "right" size..
            HidePopDown(); // Hide the playback button bar..

            m_GlobalHook = Hook.GlobalEvents(); // The playback prevents the Form from getting mouse signals, so we add this (Gma.System.MouseKeyHook) event handler..
                                                // (C): https://github.com/gmamaladze/globalmousekeyhook, MIT license

            // hook these after the form has been shown,
            // otherwise an a slower computer the VLC video playback hasn't initialized yet causing exceptions..
            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove;
            m_GlobalHook.MouseDown += M_GlobalHook_MouseDown;
        }
        #endregion

        #region Misc
        private volatile bool closeForm = false; // volatile because the event comes from another thread, the VCL library.. and the timer will check it's value

        // The media has reached the end. So do close the form
        private void VlcControl_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            closeForm = true; // The PlayerForm can now be closed.
        }

        // An error occurred during the playback so close the form
        private void VlcControl_EncounteredError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            closeForm = true; // The PlayerForm can now be closed.
        }

        // Dispose the IDisposable.. when the form is closing..
        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoDispose(); // dispose..

            if (cursorHidden) // the cursor might not show at all..
            {
                Cursor.Show();
                cursorHidden = false;
            }
        }

        // Disposes the controls of this form..
        private void DoDispose()
        {
            try
            {
                using (vlcControl) // dispose..
                {
                    vlcControl.Stop(); // do stop the playback before disposing..
                }
            }
            catch (Exception ex)
            {
                // I don't have the time to care about this..

                // log the exception..
                ExceptionLogger.LogError(ex);
            }

            try
            {
                if (m_GlobalHook != null)
                {
                    using (m_GlobalHook) // dispose more..
                    {
                        m_GlobalHook.MouseMove -= M_GlobalHook_MouseMove; // release the event handlers..
                        m_GlobalHook.MouseDown -= M_GlobalHook_MouseDown;
                    }
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);

                // And again: I don't have the time to care about this..more..
            }
        }

        private void PlayerForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeButtons(); // Do resize and align the playback related buttons to a "right" size..
        }
        #endregion

        #region CustomEvents        
        /// <summary>
        /// A delegate for the PlaybackClosed event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="FormPlayerCloseEventArgs"/> instance containing the event data.</param>
        public delegate void OnPlaybackClosed(object sender, FormPlayerCloseEventArgs e);

        /// <summary>
        /// An event that is raised when the playback is closed/stopped and the FormPlayer instance is closed.
        /// </summary>
        public event OnPlaybackClosed PlaybackClosed = null;
        #endregion

        #region Timer
        private int secondsCount = 0; // A counter of how many seconds the mouse cursor remains visible
        private bool cursorHidden = false; // A value indicating whether the mouse cursor was hidden

        // a timer to monitor the playback, etc..
        private void tmMain_Tick(object sender, EventArgs e)
        {
            if (closeForm) // The VLC library has launched a signal from an event that the form can now be closed.
            {
                tmMain.Enabled = false; // Disable the timers from screwing up the form close..
                tmWindRewind.Enabled = false;
                if (file != null) // only update if a file was playing.. (an exception might occur)
                {
                    Database.UpdateFile(file.FullName, vlcControl.Time, vlcControl.Length, IsWacthed, Volume);
                }
                Close(); // Close the form.

                // raise the event if subscribed..
                PlaybackClosed?.Invoke(this, new FormPlayerCloseEventArgs() { FileInfo = file });

                return; // nothing to do here..
            }

            if (statisticsLoaded && statistic != null)
            {
                if (statistic.Position > 0) // if there is anything to adjust to the playback position as it's good to remember it..
                {
                    vlcControl.Playing -= VlcControl_Playing; // unsubscribe some events..

                    // calculate the percentage of the saved playback position..
                    double positionPercentage = ((double)statistic.Position * 100 / (double)vlcControl.Length);
                    if (positionPercentage >= 99.50) // .. and if it exceeds 99.5%, the jump to the start so the playback won't stop prematurely..
                    {
                        vlcControl.Time = 0; // .. 99.5 or more means a position of 0..
                    }
                    else
                    {
                        vlcControl.Time = statistic.Position; // ..otherwise continue the playback from the saved position..
                    }

                    sliderVolume.Scroll -= sliderVolume_Scroll; // unsubscribe some more events..
                    sliderVolume.Value = (int)statistic.Volume; // set the saved to the volume slider..
                    vlcControl.Audio.Volume = (int)statistic.Volume; // set the saved volume to the actual playback track..
                    sliderVolume.Scroll += sliderVolume_Scroll; // subscribe the events back..
                    vlcControl.Playing += VlcControl_Playing; // and subscribe more events back..
                }
                statisticsLoaded = false; // no forget that any statistics were ever loaded..
                statistic = null; // .. otherwise an endless loop might occur.
            }

            if (secondsCount > 10) // Hide the annoying mouse cursor..
            {
                tmMain.Enabled = false; // disable the timer while processing..
                if (!cursorHidden && popupHidden)
                {
                    Cursor.Hide();
                    cursorHidden = true;
                }
                secondsCount = 0;
                HidePopDown(); // we don't want to see this either as the mouse can be far-far away.. when sitting on the couch :-(
                tmMain.Enabled = true; // ..enable the timer after processed
            }

            tmMain.Enabled = false; // disable the timer while processing..
            secondsCount++; // increase the mouse cursor hide counter (seconds)..

            // Show the current playback time
            TimeSpan timeSpanTotal = new TimeSpan(0, 0, (int)vlcControl.Length / 1000);
            TimeSpan timeSpanPosition = new TimeSpan(0, 0, (int)vlcControl.Time / 1000);
            lbTimeValue.Text = timeSpanPosition.ToString(@"hh\:mm\:ss") + "/" + timeSpanTotal.ToString(@"hh\:mm\:ss");

            SetTimeSliderPosition(); // Sets the slider position to match the playback position..
            tmMain.Enabled = true; // ..enable the timer after processed
        }
        #endregion

        #region GUILogic
        /// <summary>
        /// Toggles the playback state between pause and play and shows the correct button for the playback state.
        /// </summary>
        private void TogglePause()
        {
            if (startPlay) // If the media has been set by calling the overloaded method VlcControl.SetMedia()
            {
                if (vlcControl.IsPlaying && !IsDvdMode()) // If the VlcControl class instance is playing, then pause.. (if not DVD (menus, etc.. --> can be annoying!))..
                {
                    vlcControl.Pause();
                    if (statistic != null) // this ensures that a saved playback will not be re-read from previous statistics..
                    {
                        statistic.Position = vlcControl.Time;
                    }

                    btnPlay.Visible = true; // Set the button visibility
                    btnPause.Visible = false;
                }
                else // .. if the VlcControl class instance's playback state is paused, then play..
                {
                    if (startPlay) // avoid the play command to reload the saved playback position..
                    {
                        Database.UpdateFile(file.FullName, vlcControl.Time, vlcControl.Length, IsWacthed, Volume);
                    }

                    if (statistic != null && file != null)
                    {
                        statistic.Position = vlcControl.Time;
                    } // END: avoid the play command to reload the saved playback position..

                    vlcControl.Play();
                    btnPlay.Visible = false; // Set the button visibility
                    btnPause.Visible = true;
                }
                wind = false; // don't wind while paused or play is clicked
                rewind = false; // don't rewind while paused or play is clicked
            }
        }

        /// <summary>
        /// Returns true if a DVD is being played.
        /// </summary>
        /// <returns></returns>
        private bool IsDvdMode()
        {
            if (mrl != null)
            {
                return mrl.StartsWith("dvd:///");
            }
            return false;
        }

        private bool IsWacthed
        {
            get
            {
                if (!startPlay)
                {
                    return false;
                }
                else
                {
                    double percentage = (double)vlcControl.Time * 100.0 / (double)vlcControl.Length;
                    return percentage >= 90.0;
                }
            }
        }

        private float Volume
        {
            get
            {
                if (!startPlay)
                {
                    return 100.0f;
                }
                else
                {
                    return ((float)sliderVolume.Value * 300.0f) / (float)sliderVolume.Maximum;
                }
            }
        }

        // Handle all the button clicks (Panel).
        private void CommonClickHandler(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Panel)) // only accept panels..
            {
                return;
            }

            Panel btn = (sender as Panel);

            if (btn.Equals(btnWindForward)) // if the wind forward was clicked..
            {
                wind = !wind; // toggle the state..
                rewind = false; // disable rewind to avoid "mental" state..
            }
            else if (btn.Equals(btnWindBackward)) // if the wind forward was clicked..
            {
                rewind = !rewind; // toggle the state..
                wind = false; // disable wind to avoid "mental" state..
            }
            else if (btn.Equals(btnPause))
            {
                TogglePause();
            }
            else if (btn.Equals(btnPlay))
            {
                if (wind || rewind)
                {
                    wind = false;
                    rewind = false;
                    if (!vlcControl.IsPlaying)
                    {
                        vlcControl.Play();
                    }
                }
                else if (!vlcControl.IsPlaying) // If pausing is possible..
                {
                    TogglePause(); // .. do the pause thing.
                }
            }
            else if (btn.Equals(btnStop)) // Stop button was clicked..
            {
                if (startPlay)
                {
                    Database.UpdateFile(file.FullName, vlcControl.Time, vlcControl.Length, IsWacthed, Volume);
                }
                closeForm = true; // signal the timer to close the form..
            }
            else if (btn.Equals(btnSeekStart)) // If to-the-beginning button was clicked
            {
                tmMain.Enabled = false; // disable the timer from doing it's job..
                // No winding/rewinding
                wind = false;
                rewind = false;
                vlcControl.Time = 0; // Back to start
                tmMain.Enabled = true; // .. enable the timer to do it's job.
            }
            else if (btn.Equals(btnSeekEnd)) // If to-the-ending button was clicked
            {
                tmMain.Enabled = false; // disable the timer from doing it's job..
                // No winding/rewinding
                wind = false;
                rewind = false;
                vlcControl.Time = vlcControl.Length - 1; // To the end
                tmMain.Enabled = true; // .. enable the timer to do it's job.
            }
            else if (btn.Equals(btnVolume)) // the volume button was clicked..
            {
                int volume = Convert.ToInt32(btn.Tag.ToString()); // get the saved volume, if zero set to hundred (muted by the volume slider)
                volume = volume == 0 ? 100 : volume;

                sliderPosition.Scroll -= sliderPosition_Scroll; // detach the event handler, so the slider does not launch the scroll event..
                if (muted)
                {
                    muted = false; // not muted..
                    btn.BackgroundImage = Properties.Resources.volume; // set the image to not muted..
                    sliderVolume.Value = volume; // set the volume..
                    btn.Tag = volume; // save the volume to the Tag property
                }
                else
                {
                    muted = true; // set to muted..
                    btn.Tag = sliderVolume.Value; // save the volume to the Tag property
                    sliderVolume.Value = 0; // set the volume slider to 0 = muted
                    btn.BackgroundImage = Properties.Resources.volume_off; // set the image to muted..
                }
                // set the tool-tip value
                lbToolTip.Text = DBLangEngine.GetMessage("msgVolumePercentage", "Volume: {0}%|As in a tool-tip to describe volume and its percentage value", (sliderVolume.Value * 300) / sliderVolume.Maximum);
                sliderPosition.Scroll += sliderPosition_Scroll; // re-attach the event handler back..
            }
            else if (btn.Equals(btnSelectSubtitle)) // Select subtitle was clicked..
            {
                m_GlobalHook.MouseMove -= M_GlobalHook_MouseMove; // don't listen the global events when a dialog is visible..
                m_GlobalHook.MouseDown -= M_GlobalHook_MouseDown; // don't listen the global events when a dialog is visible..

                // as the user which subtitle track one might want..
                TrackDescription desc = FormSelectSubtitle.Execute(vlcControl.SubTitles.All, vlcControl.SubTitles.Current);
                if (desc != null) // if something was selected assign it to be the current subtitle track..
                {
                    vlcControl.SubTitles.Current = desc;
                }
                m_GlobalHook.MouseMove += M_GlobalHook_MouseMove; // start listening the global events again as the dialog closed..
                m_GlobalHook.MouseDown += M_GlobalHook_MouseDown; // start listening the global events again as the dialog closed..
            }
            SetButtonStates(); // sets the button states to enabled / disabled depending on the playback "conditions"..
        }

        /// <summary>
        /// Sets the button states to enabled / disabled depending on the playback "conditions".
        /// </summary>
        private void SetButtonStates()
        {
            btnWindForward.Enabled = !wind; // no winding while winding..
            btnWindBackward.Enabled = !rewind; // no rewinding while rewinding..

            if ((wind || rewind) && btnPause.Visible) // no pause while winding/rewinding..
            {
                btnPause.Visible = false;
                btnPlay.Visible = true;
            }

            if (vlcControl.IsPlaying && !btnPause.Visible && !(wind || rewind)) // if playing and pause is not visible and there is no winding/rewinding, enable pause..
            {
                btnPause.Visible = true;
                btnPlay.Visible = false;
            }

            SetButtonImages(); // set the button images..
        }

        /// <summary>
        /// Sets the button images (Panel) to indicate their enabled/disabled state..
        /// </summary>
        private void SetButtonImages()
        {
            btnPlay.BackgroundImage = // play button image..
                btnPlay.Enabled ? Properties.Resources.play :
                UtilsMisc.MakeGrayscale3(Properties.Resources.play);

            btnSeekStart.BackgroundImage = // jump to the beginning button image..
                btnSeekStart.Enabled ? Properties.Resources.previous :
                UtilsMisc.MakeGrayscale3(Properties.Resources.previous);

            btnSeekEnd.BackgroundImage = // jump to the end button image..
                btnSeekEnd.Enabled ? Properties.Resources.next :
                UtilsMisc.MakeGrayscale3(Properties.Resources.next);

            btnWindBackward.BackgroundImage = // jump to the end button image..
                btnWindBackward.Enabled ? Properties.Resources.wind_back :
                UtilsMisc.MakeGrayscale3(Properties.Resources.wind_back);

            btnWindForward.BackgroundImage = // wind forward button image..
                btnWindForward.Enabled ? Properties.Resources.wind_forward :
                UtilsMisc.MakeGrayscale3(Properties.Resources.wind_forward);

            btnSelectSubtitle.BackgroundImage = // wind forward button image..
                btnSelectSubtitle.Enabled ? Properties.Resources.subtitle :
                UtilsMisc.MakeGrayscale3(Properties.Resources.subtitle);

            btnVolume.BackgroundImage = // volume button image..
                btnVolume.Enabled ? (muted ? Properties.Resources.volume_off : Properties.Resources.volume) :
                UtilsMisc.MakeGrayscale3(Properties.Resources.volume);
        }

        private void sliderPosition_Scroll(object sender, ScrollEventArgs e)
        {
            tmWindRewind.Enabled = false; // disable the timers so they cant screw up the scrolling..
            tmMain.Enabled = false;
            wind = false;
            rewind = false;
            vlcControl.Time = e.NewValue * 1000;
            tmWindRewind.Enabled = true; // enable the timers
            tmMain.Enabled = true;
        }

        private void SetPlayBackControlsEnabled() // set the playback controls as enabled after the playback is started..
        {
            btnPlay.Visible = false; // can't play while playing..
            btnPause.Visible = true; // can pause while playing..
            sliderVolume.Enabled = true; // we don't adjust the volume, if nothing is playing..
            sliderPosition.Enabled = true;  // we don't adjust the position, if nothing is playing..
            btnVolume.Enabled = true; // set the volume button enabled..
            btnSelectSubtitle.Enabled = true; // set the subtitle button enabled..
            btnSeekStart.Enabled = true; // Enable the playback buttons..
            btnWindBackward.Enabled = true; // Enable the playback buttons..
            btnPlay.Enabled = true; // Enable the playback buttons..
            btnStop.Enabled = true; // Enable the playback buttons..
            btnWindForward.Enabled = true; // Enable the playback buttons..
            btnSeekEnd.Enabled = true; // Enable the playback buttons..
        }


        private bool muted = false; // save the value if the volume is set to 0 percentage == muted..

        // volume slider logic
        private void sliderVolume_Scroll(object sender, ScrollEventArgs e)
        {
            vlcControl.VlcMediaPlayer.Audio.Volume = e.NewValue; // Set the volume (0-300 %)

            muted = e.NewValue == 0; // save the muted value

            if (e.NewValue == 0) // if volume is muted..
            {
                btnVolume.BackgroundImage = Properties.Resources.volume_off; // volume is muted..
            }
            else
            {
                btnVolume.BackgroundImage = Properties.Resources.volume; // volume is not muted..
            }

            btnVolume.Tag = e.NewValue; // save the volume value to the tag..

            lbToolTip.Text = DBLangEngine.GetMessage("msgVolumePercentage", "Volume: {0}%|As in a tool-tip to describe volume and its percentage value", (sliderVolume.Value * 300) / sliderVolume.Maximum);
        }
        #endregion

        #region ToolTips
        // Messages for the translated tool-tips
        private void ToolTipEnter(object sender, EventArgs e)
        {
            string toolTip = string.Empty;
            if (sender.Equals(btnSelectSubtitle))
            {
                toolTip = DBLangEngine.GetMessage("msgSubtitles", "Subtitles|As in a tool-tip to describe subtitles");
            }
            else if (sender.Equals(btnVolume) || sender.Equals(sliderVolume))
            {
                toolTip = DBLangEngine.GetMessage("msgVolumePercentage", "Volume: {0}%|As in a tool-tip to describe volume and its percentage value", (sliderVolume.Value * 300) / sliderVolume.Maximum);
            }
            else if (sender.Equals(btnPlay))
            {
                toolTip = DBLangEngine.GetMessage("msgPlay", "Play|As in a tool-tip to describe user clicking the play button");
            }
            else if (sender.Equals(lbTimeText) || sender.Equals(lbTimeValue))
            {
                toolTip = DBLangEngine.GetMessage("msgPlaybackPosition", "Playback position|A tool-tip for describing a text box with time");
            }
            else if (sender.Equals(sliderPosition))
            {
                toolTip = DBLangEngine.GetMessage("msgPlaybackPositionSlider", "Seek|A slider with current playback position");
            }
            else if (sender.Equals(btnSeekStart))
            {
                toolTip = DBLangEngine.GetMessage("msgJumToStart", "Jump to start|A text describing a button tool-tip that jumps the playback to the start");
            }
            else if (sender.Equals(btnSeekEnd))
            {
                toolTip = DBLangEngine.GetMessage("msgSeekEnd", "Jump to end and exit|A text describing a button tool-tip that jumps the playback to the end. The playback window is closed.");
            }
            else if (sender.Equals(btnWindForward))
            {
                toolTip = DBLangEngine.GetMessage("msgWindForward", "Wind|A text describing a button tool-tip starts winding the playback forward with a higher speed");
            }
            else if (sender.Equals(btnWindBackward))
            {
                toolTip = DBLangEngine.GetMessage("msgRewind", "Rewind|A text describing a button tool-tip starts winding the playback backwards with a higher speed");
            }
            else if (sender.Equals(btnStop))
            {
                toolTip = DBLangEngine.GetMessage("msgStop", "Stop and exit|A text describing a button tool-tip that stops the playback and closes the playback window");
            }
            else if (sender.Equals(btnPause))
            {
                toolTip = DBLangEngine.GetMessage("msgPause", "Pause|A text describing a button tool-tip that pauses the playback");
            }
            lbToolTip.Text = toolTip;
        }

        // when no tool-tip should be shown
        private void ToolTipLeave(object sender, EventArgs e)
        {
            lbToolTip.Text = string.Empty;
        }
        #endregion

        #region WindRewind
        private bool rewind = false; // indicates if rewind is enabled for the wind/rewind timer
        private bool wind = false; // indicates if wind is enabled for the wind/rewind timer

        private void tmWindRewind_Tick(object sender, EventArgs e)
        {
            if (wind || rewind) // wind/rewind is enabled..
            {
                tmWindRewind.Enabled = false; // stop the timer for seeking backwards/forwards..
                if (wind) // if seek forward..
                {
                    if (vlcControl.Time + 1000 < vlcControl.Length) // if can seek forward..
                    {
                        vlcControl.Time += 1000;
                    }
                    else
                    {
                        vlcControl.Time = vlcControl.Length; // ..otherwise disable wind and set the playback position to the end.
                        wind = false;
                    }
                }
                else if (rewind)
                {
                    if (vlcControl.Time - 1000 >= 0) // If can seek backward..
                    {
                        vlcControl.Time -= 1000;
                    }
                    else // ..otherwise disable rewind and set the playback position to the start.
                    {
                        vlcControl.Time = 0;
                        rewind = false;
                    }
                }

                tmWindRewind.Enabled = true; // enable the timer again.
            }
        }
        #endregion
    }

    #region EventArgs
    /// <summary>
    /// Event arguments for the PlaybackClosed event for the FormPlayer form.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class FormPlayerCloseEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the FileInfo class instance to be passed along with the event.
        /// </summary>
        public FileInfo FileInfo { get; set; } = null;
    }
    #endregion
}
