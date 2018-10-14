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

using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A splash screen to so the status of the software loading.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FormSplash : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormSplash"/> class.
        /// </summary>
        public FormSplash()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            // initialize static localized messages..
            MsgBindExceptionLogger = DBLangEngine.GetMessage("msgBindExceptionLogger", "Binding exception logger|As in bind the application global exception logger");
            MsgVisualStyles = DBLangEngine.GetMessage("msgVisualStyles", "Visual styles|As in initializing the visual styles");
            MsgInitGeckoFXEngine = DBLangEngine.GetMessage("msgInitGeckoFXEngine", "Initialize GeckoFx engine|As in initialize the GeckoFX web browser engine");
            MsgInitChromiumEmbeddedFrameworkSettings = DBLangEngine.GetMessage("msgInitChromiumEmbeddedFrameworkSettings", "Initialize Chromium Embedded Framework settings");
            MsgLoadChromiumEmbeddedFramework = DBLangEngine.GetMessage("msgLoadChromiumEmbeddedFramework", "Load Chromium Embedded Framework");
            MsgLocalization = DBLangEngine.GetMessage("msgLocalization", "Localization|As in localize the main form");
            MsgInitDatabase = DBLangEngine.GetMessage("msgInitDatabase", "Initialize database|As in initialize the SQLite database connection and do some caching");
            MsgConfigureTMDbClient = DBLangEngine.GetMessage("msgConfigureTMDbClient", "Configure the TMDb client|As in configure the TMdbEasy client and get its configuration");
            MsgDatabaseCacheLoading = DBLangEngine.GetMessage("msgDatabaseCacheLoading", "Database cache loading|As in data from the SQLite database is being cached in to the memory");
            MsgDatabaseMediaLocationCacheLoading = DBLangEngine.GetMessage("msgMsgDatabaseMediaLocationCacheLoading", "Database media location cache loading|As in data from the SQLite database from the MEDIALOCATION and from the PHOTOALBUM tables are being cached in to the memory");
            MsgDatabasePhotoCacheLoading = DBLangEngine.GetMessage("msgDatabasePhotoCacheLoading", "Database photo file information cache loading|As in data from the SQLite database from the V_PHOTOALBUM view is being cached in to the memory");
            MsgInitializeVLCDotNet = DBLangEngine.GetMessage("msgInitializeVLCDotNet", "Initialize the VLC.DotNet|As in initialize the Vcl.DotNet library and underlying VLC native library");
            MsgDone = DBLangEngine.GetMessage("msgDone", "..done.|As in some operation is done");
            MsgReady = DBLangEngine.GetMessage("msgReady", "Ready|As in some operation is ready");
            MsgPercentage = DBLangEngine.GetMessage("msgPercentage", "{0} %|An indicator of percentage");
            // END: initialize static localized messages..

            // set the version to be seen..
            lbVersion.Text = "v." + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's exception logger has been bound. The setting this will enable localization.
        /// </summary>
        public static string MsgBindExceptionLogger { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's visual styles are enabled.
        /// </summary>
        public static string MsgVisualStyles { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's GeckoFX engine has been initialized.
        /// </summary>
        public static string MsgInitGeckoFXEngine { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's Chromium Embedded Framework has been initialized.
        /// </summary>
        public static string MsgInitChromiumEmbeddedFrameworkSettings { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's Chromium Embedded Framework has been loaded.
        /// </summary>
        public static string MsgLoadChromiumEmbeddedFramework { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's localization has been initialized.
        /// </summary>
        public static string MsgLocalization { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's SQLite database connection has been initialized.
        /// </summary>
        public static string MsgInitDatabase { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's TBdmEasy client has been initialized and it's configuration has been loaded.
        /// </summary>
        public static string MsgConfigureTMDbClient { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's database is being cached into the memory.
        /// </summary>
        public static string MsgDatabaseCacheLoading { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's database's media locations are being cached into the memory.
        /// </summary>
        public static string MsgDatabaseMediaLocationCacheLoading { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" while the program's database's photo file informations are being cached into memory.
        /// </summary>
        public static string MsgDatabasePhotoCacheLoading { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after the program's VLC.DotNet library has been initialized.
        /// </summary>
        public static string MsgInitializeVLCDotNet { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the splash "screen" after an item has reached 100 percent. The setting this will enable localization.
        /// </summary>
        public static string MsgDone { get; set; }


        /// <summary>
        /// Gets or sets the message to show when the splash "screen" is about to be closed. The setting this will enable localization.
        /// </summary>
        public static string MsgReady { get; set; }

        /// <summary>
        /// Gets or sets the format of how the percentage of loading should be shown. The setting this will enable localization.
        /// </summary>
        public static string MsgPercentage { get; set; }


        /// <summary>
        /// An instance to be constructed of this class when the program starts loading.
        /// </summary>
        private static FormSplash formSplash = null;

        /// <summary>
        /// An indicator if the splash screen has already been shown.
        /// </summary>
        private static bool splashShown = false;

        private static Thread splashThread = null;

        /// <summary>
        /// Shows the form splash form in a separate thread.
        /// </summary>
        public static void ShowFormSplash()
        {
            if (splashShown) // do not show if already shown..
            {
                return;
            }

            // a new thread is required..
            splashThread = new Thread(new ThreadStart(() =>
            {
                // set the indicator that the splash screen has been shown to avoid another time..
                splashShown = true;

                // construct the splash "screen"..
                formSplash = new FormSplash();
                Application.Run(formSplash); // a separate application run..
            }))
            {
                IsBackground = true // make it a background thread..
            };

            // set it a: The Thread will create and enter a single-threaded apartment.
            // (https://docs.microsoft.com/en-us/dotnet/api/system.threading.apartmentstate)..
            //            splashThread.SetApartmentState(ApartmentState.STA);

            splashThread.Start(); // start the thread..
        }

        /// <summary>
        /// Invokes the splash "screen" to close..
        /// </summary>
        public static void CloseFormSplash()
        {
            formSplash.Invoke(new MethodInvoker(() => 
            {
                using (formSplash)
                {
                    formSplash.Close();
                    formSplash = null;
                }
            }));

            while (!splashThread.Join(100))
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Sets the status of a loading operation by giving a name of the loading item and the minimum and maximum values.
        /// </summary>
        /// <param name="loadingItem">The name of the item currently loading.</param>
        /// <param name="currentValue">The current value of the loading process vs. the maximum value.</param>
        /// <param name="maximumValue">The value when given item has done loading.</param>
        public static void SetStatus(string loadingItem, int currentValue, int maximumValue)
        {
            if (maximumValue > 0) // if no division by zero..
            {
                // calculate the percentage and call the overload..
                SetStatus(loadingItem, currentValue * 100 / maximumValue);
            }
            else // .. otherwise call the overload by 100 percentage
            {
                SetStatus(loadingItem, 100);
            }
        }

        /// <summary>
        /// Sets the status of a loading operation by giving a name and the completion percentage.
        /// </summary>
        /// <param name="loadingItem">The name of the item currently loading.</param>
        /// <param name="percentage">The percentage indicating the loading process completion.</param>
        public static void SetStatus(string loadingItem, int percentage)
        {
            if (formSplash != null) // only do something to an existing object..
            {
                if (!formSplash.IsHandleCreated) // otherwise an exception will occur with Invoke method..
                {
                    return;
                }

                // as running in a separate thread do use the Invoke method..
                formSplash.Invoke(new MethodInvoker(() =>
                {
                    // the localization must come from elsewhere..
                    formSplash.lbLoadingItemValue.Text = loadingItem;

                    // set the percentage value..
                    formSplash.lbPercentage.Text = string.Format(MsgPercentage, percentage); // for localization this is also formatted..

                    // display a finalized task in a separate label..
                    if (percentage >= 100)
                    {
                        formSplash.lbLoadingItemValueDone.Text = loadingItem + MsgDone;
                    }
                }));
            }
        }

        private void FormSplash_FormClosing(object sender, FormClosingEventArgs e)
        {
            formSplash.lbLoadingItemValue.Text = MsgReady; // set the message that everything is ready..
            formSplash.lbLoadingItemValueDone.Text = MsgReady; // set the message that everything is ready..
            formSplash.lbPercentage.Text = string.Format(MsgPercentage, 100); // all is ready, so show 100 %..
        }
    }
}
