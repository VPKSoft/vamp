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
using System.Globalization;
using System.IO;
using VPKSoft.ConfLib; // (C): https://www.vpksoft.net/2015-03-31-13-33-28/libraries/conflib, GNU Lesser General Public License Version 3
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3

namespace vamp
{
    /// <summary>
    /// Settings for the vamp#.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// An instance to a Conflib class.
        /// </summary>
        private static Conflib Conflib = null;

        /// <summary>
        /// Initializes the Conflib class instance.
        /// </summary>
        private static void Init()
        {
            if (Conflib == null) // don't initialize if already initialized..
            {
                Conflib = new Conflib
                {
                    AutoCreateSettings = true // set it to auto-create SQLite database tables..
                }; // create a new instance of the Conflib class..
            }
        }

        /// <summary>
        /// Closes the Conflib class instance.
        /// </summary>
        public static void Close()
        {
            if (Conflib != null) // on if initialized..
            {
                // this disposes of the underlying SQlite database connection..
                Conflib.Close();
                Conflib = null; // set to null..
            }
        }

        /// <summary>
        /// Initializes the settings for the vamp# software.
        /// </summary>
        public static void InitSettings()
        {
            // only initialize if needed..
            if (!SettingsInitialized)
            {
                // create dummy self to self assignments so the default setting values go the config.sqlite database..
                AmpRemoteURL = AmpRemoteURL;
                MovieBaseDir = MovieBaseDir;
                TVShowBaseDir = TVShowBaseDir;
                PhotoBaseDir = PhotoBaseDir;
                UseDatabaseMemoryCache = UseDatabaseMemoryCache;
                UseMemoryForTMDbImagesCache = UseMemoryForTMDbImagesCache;
                TMDBEnabled = TMDBEnabled;
                TMDbImagesCacheDir = TMDbImagesCacheDir;
                TVShowEpisodeFileNameTitle = TVShowEpisodeFileNameTitle;
                Culture = Culture;
                // END: create dummy self to self assignments so the default setting values go the config.sqlite database..

                // indicate that the settings have now been initialized..
                SettingsInitialized = true;
            }
        }

        // an URL for the amp# (music player software) remote API..
        private static string _AmpRemoteURL = string.Empty;

