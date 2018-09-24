using System;
using System.Windows.Forms;
using PdfiumViewer; // (C) https://github.com/pvginkel/PdfiumViewer, Apache license
using Gma.System.MouseKeyHook; // (C): https://github.com/gmamaladze/globalmousekeyhook, MIT license
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A PDF file viewer based on the Google's PDFium and the PdfiumViewer project.
    /// </summary>
    public partial class FormViewPDF : DBLangEngineWinforms
    {
        #region PrivateMembers
        // create a new instance of the PdfViewer class..
        private PdfiumViewer.PdfViewer pdfViewer = new PdfViewer();

        // a global mouse hook to ease up the mouse movement and keyboard event tracking on the form..
        private IKeyboardMouseEvents m_GlobalHook = null;

        // This will be set to indicate if the navigation control bar is visible or not.
        private bool popupHidden = true;
        #endregion

        #region MassiveConstructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FormViewPDF"/> class.
        /// </summary>
        public FormViewPDF()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            // add the PdfViewer control to the form
            pnMain.Controls.Add(pdfViewer); // add the PdfViewer control to the container panel..
            pdfViewer.Parent = pnMain; // set a parent control for the PdfViewer control..
            pdfViewer.ShowToolbar = false; // hide the PdfViewer control from the tool bar..
            pdfViewer.ZoomMode = PdfViewerZoomMode.FitWidth; // set the PdfViewer control to zoom to document's width..
            pdfViewer.Dock = DockStyle.Fill; // dock the PdfViewer control to fill the form..
            pdfViewer.LinkClick += PdfViewer_LinkClick; // assign a link click handler to the PdfViewer control..

            m_GlobalHook = Hook.GlobalEvents(); // The PdfViewer prevents the Form from getting mouse signals, so we add this (Gma.System.MouseKeyHook) event handler..
                                                // (C): https://github.com/gmamaladze/globalmousekeyhook, MIT license

            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove; // Add a global MouseMove event..
            m_GlobalHook.MouseDown += M_GlobalHook_MouseDown; // Add a global MouseDown event..
            m_GlobalHook.KeyDown += GlobalKeyDown; // Add a global KeyDown event..
        }
        #endregion

        /// <summary>
        /// Constructs a new instance of the ViewPDFForm class and displays it with the specified PDF file.
        /// </summary>
        /// <param name="pdfFile">A PDF file to display on the </param>
        public static void Execute(string pdfFile)
        {
            FormViewPDF formViewPDF = new FormViewPDF();
            formViewPDF.pdfViewer.Document = PdfDocument.Load(pdfFile);
            formViewPDF.Show();
        }

        #region GUILogic
        // a hyper link was clicked on the PdfViewer control..
        private void PdfViewer_LinkClick(object sender, LinkClickEventArgs e)
        {
            e.Handled = true;
            // ..so display a Gecko based web browser with the link's address..
            new FormWebBrowserGecko(e.Link.Uri).Show();
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
        }

        private void M_GlobalHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActiveForm == null) // do nothing if the application is inactive..
            {
                return;
            }

            if (!popupHidden) // If the bottom control bar is visible..
            {
                return; // .. then we do nothing..
            }
        }

        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (ActiveForm == null) // do nothing if the application is inactive..
            {
                return;
            }

            if (!popupHidden && e.Y >= tlpPopDown.Top) // If the pop-up control bar is not hidden and the cursor hovers over it..
            {
                return; // .. we can return
            }

            if (e.Y >= Height - 20) // Show the pop-up control bar, if the mouse cursor is less than 20 pixels from the bottom of the screen..
            {
                ShowPopDown(); // Show the pop-up control bar..
            }
            else
            {
                HidePopDown(); // Hide the pop-up control bar..
            }
        }

        // a close "button" was clicked.. 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close(); // ..so close the form..
        }


        private void FormViewPDF_Shown(object sender, EventArgs e)
        {
            // create a "suitable" size for the pop-up "tool bar"..
            tlpPopDown.Height = (int)(((double)Height) * 0.14);
            HidePopDown(); // Hide the browser control button bar..
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// Hides the "pop-up" control bar..
        /// </summary>
        private void HidePopDown()
        {
            if (popupHidden) // If already hidden, there is no need to hide it
            {
                return;
            }

            popupHidden = true; // We need to know if the control bar is hidden or not..

            tlpPopDown.Anchor = AnchorStyles.None; // Set its position of the screen
            tlpPopDown.Left = 0;
            tlpPopDown.Width = Width;
            tlpPopDown.Top = Height;
            tlpPopDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        /// <summary>
        /// Shows the "pop-up" control bar..
        /// </summary>
        private void ShowPopDown()
        {
            if (!popupHidden) // If already visible, there is no need to show it
            {
                return;
            }

            popupHidden = false; // We need to know if the control bar is hidden or not..

            tlpPopDown.Anchor = AnchorStyles.None; // Set its position on the screen
            tlpPopDown.Left = 0;
            tlpPopDown.Width = Width;
            tlpPopDown.Top = Height - tlpPopDown.Height;
            tlpPopDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }
        #endregion

        #region InternalLogic
        private void FormViewPDF_FormClosing(object sender, FormClosingEventArgs e)
        {
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

            using (pdfViewer) // dispose of the PdfViewer control..
            {
                // unsubscribe the event subscriptions from the PdfViewer control..
                pdfViewer.LinkClick -= PdfViewer_LinkClick;
            }
        }
        #endregion
    }
}
