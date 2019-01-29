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
using vamp.ampService;

namespace vamp
{
    /// <summary>
    /// A helper class for the amp# remote control.
    /// </summary>
    public static class AmpWCFHelper
    {
        /// <summary>
        /// Checks if this AlbumSongWCF class instance matches with a given search string.
        /// </summary>
        /// <param name="song">The song.</param>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public static bool Match(this AlbumSongWCF song, string search)
        {
            if (search.Trim() == string.Empty)
            {
                return true;
            }
            search = search.ToUpper().Trim();
            bool bfound1 =
                song.Artist.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                song.Album.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                song.Title.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                song.Year.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                song.Track.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                song.FullFileName.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                song.OverrideName.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                song.TagStr.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0;

            string[] search2 = search.Split(' ');
            if (search2.Length <= 1 || bfound1)
            {
                return bfound1;
            }
            bool bfound2 = true;
            string tmpStr;
            foreach (string str in search2)
            {
                tmpStr = str;
                bfound2 &=
                    song.Artist.IndexOf(tmpStr, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    song.Album.IndexOf(tmpStr, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    song.Title.IndexOf(tmpStr, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    song.Year.IndexOf(tmpStr, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    song.Track.IndexOf(tmpStr, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    song.FullFileName.IndexOf(tmpStr, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    song.OverrideName.IndexOf(tmpStr, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    song.TagStr.IndexOf(tmpStr, StringComparison.InvariantCultureIgnoreCase) >= 0;
            }
            return bfound1 || bfound2;
        }               
    }
}