        /// <summary>
        /// Gets or sets an URL for the amp# (music player software) remote API.
        /// </summary>
        public static string AmpRemoteURL
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _AmpRemoteURL == 
                    string.Empty ?
                    // the default (http://localhost:11316/ampRemote) is assumed..
                    Conflib["amp/amp_remote_url", "http://localhost:11316/ampRemote"] : _AmpRemoteURL;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _AmpRemoteURL = value; // set the value..
                Conflib["amp/amp_remote_url"] = value; // save the value to the config.sqlite database..
            }
        }

        // a base directory for movie files..
        private static string _MovieBaseDir = string.Empty;

        /// <summary>
        /// Gets or sets the base directory for movie files.
        /// </summary>
        public static string MovieBaseDir
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _MovieBaseDir == 
                    string.Empty ?
                    // assume the default is in the 'C:\Users\[profile name]\Videos directory..
                    Conflib["database/movie_base_dir", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)] : _MovieBaseDir;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _MovieBaseDir = value; // set the value..
                Conflib["database/movie_base_dir"] = value; // save the value to the config.sqlite database..
            }
        }

        // a value indicating if the file name should be used as title for a TV show episode..
        private static bool? _TVShowEpisodeFileNameTitle = null;

        /// <summary>
        /// Gets or sets a value indicating if the file name should be used as title for a TV show episode.
        /// </summary>
        public static bool TVShowEpisodeFileNameTitle
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..

                return _TVShowEpisodeFileNameTitle == null ?
                    // assume false..
                    bool.Parse(Conflib["misc/tv_show_use_filename", false.ToString()]) :
                    (bool)_TVShowEpisodeFileNameTitle;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _TVShowEpisodeFileNameTitle = value; // set the value..
                Conflib["misc/tv_show_use_filename"] = value.ToString(); // save the value to the config.sqlite database..
            }
        }

        // a base directory for TV show season files..
        private static string _TVShowBaseDir = string.Empty;

        /// <summary>
        /// Gets or sets the base directory for TV show season files.
        /// </summary>
        public static string TVShowBaseDir
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _MovieBaseDir == 
                    string.Empty ?
                    // assume the default is in the 'C:\Users\[profile name]\Videos directory..
                    Conflib["database/tv_base_dir", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)] : _TVShowBaseDir;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _TVShowBaseDir = value; // set the value..
                Conflib["database/tv_base_dir"] = value; // save the value to the config.sqlite database..
            }
        }

        // the current language (Culture) to be used with the software..
        private static CultureInfo _Culture = null;

        /// <summary>
        /// Gets or sets the current language (Culture) to be used with the software's localization.
        /// </summary>
        public static CultureInfo Culture
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _Culture == null ?
                    new CultureInfo(Conflib["language/culture", "en-US"].ToString()) :
                    _Culture;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _Culture = value;
                Conflib["language/culture"] = _Culture.Name;
            }
        }

        // a base directory for photo files..
        private static string _PhotoBaseDir = string.Empty;

        /// <summary>
        /// Gets or sets the base directory for photo files.
        /// </summary>
        public static string PhotoBaseDir
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _PhotoBaseDir == 
                    string.Empty ?
                    // assume the default is in the 'C:\Users\[profile name]\Pictures directory..
                    Conflib["database/photo_base_dir", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)] : _PhotoBaseDir;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _PhotoBaseDir = value; // set the value..
                Conflib["database/photo_base_dir"] = value; // save the value to the config.sqlite database..
            }
        }

        // indicates if the database's main contents should be loaded into the memory for faster access..
        private static bool? _UseDatabaseMemoryCache = null;

        /// <summary>
        /// Gets or sets a value indicating if the database's main contents should be loaded into the memory for faster access.
        /// </summary>
        public static bool UseDatabaseMemoryCache
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _UseDatabaseMemoryCache == null ? 
                    // assume false (set to true for faster computers..)..
                    bool.Parse(Conflib["database/cache_enabled", false.ToString()]) :
                    (bool)_UseDatabaseMemoryCache;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _UseDatabaseMemoryCache = value; // set the value..
                Conflib["database/cache_enabled"] = value.ToString(); // save the value to the config.sqlite database..
            }
        }

        // a value indicating if the poster/still images should be loaded in to the memory instead of caching them to the disk from the database..
        private static bool? _UseMemoryForTMDbImagesCache = null;

        /// <summary>
        /// Gets or sets a value indicating whether the poster/still images should be loaded in to the memory instead of caching them to the disk from the database.
        /// </summary>
        public static bool UseMemoryForTMDbImagesCache
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _UseMemoryForTMDbImagesCache == null ? 
                    // assume false as this takes a lot of memory depending of the size of the library..
                    bool.Parse(Conflib["database/tmbd_image_memory_cache", false.ToString()]) : 
                    (bool)_UseMemoryForTMDbImagesCache;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _UseMemoryForTMDbImagesCache = value; // set the value..
                Conflib["database/tmbd_image_memory_cache"] = value.ToString(); // save the value to the config.sqlite database..
            }
        }

        // a value indicating where the poster/still images from the TMDb should be cached in the file system..
        private static string _TMDbImagesCacheDir = string.Empty;

        /// <summary>
        /// Gets or sets the value indicating where the poster/still images from the TMDb should be cached in the file system.
        /// </summary>
        public static string TMDbImagesCacheDir
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..

                // assume the default is in the 'C:\Users\[user profile]\AppData\Local\vamp#\TBDbImageCache' directory..
                string dir = Path.Combine(VPKSoft.Utils.Paths.GetAppSettingsFolder(), "TBDbImageCache");

                // if no value has been set and the default directory doesn't exists, try to create a directory for 
                // the poster/still image cache..
                if (_TMDbImagesCacheDir == string.Empty && !Directory.Exists(dir))
                {
                    try
                    {
                        // no existing directory so try to create one..
                        Directory.CreateDirectory(dir);
                    }
                    catch (Exception ex)
                    {
                        // nothing do be done..

                        // log the exception..
                        ExceptionLogger.LogError(ex);
                    }
                }

                return _TMDbImagesCacheDir == string.Empty ? Conflib["database/tmbd_image_file_cache_dir", dir] : _TMDbImagesCacheDir;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..

                // if the given directory doesn't exist..
                if (!Directory.Exists(value))
                {
                    try // try to create one..
                    {
                        Directory.CreateDirectory(value);
                        _TMDbImagesCacheDir = value; // set the value..
                        Conflib["database/tmbd_image_file_cache_dir"] = value; // save the value to the config.sqlite database..
                    }
                    catch (Exception ex)
                    {
                        // nothing do be done.. the value is only saved if the directory creation succeeds..

                        // log the exception..
                        ExceptionLogger.LogError(ex);
                    }
                }
            }
        }

        // a value indicating whether to use the TMDb (The Movie Database) with the vamp# software..
        private static bool? _TMDBEnabled = null;

        /// <summary>
        /// Gets or sets a value indicating whether to use the TMDb (The Movie Database) with the vamp# software.
        /// </summary>
        public static bool TMDBEnabled
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _TMDBEnabled == null ? 
                    // definitely assume true..
                    bool.Parse(Conflib["misc/tmbd_enabled", true.ToString()]) : 
                    (bool)_TMDBEnabled;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _TMDBEnabled = value; // set the value..
                Conflib["misc/tmbd_enabled"] = value.ToString(); // save the value to the config.sqlite database..
            }
        }

        // a value indicating if the settings have been initialized to defaults or not..
        private static bool? _SettingsInitialized = null;

        /// <summary>
        /// Gets or sets a value indicating whether the settings have been initialized to defaults or not.
        /// </summary>
        public static bool SettingsInitialized
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _SettingsInitialized == null ?
                    // definitely assume false..
                    bool.Parse(Conflib["misc/settings_init", false.ToString()]) : 
                    (bool)_SettingsInitialized;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _SettingsInitialized = value; // set the value..
                Conflib["misc/settings_init"] = value.ToString(); // save the value to the config.sqlite database..
            }
        }

        // a value indicating the previous playback folder..
        private static string _PlayFolder = string.Empty;

        /// <summary>
        /// Gets or sets the previous playback folder.
        /// </summary>
        public static string PlayFolder
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _PlayFolder == string.Empty ?
                    // assume system "root"..
                    Conflib["paths/last_play_folder", ":DRIVES:"] :
                    _PlayFolder;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _PlayFolder = value; // set the value..
                Conflib["paths/last_play_folder"] = value; // save the value to the config.sqlite database..
            }
        }

        // a value indicating the previous folder which was browsed for a video file playback..
        private static string _LastBrowseFolder = string.Empty;

        /// <summary>
        /// Gets or sets the previous folder which was browsed for a video file playback.
        /// </summary>
        public static string LastBrowseFolder
        {
            get
            {
                Init(); // initialize the Conflib if not yet initialized..
                return _LastBrowseFolder == string.Empty ?
                    // assume system "root"..
                    Conflib["paths/last_browsed_folder", ":DRIVES:"] :
                    _LastBrowseFolder;
            }

            set
            {
                Init(); // initialize the Conflib if not yet initialized..
                _LastBrowseFolder = value; // set the value..
                Conflib["paths/last_browsed_folder"] = value; // save the value to the config.sqlite database..
            }
        }
    }
}
