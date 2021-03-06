﻿#region License
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

using vamp.ampService;

namespace vamp
{
    /// <summary>
    /// An extension class for the AlbumSongWCF class.
    /// </summary>
    /// <seealso cref="vamp.ampService.AlbumSongWCF" />
    public class AlbumSongWCFExt: AlbumSongWCF
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumSongWCFExt"/> class.
        /// </summary>
        /// <param name="albumSongWCF">A AlbumSongWCF class to copy the properties from.</param>
        public AlbumSongWCFExt(AlbumSongWCF albumSongWCF)
        {
            // set the properties..
            QueueIndex = albumSongWCF.QueueIndex;
            Rating = albumSongWCF.Rating;
            SongName = albumSongWCF.SongName;
            Album = albumSongWCF.SongName;
            Artist = albumSongWCF.Artist;
            Duration = albumSongWCF.Duration;
            FullFileName = albumSongWCF.FullFileName;
            ID = albumSongWCF.ID;
            OverrideName = albumSongWCF.OverrideName;
            SongNameNoQueue = albumSongWCF.SongNameNoQueue;
            TagStr = albumSongWCF.TagStr;
            Title = albumSongWCF.Title;
            Track = albumSongWCF.Track;
            Volume = albumSongWCF.Volume;
            Year = albumSongWCF.Year;
            // END: set the properties..
        }

        /// <summary>
        /// Creates a AlbumSongWCF class instance of a given AlbumSongWCFExt class instance.
        /// </summary>
        /// <param name="songWCFExt">An AlbumSongWCFExt class instance to covert to AlbumSongWCF class instance.</param>
        /// <returns>An AlbumSongWCF class instance of a given AlbumSongWCFExt class instance.</returns>
        public static AlbumSongWCF FromExt(AlbumSongWCFExt songWCFExt)
        {
            AlbumSongWCF result = new AlbumSongWCF();
            result.Album = songWCFExt.Album;
            result.Artist = songWCFExt.Artist;
            result.Duration = songWCFExt.Duration;
            result.FullFileName = songWCFExt.FullFileName;
            result.ID = songWCFExt.ID;
            result.OverrideName = songWCFExt.OverrideName;
            result.QueueIndex = songWCFExt.QueueIndex;
            result.Rating = songWCFExt.Rating;
            result.SongName = songWCFExt.SongName;
            result.SongNameNoQueue = songWCFExt.SongNameNoQueue;
            result.TagStr = songWCFExt.TagStr;
            result.Title = songWCFExt.Title;
            result.Track = songWCFExt.Track;
            result.Volume = songWCFExt.Volume;
            result.Year = songWCFExt.Year;
            return result;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return // an album song name with it's queue index..
                this.SongNameNoQueue +
                (QueueIndex > 0 ? " [" + QueueIndex + "]" : string.Empty);
        }
    }
}
