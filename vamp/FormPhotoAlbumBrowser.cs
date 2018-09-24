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
using System.Drawing;
using System.Windows.Forms;
using Gma.System.MouseKeyHook; // (C): https://github.com/gmamaladze/globalmousekeyhook, MIT license
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.VisualUtils; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using System.IO;
using VPKSoft.ImageViewer; // (C): https://github.com/VPKSoft/VPKSoft.VisualComponents, GNU General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A full screen photo/image navigation window.
    /// </summary>
    public partial class FormPhotoAlbumBrowser : DBLangEngineWinforms
    {
        #region MassiveConstructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="FormPhotoAlbumBrowser"/> class.
        /// </summary>
        public FormPhotoAlbumBrowser()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            m_GlobalHook = Hook.GlobalEvents(); // Easier to listen mouse movement on a multi-control form, so we add this (Gma.System.MouseKeyHook) event handler..
                                                // (C): https://github.com/gmamaladze/globalmousekeyhook, MIT license

            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove; // Add a global MouseMove event..

            lbToolTip.Text = string.Empty; // No too-tip as there is nothing to show at this time..

            SetButtonImages(); // Set the control buttons states to match the navigation bar's state..
        }
        #endregion

        #region PrivateMembers
        // the base path for the photo album collection..
        private string basePath = string.Empty;

        // a list of PhotoAlbumEntry class instances for a photo album contents..
        private List<PhotoAlbumEntry> albumContents = null;

        // the currently visible index of an image displayed on the form..
        private int currentImageIndex = 0;
        #endregion

        /// <summary>
        /// Creates a new instance if the PhotoAlbumBrowserForm class and displays it.
        /// </summary>
        /// <param name="basePath">The base path for the photo album contents.</param>
        /// <param name="albumContents">A list of PhotoAlbumEntry class instances which contains the items of a photo album.</param>
        public static void Execute(string basePath, List<PhotoAlbumEntry> albumContents)
        {
            if (albumContents.Count == 0) // if the album is empty, just return..
            {
                return;
            }

            // create a new instance of the PhotoAlbumBrowserForm class and assign it the given parameters..
            FormPhotoAlbumBrowser form = new FormPhotoAlbumBrowser
            {
                basePath = basePath, // save the base path..
                albumContents = albumContents // save the photo album's contents..
            };
            form.Show(); // display the form..
        }

        #region DisplayImage
        /// <summary>
        /// Displays the currently selected image.
        /// </summary>
        private void DisplayImage()
        {
            // call the actual display method with an index..
            DisplayImage(currentImageIndex);
        }

        /// <summary>
        /// Displays the next image based on the currently selected image.
        /// </summary>
        private void DisplayNextImage()
        {
            currentImageIndex++; // increase the index..
            if (currentImageIndex >= albumContents.Count)
            {
                currentImageIndex = 0; // ..if the index "overflows" set it back to zero..
            }
            DisplayImage(); // display the currently selected image..
        }

        /// <summary>
        /// Displays the previous image based on the currently selected image.
        /// </summary>
        private void DisplayPreviousImage()
        {
            currentImageIndex--; // increase the index..
            if (currentImageIndex < 0)
            {
                currentImageIndex = albumContents.Count - 1; // ..if the index gets smaller than zero set it to last index..
            }
            DisplayImage(); // display the currently selected image..
        }

        /// <summary>
        /// Displays the image with a given index.
        /// </summary>
        /// <param name="index">The index of an image display within the album.</param>
        private void DisplayImage(int index)
        {
            // load the image from a file to the VPKSoft.ImageViewer control..
            pbPhoto.Image = Image.FromFile(Path.Combine(basePath, albumContents[index].FILENAME));

            // give a description for the image..
            lbImageDesc.Text = DBLangEngine.GetMessage(
                "msgPhotoDescription",
                "{0}/{1}: '{2}' [{3}]|A tool-tip for a position of a photo in a photo album, description for a photo and its take time",
                index + 1,
                albumContents.Count,
                albumContents[index].DESCRIPTION,
                albumContents[index].DATETIME_FREE == string.Empty ? albumContents[index].DATETIME.ToString() : albumContents[index].DATETIME_FREE);

            // ..give the previous description for the image's full screen mode label..
            lbFullScreenDescription.Text = lbImageDesc.Text;
        }
        #endregion

        #region Misc
        // The form is closing, so dispose of the mouse hook..
        private void PhotoAlbumBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (m_GlobalHook)
            {
                // ..and unsubscribe the event for mouse moving..
                m_GlobalHook.MouseMove -= M_GlobalHook_MouseMove;
            }
        }

        private void PhotoAlbumBrowserForm_Shown(object sender, EventArgs e)
        {
            // create a "suitable" size for the pop-up "tool bar"..
            tlpPopDown.Height = (int)(((double)Height) * 0.14);
            ResizeButtons(); // Do resize and align the navigation related buttons to a "right" size..
            HidePopDown(); // Hide the navigation control button bar..

            // something weird with the label.. (trying to keep it the position sane)..
            lbFullScreenDescription.AutoSize = false;
            lbFullScreenDescription.MaximumSize = Size.Empty;
            lbFullScreenDescription.Location = Point.Empty;
            lbFullScreenDescription.MaximumSize = new Size(Width, tlpPopDown.Height);
            lbFullScreenDescription.MinimumSize = new Size(Width, 1);
            lbFullScreenDescription.AutoSize = true;
            // END: something weird with the label.. (trying to keep it the position sane)..

            DisplayImage(); // display the currently selected image..
        }
        #endregion

        #region Layout
        /// <summary>
        /// Does to resizing of the navigation control buttons to scale for the current screen resolution (full screen).
        /// </summary>
        private void ResizeButtons()
        {
            int spacing = 1920 / 100 + 1; // my screen width.. voodoo and/or hoodoo magic :-)
            int leftStart = Width - (pnButtons.Height * pnButtons.Controls.Count) - (pnButtons.Controls.Count * spacing); // Calculate the most left position for the navigation control buttons
            leftStart /= 2; // some division for some reason
            foreach (Control ctrl in pnButtons.Controls) // Go thought the navigation control buttons
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
                    Convert.ToInt32((ctrl as Panel).Tag.ToString()) * spacing; // add some space between the navigation control buttons..
                                                                               // The ordering of the buttons is indicated by their Tag value, so use it for calculation too..
            }

            tlpPopDown.ColumnStyles[0].Width = leftStart / 2; // Span the right and left outer-most columns of the TableLayoutPanel..
            tlpPopDown.ColumnStyles[tlpPopDown.ColumnCount - 1].Width = leftStart / 2; // ..
            UtilsMisc.ResizeFontWidthHeight(lbImageDesc); // Resize the labels fonts
            UtilsMisc.ResizeFontHeight(lbToolTip, true); // END: Resize the labels fonts
        }
        #endregion

        #region ToolTips
        // Messages for the translated tool-tips
        private void ToolTipEnter(object sender, EventArgs e)
        {
            string toolTip = string.Empty;
            if (sender.Equals(btnPervious))
            {
                toolTip = DBLangEngine.GetMessage("msgPhotoAlbumPrevious", "Previous photo|A tool-tip to indicate that a button would select a previous photo from a photo album");
            }
            else if (sender.Equals(btnNext))
            {
                toolTip = DBLangEngine.GetMessage("msgPhotoAlbumNext", "Next photo|A tool-tip to indicate that a button would select a next photo from a photo album");
            }
            else if (sender.Equals(btnRotateClockwise))
            {
                toolTip = DBLangEngine.GetMessage("msgPhotoRotateClockwise", "Rotate clockwise|A tool-tip to indicate that a button would rotate a photo clockwise");
            }
            else if (sender.Equals(btnRotateCounterClockwise))
            {
                toolTip = DBLangEngine.GetMessage("msgPhotoRotateCounterClockwise", "Rotate counterclockwise|A tool-tip to indicate that a button would rotate a photo counterclockwise");
            }
            else if (sender.Equals(btnExit))
            {
                toolTip = DBLangEngine.GetMessage("msgPhotoAlbumExit", "Exit|A tool-tip for a photo album browser exit button");
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
            btnPervious.BackgroundImage = // navigation back button image..
                btnPervious.Enabled ? Properties.Resources.back : // the button is enabled..
                UtilsMisc.MakeGrayscale3(Properties.Resources.back); // the button is disabled..

            btnNext.BackgroundImage = // navigation forward button image..
                btnNext.Enabled ? Properties.Resources.forward : // the button is enabled..
                UtilsMisc.MakeGrayscale3(Properties.Resources.forward); // the button is disabled..
        }

        // Handle all the button clicks (Panel).
        private void CommonClickHandler(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Panel)) // only accept panels..
            {
                return;
            }

            Panel btn = (sender as Panel);

            if (btn.Equals(btnExit)) // if the close button was clicked..
            {
                Close(); // .. do close the form
            }
            else if (btn.Equals(btnNext)) // the next image/photo button was clicked..
            {
                DisplayNextImage(); // .. so display it..
            }
            else if (btn.Equals(btnPervious)) // the previous image/photo button was clicked..
            {
                DisplayPreviousImage(); // .. so display it..
            }
            else if (btn.Equals(btnRotateClockwise)) // the image/photo was requested to be rotated clockwise..
            {
                pbPhoto.RotateImageRight(); // .. so rotate it..
            }
            else if (btn.Equals(btnRotateCounterClockwise)) // the image/photo was requested to be rotated counterclockwise..
            {
                pbPhoto.RotateImageLeft(); // .. so rotate it..
            }
        }

        /// <summary>
        /// Sets the button states to enabled / disabled depending on the navigation state.
        /// </summary>
        private void SetButtonStates()
        {
            SetButtonImages(); // set the button images..
        }

        // make the "buttons" = panels to listen to the keyboard also..
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
            // only handle this key if the VPKSoft.ImagePanel is not in a keyboard zoom / pan mode..
            else if (e.KeyCode == Keys.Right && !pbPhoto.KeyboardZooming) 
            {
                
                DisplayNextImage();
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
            }
            // only handle this key if the VPKSoft.ImagePanel is not in a keyboard zoom / pan mode..
            else if (e.KeyCode == Keys.Left && !pbPhoto.KeyboardZooming)
            {
                DisplayPreviousImage();
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
            }
            // page down key rotates the image to the right..
            else if (e.KeyCode == Keys.PageDown)
            {
                pbPhoto.RotateImageRight(); // rotate the photo/image 90 degrees to the right..
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
            }
            // page down key rotates the image to the left..
            else if (e.KeyCode == Keys.PageUp)
            {
                pbPhoto.RotateImageLeft(); // rotate the photo/image 90 degrees to the left..
                e.SuppressKeyPress = true; // A "delegation" of this key is not needed..
                e.Handled = true; // This is handled..
            }
        }
        #endregion

        #region PhotoControlBox
        // a global mouse hook to ease up the mouse movement tracking on the form..
        private IKeyboardMouseEvents m_GlobalHook = null;


        // Handle mouse moving over the form.
        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (ActiveForm == null) // do nothing if the application is inactive..
            {
                return;
            }

            if (!popupHidden && e.Y >= tlpPopDown.Top) // If the pop-up navigation control bar is not hidden and the cursor hovers over it..
            {
                return; // .. we can return
            }

            if (e.Y >= Height - 20) // Show the pop-up navigation control bar, if the mouse cursor is less than 20 pixels from the bottom of the screen..
            {
                ShowPopDown(); // Show the pop-up navigation control bar..
            }
            else
            {
                HidePopDown(); // Hide the pop-up navigation control bar..
            }
        }

        private bool popupHidden = false; // This will be set to indicate if the navigation control bar is visible or not.

        /// <summary>
        /// Hides the "pop-up" navigation control bar..
        /// </summary>
        private void HidePopDown()
        {
            if (popupHidden) // If already hidden, there is no need to hide it
            {
                return;
            }

            lbFullScreenDescription.Visible = true;
            popupHidden = true; // We need to know if the navigation control bar is hidden or not..
            pbPhoto.Height = Height;

            tlpPopDown.Anchor = AnchorStyles.None; // Set its position of the screen
            tlpPopDown.Left = 0;
            tlpPopDown.Width = Width;
            tlpPopDown.Top = Height;
            ResizeButtons(); // Do resize and align the navigation related buttons to a "right" size..
            tlpPopDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        /// <summary>
        /// Shows the "pop-up" navigation control bar..
        /// </summary>
        private void ShowPopDown()
        {
            if (!popupHidden) // If already visible, there is no need to show it
            {
                return;
            }

            SetButtonStates(); // sets the button states to enabled / disabled depending on the navigation component's state..
            lbFullScreenDescription.Visible = false;

            popupHidden = false; // We need to know if the navigation control bar is hidden or not..


            tlpPopDown.Anchor = AnchorStyles.None; // Set its position on the screen
            tlpPopDown.Left = 0;
            tlpPopDown.Width = Width;
            tlpPopDown.Top = Height - tlpPopDown.Height;

            pbPhoto.Height = Height - tlpPopDown.Height;


            ResizeButtons(); // Do resize and align the navigation related buttons to a "right" size..
            tlpPopDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }
        #endregion

        #region DelegateEvents
        // the photo description label needs to be mouse-"transparent"..
        private void lbFullScreenDescription_MouseMove(object sender, MouseEventArgs e)
        {
            // ..so just delegate the mouse events on the label..
            Control label = (Control)sender;
            // delegate the mouse move event..
            pbPhoto.RaiseMouseMove(ImageViewer.CalcPointFromControl(label, e));
        }

        private void lbFullScreenDescription_MouseUp(object sender, MouseEventArgs e)
        {
            Control label = (Control)sender;
            // delegate the mouse up event..
            pbPhoto.RaiseMouseUp(ImageViewer.CalcPointFromControl(label, e));
        }

        private void lbFullScreenDescription_MouseDown(object sender, MouseEventArgs e)
        {
            Control label = (Control)sender;
            // delegate the mouse down event..
            pbPhoto.RaiseMouseDown(ImageViewer.CalcPointFromControl(label, e));
        }
        #endregion
    }
}
