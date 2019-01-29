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

using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A form to indicate data loading process from the TMdb.
    /// </summary>
    public partial class FormTMDBLoadProgress : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormTMDBLoadProgress"/> class.
        /// </summary>
        public FormTMDBLoadProgress()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..
            DBLangEngine.AddNameSpace("VPKSoft.ImageButton"); // no localization from a foreign name space..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            DBLangEngine.InitalizeLanguage("vamp.Messages");

            formatPercentage = DBLangEngine.GetMessage("msgPercentage", "{0} %|An indicator of percentage");
        }

        private static FormTMDBLoadProgress progress = null;
        private static string formatPercentage = string.Empty;
        private static int previousPercentage;

        /// <summary>
        /// Shows the progress dialog while the application is loading data from the TMDb database.
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="easyClientConfigured">An indicator if the TMdbEasy class instance was successfully loaded.</param>
        public static void ShowProgress(int currentValue, int maximumValue, bool easyClientConfigured)
        {
            // create a new instance of the dialog if not already created..
            if (progress == null)
            {
                progress = new FormTMDBLoadProgress();

                if (!Settings.TMDBEnabled || !easyClientConfigured)
                {
                    // set the image according to the indicator if the TMDb database is in use..
                    progress.btLoading.ButtonImage = Properties.Resources.sand_class_steel_blue;

                    // refresh the form..
                    progress.Refresh();
                    Application.DoEvents();
                }

                // show the progress dialog..
                progress.Show();

                // set the previous percentage value to invalid..
                previousPercentage = -1;
            }

            int currentPercentage = 0;

            // calculate the current percentage value..
            if (maximumValue != 0)
            { 
                currentPercentage = currentValue * 100 / maximumValue;
            }

            // only update the current percentage value if it has been changed..
            if (currentPercentage != previousPercentage)
            {
                // set the percentage text..
                progress.lbPercentage.Text = string.Format(formatPercentage, currentPercentage == 0 ? "-" : currentPercentage.ToString());

                // refresh the form..
                progress.Refresh();
                Application.DoEvents();

                // save the current progress percentage..
                previousPercentage = currentPercentage;
            }            
        }

        /// <summary>
        /// Close the progress dialog after the application is done loading data from the TMDb database.
        /// </summary>
        public static void EndProgress()
        {
            // only close the progress form if initialized..
            if (progress != null)
            {
                // IDisposable so do dispose..
                using (progress)
                {
                    // close the form..
                    progress.Close();
                    progress = null;

                    // set the previous percentage value to valid..
                    previousPercentage = -1;
                }
            }
        }
    }
}
