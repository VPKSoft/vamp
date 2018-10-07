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
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using vamp.ampService;
using VPKSoft.VisualUtils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.KeySendList; // (C): http://www.vpksoft.net/, Public Domain
using VPKSoft.Utils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A form which operates the amp# WCF remote control interface.
    /// </summary>
    public partial class FormAmpMusicPlayer : DBLangEngineWinforms
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FormAmpMusicPlayer"/> class.
        /// </summary>
        public FormAmpMusicPlayer()
        {
            InitializeComponent(); // the generated code..

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation
            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..
            DBLangEngine.AddNameSpace("VPKSoft.VisualTextBox"); // no localization from a foreign name space..
            DBLangEngine.AddNameSpace("MB.Controls"); // no localization from a foreign name space..
            DBLangEngine.AddNameSpace("VPKSoft.ImageSlider"); // no localization from a foreign name space..
            DBLangEngine.AddNameSpace("VPKSoft.VisualListBox"); // no localization from a foreign name space..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            lbToolTip.Text = string.Empty; // assume no tool tips at this time..

            // indicate that the player form was initialized to the end.. no return after localization, etc..
            _remoteStart = true;

            ClientConnect(); // try to connect to the amp# remote API..
        }
        #endregion

        #region IampRemoteClient
        /// <summary>
        /// Tries to connect to the amp# remote API and list the contents of it's currently loaded album.
        /// </summary>
        private void ClientConnect()
        {
            try
            {
                // create a BasicHttpBinding class instance for the amp# remote API..
                BasicHttpBinding basicbinding = new BasicHttpBinding
                {
                    MaxReceivedMessageSize = int.MaxValue // a lot of data transfer is expected as the album meta data is loaded..
                };

                // load the service endpoint settings from the vnml file..
                VPKNml vnml = new VPKNml();
                Paths.MakeAppSettingsFolder(); // ensure there is an application settings folder..
                vnml.Load(Paths.GetAppSettingsFolder() + "settings.vnml"); // load the settings..
                string cliPort = Convert.ToString(vnml["remoteURL", "port", "11316"]); // the port for the endpoint..
                string cliEndPoint = Convert.ToString(vnml["remoteURL", "endpoint", "ampRemote"]); // the endpoint part of the service endpoint..
                string cliBaseURL = Convert.ToString(vnml["remoteURL", "baseURL", "http://localhost"]); // the address part of the service endpoint..

                // combine the endpoint parts to an endpoint address..
                string cliAddress = cliBaseURL + ":" + cliPort + "/" + cliEndPoint;
                if (!cliAddress.EndsWith("/")) // verify that the endpoint address ends with a slash (/) character..
                {
                    cliAddress = cliAddress + "/";
                }

                // initialize the amp# remote API..
                cli = new IampRemoteClient(basicbinding, new EndpointAddress(new Uri(cliAddress)));
                cli.Open();
                cli.ConnectionTest(); // execute ConnectionTest() method for the client to cause an exception if the client doesn't work..
                ampError = false; // set a value indicating the no error with the amp# remote API did occur..
                ListAlbum(false); // list the current album opened in the amp#..
            }
            catch (Exception ex) // an exception did occur, so there is some problem with the amp# remote client..
            {
                try
                {
                    // try to close the client..
                    cli.Close();
                }
                catch (Exception ex2)
                {
                    // log the exception..
                    ExceptionLogger.LogError(ex2);
                }

                // log the exception..
                ExceptionLogger.LogError(ex);


                // set the error text with an exception message..
                lbError.Text = DBLangEngine.GetMessage("msgAmpRemoteError", "amp# remote connection error: {0}{1}|Something wrong with the amp# remote connection API with an error message", Environment.NewLine, ex.Message);
                ampError = true; // set the flag to indicate that an error occurred..
            }
        }

        /// <summary>
        /// Executes an amp# remote API command with the IampRemoteClient instance.
        /// </summary>
        /// <typeparam name="T">The return type of the method.</typeparam>
        /// <param name="action">A code (a Lambda expression) to execute.</param>
        /// <returns>If success, returns a value with a given type of a predefined, otherwise default(T) is returned.</returns>
        private T ClientAction<T>(Func<T> action)
        {
            try
            {
                T retval = action(); // execute the action..
                ampError = false; // set the error flag to false..
                return retval; // return the value..
            }
            catch (Exception ex) // an exception occurred while trying to communicate with the amp# API..
            {
                // log the exception..
                ExceptionLogger.LogError(ex);
                // display the error text with the exception message..
                lbError.Text = DBLangEngine.GetMessage("msgAmpRemoteError", "amp# remote connection error: {0}{1}|Something wrong with the amp# remote connection API with an error message", Environment.NewLine, ex.Message);
                ampError = true; // set the error flag to true..
                return default(T); // return a default value..
            }
        }

        /// <summary>
        /// Executes an amp# remote API command with the IampRemoteClient instance.
        /// </summary>
        /// <param name="action">A code (a Lambda expression) to execute.</param>
        /// <returns>True if the execution was successful, otherwise false.</returns>
        private bool ClientAction(Action action)
        {
            try
            {
                action(); // execute the action..
                ampError = false; // set the error flag to false..
                return true; // return true to indicate that the execution was a success.
            }
            catch (Exception ex) // an exception occurred while trying to communicate with the amp# API..
            {
                // log the exception..
                ExceptionLogger.LogError(ex);
                // display the error text with the exception message..
                lbError.Text = DBLangEngine.GetMessage("msgAmpRemoteError", "amp# remote connection error: {0}{1}|Something wrong with the amp# remote connection API with an error message", Environment.NewLine, ex.Message);
                ampError = true; // set the error flag to true..
                return false; // return false to indicate that the execution failed..
            }
        }
        #endregion

        #region InternalLogic
        IampRemoteClient cli = null; // a remote control interface for the amp#, (C) VPKSoft..
        List<AlbumSongWCFExt> PlayList = new List<AlbumSongWCFExt>(); // a current play list..
        private HumanActivity humanActivity = null; // this will assume a "user dead" in 15 seconds if nothing is happening..

        private bool _ampError = false; // an indicator if the amp# API has somehow failed (a connection error or something other..)

        // an indicator the form was actually initialized to the end: no localization (LangLib), etc. - the timer for amp# API client..
        private bool _remoteStart = false;

        // a value indicating if the "Display Queue" button was clicked..
        private bool lastQueuedValue = false; 

        /// <summary>
        /// Gets or sets a value indicating whether the amp# client initialization failed or a request to the API after initialization failed.
        /// </summary>
        private bool ampError
        {
            get
            {
                // return the value if the client to the API presented an error..
                return _ampError;
            }

            set
            {
                // set the GUI state depending of the value (error..) only if the value has changed from the previous value..
                if (_ampError != value || _remoteStart)
                {
                    lbMusic.Visible = !value; // toggle the list box visibility based on the value..
                    lbError.Visible = value; // toggle the error message visibility based on the value..
                    SetGUIStateErrorNoError(value); // set the button enable / disable state based on the value..
                    _ampError = value; // save the error value to avoid UI "refresh" all the time..
                    _remoteStart = false; // set the remote start flag to false..
                }
            }
        }

        /// <summary>
        /// List the contents of the currently selected album in amp#.
        /// </summary>
        /// <param name="queued">If true, only list queued songs.</param>
        private void ListAlbum(bool queued)
        {
            // clear the current play list..
            PlayList.Clear();

            // get the new play list..
            AlbumSongWCF[] albumSongWCF = ClientAction<AlbumSongWCF[]>(() => cli.GetAlbumSongs(false));
            if (albumSongWCF == null) // an error occurred so..
            {
                return; // ..just return..
            }

            // Add the songs to the play list..
            foreach (AlbumSongWCF song in albumSongWCF)
            {
                PlayList.Add(new AlbumSongWCFExt(song));
            }

            // List the play list..
            ListSongs(string.Empty, queued);
        }

        // the form was shown so align the buttons and re-layout the playback control panel..
        private void AmpMusicPlayerForm_Shown(object sender, EventArgs e)
        {
            // the playback control panel..
            tlpMain.RowStyles[0] = new RowStyle(SizeType.Percent, Height * 0.10f);
            tlpMain.RowStyles[1] = new RowStyle(SizeType.Percent, Height * 0.10f);
            tlpMain.RowStyles[2] = new RowStyle(SizeType.Percent, Height * 0.66f);
            tlpMain.RowStyles[3] = new RowStyle(SizeType.Percent, Height * 0.14f);

            // re-align the buttons..
            ResizeButtons();
        }

        // the user is sleeping: no keyboard or mouse activity..
        void humanActivity_OnUserSleep(object sender, UserSleepEventArgs e)
        {
            lastQueuedValue = false; // disable the queue if visible..
            ShowPlayingSong(true, false); // reset the play list..
        }

        // a common click handler for all the Click events..
        private void GlobalClickHandler(object sender, EventArgs e)
        {
            if (sender.Equals(btnExit)) // the Exit button was clicked..
            {
                ClientAction(() => cli.Close()); // close the amp# remote API connection..
                Close(); // close the form..
            }
            else if (sender.Equals(btnNextSong) && !ampError) // the Next Song button was clicked..
            {
                ClientAction(() => cli.NextSong()); // ask the API to play the next song..
            }
            else if (sender.Equals(btnPlay) && !ampError) // the Play button was clicked..
            {
                if (btnPlay.Tag == null) // no song selected - so play the next song..
                {
                    ClientAction(() => cli.NextSong());
                }
                if (btnPlay.Tag.ToString() == "NEXTSONG") // no song selected - so play the next song..
                {
                    ClientAction(() => cli.NextSong());
                }
                else // the song is paused, so resume the playback..
                {
                    ClientAction(() => cli.Play());
                }
            }
            else if (sender.Equals(btnPause) && !ampError) // the Pause button was clicked..
            {
                ClientAction(() => cli.Pause()); // so pause the playback..
            }
            else if (sender.Equals(btnRepeat) && !ampError) // the Repeat button was clicked..
            {
                PlayerState playerState = (PlayerState)btnRepeat.Tag; // so check the previous player state..
                ClientAction(() => cli.SetShuffle(!playerState.Shuffle)); // and toggle play list repeating..
            }
            else if (sender.Equals(btnRandom) && !ampError) // the Random button was clicked..
            {
                PlayerState playerState = (PlayerState)btnRepeat.Tag; // so check the previous player state..
                ClientAction(() => cli.SetRandomizing(!playerState.Random)); // and toggle play list randomizing..
            }
            else if (sender.Equals(btnPreviousSong) && !ampError) // the Previous Song button was clicked..
            {
                ClientAction(() => cli.PreviousSong()); // ask the API to play the previous song..
            }
            else if (sender.Equals(btnQueue) && !ampError) // the Display Queue button was clicked..
            {
                if (PlayList.Count(f => f.QueueIndex > 0) > 0)
                {
                    tmSongState.Enabled = false; // disable the timer for a while..
                    ShowPlayingSong(true, true); // refresh the play list to show only queued songs..
                    tmSongState.Enabled = true; // enabled the timer again..
                }
            }
            else if (sender.Equals(btnContextMenu) && !ampError) // the Context Menu button was clicked..
            {
                if (!mnuContext.Visible)
                {
                    mnuContext.Show((Control)sender, new Point(0, 0));
                }
            }
        }

        /// <summary>
        /// Shows the play list and the currently playing song if any.
        /// </summary>
        /// <param name="resetList">Indicates if the play list should be refreshed entirely.</param>
        /// <param name="queued">Indicates if only the queued song should be shown.</param>
        internal void ShowPlayingSong(bool resetList, bool queued)
        {
            if (InvokeRequired) // if invocation is required - a thread..
            {
                // display the play list with the given parameters..
                Invoke(new MethodInvoker(delegate { DisplayPlayingSong(resetList, queued); }));
            }
            else // .. no invocation is required, just a plain call
            {
                // display the play list with the given parameters..
                DisplayPlayingSong(resetList, queued);
            }
        }

        private int lastSongID = -1; // the ID number of the last played song..
        private int lastSongIndex = -1; // the index of the last played song in the PlayList..

        /// <summary>
        /// Displays the play list and the currently playing song if any.
        /// </summary>
        /// <param name="resetList">Indicates if the play list should be refreshed entirely.</param>
        /// <param name="queued">Indicates if only the queued song should be shown.</param>
        internal void DisplayPlayingSong(bool resetList, bool queued)
        {
            // first get the state of the amp# music player..
            PlayerState playerState = ClientAction<PlayerState>(() => cli.GetPlayerState());

            if (playerState == null) // an error occurred as the client always returns a PlayerState class instance..
            {
                return; // ..so just return..
            }

            if (playerState.AlbumLoading)
            {
                return;
            }

            // the list should be refreshed entirely if the value of the queued parameter was changed from the lastQueuedValue or
            // the resetList parameter was set to true...
            resetList = resetList ? resetList : queued && (lastQueuedValue != queued);
            lastQueuedValue = queued; // save the queued parameter value..

            SetButtonStates(playerState); // set the playback button states accordingly to the player state..

            if (playerState.QueueChangedFromPreviousQuery) // the queue was changed from the previous query..
            {
                AlbumSongWCF[] queuedSongs = ClientAction(() => cli.GetQueuedSongs());
                if (queuedSongs != null) // if no error occurred..
                {
                    // ..update the queue indices of the play list..
                    RefreshQueue(new List<AlbumSongWCF>(queuedSongs));
                }
            }

            if (playerState.CurrentSongID != -1) // if a song is selected..
            {
                // calculate the play back position of the current song..
                TimeSpan ts = TimeSpan.FromSeconds(playerState.CurrentSongLength - playerState.CurrentSongPosition);

                // get the current song from the play list..
                AlbumSongWCFExt song = PlayList.First(f => f.ID == playerState.CurrentSongID);

                // save the current song index..
                lastSongIndex = PlayList.FindIndex(f => f.ID == playerState.CurrentSongID);

                // avoid causing an exception with the slider..
                if (playerState.CurrentSongPosition > sliderPosition.Maximum)
                {
                    sliderPosition.Value = 0; // ..so just set it to zero..
                }

                // set the volume slider's value without raising an event..
                sliderVolume.ValueNoEvent = (int)(song != null ? song.Volume * 100 : 100);

                if (resetList) // if the play list should be refreshed entirely..
                {
                    lbMusic.Focus(); // focus the play list box.. (necessary ?)
                    ListSongs(string.Empty, queued); // list the songs..
                    SelectSongByID(playerState.CurrentSongID); // select the current song..
                }
                else if (lastSongID != playerState.CurrentSongID) // if the song was changed from the previous one..
                {
                    SelectSongByID(playerState.CurrentSongID); // select the current song..
                }
                lastSongID = playerState.CurrentSongID; // save the current song's ID number..

                try // try to set the value of the play back position slider..
                {
                    sliderPosition.Maximum = (int)playerState.CurrentSongLength; // let the length be the Maximum property value..
                    sliderPosition.Value = (int)playerState.CurrentSongPosition; // let the playback position be the Value property value..

                    sliderRating.Maximum = 1000; // the song rating is between 0 and 1000..

                    // if the rating slider's value isn't changing and the "noUpdateRating" flag isn't set..
                    if (!noUpdateRating && !sliderRating.ValueChanging)
                    {
                        // set the rating slider's value..
                        sliderRating.ValueNoEvent = song != null ? song.Rating : 0;
                    }
                }
                catch (Exception ex)
                {
                    // these sliders always throw exceptions..

                    // log the exception..
                    ExceptionLogger.LogError(ex);
                }

                if (song != null) // if there is a current song..
                {
                    // ..display it's name and its playback position..
                    lbCurrentSong.Text = "[" + playerState.CurrentAlbumName + "]: " + song.SongName;
                    lbTimeValue.Text = "-" + ts.ToString(@"mm\:ss");
                }
            }
            else // no song is selected..
            {
                if (resetList) // if the play list should be refreshed entirely..
                {
                    lbMusic.Focus(); // focus the play list box.. (necessary ?)
                    ListSongs(string.Empty, queued); // list the songs..
                }

                // only display an album name if no song is selected..
                lbCurrentSong.Text = "[" + playerState.CurrentAlbumName + "]: -";
                lastSongID = -1; // no song, no ID..
                lastSongIndex = -1; // no song, no index..
            }

            if (playerState.AlbumChanged) // if the album was changed entirely..
            {
                // .. list the new album..
                ListAlbum(queued);
            }
        }

        // a timer checking the playback state..
        private void tmSongState_Tick(object sender, EventArgs e)
        {
            tmSongState.Enabled = false; // disable the timer..
            if (ampError) // if an error is on..
            {
                ClientConnect(); // ..keep on retrying a connection to the amp# remote API..
            }

            if (!ampError) // no error.. just update the player and the current song states..
            {
                ShowPlayingSong(false, lastQueuedValue);
            }
            tmSongState.Enabled = true; // enable the timer..
        }

        /// <summary>
        /// Sets the visual state of the play back controls and the player form controls depending if 
        /// an error state is occurred with the amp# remote API.
        /// </summary>
        /// <param name="value">A value indicating if the amp# remote control API is in erroneous state.</param>
        private void SetGUIStateErrorNoError(bool value)
        {
            if (value) // if no error then set the controls accordingly..
            {
                btnRandom.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.shuffle);
                btnRepeat.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.repeat);
                btnPreviousSong.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.previous);
                btnPlay.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.play);
                btnPause.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.pause);
                btnNextSong.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.next);
                btnQueue.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.queue);
                btnContextMenu.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.menu);
                sliderRating.Enabled = false;
                sliderVolume.Enabled = false;
                sliderPosition.Value = 0;
                sliderPosition.Enabled = false;
                sliderVolume.Enabled = false;
                lbCurrentSong.Enabled = false;
                lbCurrentSong.Text = "-";
                tbFind.Enabled = false;
                btnVolume.BackgroundImage = UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.volume_off);
                lbInQueue.Enabled = false;
                lbInQueueCount.Text = "0";
                lbInQueueCount.Enabled = false;
                lbTimeValue.Text = "-00:00";
                lbTimeValue.Enabled = false;
                lbTimeText.Enabled = false;
                lbFind.Enabled = false;
            }
            else // error, so set the control accordingly..
            {
                btnRandom.BackgroundImage = vamp.Properties.Resources.shuffle;
                btnRepeat.BackgroundImage = vamp.Properties.Resources.repeat;
                btnPreviousSong.BackgroundImage = vamp.Properties.Resources.previous;
                btnPlay.BackgroundImage = vamp.Properties.Resources.play;
                btnPause.BackgroundImage = vamp.Properties.Resources.pause;
                btnNextSong.BackgroundImage = vamp.Properties.Resources.next;
                btnQueue.BackgroundImage = vamp.Properties.Resources.queue;
                btnContextMenu.BackgroundImage = vamp.Properties.Resources.menu;
                sliderRating.Enabled = true;
                sliderVolume.Enabled = true;
                sliderPosition.Enabled = true;
                sliderVolume.Enabled = true;
                lbCurrentSong.Enabled = true;
                tbFind.Enabled = true;
                btnVolume.BackgroundImage = vamp.Properties.Resources.volume;
                lbInQueue.Enabled = true;
                lbInQueueCount.Enabled = true;
                lbTimeValue.Enabled = true;
                lbTimeText.Enabled = true;
                lbFind.Enabled = true;
            }
        }

        /// <summary>
        /// Set the button states based on the given PlayerState class instance.
        /// </summary>
        /// <param name="playerState">A PlayerState class instance to be used to set the play back button states according to it's property values.</param>
        internal void SetButtonStates(PlayerState playerState)
        {
            if (playerState.Stopped) // if the amp# music player is stopped..
            {
                btnPlay.Visible = true; // show the playback button..
                btnPause.Visible = false; // hide the pause button..
                // set the tag to indicate that the click to the Play button should select the next song as no song is selected..
                btnPlay.Tag = "NEXTSONG";
            }
            else // the play back is either playing or paused..
            {
                btnPlay.Visible = playerState.Paused; // hide or show the Play button..
                btnPause.Visible = !playerState.Paused; // hide or show the Pause button..
                // set the tag to indicate that the click to the Play button shouldn't select a next song..
                btnPlay.Tag = string.Empty;
            }

            // depending if there is a song selected, enable or disable the volume slider..
            sliderVolume.Enabled = playerState.CurrentSongID != -1;

            // depending if there is a song selected, enable or disable the volume button..
            btnVolume.Enabled = playerState.CurrentSongID != -1;

            // depending if there is a song selected, enable or disable the rating slider..
            sliderRating.Enabled = playerState.CurrentSongID != -1;

            // depending if there is a song selected, enable or disable the playback position slider..
            sliderPosition.Enabled = playerState.CurrentSongID != -1;

            // show the amount of songs currently in the queue..
            lbInQueueCount.Text = playerState.QueueCount.ToString();

            // if there are no songs in the queue, then there is no reason to enable the Show Queue button..
            btnPreviousSong.Enabled = playerState.QueueCount > 0;

            // if there are songs in the queue gray-scale the Show Queue button..
            btnQueue.BackgroundImage = playerState.QueueCount > 0 ?
                vamp.Properties.Resources.queue :
                UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.queue);

            // if there are no songs played then disable the previous song button..
            btnPreviousSong.Enabled = playerState.CanGoPrevious;

            // set the previous song button's color depending if there are previous song to jump to..
            btnPreviousSong.BackgroundImage =
                playerState.CanGoPrevious ? Properties.Resources.previous :
                UtilsMisc.MakeGrayscale3(Properties.Resources.previous);

            // save the player state for the repeat and random buttons..
            btnRepeat.Tag = playerState;
            btnRandom.Tag = playerState;

            // save the player state for the context menu items..
            mnuSelectAlbum.Tag = playerState;
            mnuLoadSavedQueue.Tag = playerState;
            mnuAppendToQueue.Tag = playerState;


            // just to please my spouse if he sees the UI, on my account the back parameter should always be set to true..
            // ..so this is just a "pleasant" cheat ;-)
            ColorizeButtons(playerState, true);
        }

        /// <summary>
        /// This is a mean to an end to please my spouse as he thinks the background color of the buttons should be white and there 
        /// should be a left margin with the play list box.
        /// <para/>Also the border of the randomize and repeat buttons are set accordingly.
        /// </summary>
        /// <param name="playerState">The current player state.</param>
        /// <param name="black">Whether to color the buttons to black or to white, also whether to use a left margin with the play list.</param>
        private void ColorizeButtons(PlayerState playerState, bool black = false)
        {
            foreach (Control control in pnButtons.Controls) // loop through the "buttons"..
            {
                if (control.GetType() == typeof(Panel)) // ..which are actually panels..
                {
                    if (control.Equals(btnRandomBase)) // these buttons have a special handling as their state can either be down or up..
                    {
                        control.BackColor = playerState.Random ? Color.SteelBlue : (black ? Color.Black : Color.White);
                    }
                    else if (control.Equals(btnRepeatBase)) // these buttons have a special handling as their state can either be down or up..
                    {
                        control.BackColor = playerState.Shuffle ? Color.SteelBlue : (black ? Color.Black : Color.White);
                    }
                    else // the normal colorization..
                    {
                        control.BackColor = black ? Color.Black : Color.White;
                    }

                    // loop through the sub-controls..
                    for (int i = 0; i < control.Controls.Count; i++)
                    {
                        // the normal colorization..
                        control.Controls[i].BackColor = black ? Color.Black : Color.White;
                    }
                }
            }

            if (black) // set the left margin of the play list depending on the black parameter
            {
                // black = no margin..
                tlpSideMargin.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 0);
                tlpSideMargin.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 100);
            }
            else
            {
                // white = margin of 5 percent..
                tlpSideMargin.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 5);
                tlpSideMargin.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 95);
            }
        }

        /// <summary>
        /// Unselects all the items in the play list and select the current song.
        /// </summary>
        /// <param name="ID">An ID number for a song in the album which to select.</param>
        private void SelectSongByID(int ID)
        {
            lbMusic.ClearSelected(); // unselect all the items in the play list..
            for (int i = 0; i < lbMusic.Items.Count; i++) // loop through the "visual" play list..
            {
                // get an item (a song) from the list box..
                AlbumSongWCFExt albumSong = (AlbumSongWCFExt)lbMusic.Items[i];
                if (albumSong.ID == ID) // check for an ID number match..
                {
                    lbMusic.SelectedIndex = i; // .. match found so..
                    break; // ..stop the loop..
                }
            }
        }

        /// <summary>
        /// Delegate key presses to the search box if the search box isn't focused. This was invented in the amp#.
        /// </summary>
        /// <param name="e">A KeyEventArgs class instance containing the key information.</param>
        internal void DelegateKeys(KeyEventArgs e)
        {
            if (!tbFind.Focused) // only if the focus is elsewhere..
            {
                // check if the key to delegate is valid.. (letter or digit or a key in the KeySendList class's key list)..
                if (char.IsLetterOrDigit((char)e.KeyValue) || KeySendList.HasKey(e.KeyCode))
                {
                    tbFind.Focus(); // focus the control..
                    char key = (char)e.KeyValue; // cast to a character..

                    if (char.IsLetterOrDigit(key)) // all the letters and digits will be delegated..
                    {
                        SendKeys.Send(key.ToString().ToLower());
                    }
                    else // not a letter or a digit..
                    {
                        // send via conversion from the KeySendList class..
                        SendKeys.Send(KeySendList.GetKeyString(e.KeyCode));
                    }
                    e.SuppressKeyPress = true; // suppress the key presses on valid keys..
                    e.Handled = true; // set the Handled property to true..
                }
            }
        }

        /// <summary>
        /// Updates the queue to the play list box and to the PlayList.
        /// </summary>
        /// <param name="queueList">A list of songs with a changed QueueIndex property value.</param>
        private void RefreshQueue(List<AlbumSongWCF> queueList)
        {
            // loop through the items in the play list box..
            for (int i = 0; i < lbMusic.Items.Count; i++)
            {
                foreach (AlbumSongWCF song in queueList) // loop through the queueList parameter values..
                {
                    // cast the item in the play list box to a AlbumSongWCFExt class.. 
                    AlbumSongWCFExt albumSongWCF = (AlbumSongWCFExt)lbMusic.Items[i];
                    if (albumSongWCF.ID == song.ID) // check if the ID numbers match..
                    {
                        // match found so break the loop and move on to the next song..
                        lbMusic.Items[i] = new AlbumSongWCFExt(song);
                        break;
                    }
                }
            }

            // loop through the items in the play list..
            for (int i = 0; i < PlayList.Count; i++)
            {
                foreach (AlbumSongWCF song in queueList) // loop through the queueList parameter values..
                {
                    if (PlayList[i].ID == song.ID) // check if the ID numbers match..
                    {
                        // match found so create a new instance of the AlbumSongWCFExt class from the AlbumSongWCF class instance..
                        PlayList[i] = new AlbumSongWCFExt(song); // ..and assign it..
                        break; // and break the loop and move on to the next song..
                    }
                }
            }
        }

        // a user requested a song to be removed from the amp#'s current database..
        private void lbMusic_ButtonClicked(object sender, VPKSoft.VisualListBox.ListBoxButtonClickEventArgs e)
        {
            ClientAction(() =>
            {
                // create an AlbumSongWCF class instance from the selected item in the list..
                AlbumSongWCF removeSong = AlbumSongWCFExt.FromExt((AlbumSongWCFExt)e.Item);

                // ask the amp# remote API to remove to song..
                cli.RemoveSongFromAlbum(removeSong);
            });
        }

        // handle the keyboard events, KeyPreview = true..
        private void AmpMusicPlayerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) // an item was selected form the play list box..
            {
                if (lbMusic.SelectedItem != null) // if there is an item actually selected..
                {
                    AlbumSongWCFExt song = lbMusic.SelectedItem as AlbumSongWCFExt; // cast the selected item as AlbumSongWCFExt..

                    if (ClientAction(() => cli.PlayID(song.ID))) // send a command to the amp# remote API to play the song..
                    {
                        DisplayPlayingSong(false, lastQueuedValue); // display the current song..
                    }

                    e.Handled = true; // the key event was handled..
                    e.SuppressKeyPress = true; // suppress the event..
                }
                return; // don't allow the key press to be delegated..
            }
            else if (e.KeyCode == Keys.Add || e.KeyValue == 187)  // a queue of selected item(s) was requested..
            {
                if (lbMusic.SelectedItems.Count > 0) // if nothing is selected there is nothing to do..
                {
                    List<int> idList = new List<int>(); // initialize a list to collect the ID's for the selected items..
                    foreach (AlbumSongWCF mf in lbMusic.SelectedItems) // collect the ID numbers of the selected items to the list..
                    {
                        idList.Add(mf.ID); // add the ID number to the list..
                    }

                    List<AlbumSongWCF> queueList = new List<AlbumSongWCF>(); // create a list of AlbumSongWCF class instances..
                    if (ClientAction(() => // get a list of AlbumSongWCF class instances from the amp# remote API with an ID number list..
                        queueList.AddRange(
                        cli.QueueID(e.Control, idList.ToArray()))))
                    {
                        RefreshQueue(queueList); // if success, refresh the queue..
                    }
                }

                e.Handled = true; // the key event was handled..
                e.SuppressKeyPress = true; // suppress the event..
                return; // don't allow the key press to be delegated..
            }
            // a deletion was requested for the selected songs in the album..
            else if (e.KeyCode == Keys.Delete)
            {
                if (lbMusic.SelectedItems.Count > 0) // if nothing is selected there is nothing to do..
                {
                    // initialize a list of AlbumSongWCF class instances to be removed from the album..
                    List<AlbumSongWCF> deleteList = new List<AlbumSongWCF>();

                    // fill the list of AlbumSongWCF class instances for the deletion..
                    foreach (AlbumSongWCFExt mf in lbMusic.SelectedItems) 
                    {
                        deleteList.Add(AlbumSongWCFExt.FromExt(mf));
                        ClientAction(() => cli.RemoveSongFromAlbum(mf));
                    }

                    // loop through the list of AlbumSongWCF class instances..
                    foreach (AlbumSongWCF albumSongWCF in deleteList)
                    {
                        ClientAction(() =>
                        {
                            // ask the amp# remote API to remove to song..
                            cli.RemoveSongFromAlbum(albumSongWCF);
                        });
                    }
                }
                e.Handled = true; // the key event was handled..
                e.SuppressKeyPress = true; // suppress the event..
                return; // don't allow the key press to be delegated..
            }
            else if (e.KeyCode == Keys.Up || // these keys don't need to be delegated to the search text box..
                e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.PageDown ||
                e.KeyCode == Keys.PageUp ||
                e.KeyCode == Keys.Shift ||
                e.KeyCode == Keys.Control ||
                e.KeyCode == Keys.Return ||
                e.KeyCode == Keys.F2)
            {
                return; // but no suppress either..
            }

            DelegateKeys(e); // delegate the keys to the search text box..
        }

        /// <summary>
        /// Finds the songs matching the search text box text.
        /// </summary>
        /// <param name="onlyIfText">Indicates if the search should be executed even if the search text box is empty.</param>
        /// <param name="queued">Indicates if only queued song should be searched.</param>
        private void Find(bool onlyIfText, bool queued)
        {
            if (onlyIfText && tbFind.Text == string.Empty) // only search if there is some text..
            {
                return; // nothing to search..
            }

            // list the songs with the parameters..
            ListSongs(tbFind.Text, queued);
        }

        /// <summary>
        /// List the songs with a given search text or lists queued songs.
        /// </summary>
        /// <param name="findStr">A search string to be used for finding songs in the play list.</param>
        /// <param name="queued">A flag which indicates to only find queued songs - if true the search string will be ignored.</param>
        private void ListSongs(string findStr, bool queued)
        {
            tmSongState.Enabled = false; // disable the player state timer for this period..

            lbMusic.Items.Clear(); // clear the item in the play list box..
            lbMusic.SuspendLayout(); // suspend the play list box layout..

            // set the queued parameter to false if there is nothing in the queue..
            queued = queued && PlayList.Count(f => f.QueueIndex > 0) > 0;

            // create a new list of AlbumSongWCFExt class instances to filled with found songs..
            List<AlbumSongWCFExt> manipulatedPlayList = new List<AlbumSongWCFExt>();
            if (queued) // if queued..
            {
                // just us a lambda function with the play list and sort ascending..
                foreach (AlbumSongWCFExt mf in PlayList.Where(f => f.QueueIndex > 0).OrderBy(f => f.QueueIndex))
                {
                    manipulatedPlayList.Add(mf); // add the queued songs to the list..
                }
            }
            else // use the find string..
            {
                // loop through the play list
                foreach (AlbumSongWCFExt mf in PlayList)
                {
                    if (findStr != string.Empty) // if there is a find string..
                    {
                        // .. only matching songs will be listed..
                        if (mf.Match(findStr))
                        {
                            manipulatedPlayList.Add(mf);
                        }
                    }
                    else // .. otherwise list the all..
                    {
                        manipulatedPlayList.Add(mf);
                    }
                }
            }

            // fill the play list box with matching search criteria..
            foreach (AlbumSongWCFExt mf in manipulatedPlayList)
            {
                lbMusic.Items.Add(mf);
            }
            lbMusic.RefreshScroll(); // refresh the "overridden" scroll bar..
            lbMusic.ResumeLayout(); // resume the lay out..

            tmSongState.Enabled = true; // enable the player state timer again..
        }

        // the text in the search text box was changed so..
        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            Find(false, lastQueuedValue); // ..search..
        }

        // the focus was changed to the search text box so..
        private void tbFind_Enter(object sender, EventArgs e)
        {
            Find(true, lastQueuedValue); // ..search..
        }

        // the form was loaded..
        private void AmpMusicPlayerForm_Load(object sender, EventArgs e)
        {
            // this initializes a VPKSoft.HumanActivity class instance to check if the user has gone idle (i.e. sleep)..
            humanActivity = new HumanActivity(15); // use 15 second delay to check if the user is idle..
            humanActivity.UserSleep += humanActivity_OnUserSleep; // subscribe to the UserSleep event..
        }

        // a key was pressed in the search text box..
        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) // the down key means the play list box should be scrolled..
            {
                int iIndex = lbMusic.SelectedIndex; // save the selected index..
                lbMusic.ClearSelected(); // clear the selected indices..

                // if the previous index plus one would be greater than the amount if items in the play list box..
                if (iIndex + 1 == lbMusic.Items.Count)
                {
                    // .. go to the top of the list..
                    lbMusic.SelectedIndex = 0;
                }
                else // increase the selected index by one..
                {
                    iIndex++;
                    lbMusic.SelectedIndex = iIndex;
                }
                e.Handled = true; // the key event was handled..
                e.SuppressKeyPress = true; // suppress the event..
                lbMusic.Focus(); // focus the play list box..
            }
            else if (e.KeyCode == Keys.Up) // the up key also means the play list box should be scrolled..
            {
                int iIndex = lbMusic.SelectedIndex; // save the selected index..
                lbMusic.ClearSelected(); // clear the selected indices..

                // if the previous index minus one would be smaller than zero..
                if (iIndex - 1 < 0)
                {
                    // .. go to the bottom of the list..
                    lbMusic.SelectedIndex = lbMusic.Items.Count - 1;
                }
                else // decrease the selected index by one..
                {
                    iIndex--;
                    lbMusic.SelectedIndex = iIndex;
                }
                e.Handled = true; // the key event was handled..
                e.SuppressKeyPress = true; // suppress the event..
                lbMusic.Focus(); // focus the play list box..
            }
        }

        // the volume slider's value was changed..
        private void sliderVolume_ValueChanged(object sender, EventArgs e)
        {
            // set the tool tip to indicate the volume in percentage of the original (0-200%)..
            lbToolTip.Text = DBLangEngine.GetMessage("msgVolumePercentage", "Volume: {0}%|As in a tool-tip to describe volume and its percentage value", (sliderVolume.Value * 200) / sliderVolume.Maximum);

            // request the amp# API to change the song's volume..
            ClientAction(() => cli.SetVolume((float)sliderVolume.Value * 2.0f / sliderVolume.Maximum));
            if (lastSongIndex != -1) // if there is a song selected..
            {
                // set the song's volume too..
                PlayList[lastSongIndex].Volume = (float)sliderVolume.Value * 2.0f / sliderVolume.Maximum;
            }

            // toggle the volume "button's" enabled state depending on the mute (volume = 0) possibility..
            btnVolume.Enabled = sliderVolume.Value > 0;

            // toggle the volume "button's" image depending on the mute (volume = 0) possibility..
            btnVolume.BackgroundImage =
                btnVolume.Enabled ? Properties.Resources.volume :
                UtilsMisc.MakeGrayscale3(vamp.Properties.Resources.volume_off);
        }

        // the player form is closing..
        private void AmpMusicPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmSongState.Enabled = false; // the player state timer is no longer required..
            humanActivity.UserSleep -= humanActivity_OnUserSleep; // unsubscribe the human activity watcher..
        }

        // user double-clicked an item in the play list box..
        private void lbMusic_DoubleClick(object sender, EventArgs e)
        {
            if (lbMusic.SelectedItem != null) // if an item is actually selected..
            {
                AlbumSongWCFExt song = lbMusic.SelectedItem as AlbumSongWCFExt; // cast the selected item as AlbumSongWCFExt..

                if (ClientAction(() => cli.PlayID(song.ID))) // send a command to the amp# remote API to play the song..
                {
                    DisplayPlayingSong(false, lastQueuedValue); // display the current song..
                }
            }
        }

        // indicates to the timer that the song rating slider value shouldn't be changed..
        private bool noUpdateRating = false;

        // the rating slider's value was changed..
        private void sliderRating_ValueChanged(object sender, EventArgs e)
        {
            // indicate to the timer that the song rating slider value shouldn't be changed..
            noUpdateRating = true;

            if (lastSongIndex != -1) // if there is an actually selected song..
            {
                PlayList[lastSongIndex].Rating = sliderRating.Value; // set its rating to the changed value..
            }
            // request the amp# API to change the song's rating..
            ClientAction(() => cli.SetRating(sliderRating.Value));

            // indicate to the timer that the song rating slider value can now be changed..
            noUpdateRating = false;
        }

        // the playback position slider's value was changed..
        private void sliderPosition_ValueChanged(object sender, EventArgs e)
        {
            if (lastSongIndex != -1) // if there is an actually selected song..
            {
                // request the amp# API to change the song's playback position..
                ClientAction(() => cli.SetPositionSeconds(sliderPosition.Value));
            }
        }

        // a select album context menu was clicked..
        private void mnuSelectAlbum_Click(object sender, EventArgs e)
        {
            tmSongState.Enabled = false; // disable the timer for a while..

            // create a list of AlbumWCF class instances..
            List<AlbumWCF> albumWCFs = new List<AlbumWCF>();

            // try to get the album list from the amp# remote control API..
            if (ClientAction(() => { albumWCFs.AddRange(cli.GetAlbums()); }))
            {
                // display a selection dialog for the new album..
                AlbumWCF album = FormDialogSelectCustomContent.Execute(albumWCFs, ((ToolStripMenuItem)sender).Text, "Name");
                if (album != null) // if the dialog returned a valid value..
                {
                    // set the new album..
                    ClientAction(() => cli.SelectAlbum(album.Name));
                }
            }
            tmSongState.Enabled = true; // enable the timer again..
        }

        // a load queue or append to queue context menu item was clicked..
        private void mnuLoadSavedQueue_Click(object sender, EventArgs e)
        {
            // get the current play back state..
            PlayerState playerState = (PlayerState)((ToolStripMenuItem)sender).Tag;

            // with comparison to the sender, select the correct method of loading a saved queue from the amp# remote control API..
            bool append = sender.Equals(mnuAppendToQueue);

            // null is not fine..
            if (playerState == null)
            {
                return; // .. so return..
            }

            tmSongState.Enabled = false; // disable the timer for a while..

            // create a list of QueueEntry class instances..
            List<QueueEntry> queueEntries = new List<QueueEntry>();

            // try to get the saved queue list from the amp# remote control API..
            if (ClientAction(() => { queueEntries.AddRange(cli.GetQueueList(playerState.CurrentAlbumName)); }))
            {
                if (queueEntries.Count > 0) // no reason to continue if there are no saved queues..
                {
                    // display a selection dialog for the saved queue..
                    QueueEntry queueEntry = FormDialogSelectCustomContent.Execute(queueEntries, ((ToolStripMenuItem)sender).Text, "QueueName");
                    if (queueEntry != null) // if the dialog returned a valid value..
                    {
                        // create an Action class instance based on the value if the amp# remote API should load the queue or append to it..
                        Action action = null;
                        if (append) // the append case..
                        {
                            // create a new action which appends to the queue (AppendQueue(int ID))..
                            action = () => { cli.AppendQueue(queueEntry.ID); };
                        }
                        else
                        {
                            // create a new action which loads a queue (LoadQueue(int ID))..
                            action = () => { cli.LoadQueue(queueEntry.ID); };
                        }

                        // if the action is not null and the call to the amp# remote call was successful..
                        if (action != null && ClientAction(action))
                        {
                            List<AlbumSongWCF> queueList = new List<AlbumSongWCF>(); // create a list of AlbumSongWCF class instances..
                            if (ClientAction(() => // get a list of AlbumSongWCF class instances from the amp# remote API..
                                queueList.AddRange(
                                cli.GetQueuedSongs())))
                            {
                                RefreshQueue(queueList); // if success, refresh the queue..
                            }
                        }
                    }
                }
            }
            tmSongState.Enabled = true; // enable the timer again..
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
            UtilsMisc.ResizeFontHeight(lbInQueue, true);
            UtilsMisc.ResizeFontHeight(lbInQueueCount, true);
            UtilsMisc.ResizeFontHeight(lbToolTip, true); // END: Resize the labels fonts
            UtilsMisc.ResizeFontWidth(lbFind);
            tbFind.Font = lbFind.Font;
        }
        #endregion

        #region ToolTips
        // Messages for the translated tool-tips
        private void ToolTipEnter(object sender, EventArgs e)
        {
            string toolTip = string.Empty; // assume that there might not be a tool tip at all..

            if (sender.Equals(btnPlay)) // check the sender..
            {
                toolTip = DBLangEngine.GetMessage("msgPlay", "Play|As in a tool-tip to describe user clicking the play button");
            }
            else if (sender.Equals(btnPause)) // ..and again check the sender.. and keep repeating the check..
            {
                toolTip = DBLangEngine.GetMessage("msgPause", "Pause|A text describing a button tool-tip that pauses the playback");
            }
            else if (sender.Equals(btnNextSong))
            {
                toolTip = DBLangEngine.GetMessage("msgNext", "Next|A text describing a button tool-tip of a button to jump to a next item in the playback");
            }
            else if (sender.Equals(btnPreviousSong))
            {
                toolTip = DBLangEngine.GetMessage("msgPrevious", "Previous|A text describing a button tool-tip of a button to jump to a previous item in the playback");
            }
            else if (sender.Equals(btnRepeat))
            {
                toolTip = DBLangEngine.GetMessage("msgRepeat", "Repeat|A text describing a button tool-tip of a button to toggle playback repeat mode");
            }
            else if (sender.Equals(btnQueue))
            {
                toolTip = DBLangEngine.GetMessage("msgQueue", "Queue|A text describing a button tool-tip of a button to show only queued items in a play list");
            }
            else if (sender.Equals(btnRandom))
            {
                toolTip = DBLangEngine.GetMessage("msgRandom", "Random|A text describing a button tool-tip of a button to toggle play list randomization");
            }
            else if (sender.Equals(btnVolume) || sender.Equals(sliderVolume))
            {
                // set the tool-tip value
                toolTip = DBLangEngine.GetMessage("msgVolumePercentage", "Volume: {0}%|As in a tool-tip to describe volume and its percentage value", (sliderVolume.Value * 200) / sliderVolume.Maximum);
            }
            else if (sender.Equals(sliderPosition))
            {
                toolTip = DBLangEngine.GetMessage("msgPlaybackPositionSlider", "Seek|A slider with current playback position");
            }
            else if (sender.Equals(sliderRating))
            {
                toolTip = DBLangEngine.GetMessage("msgItemRating", "Rating|Rating for a item in a play list");
            }
            else if (sender.Equals(btnContextMenu))
            {
                toolTip = DBLangEngine.GetMessage("msgMenu", "Menu|A tool-tip for a context menu button");
            }
            else if (sender.Equals(btnExit))
            {
                toolTip = DBLangEngine.GetMessage("msgWindowExit", "Exit|A tool-tip for a window close/exit button");
            }

            if (!sender.Equals(btnExit) && ampError) // no tool tips on "disabled" buttons..
            {
                toolTip = string.Empty;
            }

            lbToolTip.Text = toolTip; // set the tool tip..
        }

        // when no tool-tip should be shown
        private void ToolTipLeave(object sender, EventArgs e)
        {
            lbToolTip.Text = string.Empty;
        }
        #endregion
    }
}
