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

using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using VPKSoft.VideoBrowser; // (C): https://github.com/VPKSoft/VPKSoft.VisualComponents, GNU General Public License Version 3

namespace vamp
{
    /// <summary>
    /// A form to select either a movie or a TV show season episode from a list for playback.
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormSelectMovie : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormSelectMovie"/> class.
        /// </summary>
        public FormSelectMovie()
        {
            InitializeComponent();

            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("vamp.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }
        }

        // the current file's TMDb details..
        private TMDbDetailExt TMDbDetailExt { get; set; } = null;

        // a collection of VideoFileStatistic class instances to be shown on the form..
        private IEnumerable<VideoFileStatistic> statistics = null;

        /// <summary>
        /// Displays the FormSelectMovie form with given video file statistics and returns the item a user selected.
        /// </summary>
        /// <param name="statistics">A collection of video file statistics.</param>
        /// <param name="useTVShowEpisodeFileNameAsTitle">If set to <c>true</c> a file name without an extension is used as a title for a TV show season episode.</param>
        /// <returns>An instance of the VideoFileStatistic class representing the item the user selected from the dialog or null if no selection was made.</returns>
        public static VideoFileStatistic Execute(IEnumerable<VideoFileStatistic> statistics,
            bool useTVShowEpisodeFileNameAsTitle)
        {
            int tmpVideoDetailIndex = -1;
            int tmpVideoIndex = -1;

            return Execute(statistics, useTVShowEpisodeFileNameAsTitle, ref tmpVideoDetailIndex, ref tmpVideoIndex);
        }

        /// <summary>
        /// Displays the FormSelectMovie form with given video file statistics and returns the item a user selected.
        /// </summary>
        /// <param name="statistics">A collection of video file statistics.</param>
        /// <param name="useTVShowEpisodeFileNameAsTitle">If set to <c>true</c> a file name without an extension is used as a title for a TV show season episode.</param>
        /// <param name="videoDetailIndex">A reference to a video detail index for the from's VideoBrowser control.</param>
        /// <param name="videoIndex">A reference to a video index for the from's VideoBrowser control.</param>
        /// <returns>An instance of the VideoFileStatistic class representing the item the user selected from the dialog or null if no selection was made.</returns>
        public static VideoFileStatistic Execute(IEnumerable<VideoFileStatistic> statistics, 
            bool useTVShowEpisodeFileNameAsTitle,
            ref int videoDetailIndex, ref int videoIndex)
        {
            // don't display the dialog if the given collection of VideoFileStatistic class instances
            // is empty..
            if (statistics.Count() == 0)
            {
                // ..so just return null..
                return null;
            }

            // create a new instance of the FormSelectMovie form..
            FormSelectMovie form = new FormSelectMovie
            {
                // order the given VideoFileStatistic collection by title, season and episode and
                // set the form's statistics field with the ordered collection..
                statistics =
                statistics.
                    OrderBy(f => f.TMDbDetails.Title).
                    OrderBy(f => f.TMDbDetails.Season).
                    OrderBy(f => f.TMDbDetails.Episode)
            };

            // create a list of TMDbDetailExt class instances to be used to display the
            // video file list on the form's VideoBrowser control..
            List<TMDbDetailExt> details = new List<TMDbDetailExt>();

            // loop through the given collection of VideoFileStatistic..
            foreach (VideoFileStatistic statistic in form.statistics)
            {
                // set the title for a video file..
                statistic.TMDbDetails.Title =
                    // if the file name without extension was set to be used as a title..
                    useTVShowEpisodeFileNameAsTitle ?
                    // ..re-set the title of the TMDbDetailExt class instance accordingly..
                    Path.GetFileNameWithoutExtension(statistic.TMDbDetails.FileName) :
                    statistic.TMDbDetails.Title;

                // add the modified TMDbDetails member of the VideoFileStatistic to the list..
                details.Add(statistic.TMDbDetails);
            }

            // set the value of form's Videos field with the created list of
            // TMDbDetailExt class instances..
            form.videoBrowser.Videos = details;


            // set the video index with the given ref parameter's value..
            if (videoIndex > 0)
            {
                form.videoBrowser.VideoIndex = videoIndex;
            }

            // set the video detail index with the given ref parameter's value..
            if (videoDetailIndex > 0)
            {
                form.videoBrowser.VideoDetailIndex = videoDetailIndex;
            }

            // show the form..
            form.ShowDialog();

            // set the ref index integer parameter values..
            videoDetailIndex = form.videoBrowser.VideoDetailIndex;
            videoIndex = form.videoBrowser.VideoIndex;

            // use the "funny" AlmostEquals method to compare the user's selection to the TMDbDetailExt class instance
            // to the form's statistics collection and return the first matching value or null if no selection was made..
            return form.statistics.FirstOrDefault(f => f.TMDbDetails.AlmostEquals(form.TMDbDetailExt)); 
        }

        // set the form's TMDbDetailExt property value when the PlaybackRequested event is
        // raised from the form's VideoBrowser control's instance..
        private void videoBrowser_PlaybackRequested(object sender, TBDbDetailExtArgs e)
        {
            // set the property value..
            TMDbDetailExt = e.TMDbDetailExt;

            // close the form (dialog) with a DialogResult value of OK..
            DialogResult = DialogResult.OK;
        }
    }
}
