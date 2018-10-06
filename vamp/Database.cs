using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.IO;
using System.Globalization;
using VPKSoft.VideoBrowser;
using System.Drawing;
using TMdbEasy; // (C): https://github.com/tonykaralis/TMdbEasy, GNU General Public License Version 3
using VPKSoft.TMDbFileUtils; // (C): https://www.vpksoft.net/2015-03-31-13-33-28/libraries/vpksoft-tmdbfileutils, GNU General Public License Version 3
using MediaInfoDotNet; // (C): https://github.com/cschlote/MediaInfoDotNet/tree/master/MediaInfoDotNet, BSD-2-Clause license
using VPKSoft.SecureAPIKey; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3
using VPKSoft.ErrorLogger; // (C): https://www.vpksoft.net, GNU Lesser General Public License Version 3
using System.Xml.Linq;

namespace vamp
{
    #region DatabaseStructure
    /// <summary>
    /// An enumeration of the media location types.
    /// </summary>
    public enum MediaLocationType
    {
        /// <summary>
        /// A folder for a series directory.
        /// </summary>
        MediaLocationSeries = 0,

        /// <summary>
        /// A folder for a movie directory.
        /// </summary>
        MediaLocationMovie = 1,

        /// <summary>
        /// An URL to a web site from where you can watch videos.
        /// </summary>
        MediaLocationURL = 2,

        /// <summary>
        /// A photo album in some location.
        /// </summary>
        MediaLocationPhotoAlbum = 3,

        /// <summary>
        /// A path for a single file in a file system.
        /// </summary>
        MediaLocationSingleFile = 4,

        /// <summary>
        /// A path in the file system which was recently browsed.
        /// </summary>
        MediaLocationBrowsedPath = 5
    }

    /// <summary>
    /// A type of a video file in the database.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// Unknown file type.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The file is a TV show season episode.
        /// </summary>
        TVSeasonEpisode =1,

        /// <summary>
        /// The file is a movie.
        /// </summary>
        Movie = 2
    }

    /// <summary>
    /// A class describing a single entry of a video file in the database.
    /// <note type="note">Everything is written in uppercase as I still do think that SQL should be written in uppercase.</note>
    /// </summary>
    public class VIDEOFILE
    {
        /// <summary>
        /// ID INTEGER PRIMARY KEY AUTOINCREMENT.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// A file name without a path, but with an extension.
        /// </summary>
        public string FILENAME { get; set; }

        /// <summary>
        /// A full file name with path and extension.
        /// </summary>
        public string FILENAMEFULL { get; set; }

        /// <summary>
        /// A full path of the file.
        /// </summary>
        public string FILEPATH { get; set; }

        /// <summary>
        /// A size of a file in bytes.
        /// </summary>
        public long FILESIZE { get; set; }

        /// <summary>
        /// A volume used to play the file. The default is 100%.
        /// </summary>
        public float VOLUME { get; set; } = 100.0f;

        /// <summary>
        /// A long integer indicating the position if the playback on which the video file was previously stopped.
        /// <para/>The value is in milliseconds.
        /// </summary>
        public long PLAYBACKPOSITION { get; set; }

        /// <summary>
        /// A long integer describing the length of a video file. This is zero by default until statistics of the video file is saved.
        /// <para/>The value is in milliseconds.
        /// </summary>
        public long LENGTH { get; set; }

        /// <summary>
        /// A value indicating if a video file was once watched (played).
        /// </summary>
        public bool PLAYED { get; set; }

        /// <summary>
        /// A value indicating if the data for the video file was fetched from the TMDb database.
        /// </summary>
        public bool TMDBFETCHED { get; set; }

        /// <summary>
        /// A value indicating the file type of the file (TV show episode, movie, unknown, etc..)
        /// </summary>
        public FileType FILETYPE { get; set; }

        /// <summary>
        /// Details from the TMDb database.
        /// </summary>
        public TMDbDetailExt TMDbDetails { get; set; } = new TMDbDetailExt();
    }

    /// <summary>
    /// A class to represent the V_PHOTOALBUM view in the database.
    /// </summary>
    public class PhotoAlbumEntry
    {
        /// <summary>
        /// Gets or sets a name of the album.
        /// </summary>
        public string NAME { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a description of the photo file.
        /// </summary>        
        public string DESCRIPTION
        {
            get
            {
                // don't want to return nothing..
                if (DESCRIPTION_REAL == string.Empty && TAGTEXT == string.Empty)
                {
                    // so if all descriptive members are empty strings, return the file name..
                    return Path.GetFileNameWithoutExtension(FILENAME);
                }
                else if (DESCRIPTION_REAL == string.Empty && TAGTEXT != string.Empty)
                {
                    // return the tag text..
                    return TAGTEXT;
                }
                else
                {
                    // return the description..
                    return DESCRIPTION_REAL;
                }
            }

            set
            {
                DESCRIPTION_REAL = value;
            }
        }

        /// <summary>
        /// Gets or sets a description of the photo file without using any fall backs
        /// </summary>
        /// <value>
        /// The description real.
        /// </value>
        public string DESCRIPTION_REAL { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a date and time of the album photo file.
        /// </summary>
        public DateTime DATETIME { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets a file name of the photo file.
        /// </summary>
        public string FILENAME { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a concatenated tag text of the photo file.
        /// </summary>
        public string TAGTEXT { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the album.
        /// </summary>
        public string DATETIME_FREE { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a MD5 hash string for the photo file.
        /// </summary>
        public string MD5HASH { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a overridden base directory for the photo file in the album if any.
        /// </summary>
        public string BASEDIROVERRIDE { get; set; } = string.Empty;
    }

    /// <summary>
    /// A class describing a single entry of a location in the database.
    /// <note type="note">Everything is written in uppercase as I still do think that SQL should be written in uppercase.</note>
    /// </summary>
    public class MEDIALOCATION
    {
        /// <summary>
        /// ID INTEGER PRIMARY KEY AUTOINCREMENT.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// A location which can be almost anything describable by a string.
        /// </summary>
        public string LOCATION { get; set; }

        /// <summary>
        /// A parent location of the LOCATION member which can be almost anything describable by a string.
        /// </summary>
        public string PARENT_LOCATION { get; set; }

        /// <summary>
        /// A description for the location.
        /// </summary>
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// A type of this location which somehow should help to indicate to determine the LOCATION string member.
        /// </summary>
        public MediaLocationType TYPE { get; set; }

        /// <summary>
        /// A context of this location. This value is not limited to anything - just to describe the location context.
        /// <para/>The default value for the CONTEXT is 'DEFAULT'.
        /// </summary>
        public string CONTEXT { get; set; }

        /// <summary>
        /// A date and time for this media location item (used with photos, e.g.).
        /// </summary>
        public string DATE { get; set; } = "0000-00-00 00:00:00.000";
    }
    #endregion

    #region MiscClasses
    /// <summary>
    /// A class representing current statistics of a video file.
    /// </summary>
    public class VideoFileStatistic
    {
        /// <summary>
        /// A value indicating if the video file has once been played or watched to the end. A user sleep mode is not expected to be accounted for.
        /// </summary>
        public bool Played { get; set; }

        /// <summary>
        /// A position in the video file (milliseconds).
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        /// A length of a video file. This only has a value if the video file has at least once been played.
        /// <note type="note">The statistics of video files are not gathered without a user action.</note>
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// A volume of the video file in percentage of the base volume (100 %).
        /// </summary>
        public float Volume { get; set; } = 100.0f;

        /// <summary>
        /// A value indicating the file type of the file (TV show episode, movie, unknown, etc..)
        /// </summary>
        public FileType FileType { get; set; }

        /// <summary>
        /// Gets or sets the full file name and path of the video file.
        /// </summary>
        public string FileNameFull { get; set; }

        /// <summary>
        /// A value indicating if the data for the video file was fetched from the TMDb database.
        /// </summary>
        public bool TMDbFetched { get; set; }

        /// <summary>
        /// Gets the playback position in percentage if assigned.
        /// </summary>
        public double PlayBackPercentage
        {
            get
            {
                if (Length != 0)
                {
                    return (double)Position / Length * 100.0;
                }
                else
                {
                    return 0.0;
                }
            }
        }

        /// <summary>
        /// Details from the TMDb database.
        /// </summary>
        public TMDbDetailExt TMDbDetails { get; set; } = new TMDbDetailExt();
    }

    /// <summary>
    /// A type indicating of which the database is loading.
    /// </summary>
    public enum DatabaseLoadingType
    {
        /// <summary>
        /// The database contents are being cached into the memory.
        /// </summary>
        Caching = 0,

        /// <summary>
        /// The database media location contents are being cached into the memory.
        /// </summary>
        CachingMediaLocations = 1,

        /// <summary>
        /// The database photo file locations are being cached into the memory.
        /// </summary>
        CachingPhotoFileLocations = 2
    };

    /// <summary>
    /// Event arguments to indicate how much of the database is cached into the memory.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class DatabaseLoadingEventArgs: EventArgs
    {
        /// <summary>
        /// Gets or sets the current value of how many records are processed with the database.
        /// </summary>
        public int CurrentValue { get; set; } = 0;

        /// <summary>
        /// Gets or sets the maximum value of how many records will be processed.
        /// </summary>
        public int EndValue { get; set; } = 0;

        /// <summary>
        /// Gets or sets the type of which the database is loading.
        /// </summary>
        public DatabaseLoadingType DatabaseLoadingType { get; set; } = DatabaseLoadingType.Caching;
    }
    #endregion

    /// <summary>
    /// A static class the handle the SQLite database.
    /// </summary>
    public static class Database
    {
        #region PrivateMembers
        // the database connection to use..
        private static SQLiteConnection conn = null;

        // indicates if a cache is initialized for the database's VIDEOFILE table..
        private static bool cacheInitialized = false;

        // indicates if a cache is initialized for the database's LOCATION table..
        private static bool locationCacheInitialized = false;

        // indicates if a cache is initialized for the database's V_PHOTOALBUM view..
        private static bool photoAlbumCacheInitialized = false;

        // a cache which stores the VIDEOFILE table's contents at runtime.. do remember to save the cache before exiting the program..
        // ..a possible timed saving should be advisable too in a such rare case that the program consisting of N different libraries would crash..
        private static List<VIDEOFILE> fileCache = new List<VIDEOFILE>();

        // a cache which stores the MEDIALOCATION table's contents at runtime.. do remember to save the cache before exiting the program..
        // ..a possible timed saving should be advisable too in a such rare case that the program consisting of N different libraries would crash..
        private static List<MEDIALOCATION> medialocationCache = new List<MEDIALOCATION>();

        // a cache which stores the V_PHOTOALBUM view's contents at runtime.. 
        private static List<PhotoAlbumEntry> photoAlbumCache = new List<PhotoAlbumEntry>();
        #endregion

        /// <summary>
        /// Assigns a given reference of a SQLiteConnection class instance reference to be used as the database for this class.
        /// </summary>
        /// <param name="conn">An open SQLiteConnection connection class instance.</param>
        public static void InitConnection(ref SQLiteConnection conn)
        {
            Database.conn = conn; // save the given SQLiteConnection class instance reference..
            if (Settings.UseDatabaseMemoryCache)
            {
                InitCache(); // load the VIDEOFILE and photo album data table to a cache..
            }
        }

        #region Cache
        /// <summary>
        /// A delegate to be used to indicate a status of a long term database operations.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="DatabaseLoadingEventArgs"/>An instance containing the event data.</param>
        public delegate void OnDatabaseLoading(object sender, DatabaseLoadingEventArgs e);

        /// <summary>
        /// Occurs when something time taking operation is occurring with the database.
        /// </summary>
        public static event OnDatabaseLoading DatabaseLoading = null;

        /// <summary>
        /// Raises the DatabaseLoading event if subscribed.
        /// </summary>
        /// <param name="currentValue">The current value of the loading process.</param>
        /// <param name="endValue">The end value of the loading process.</param>
        /// <param name="databaseLoadingType">The type of the database loading process.</param>
        private static void RaiseDatabaseLoading(long currentValue, long endValue, DatabaseLoadingType databaseLoadingType)
        {
            // raise the DatabaseLoading event if subscribed..
            DatabaseLoading?.Invoke(typeof(Database),
            new DatabaseLoadingEventArgs()
            {
                CurrentValue = (int)currentValue, // set the current value of records processed..
                EndValue = (int)endValue, // set the value of how many records will be processed..
                DatabaseLoadingType = databaseLoadingType
            });
        }

        private static long GetRecordsAffected(string sql)
        {
            // get the amount of records the next query will return..
            using (SQLiteCommand command = new SQLiteCommand(conn))
            {
                command.CommandText = sql;
                return (long)command.ExecuteScalar(); // ..and save the amount to a variable..
            }
        }

        /// <summary>
        /// Reads everything from the VIDEOFILE table from the database to a in-memory cache.
        /// </summary>
        public static void InitCache()
        {
            int currentRecord = 0; // the current record being processed..

            // get the amount of records the next query will return..
            long recordsAffected = GetRecordsAffected("SELECT COUNT(*) FROM V_VIDEOFILE ");

            string sql = // no WHERE clause..
                "SELECT " + Environment.NewLine +
              // 0,  1,        2,            3,        4,      5,
                "ID, FILENAME, FILENAMEFULL, FILESIZE, VOLUME, PLAYBACKPOSITION, " + Environment.NewLine +
              // 6,      7,      8,        9,           10,     11,       12,        13,    14,
                "LENGTH, PLAYED, FILETYPE, TMDBFETCHED, TMDBID, SEASONID, EPISODEID, TITLE, DESCRIPTION, " + Environment.NewLine +
              // 15,                16,               17,     18,      19,
                "DETAILDESCRIPTION, POSTERORSTILLURL, SEASON, EPISODE, DURATION, " + Environment.NewLine +
              // 20,    21,            22,        23,            24
                "IMAGE, IMAGEFILENAME, IMAGESIZE, PLAYBACKSTATE, FILEPATH FROM V_VIDEOFILE ";

            fileCache.Clear(); // .. appending to a cache would be stupid..

                using (SQLiteDataReader dr = GetDataReaderFromSQL(sql)) // ..as this is an actual query, the results should be read..
                {
                    // raise the DatabaseLoading event if subscribed..
                    RaiseDatabaseLoading(0, recordsAffected, DatabaseLoadingType.Caching);

                while (dr.Read()) // .. while there is something to read..
                {
                    // don't return non-existing files..
                    if (!File.Exists(dr.GetString(2)))
                    {
                        continue; // ..so do continue..
                    }

                    fileCache.Add(new VIDEOFILE() // .. fill the previously mentioned cache..
                    {
                        ID = dr.GetInt32(0), // .. in an ordered manor..
                        FILENAME = dr.GetString(1),
                        FILENAMEFULL = dr.GetString(2),
                        FILESIZE = dr.GetInt64(3),
                        VOLUME = dr.GetFloat(4),
                        PLAYBACKPOSITION = dr.GetInt64(5),
                        PLAYED = dr.GetInt32(7) == 1,
                        LENGTH = dr.GetInt64(6), // .. that should be all.
                        TMDBFETCHED = dr.GetInt32(9) == 1,
                        FILETYPE = (FileType)dr.GetInt32(8),
                        FILEPATH = dr.GetString(24),
                        TMDbDetails = FromDataReader(dr, !Settings.UseMemoryForTMDbImagesCache, Settings.TMDbImagesCacheDir)
                    });
                    currentRecord++; // increase the amount of records processed..

                    // raise the DatabaseLoading event if subscribed..
                    RaiseDatabaseLoading(currentRecord, recordsAffected, DatabaseLoadingType.Caching);
                }
            }
            cacheInitialized = true; // indicate the "logic" that the database cache has been read.

            // get the amount of records the next query will return..
            recordsAffected = GetRecordsAffected("SELECT COUNT(*) + (SELECT COUNT(*) FROM PHOTOALBUM) FROM MEDIALOCATION ");
            currentRecord = 0; // the current record being processed..

            sql = // bad database design so make sure we get something .. IFNULL(NULLIF()) ..
                string.Format(
                "SELECT X.* FROM( " + Environment.NewLine +
                "SELECT ID, IFNULL(NULLIF(PARENT_LOCATION, ''), LOCATION) AS LOCATION, " + Environment.NewLine +
                "IFNULL(NULLIF(PARENT_LOCATION, ''), LOCATION) AS PARENT_LOCATION, " + Environment.NewLine +
                "DESCRIPTION, TYPE, CONTEXT, '0000-00-00 00:00:00.000' AS FIRSTDATE " + Environment.NewLine +
                "FROM MEDIALOCATION " + Environment.NewLine +
                "UNION " + Environment.NewLine +
                "SELECT -1 AS ID, IFNULL(BASEDIROVERRIDE, {0}) AS LOCATION," + Environment.NewLine +
                "IFNULL(BASEDIROVERRIDE, {1}) AS PARENT_LOCATION, " + Environment.NewLine +
                "NAME AS DESCRIPTION, 3 AS TYPE, 'PHOTOS' AS CONTEXT, FIRSTDATE " + Environment.NewLine +
                "FROM PHOTOALBUM) AS X " + Environment.NewLine +
                "ORDER BY X.FIRSTDATE, X.DESCRIPTION " + Environment.NewLine +
                "COLLATE NOCASE " + Environment.NewLine, QS(Settings.PhotoBaseDir), QS(Settings.PhotoBaseDir));

            medialocationCache.Clear(); // .. appending to a cache would be stupid..
                                        // as a SQLiteCommand is disposable confirm it will be disposed of..
            using (SQLiteDataReader dr = GetDataReaderFromSQL(sql)) // ..as this is an actual query, the results should be read..
            {
                // raise the DatabaseLoading event if subscribed..
                RaiseDatabaseLoading(0, recordsAffected, DatabaseLoadingType.CachingMediaLocations);

                while (dr.Read()) // .. while there is something to read..
                {
                    // non-existing directories are not allowed..
                    if (IsFileSystemLocation(dr.GetInt32(4)) && !Directory.Exists(dr.GetString(1)))
                    {
                        continue; // ..so continue..
                    }

                    //if (((MediaLocationType)dr.GetInt32(4)) == MediaLocationType.

                    medialocationCache.Add( // .. fill the previously mentioned cache..
                        new MEDIALOCATION()
                        {
                            ID = dr.GetInt32(0),
                            LOCATION = dr.GetString(1),
                            PARENT_LOCATION = dr.GetString(2),
                            DESCRIPTION = dr.GetString(3),
                            TYPE = (MediaLocationType)dr.GetInt32(4),
                            CONTEXT = dr.GetString(5),
                            DATE = dr.GetString(6)
                        });
                    currentRecord++; // increase the amount of records processed..

                    // raise the DatabaseLoading event if subscribed..
                    RaiseDatabaseLoading(currentRecord, recordsAffected, DatabaseLoadingType.CachingMediaLocations);
                }
            }

            locationCacheInitialized = true; // indicate the "logic" that the database cache has been read.

            // get the amount of records the next query will return..
            recordsAffected = GetRecordsAffected("SELECT COUNT(*) FROM V_PHOTOALBUM ");
            currentRecord = 0; // the current record being processed..

            photoAlbumCache.Clear();
            sql =
                "SELECT NAME, DESCRIPTION, DATETIME, FILENAME, IFNULL(TAGTEXT, '') AS TAGTEXT, " + Environment.NewLine +
                "IFNULL(DATETIME_FREE, '') AS DATETIME_FREE, MD5HASH, " + Environment.NewLine +
                "IFNULL(BASEDIROVERRIDE, '') AS BASEDIROVERRIDE " + Environment.NewLine +
                "FROM V_PHOTOALBUM ORDER BY DATETIME, DESCRIPTION, FILENAME COLLATE NOCASE ";

            using (SQLiteDataReader dr = GetDataReaderFromSQL(sql))
            {
                // raise the DatabaseLoading event if subscribed..
                RaiseDatabaseLoading(0, recordsAffected, DatabaseLoadingType.CachingPhotoFileLocations);
                while (dr.Read())
                {
                    photoAlbumCache.Add(
                        new PhotoAlbumEntry
                        {
                            NAME = dr.GetString(0),
                            DESCRIPTION_REAL = dr.GetString(1),
                            DATETIME = DateTime.ParseExact(dr.GetString(2), "yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture),
                            FILENAME = dr.GetString(3),
                            TAGTEXT = dr.GetString(4),
                            DATETIME_FREE = dr.GetString(5),
                            MD5HASH = dr.GetString(6),
                            BASEDIROVERRIDE = dr.GetString(7)
                        });
                    currentRecord++; // increase the amount of records processed..

                    // raise the DatabaseLoading event if subscribed..
                    RaiseDatabaseLoading(currentRecord, recordsAffected, DatabaseLoadingType.CachingPhotoFileLocations);
                }
            }

            photoAlbumCacheInitialized = true; // indicate the "logic" that the database cache has been read.
        }

        /// <summary>
        /// Saves the cache read from the database tables VIDEOFILE and MEDIALOCATION to the database.
        /// </summary>
        public static void WriteCache()
        {
            if (!cacheInitialized) // if no cache was never constructed, nothing needs to be written..
            {
                return;
            }

            string sql = 
                "DELETE FROM VIDEOFILE; "; // to avoid complex logic we just delete everything..

            // it's not wanted that an 64 bit integer overflow would occur in the history of the known universe :-)
            sql += 
                "DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'VIDEOFILE'; ";

            foreach (VIDEOFILE videoFile in fileCache) // these are new VIDEOFILE entries in with a condition that the file name and size are unique..
            {
                sql += string.Format(
                "INSERT INTO VIDEOFILE(FILENAME, FILENAMEFULL, FILESIZE, VOLUME, PLAYBACKPOSITION, LENGTH, PLAYED, FILETYPE, TMDBFETCHED) " + Environment.NewLine +
                "SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}; " + Environment.NewLine, // .. a semicolon is required for
                QS(videoFile.FILENAME), // the values..                             // multiple statements..
                QS(videoFile.FILENAMEFULL),
                videoFile.FILESIZE,
                videoFile.VOLUME,
                videoFile.PLAYBACKPOSITION,
                videoFile.LENGTH,
                videoFile.PLAYED ? 1 : 0,
                (int)videoFile.FILETYPE,
                videoFile.TMDBFETCHED ? 1 : 0);
            }

            ExecuteArbitrarySQL(sql); // run the sentence against the database..

            // the MEDIALOCATION table's cache..
            sql = 
                "DELETE FROM MEDIALOCATION; "; // to avoid complex logic we just delete everything..
            // it's not wanted that an 64 bit integer overflow would occur in the history of the known universe :-)
            sql += 
                "DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'MEDIALOCATION'; ";
            foreach (MEDIALOCATION location in medialocationCache)
            {
                if (location.TYPE == MediaLocationType.MediaLocationPhotoAlbum)
                {
                    continue; // different handling for these..
                }
                sql += string.Format( // now do formulate a SQL sentence..
                    "INSERT INTO MEDIALOCATION (LOCATION, DESCRIPTION, PARENT_LOCATION, TYPE, CONTEXT) " + Environment.NewLine +
                    "SELECT {0}, {1}, {2}, {3}, {4}; " + Environment.NewLine, // .. a semicolon is required for
                    QS(location.LOCATION),                                    // multiple statements..
                    QS(location.DESCRIPTION),
                    QS(location.PARENT_LOCATION == "" ? location.LOCATION : location.PARENT_LOCATION), // if no parent location the parent is it self..
                    (int)location.TYPE,
                    QS(location.CONTEXT));
            }

            ExecuteArbitrarySQL(sql); // run the sentence against the database..
        }
        #endregion

        #region VideoFile
        /// <summary>
        /// A conditional database or cache insert or update for a video file.
        /// </summary>
        /// <param name="fileName">A full file name of the video file.</param>
        /// <param name="detailExt">A TMDbDetailExt class instance which stores the TMDb database data.</param>
        /// <param name="position">A position where the playback was (milliseconds).</param>
        /// <param name="length">A length of the video file (milliseconds).</param>
        /// <param name="played">A value indicating if the video was watched / played to the end or not.
        /// <para/>A user sleep mode is not expected to be accounted for.</param>
        /// <param name="volume">A volume value to save for this video file - in case it was adjusted.</param>
        public static void SetFile(string fileName, TMDbDetailExt detailExt, long position = 0, long length = 0, bool played = false, float volume = 100.0f)
        {
            SetFile(fileName, position, length, played, volume, detailExt);
        }

        /// <summary>
        /// A conditional database or cache insert or update for a video file.
        /// </summary>
        /// <param name="fileName">A full file name of the video file.</param>
        /// <param name="position">A position where the playback was (milliseconds).</param>
        /// <param name="length">A length of the video file (milliseconds).</param>
        /// <param name="played">A value indicating if the video was watched / played to the end or not.
        /// <para/>A user sleep mode is not expected to be accounted for.</param>
        /// <param name="volume">A volume value to save for this video file - in case it was adjusted.</param>
        /// <param name="detailExt">A TMDbDetailExt class instance which stores the TMDb database data.</param>
        public static void SetFile(string fileName, long position = 0, long length = 0, bool played = false, float volume = 100.0f, TMDbDetailExt detailExt = null)
        {
            FileType fileType = GetFileType(fileName); // get the file type with "weird algorithm"..
            FileInfo fileInfo = new FileInfo(fileName); // file info can give a size of a file..
            if (cacheInitialized) // if the whole VIDEOFILE table from the database was read to a cache..
            {
                // ..then do LINQ without the stupid syntax.. 
                VIDEOFILE videoFile = fileCache.FirstOrDefault(f => f.FILENAME == Path.GetFileName(fileName) && f.FILESIZE == fileInfo.Length);
                if (videoFile == null) // .. nothing was found, so this must be a new file..
                {
                    fileCache.Add(
                    new VIDEOFILE() // .. so do add in the cache..
                    {
                        ID = -1,
                        FILENAME = Path.GetFileName(fileName),
                        FILENAMEFULL = fileName,
                        FILESIZE = fileInfo.Length,
                        VOLUME = volume,
                        PLAYBACKPOSITION = position,
                        LENGTH = length,
                        PLAYED = played,
                        FILETYPE = fileType,
                        TMDBFETCHED = false
                    });
                }
                else // if the DMDb details where updated, then update then to cache..
                {
                    if (videoFile.TMDbDetails.ID == -1 && detailExt != null) // if the given parameter is not null..
                    {
                        videoFile.TMDbDetails = detailExt; // set the TMDbDetailExt for the VIDEOFILE class instance..
                        videoFile.TMDBFETCHED = true; // set the TMDb database details fetched flag to true..
                    }
                }
            }
            else // .. or else add it directly to the database..
            {
                string sql = // .. do a conditional insert based on the full file name and file size..
                    string.Format(
                    "INSERT INTO VIDEOFILE(FILENAME, FILENAMEFULL, FILESIZE, VOLUME, PLAYBACKPOSITION, LENGTH, PLAYED, FILETYPE, TMDBFETCHED) " + Environment.NewLine +
                    "SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8} " + Environment.NewLine +
                    "WHERE NOT EXISTS(SELECT * FROM VIDEOFILE WHERE FILENAME = {9} AND FILESIZE = {10}) ",
                    QS(Path.GetFileName(fileName)),
                    QS(fileName),
                    fileInfo.Length,
                    volume,
                    position,
                    played ? 1 : 0,
                    length,
                    (int)fileType,
                    detailExt != null ? 1 : 0, // if the given parameter is not null..
                    QS(Path.GetFileName(fileName)),
                    fileInfo.Length);

                ExecuteArbitrarySQL(sql); // run the sentence against the database..
            }
        }

        /// <summary>
        /// This will cause a previously video file statistics to be updated or a new file to be inserted to a database (or cache).
        /// </summary>
        /// <param name="fileName">A full file name to be either inserted or updated.</param>
        /// <param name="detailExt">A TMDbDetailExt class instance which stores the TMDb database data.</param>
        /// <param name="position">A position which the playback was (milliseconds).</param>
        /// <param name="length">A length of the video file if it was gotten from somewhere (milliseconds).</param>
        /// <param name="played">A value indicating if the video was watched / played to the end or not.
        /// <para/>A user sleep mode is not expected to be accounted for.</param>
        /// <param name="volume">A volume value to save for this video file - in case it was adjusted.</param>
        public static void UpdateFile(string fileName, TMDbDetailExt detailExt, long position = 0, long length = 0, bool played = false, float volume = 100.0f)
        {
            UpdateFile(fileName, position, length, played, volume, detailExt);
        }


        /// <summary>
        /// This will cause a previously video file statistics to be updated or a new file to be inserted to a database (or cache).
        /// </summary>
        /// <param name="fileName">A full file name to be either inserted or updated.</param>
        /// <param name="position">A position which the playback was (milliseconds).</param>
        /// <param name="length">A length of the video file if it was gotten from somewhere (milliseconds).</param>
        /// <param name="played">A value indicating if the video was watched / played to the end or not.
        /// <para/>A user sleep mode is not expected to be accounted for.</param>
        /// <param name="volume">A volume value to save for this video file - in case it was adjusted.</param>
        /// <param name="detailExt">A TMDbDetailExt class instance which stores the TMDb database data.</param>
        public static void UpdateFile(string fileName, long position = 0, long length = 0, bool played = false, float volume = 100.0f, TMDbDetailExt detailExt = null)
        {
            FileType fileType = GetFileType(fileName); // get the file type with "weird algorithm"..
            FileInfo fileInfo = new FileInfo(fileName); // file info can give a size of a file..

            if (cacheInitialized) // if the whole VIDEOFILE table from the database was read to a cache..
            {
                // ..then do LINQ without the stupid syntax.. 
                int idx = fileCache.FindIndex(f => f.FILENAME == Path.GetFileName(fileName) && f.FILESIZE == fileInfo.Length && f.PLAYED == played);
                if (idx != -1) // a video file with a valid index was found..
                {
                    // .. so update it..
                    fileCache[idx].VOLUME = volume;
                    fileCache[idx].PLAYBACKPOSITION = position;
                    fileCache[idx].PLAYED = played;
                    fileCache[idx].LENGTH = length;
                    fileCache[idx].FILETYPE = fileType;
                    fileCache[idx].FILENAMEFULL = fileName;

                    // update the DMDb details if there is anything to be updated..
                    if (fileCache[idx].TMDbDetails.ID == -1 && detailExt != null)
                    {
                        fileCache[idx].TMDbDetails = detailExt;
                    }
                }
                else // a video file with a valid index wasn't found.. try to find an index without the played condition..
                {
                    // ..then do LINQ without the stupid syntax.. 
                    idx = fileCache.FindIndex(f => f.FILENAME == Path.GetFileName(fileName) && f.FILESIZE == fileInfo.Length);
                    if (idx != -1) // a video file with a valid index was found..
                    {
                        // .. so update it..
                        fileCache[idx].VOLUME = volume;
                        fileCache[idx].PLAYBACKPOSITION = position;
                        fileCache[idx].LENGTH = length;
                        fileCache[idx].FILETYPE = fileType;
                        fileCache[idx].FILENAMEFULL = fileName;
                        if (!fileCache[idx].PLAYED)
                        {
                            fileCache[idx].PLAYED = played;
                        }

                        // update the DMDb details if there is anything to be updated..
                        if (fileCache[idx].TMDbDetails.ID == -1 && detailExt != null)
                        {
                            fileCache[idx].TMDbDetails = detailExt;
                        }
                    }
                }
            }
            else // if no cache was initialized, just do the same above with SQL..
            {
                string sql = string.Format( // first try to update with the played flag..
                    "UPDATE VIDEOFILE SET VOLUME = {0}, PLAYBACKPOSITION = {1}, PLAYED = {2}, LENGTH = {3}, TMDBFETCHED = {4}, " + Environment.NewLine +
                    "FILETYPE = {5}, FILENAMEFULL = {6} " + Environment.NewLine +
                    "WHERE FILENAME = {7} AND FILESIZE = {8} AND PLAYED = 0 " + Environment.NewLine,
                    volume,
                    position,
                    played ? 1 : 0,
                    length,
                    (detailExt != null && detailExt.ID != -1) ? 1 : 0,
                    (int)fileType,
                    QS(fileName),
                    QS(Path.GetFileName(fileName)),
                    fileInfo.Length);

                ExecuteArbitrarySQL(sql); // run the sentence against the database..


                sql = string.Format( // try to update without the played flag..
                    "UPDATE VIDEOFILE SET VOLUME = {0}, PLAYBACKPOSITION = {1}, LENGTH = {2}, " + Environment.NewLine +
                    "TMDBFETCHED = {3}, FILETYPE = {4}, FILENAMEFULL = {5} " + Environment.NewLine +
                    "WHERE FILENAME = {6} AND FILESIZE = {7} " + Environment.NewLine,
                    volume,
                    position,
                    length,
                    (detailExt != null && detailExt.ID != -1) ? 1 : 0,
                    (int)fileType,
                    QS(fileName),
                    QS(Path.GetFileName(fileName)),
                    fileInfo.Length);

                ExecuteArbitrarySQL(sql); // run the sentence against the database..
            }
        }

        /// <summary>
        /// Gets the statistic of a video file based on the given type of the video file.
        /// </summary>
        /// <param name="fileType">A file type enumeration of the video file's type.</param>
        /// <param name="mediaLocationType">A MediaLocationType enumeration to indicate the type of the media location.</param>
        /// <param name="context">A value for the CONTEXT column from the MEDIALOCATION table.</param>
        /// <param name="filterDirectory">An optional path to filter directories with.</param>
        /// <returns>A collection of VideoFileStatistic class instances matching the given file type.</returns>
        public static IEnumerable<VideoFileStatistic> GetStatistic(FileType fileType, MediaLocationType mediaLocationType, string context, string filterDirectory = "")
        {
            // append the last directory separator character to the path if it doesn't already exist..
            if (filterDirectory.Length > 0 && 
                filterDirectory.Last() != Path.DirectorySeparatorChar)
            {
                filterDirectory += Path.DirectorySeparatorChar;
            }

            if (cacheInitialized) // if the whole VIDEOFILE table from the database was read to a cache..
            {
                var videoFiles =
                    fileCache.Where(f => (f.FILETYPE == fileType || f.FILETYPE == FileType.Unknown) &&
                                    medialocationCache.Exists(m => f.FILENAMEFULL.StartsWith(m.LOCATION) &&
                                    m.CONTEXT == context && m.TYPE == mediaLocationType) &&
                                    (f.FILEPATH.StartsWith(filterDirectory) || filterDirectory == string.Empty));
                foreach (var videoFile in videoFiles)
                {
                    // don't return non-existing files..
                    if (!File.Exists(videoFile.FILENAMEFULL))
                    {
                        continue; // ..so do continue..
                    }
                    yield return new VideoFileStatistic()
                    {
                        Played = videoFile.PLAYED,
                        Position = videoFile.PLAYBACKPOSITION,
                        Volume = videoFile.VOLUME,
                        Length = videoFile.LENGTH,
                        TMDbFetched = videoFile.TMDBFETCHED,
                        FileType = videoFile.FILETYPE,
                        TMDbDetails = videoFile.TMDbDetails,
                        FileNameFull = videoFile.FILENAMEFULL
                    };
                }
            }
            else // no cache was initialized, so get the video file statistics from the database..
            {
                string sql = string.Format( // now do formulate a SQL sentence..
                "SELECT " + Environment.NewLine +
              // 0,    1,          2,              3,          4,        5,
                "V.ID, V.FILENAME, V.FILENAMEFULL, V.FILESIZE, V.VOLUME, V.PLAYBACKPOSITION, " + Environment.NewLine +
              // 6,        7,        8,          9,             10,       11,         12,          13,      14,
                "V.LENGTH, V.PLAYED, V.FILETYPE, V.TMDBFETCHED, V.TMDBID, V.SEASONID, V.EPISODEID, V.TITLE, V.DESCRIPTION, " + Environment.NewLine +
              // 15,                  16,                 17,       18,        19,
                "V.DETAILDESCRIPTION, V.POSTERORSTILLURL, V.SEASON, V.EPISODE, V.DURATION, " + Environment.NewLine +
              // 20,      21,              22,          23,              24
                "V.IMAGE, V.IMAGEFILENAME, V.IMAGESIZE, V.PLAYBACKSTATE, V.FILEPATH FROM V_VIDEOFILE V " + Environment.NewLine +
                "  JOIN MEDIALOCATION M ON (INSTR(V.FILENAMEFULL, M.LOCATION) > 0 AND M.TYPE = {0} AND M.CONTEXT = {1}) " + Environment.NewLine +
                "WHERE (V.FILETYPE = {2} OR V.FILETYPE = {3}) " +
                // alternative directory filter..
                (filterDirectory == string.Empty ? string.Empty : "AND " + Environment.NewLine + $"INSTR(V.FILEPATH, {QS(filterDirectory)}) = 1 "),
                (int)mediaLocationType,
                QS(context),
                (int)fileType,
                (int)FileType.Unknown);

                // And as a SQLiteDataReader is disposable also, confirm it will be disposed of..
                using (SQLiteDataReader dr = GetDataReaderFromSQL(sql))
                {
                    while (dr.Read()) // while data is coming from the database..
                    {
                        // don't return non-existing files..
                        if (!File.Exists(dr.GetString(2)))
                        {
                            continue; // ..so do continue..
                        }

                        // first result should also be the last in this case (uniqueness)..
                        yield return new VideoFileStatistic()
                        {
                            Played = dr.GetInt32(7) == 1,
                            Position = dr.GetInt64(5),
                            Volume = dr.GetFloat(4),
                            Length = dr.GetInt64(6),
                            FileType = (FileType)dr.GetInt32(8),
                            TMDbFetched = dr.GetInt32(9) == 1,
                            TMDbDetails = FromDataReader(dr, !Settings.UseMemoryForTMDbImagesCache, Settings.TMDbImagesCacheDir),
                            FileNameFull = dr.GetString(2)
                        };
                    }
                }
            }
        }

        /// <summary>
        /// Gets a VideoFileStatistic class instance either from the database or from the cache.
        /// </summary>
        /// <param name="fileName">A file name for a video file to get the statistics to.</param>
        /// <returns>A VideoFileStatistic class instance.</returns>
        public static VideoFileStatistic GetStatistic(string fileName)
        {
            SetFile(fileName); // if the video file has never been "introduced" to the database, do so.
            FileInfo fileInfo = new FileInfo(fileName); // file info can give a size of a file..

            if (cacheInitialized) // if the whole VIDEOFILE table from the database was read to a cache..
            {
                // ..then do LINQ without the stupid syntax.. 
                VIDEOFILE videoFile =
                    fileCache.FirstOrDefault(f => f.FILENAME == Path.GetFileName(fileName) &&
                                             f.FILESIZE == fileInfo.Length);
                if (videoFile != null && File.Exists(videoFile.FILENAMEFULL)) // if a video file was found from the cache the return it's statistics..
                {
                    return new VideoFileStatistic()
                    {
                        Played = videoFile.PLAYED,
                        Position = videoFile.PLAYBACKPOSITION,
                        Volume = videoFile.VOLUME,
                        Length = videoFile.LENGTH,
                        TMDbFetched = videoFile.TMDBFETCHED,
                        FileType = videoFile.FILETYPE,
                        TMDbDetails = videoFile.TMDbDetails,
                        FileNameFull = videoFile.FILENAMEFULL
                    };
                }
                else // otherwise return "empty". Do note that this shouldn't happen ever.
                {
                    return new VideoFileStatistic()
                    {
                        Played = false,
                        Position = 0,
                        Volume = 100.0f,
                        Length = 0,
                        FileType = FileType.Unknown,
                        TMDbFetched = false,
                        FileNameFull = string.Empty
                    };
                }
            }
            else // no cache was initialized, so get the video file statistics from the database..
            {
                string sql = string.Format( // now do formulate a SQL sentence..
                "SELECT " + Environment.NewLine +
              // 0,  1,        2,            3,        4,      5,
                "ID, FILENAME, FILENAMEFULL, FILESIZE, VOLUME, PLAYBACKPOSITION, " + Environment.NewLine +
              // 6,      7,      8,        9,           10,     11,       12,        13,    14,
                "LENGTH, PLAYED, FILETYPE, TMDBFETCHED, TMDBID, SEASONID, EPISODEID, TITLE, DESCRIPTION, " + Environment.NewLine +
              // 15,                16,               17,     18,      19,
                "DETAILDESCRIPTION, POSTERORSTILLURL, SEASON, EPISODE, DURATION, " + Environment.NewLine +
              // 20,    21,            22,        23
                "IMAGE, IMAGEFILENAME, IMAGESIZE, PLAYBACKSTATE FROM V_VIDEOFILE WHERE FILENAME = {0} AND FILESIZE = {1}",
                QS(Path.GetFileName(fileName)),
                fileInfo.Length);

                // And as a SQLiteDataReader is disposable also, confirm it will be disposed of..
                using (SQLiteDataReader dr = GetDataReaderFromSQL(sql))
                {
                    // if data is coming from the database and
                    // the file in the data exits..
                    if (dr.Read() && File.Exists(dr.GetString(2)))
                    {
                        // first result should also be the last in this case (uniqueness)..
                        return new VideoFileStatistic()
                        {
                            Played = dr.GetInt32(7) == 1,
                            Position = dr.GetInt64(5),
                            Volume = dr.GetFloat(4),
                            Length = dr.GetInt64(6),
                            FileType = (FileType)dr.GetInt32(8),
                            TMDbFetched = dr.GetInt32(9) == 1,
                            TMDbDetails = FromDataReader(dr, !Settings.UseMemoryForTMDbImagesCache, Settings.TMDbImagesCacheDir),
                            FileNameFull = dr.GetString(2)
                        };
                    }
                }

                // nothing was found? - return "empty". Do note that this shouldn't happen ever.
                return new VideoFileStatistic() { Played = false, Position = 0, Length = 0, FileNameFull = string.Empty, FileType = FileType.Unknown, TMDbFetched = false };
            }
        }
        #endregion

        #region MediaLocation
        /// <summary>
        /// Gets a list of entries in the MEDIALOCATION table in the database.
        /// </summary>
        /// <param name="mediaLocationType">A type must be given.</param>
        /// <param name="context">A context must be given.</param>
        /// <returns>A list of entries in the MEDIALOCATION table with the given parameters.</returns>
        public static List<MEDIALOCATION> GetLocations(MediaLocationType mediaLocationType, string context)
        {
            // A null return value is not to be expected - only an empty list..
            List<MEDIALOCATION> locations = new List<MEDIALOCATION>();

            if (locationCacheInitialized)
            {
                var locationsLINQ =
                    medialocationCache.Where(f => f.CONTEXT == context && f.TYPE == mediaLocationType).OrderBy(f => f.DATE);
                foreach (MEDIALOCATION location in locationsLINQ)
                {
                    // non-existing directories are not allowed..
                    if (IsFileSystemLocation(mediaLocationType) && !Directory.Exists(location.LOCATION))
                    {
                        continue; // ..so continue..
                    }
                    locations.Add(location);
                }
            }
            else
            {
                string sql = string.Format( // format the SQL query..
                                            // bad database design so make sure we get something .. IFNULL(NULLIF()) ..
                    "SELECT ID, IFNULL(NULLIF(PARENT_LOCATION, ''), LOCATION) AS LOCATION, " + Environment.NewLine +
                    "IFNULL(NULLIF(PARENT_LOCATION, ''), LOCATION) AS PARENT_LOCATION, " + Environment.NewLine +
                    "DESCRIPTION, TYPE, CONTEXT " + Environment.NewLine +
                    "FROM MEDIALOCATION " + Environment.NewLine +
                    "WHERE TYPE = {0} AND CONTEXT = {1} COLLATE NOCASE ",
                    (int)mediaLocationType,
                    QS(context));

                // different handling for photo albums..
                if (mediaLocationType == MediaLocationType.MediaLocationPhotoAlbum)
                {
                    sql = string.Format(
                        "SELECT -1 AS ID, IFNULL(BASEDIROVERRIDE, {0}) AS LOCATION, " + Environment.NewLine +
                        "IFNULL(BASEDIROVERRIDE, {1}) AS PARENT_LOCATION, " + Environment.NewLine +
                        "NAME AS DESCRIPTION, 3 AS TYPE, 'PHOTOS' AS CONTEXT " + Environment.NewLine +
                        "FROM PHOTOALBUM ORDER BY FIRSTDATE, DESCRIPTION " + Environment.NewLine +
                        "COLLATE NOCASE " + Environment.NewLine, QS(Settings.PhotoBaseDir), QS(Settings.PhotoBaseDir));
                }


                // And as a SQLiteDataReader is disposable also, confirm it will be disposed of..
                using (SQLiteDataReader dr = GetDataReaderFromSQL(sql))
                {
                    while (dr.Read()) // while data is coming from the database..
                    {
                        // non-existing directories are not allowed..
                        if (IsFileSystemLocation(mediaLocationType) && !Directory.Exists(dr.GetString(1)))
                        {
                            continue; // ..so continue..
                        }

                        locations.Add( // construct MEDIALOCATION class instances of the rows and add them to the list..
                            new MEDIALOCATION()
                            {
                                ID = dr.GetInt32(0),
                                LOCATION = dr.GetString(1),
                                PARENT_LOCATION = dr.GetString(2),
                                DESCRIPTION = dr.GetString(3),
                                TYPE = (MediaLocationType)dr.GetInt32(4),
                                CONTEXT = dr.GetString(5)
                            });
                    }
                }
            }

            // now a an alphabetic sorting is needed except for photos..
            if (mediaLocationType != MediaLocationType.MediaLocationPhotoAlbum)
            {
                locations.Sort((x, y) => x.LOCATION.CompareTo(y.LOCATION));
            }

            // return the list of MEDIALOCATION entries from the database..
            return locations;
        }

        /// <summary>
        /// Remove a MEDIALOCATION entry with given parameters either from the cache or from the database.
        /// </summary>
        /// <param name="mediaLocationType">A MediaLocationType enumeration.</param>
        /// <param name="location">A MEDIALOCATION.TYPE database column value.</param>
        /// <param name="context">A MEDIALOCATION.CONTEXT database column value.</param>
        public static void RemoveLocation(MediaLocationType mediaLocationType, string location, string context = "DEFAULT")
        {
            if (locationCacheInitialized) // if the cache is initialized then just delete from the cache..
            {
                // remove an existing instance from the cache..
                medialocationCache.RemoveAll(f => f.TYPE == mediaLocationType && f.LOCATION == location && f.CONTEXT == context);
            }
            else // ..otherwise a database operation is required..
            {
                string sql = string.Format( // delete from the database..
                    "DELETE FROM MEDIALOCATION" + Environment.NewLine +
                    "WHERE" + Environment.NewLine + 
                    "TYPE = {0} AND LOCATION = {1} AND CONTEXT = {2}", // ..with a condition (!)..
                    (int)mediaLocationType,
                    QS(location), // the QuotedStr also known from the Object Pascal programming language ;-)
                    QS(context));

                ExecuteArbitrarySQL(sql); // run the sentence against the database..
            }
        }

        /// <summary>
        /// Adds a location entry to the MEDIALOCATION database table.
        /// </summary>
        /// <param name="mediaLocationType">A type must be given.</param>
        /// <param name="location">A location (however absurd) must be given.</param>
        /// <param name="parentLocation">A parent location of the given location if any (depends of the type and the context).</param>
        /// <param name="description">A description for the location. This is an optional parameter.</param>
        /// <param name="context">A string representing a context for a given location. If not given it defaults to 'DEFAULT'.</param>
        public static void AddLocation(MediaLocationType mediaLocationType, string location, string parentLocation = "", string description = "", string context = "DEFAULT")
        {
            // something needs to be done about the description if the given one was empty..
            if (description == string.Empty)
            {
                // .. first some weird assumption that it might be a directory..
                if ((mediaLocationType == MediaLocationType.MediaLocationMovie ||
                    (mediaLocationType == MediaLocationType.MediaLocationSeries ||
                    mediaLocationType == MediaLocationType.MediaLocationBrowsedPath
                    )) && Directory.Exists(location))
                {
                    description = location.Split('\\').Last();
                }
                else // .. otherwise the description will be the location..
                {
                    description = location;
                }
            }

            // if the database cache is initialized..
            if (locationCacheInitialized) 
            {
                // try to find an index for an existing item..
                int idx = 
                    medialocationCache.FindIndex( // with a lambda function rather than the LINQ.. (both do the same thing..)
                    f => f.LOCATION == location &&
                    f.TYPE == mediaLocationType
                    && f.CONTEXT == context);
                if (idx != -1) // an index was found, so just update the "record"..
                {
                    medialocationCache[idx].LOCATION = location; // with a found index update the "record" values accordingly..
                    medialocationCache[idx].DESCRIPTION = description;
                    medialocationCache[idx].PARENT_LOCATION = (parentLocation == "" ? location : parentLocation);
                    medialocationCache[idx].TYPE = mediaLocationType;
                    medialocationCache[idx].CONTEXT = context; // END: with a found index update the "record" values accordingly..
                }
                else // nothing was found so do add an instance of the MEDIALOCATION class to the cache..
                {
                    medialocationCache.Add(
                        new MEDIALOCATION
                        {
                            LOCATION = location, // do set the required values...
                            DESCRIPTION = description,
                            PARENT_LOCATION = (parentLocation == "" ? location : parentLocation),
                            TYPE = mediaLocationType,
                            CONTEXT = context
                        }); // END: do set the required values...
                }
            }
            else // no cache - so lets get to the basics of SQL syntax..
            {
                string sql = string.Format( // now do formulate a SQL sentence..
                    "INSERT INTO MEDIALOCATION (LOCATION, DESCRIPTION, PARENT_LOCATION, TYPE, CONTEXT) " + Environment.NewLine +
                    "SELECT {0}, {1}, {2}, {3}, {4} " + Environment.NewLine +
                    "WHERE NOT EXISTS (SELECT * FROM MEDIALOCATION WHERE LOCATION = {5} AND TYPE = {6} AND CONTEXT = {7}) ",
                    QS(location),
                    QS(description),
                    QS(parentLocation == "" ? location : parentLocation), // if no parent location the parent is it self..
                    (int)mediaLocationType,
                    QS(context),
                    QS(location),
                    (int)mediaLocationType,
                    QS(context));

                ExecuteArbitrarySQL(sql); // run the sentence against the database..

                sql = string.Format( // now do formulate a second SQL sentence..
                    "UPDATE MEDIALOCATION SET DESCRIPTION = {0} " + Environment.NewLine +
                    "WHERE LOCATION = {1} AND TYPE = {2} AND CONTEXT = {3} ",
                    QS(description),
                    QS(location),
                    (int)mediaLocationType,
                    QS(context));

                ExecuteArbitrarySQL(sql); // run the sentence against the database..
            }
        }
        #endregion

        #region PhotoAlbum        
        /// <summary>
        /// Gets a photo album by a given name.
        /// </summary>
        /// <param name="albumName">A name of the photo album to get.</param>
        /// <returns>A list of PhotoAlbumEntry class instances containing the entries of the photo file information.</returns>
        public static List<PhotoAlbumEntry> GetPhotoAlbum(string albumName)
        {
            List<PhotoAlbumEntry> entries = new List<PhotoAlbumEntry>();
            if (photoAlbumCacheInitialized)
            {
                var photos = photoAlbumCache.Where(f => f.NAME == albumName).
                    OrderBy(f => f.DATETIME).
                    OrderBy(f => f.DESCRIPTION).
                    OrderBy(f => f.FILENAME);
                foreach (PhotoAlbumEntry entry in photos)
                {
                    entries.Add(entry);
                }
            }
            else
            {
                string sql = string.Join(Environment.NewLine,
                        "SELECT NAME, DESCRIPTION, DATETIME, FILENAME, IFNULL(TAGTEXT, '') AS TAGTEXT, ",
                        "IFNULL(DATETIME_FREE, '') AS DATETIME_FREE, MD5HASH, ",
                        $"IFNULL(BASEDIROVERRIDE, {QS(Settings.PhotoBaseDir)}) AS BASEDIROVERRIDE ",
                        $"FROM V_PHOTOALBUM WHERE NAME = {QS(albumName)} ORDER BY DATETIME, DESCRIPTION, FILENAME COLLATE NOCASE ");

                // .. as a SQLiteDataReader is disposable also, confirm it will be disposed of..
                using (SQLiteDataReader dr = GetDataReaderFromSQL(sql))
                {
                    while (dr.Read())
                    {
                        entries.Add(
                            new PhotoAlbumEntry
                            {
                                NAME = dr.GetString(0),
                                DESCRIPTION_REAL = dr.GetString(1),
                                DATETIME = DateTime.ParseExact(dr.GetString(2), "yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture),
                                FILENAME = dr.GetString(3),
                                TAGTEXT = dr.GetString(4),
                                DATETIME_FREE = dr.GetString(5),
                                MD5HASH = dr.GetString(6),
                                BASEDIROVERRIDE = dr.GetString(7)
                            });
                    }
                }
            }
            return entries;
        }

        /// <summary>
        /// Deletes a photo album with a given name.
        /// </summary>
        /// <param name="albumName">A name of the photo album to delete.</param>
        /// <returns>True if the deletion was successful; otherwise false.</returns>
        public static bool DeletePhotoAlbum(string albumName)
        {
            // create a SQL sentence to delete a single photo album with a given name..
            string sql = string.Join(Environment.NewLine,
                // delete the photo file entries that belongs to the given album..
                "DELETE FROM PHOTOFILE WHERE MD5HASH IN ",
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME = {QS(albumName)}) AND ",
                // ..but not those photo file entries that belong to other photo albums as well..
                "MD5HASH NOT IN ",
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME <> {QS(albumName)}); ",
                Environment.NewLine,

                // delete the photo data tag entries that belongs to the given album..
                "DELETE FROM PHOTODATATAG WHERE MD5HASH IN ",
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME = {QS(albumName)}) AND ",
                // ..but not those photo data tag entries that belong to other photo albums as well..
                "MD5HASH NOT IN ",
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME <> {QS(albumName)}); ",
                Environment.NewLine,

                // delete the photo data entries that belongs to the given album..
                "DELETE FROM PHOTODATA WHERE MD5HASH IN ",
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME = {QS(albumName)}) AND ",
                // ..but not those photo data entries that belong to other photo albums as well..
                "MD5HASH NOT IN ",
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME <> {QS(albumName)}); ",
                Environment.NewLine,

                // delete the photo album link entries that belong to the given album..
                $"DELETE FROM PHOTOALBUMLINK WHERE NAME = {QS(albumName)}; ",
                Environment.NewLine,

                // delete the photo album entry of the given album..
                $"DELETE FROM PHOTOALBUM WHERE NAME = {QS(albumName)}; ");

            // run the SQL sentence against the database..
            return ExecuteArbitrarySQL(sql);
        }

        /// <summary>
        /// Deletes the photo album's file entry from the database.
        /// </summary>
        /// <param name="albumName">Name of the photo album of which photo album entry to delete.</param>
        /// <param name="photoAlbumEntry">A photo album entry belonging to the photo album to remove from the photo album.</param>
        /// <returns>True if the deletion was successful; otherwise false.</returns>
        public static bool DeletePhotoAlbumFile(string albumName, PhotoAlbumEntry photoAlbumEntry)
        {
            // create a SQL sentence to delete a single photo file from a photo album with a given name and MD5HASH value..
            string sql = string.Join(Environment.NewLine,
                // delete the photo file entry that belongs to the given album..
                $"DELETE FROM PHOTOFILE WHERE MD5HASH =  {QS(photoAlbumEntry.MD5HASH)} AND ",
                "MD5HASH NOT IN ",
                // ..but not those photo file entries that belong to other photo albums as well..                
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME <> {QS(albumName)}); ",
                Environment.NewLine,

                // delete the photo data tag entries that belongs to the given album and the given photo file entry..
                $"DELETE FROM PHOTODATATAG WHERE MD5HASH =  {QS(photoAlbumEntry.MD5HASH)} AND ",
                "MD5HASH NOT IN ",
                // ..but not those photo file entries that belong to other photo albums as well..
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME <> {QS(albumName)}); ",
                Environment.NewLine,

                // delete the photo data entry that belongs to the given album and matches the given photo file entry..
                $"DELETE FROM PHOTODATA WHERE MD5HASH =  {QS(photoAlbumEntry.MD5HASH)} AND ",
                "MD5HASH NOT IN ",
                // ..but not those photo data entries that belong to other photo albums as well..
                $"  (SELECT MD5HASH FROM PHOTOALBUMLINK WHERE NAME <> {QS(albumName)}); ",
                Environment.NewLine,

                // delete the photo album link entry that belong to the given album and matches the given photo file entry..
                $"DELETE FROM PHOTOALBUMLINK WHERE NAME = {QS(albumName)} AND MD5HASH = {QS(photoAlbumEntry.MD5HASH)}; ",
                Environment.NewLine);

            // run the SQL sentence against the database..
            return ExecuteArbitrarySQL(sql);
        }
        #endregion

        #region TMdb
        /// <summary>
        /// Returns a file type for a given path string.
        /// </summary>
        /// <param name="fileName">A path to a file name which type to get.</param>
        /// <returns>A FileType enumeration value describing the file's type.</returns>
        public static FileType GetFileType(string fileName)
        {
            // if a file name indicates that it might be a TV show episode..
            if (TMDbFileEnumerator.IsTVSeasonEpisode(fileName, out _, out _, out _))
            {
                return FileType.TVSeasonEpisode;
            }
            else // all else are considered movies..
            {
                return FileType.Movie;
            }
        }

        /// <summary>
        /// Gets the TMDb API key. Please don't misuse the key (AGAIN, Please!).
        /// </summary>
        public static string APIKey
        {
            get
            {
                string sql = // formulate the SQL..
                    "SELECT KEYVALUE FROM APIKEYS WHERE KEYNAME = 'TMDb' ";

                // as the SQLiteCommand is disposable a using clause is required..
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = sql;
                    // the result is "obfuscated"..
                    return ScrambleAPIKey.Unsecure((string)command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Sets the TMDb database information for a given file if found.
        /// </summary>
        /// <param name="fileName">A file name to set the TMDb database information to.</param>
        /// <param name="easy">A TMdbEasy client instance.</param>
        /// <param name="easyClientConfigured">An indicator if the TMdbEasy client is configured.</param>
        public static void SetTMDbInfo(string fileName, EasyClient easy, bool easyClientConfigured)
        {
            TMDbDetail detail = null;

            // first ensure that there is now data already fetched, so no excess queries will occur against the TMDb database..
            string sql = string.Format(
                "SELECT COUNT(*) FROM V_VIDEOFILE WHERE FILENAMEFULL = {0} AND FILESIZE = {1} AND TMDBFETCHED = 1 ",
                QS(fileName),
                new FileInfo(fileName).Length);

            using (SQLiteDataReader dr = GetDataReaderFromSQL(sql))
            {
                if (dr.Read())
                {
                    if (dr.GetInt32(0) > 0)
                    {
                        return; // ..if fetched then there is nothing to do..
                    }
                }
            }

            if (easyClientConfigured)
            {
                try // avoid an exception from crashing the software..
                {
                    // check a file name with this "weird algorithm" if it is a TV show season episode or a movie..
                    bool movie = !TMDbFileEnumerator.IsTVSeasonEpisode(fileName, out _, out _, out _);
                    if (movie) // if a movie is in question..
                    {
                        // ..then get details for a movie..
                        detail = TMDbFileEnumerator.GetMovie(easy, fileName);
                    }
                    else // if a TV show season episode is in question..
                    {
                        // ..then get details for a TV show season episode..
                        List<TMDbDetail> details = TMDbFileEnumerator.GetSeason(easy, fileName).ToList();
                        if (details.Count > 0) // ..and if something was found..
                        {
                            detail = details[0]; // ..pick the first one..
                        }
                    }
                }
                catch (Exception ex) // ..but do log the exception..
                {
                    ExceptionLogger.LogError(ex);
                }
            }

            int duration = 0; // get the duration of the video file..
            try
            {
                // get the details for a video file..
                MediaFile mediaFile = new MediaFile(fileName);

                // if the file has video tracks pick the first one..
                if (mediaFile.Video.Count > 0)
                {
                    // ..and set the duration..
                    duration = mediaFile.Video[0].Duration;
                }
            }
            catch (Exception ex) // an unexpected error..
            {
                // ..can't really do nothing here.. except log the exception..
                ExceptionLogger.LogError(ex);
            }

            // create a TMDbDetailExt class instance..
            TMDbDetailExt detailExt = new TMDbDetailExt();
            if (detail != null)
            {
                // from the TMDbDetail class instance..
                detailExt = TMDbDetailExt.FromTMDbDetail(detail, duration, fileName, !Settings.UseMemoryForTMDbImagesCache, Settings.TMDbImagesCacheDir, null, VideoPlaybackState.New);
            }

            // for the caching purposes, keep the cache updated..
            SetFile(fileName, detailExt);

            // update the database or cache..
            UpdateFile(fileName, detailExt);

            // if a TV show season episode or movie information was found, insert it into the database..
            if (detailExt.ID != -1)
            {
                // save the TMDb data to the database..
                sql = string.Format(
                    "INSERT INTO TMDBDETAILS(ID, SEASONID, EPISODEID, TITLE, " + Environment.NewLine +
                    "DESCRIPTION, DETAILDESCRIPTION, FILENAME, POSTERORSTILLURL, " + Environment.NewLine +
                    "SEASON, EPISODE, DURATION, IMAGE, IMAGEFILENAME, FILESIZE) " + Environment.NewLine +
                    "SELECT {0}, {1}, {2}, {3}, " +
                    "{4}, {5}, {6}, {7}, " +
                    "{8}, {9}, @DURATION, @IMAGE, {10}, {11} " + Environment.NewLine +
                    "WHERE NOT EXISTS(SELECT * FROM TMDBDETAILS WHERE ID = {12} AND SEASONID = {13} AND EPISODEID = {14}) " + Environment.NewLine,
                    detailExt.ID,
                    detailExt.SeasonID,
                    detailExt.EpisodeID,
                    QS(detailExt.Title),
                    QS(detailExt.Description),
                    QS(detailExt.DetailDescription),
                    QS(detailExt.FileName),
                    QS(detailExt.PosterOrStillURL.AbsoluteUri),
                    detailExt.Season,
                    detailExt.Episode,
                    QS(detailExt.ImageFileName),
                    detailExt.FileSize,
                    detailExt.ID,
                    detailExt.SeasonID,
                    detailExt.EpisodeID);

                // as the SQLiteCommand is disposable a using clause is required..
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = sql;
                    // add parameters to the command..
                    command.Parameters.Add("@DURATION", System.Data.DbType.Double).Value = detailExt.Duration.TotalSeconds;
                    using (MemoryStream ms = new MemoryStream()) // add the image parameter..
                    {
                        if (detailExt.Image == null) // if null the DBNull..
                        {
                            command.Parameters.Add("@IMAGE", System.Data.DbType.Binary).Value = null;
                        }
                        else
                        {
                            // save the image to a memory stream..
                            detailExt.Image.Save(ms, detailExt.Image.RawFormat); 

                            // ..and ad it's data to the parameter as a byte array..
                            command.Parameters.Add("@IMAGE", System.Data.DbType.Binary).Value = ms.ToArray();
                        }
                    }

                    // do the insert..
                    command.ExecuteNonQuery();

                    // ensure that fetched data is not re-fetched..
                    sql = string.Format(
                        "UPDATE VIDEOFILE SET TMDBFETCHED = 1 WHERE FILENAMEFULL = {0} AND FILESIZE = {1} ",
                        QS(fileName),
                        detailExt.FileSize);

                    command.CommandText = sql;
                    // do the insert..
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Misc                
        /// <summary>
        /// Determines whether given MediaLocationType enumeration indicates a location in the file system.
        /// </summary>
        /// <param name="mediaLocationType">Type of the media location.</param>
        /// <returns>
        ///   <c>true</c> if the given MediaLocationType enumeration indicates a location in the file system; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFileSystemLocation(MediaLocationType mediaLocationType)
        {
            return // check the media location types
                mediaLocationType == MediaLocationType.MediaLocationBrowsedPath ||
                mediaLocationType == MediaLocationType.MediaLocationMovie ||
                mediaLocationType == MediaLocationType.MediaLocationSeries ||
                mediaLocationType == MediaLocationType.MediaLocationSingleFile ||
                mediaLocationType == MediaLocationType.MediaLocationPhotoAlbum;
        }

        /// <summary>
        /// Determines whether given value casted to MediaLocationType enumeration indicates a location in the file system.
        /// </summary>
        /// <param name="mediaLocationType">An integer to be casted to type of the media location.</param>
        /// <returns>
        ///   <c>true</c> if the given value casted to MediaLocationType enumeration indicates a location in the file system; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFileSystemLocation(int mediaLocationType)
        {
            return IsFileSystemLocation((MediaLocationType)mediaLocationType);
        }

        /// <summary>
        /// This method stands for Quoted String. Simply double-quote the "insides" of a string and add quotes to the both sides (').
        /// </summary>
        /// <param name="str">A string to 'quote'.</param>
        /// <returns>A 'quoted' string.</returns>
        public static string QS(string str)
        {
            return "'" + str.Replace("'", "''") + "'"; // as simple as it can be..
        }

        /// <summary>
        /// This method stands for Quoted String. Simply double-quote the "insides" of a string and add quotes to the both sides (').
        /// If the string is null or empty a value of NULL is returned.
        /// </summary>
        /// <param name="str">A string to 'quote'.</param>
        /// <returns>A 'quoted' string or NULL.</returns>
        public static string QSNullIf(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                // the string can be considered as NULL..
                return "NULL ";
            }
            else
            {
                // otherwise just quote the string (')..
                return QS(str);
            }
        }

        /// <summary>
        /// Closes the SQLite database connection and released all resources. A VACUUM command is also executed.
        /// </summary>
        public static void CloseAndFinalizeDatabase()
        {
            try // to avoid a "catastrophic" failure, just try..
            {
                WriteCache(); // save the cached data to the database..

                if (conn != null) // only do this if the SQLite database connection is initialized..
                {
                    // save the connection string for the VACUUM command..
                    string connectionString = conn.ConnectionString;

                    using (conn) // close the SQLite database connection before running the VACUUM command..
                    {
                        conn.Close();
                        conn = null;
                    }

                    // reconstruct a SQLite connection to execute the WACUUM command and the close the connection again..
                    using (conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        ExecuteArbitrarySQL("VACUUM; "); // run the sentence against the database..
                        conn.Close();
                        conn = null;
                    }
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);
                // something went wrong, avoid crash..
            }
        }

        /// <summary>
        /// Creates TMDbDetailExt class instance from SQLiteDataReader.
        /// </summary>
        /// <param name="dr">A SQLiteDataReader class instance to be used.</param>
        /// <param name="cacheImageFileSystem">Indicates if the image (poster/still) should be cached to the file system instead of loading it to the memory.</param>
        /// <param name="TMDbCacheDir">A path were the images (poster/still) should be cached if the file system caching is enabled.</param>
        /// <returns>A TMDbDetailExt class instance from based on the data gotten from a SQLiteDataReader class instance.</returns>
        public static TMDbDetailExt FromDataReader(SQLiteDataReader dr, bool cacheImageFileSystem, string TMDbCacheDir)
        {
            Image image = null;
            if (!dr.IsDBNull(20))
            {
                byte[] imageData = new byte[dr.GetInt32(22)];
                dr.GetBytes(20, 0, imageData, 0, imageData.Length);
                // using (MemoryStream ms = new MemoryStream(imageData)) Exception: A generic error occurred in GDI+
                MemoryStream ms = new MemoryStream(imageData);
                image = Image.FromStream(ms);
            }

            string fileNameFull = dr.GetString(2);

            if (dr.GetInt32(10) == -1) // construct TMDbDetailExt class instance based on the data..
            {
                int duration = 0; // get the duration of the video file..
                try
                {
                    // get the details for a video file..
                    MediaFile mediaFile = new MediaFile(fileNameFull);

                    // if the file has video tracks pick the first one..
                    if (mediaFile.Video.Count > 0)
                    {
                        // ..and set the duration..
                        duration = mediaFile.Video[0].Duration;
                    }
                }
                catch // an unexpected error..
                {
                    // ..can't really do nothing here..
                }

                return new TMDbDetailExt()
                {
                    Description = Path.GetFileNameWithoutExtension(fileNameFull),
                    DetailDescription = Path.GetFileNameWithoutExtension(fileNameFull),
                    Duration = TimeSpan.FromMilliseconds(duration),
                    Title = Path.GetFileNameWithoutExtension(fileNameFull),
                    VideoPlaybackState = (VideoPlaybackState)dr.GetInt32(23)
                };
            }
            else
            {                
                TMDbDetailExt result = new TMDbDetailExt() // construct TMDbDetailExt class instance based on the data..
                {
                    Description = dr.GetString(14),
                    Episode = dr.GetInt32(18),
                    EpisodeID = dr.GetInt32(12),
                    DetailDescription = dr.GetString(15),
                    FileName = dr.GetString(1),
                    ID = dr.GetInt32(10),
                    PosterOrStillURL = string.IsNullOrEmpty(dr.GetString(16)) ? null : new Uri(dr.GetString(16)),
                    Season = dr.GetInt32(17),
                    SeasonID = dr.GetInt32(11),
                    Title = dr.GetString(13),
                    Duration = TimeSpan.FromSeconds(dr.GetDouble(19)),
                    Image = image,
                    ImageFileCache = cacheImageFileSystem,
                    FileSize = dr.GetInt64(3),
                    ImageFileCacheDir = TMDbCacheDir,
                    VideoPlaybackState = (VideoPlaybackState)dr.GetInt32(23)
                };

                result.DumpImage();
                return result;
            }
        }

        /// <summary>
        /// Executes a SQL sentence against the database and returns a scalar query value.
        /// </summary>
        /// <param name="sql">A SQL query to be used to get a scalar value from the database.</param>
        /// <param name="type">A type of to which the scalar value is to be casted to.</param>
        /// <param name="invalidCast">An indicator if an invalid type was requested.</param>
        /// <returns>A value of type of <paramref name="type"/> if successful; otherwise null.</returns>
        public static object GetScalarValue(string sql, Type type, out bool invalidCast)
        {
            // an indicator if the queried value was not if expected type..
            invalidCast = false;

            // as the SQLiteCommand is disposable a using clause is required..
            using (SQLiteCommand command = new SQLiteCommand(sql, conn))
            {
                // get the scalar value..
                object value = command.ExecuteScalar();
                if (value != null) // not null..
                {
                    try
                    {
                        // cast the return value into the given type..
                        return Convert.ChangeType(value, type);
                    }
                    // if an invalid type was requested, set the flag to true..
                    catch (InvalidCastException ex)
                    {
                        ExceptionLogger.LogError(ex); // log the error..
                        invalidCast = true; // set the flag..
                        return null; // indicate failure..
                    }
                    // in case of an another exception type (this shouldn't happen!)..
                    catch (Exception ex)
                    {
                        ExceptionLogger.LogError(ex); // log the error..
                        return null; // indicate failure..
                    }
                }
                else
                {
                    return null; // indicate no data..
                }
            }
        }

        /// <summary>
        /// Checks if a photo album of a given <paramref name="albumName"/> already exists in the database.
        /// </summary>
        /// <param name="albumName">A photo album's name.</param>
        /// <returns>True if the album already exits in the database; otherwise false.</returns>
        public static bool CheckPhotoAlbumExistense(string albumName)
        {
            // formulate a SQL sentence..
            string sql = $"SELECT COUNT(*) FROM PHOTOALBUM WHERE NAME = {QS(albumName)} ";

            // execute the SQL sentence as scalar..
            object value = GetScalarValue(sql, typeof(long), out _);

            // null means a false..
            if (value == null)
            {
                return false;
            }
            else // a value larger than zero means true..
            {
                return ((long)value) > 0;
            }
        }

        /// <summary>
        /// Executes a arbitrary SQL into the database.
        /// </summary>
        /// <param name="sql">A string containing SQL sentences to be executed to the database.</param>
        /// <returns>True if the given SQL sentences were executed successfully; otherwise false;</returns>
        public static bool ExecuteArbitrarySQL(string sql)
        {
            // as the SQLiteCommand is disposable a using clause is required..
            using (SQLiteCommand command = new SQLiteCommand(sql, conn))
            {
                try
                {
                    // try to execute the given SQL..
                    command.ExecuteNonQuery();
                    return true; // success..
                }
                catch (Exception ex) // something went wrong so do log the reason.. (ex avoids the EventArgs e in all cases!)..
                {
                    ExceptionLogger.LogError(ex); // do note that this needs to be "bound" to the application..
                    return false; // failure..
                }
            }
        }

        /// <summary>
        /// Gets a SQLiteDataReader for a given SQL select statement.
        /// </summary>
        /// <param name="sql">A SQL sentence to get a SQLiteDataReader for.</param>
        /// <returns>A SQLiteDataReader class instance if success; otherwise null.</returns>
        public static SQLiteDataReader GetDataReaderFromSQL(string sql)
        {
            // as the SQLiteCommand is disposable a using clause is required..
            using (SQLiteCommand command = new SQLiteCommand(sql, conn))
            {
                try
                {
                    // try to get a data reader for the given SQL..
                    return command.ExecuteReader(); // success..
                }
                catch (Exception ex) // something went wrong so do log the reason.. (ex avoids the EventArgs e in all cases!)..
                {
                    ExceptionLogger.LogError(ex); // do note that this needs to be "bound" to the application..
                    return null; // failure..
                }
            }
        }

        #endregion

        #region PhotosExtension        
        /// <summary>
        /// Gets the photo albums in the PHOTOALBUM table.
        /// </summary>
        /// <returns>A collection of photo albums in the database.</returns>
        public static IEnumerable<PHOTOALBUM> GetPhotoAlbums()
        {
            string sql = // formulate the SQL..
                string.Join(Environment.NewLine,
                $"SELECT NAME, IFNULL(BASEDIROVERRIDE, {QS(Settings.PhotoBaseDir)}) AS BASEDIROVERRIDE, FIRSTDATE ",
                "FROM ",
                "PHOTOALBUM ",
                "ORDER BY FIRSTDATE, NAME ");

            // .. as a SQLiteDataReader is disposable also, confirm it will be disposed of..
            using (SQLiteDataReader dr = GetDataReaderFromSQL(sql))
            {
                // loop through the results..
                while (dr.Read())
                {
                    // return an entry as it is in the database..
                    yield return new PHOTOALBUM()
                    {
                        NAME = dr.GetString(0),
                        BASEDIROVERRIDE = dr.GetString(1),
                        FIRSTDATE = DateTime.ParseExact(dr.GetString(2), "yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture),
                        PreviousName = dr.GetString(0)
                    };
                }
            }
        }

        /// <summary>
        /// Gets all tags used to describe a photo in the database in alphabetic order.
        /// </summary>
        /// <returns>A collection containing all the tags used to describe a photo in the database.</returns>
        public static IEnumerable<PHOTODATATAG> GetAllTags()
        {
            string sql = // formulate the SQL..
                string.Join(Environment.NewLine,
                "SELECT DISTINCT(TAGTEXT) AS TAGTEXT ",
                "FROM PHOTODATATAG ORDER BY TAGTEXT ");

            // .. as a SQLiteDataReader is disposable also, confirm it will be disposed of..
            using (SQLiteDataReader dr = GetDataReaderFromSQL(sql))
            {
                // loop through the results..
                while (dr.Read())
                {
                    // return an entry as it is in the database..
                    yield return new PHOTODATATAG()
                    {
                        TAGTEXT = dr.GetString(0)
                    };
                }
            }
        }

        /// <summary>
        /// Gets all the photo album names stored in a XML file.
        /// </summary>
        /// <param name="fileName">Name of the XML file.</param>
        /// <returns>A collection of strings containing the photo album names stored in a XML file.</returns>
        public static IEnumerable<string> GetAlbumsFromXML(string fileName)
        {
            try // try (first time of me to the LINQ to XML)..
            {
                // load the document, file existence is not checked..
                XDocument document = XDocument.Load(fileName);

                // enumerate the "Album" elements..
                IEnumerable<XElement> elements = document.Root.Elements("Album");

                // select the name and return the collection of strings..
                return elements.Select(f => f.Attribute("Name").Value); // a null value may be returned..
            }
            catch (Exception ex) // handle an error..
            {
                ExceptionLogger.LogError(ex); // do note that this needs to be "bound" to the application..
                return null; // fail by null (also success is possible by null)..
            }
        }

        /// <summary>
        /// Gets all photo albums stored into a XML file.
        /// </summary>
        /// <param name="fileName">The name of the XML file.</param>
        /// <returns>A collection of key-value pairs containing all the albums in the given file.</returns>
        public static IEnumerable<KeyValuePair<PHOTOALBUM, IEnumerable<PhotoAlbumEntry>>> GetAllAlbumsFromXMLFile(string fileName)
        {
            // get all the album names inside a XML file..
            IEnumerable<string> albumNames = GetAlbumsFromXML(fileName);

            // only if some results were gotten..
            if (albumNames != null)
            {
                // loop through the album names..
                foreach (string name in albumNames)
                {
                    // only if success..
                    if (GetPhotoAlbumFromXML(fileName, name, out PHOTOALBUM album, out IEnumerable<PhotoAlbumEntry> entries))
                    {
                        // return a key-value pair containing the photo album data..
                        yield return new KeyValuePair<PHOTOALBUM, IEnumerable<PhotoAlbumEntry>>(album, entries);
                    }
                }
            }
        }

        /// <summary>
        /// Appends a photo album to a XML file. If the file doesn't exist then a new file is created.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="album">The album.</param>
        /// <param name="albumEntries">The album entries.</param>
        /// <returns></returns>
        public static bool AppendPhotoAlbumXML(string fileName, PHOTOALBUM album, IEnumerable<PhotoAlbumEntry> albumEntries)
        {
            try // try (first time of me to the LINQ to XML)..
            {
                XDocument document; // the XDocument to hold the data..
                if (!File.Exists(fileName)) // no file, so create a new..
                {
                    // use a different method for creating a new XML file..
                    document = GenPhotoAlbumXML(album, albumEntries);
                    if (document != null) // fail returns null..
                    {
                        document.Save(fileName); // save the document..
                    }
                    return true; // indicate success..
                }
                // if the file exists, load the document from the file..
                else
                {
                    document = XDocument.Load(fileName); // load the XML document..
                    IEnumerable<XElement> elements = document.Root.Elements("Album");

                    // select the "Album" element where the name is the name of the PHOTOALBUM parameter..
                    XElement element = elements.
                        FirstOrDefault(f => f.Attribute("Name").Value == album.NAME);

                    // if an element was found, clear it..
                    if (element != null) 
                    {
                        element.RemoveAll(); // ..by removing existing contents..
                    }
                    // if not found create a new element..
                    else 
                    {
                        element = new XElement("Album"); // ..with a name of album..
                        document.Root.Add(element); // ..and at it to the XML document's root..
                    }

                    // create an element for album entries..
                    XElement entryElement = new XElement("AlbumEntries");

                    foreach (PhotoAlbumEntry photoAlbumEntry in albumEntries)
                    {
                        // add the album entries to the container element..
                        entryElement.Add(new XElement("AlbumEntry",
                            new XAttribute("Name", photoAlbumEntry.NAME),
                            new XAttribute("Description", photoAlbumEntry.DESCRIPTION),
                            new XAttribute("DescriptionReal", photoAlbumEntry.DESCRIPTION_REAL),
                            new XAttribute("DateTime", photoAlbumEntry.DATETIME.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture)),
                            new XAttribute("FileName", photoAlbumEntry.FILENAME),
                            new XAttribute("TagText", photoAlbumEntry.TAGTEXT),
                            new XAttribute("DateTimeFree", photoAlbumEntry.DATETIME_FREE),
                            new XAttribute("MD5Hash", photoAlbumEntry.MD5HASH),
                            new XAttribute("BaseDirOverride", photoAlbumEntry.BASEDIROVERRIDE)));
                    }

                    // set the values for the "Album" element..
                    element.Add(
                        new XAttribute("Name", album.NAME),
                        new XAttribute("FirstDate", album.FIRSTDATE.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture)),
                        new XAttribute("BaseDir", Settings.PhotoBaseDir),
                        new XAttribute("BaseDirOverride", album.BASEDIROVERRIDE),
                        entryElement);

                    document.Save(fileName); // save the document..
                    return true; // indicate success..
                }
            }
            catch (Exception ex) // handle an error..
            {
                ExceptionLogger.LogError(ex); // do note that this needs to be "bound" to the application..
                return false; // indicate failure..
            }
        }


        /// <summary>
        /// Generates a XML document of the given photo album and it's contents.
        /// </summary>
        /// <param name="album">The photo album.</param>
        /// <param name="albumEntries">The contents of the photo album.</param>
        /// <returns>An instance of a XDocument class.</returns>
            public static XDocument GenPhotoAlbumXML(PHOTOALBUM album, IEnumerable<PhotoAlbumEntry> albumEntries)
        {
            try // try (first time of me to the LINQ to XML)..
            {
                // create an element for album entries..
                XElement entryElement = new XElement("AlbumEntries");

                foreach (PhotoAlbumEntry photoAlbumEntry in albumEntries)
                {
                    // add the album entries to the container element..
                    entryElement.Add(new XElement("AlbumEntry",
                        new XAttribute("Name", photoAlbumEntry.NAME),
                        new XAttribute("Description", photoAlbumEntry.DESCRIPTION),
                        new XAttribute("DescriptionReal", photoAlbumEntry.DESCRIPTION_REAL),
                        new XAttribute("DateTime", photoAlbumEntry.DATETIME.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture)),
                        new XAttribute("FileName", photoAlbumEntry.FILENAME),
                        new XAttribute("TagText", photoAlbumEntry.TAGTEXT),
                        new XAttribute("DateTimeFree", photoAlbumEntry.DATETIME_FREE),
                        new XAttribute("MD5Hash", photoAlbumEntry.MD5HASH),
                        new XAttribute("BaseDirOverride", photoAlbumEntry.BASEDIROVERRIDE)));
                }

                // create a XDocument of the photo album's content data and the photo album it self..
                XDocument document = new XDocument(
                    new XDeclaration("1.0", "utf-8", ""),
                    new XElement("Albums", 
                        new XElement("Album",
                            new XAttribute("Name", album.NAME),
                            new XAttribute("FirstDate", album.FIRSTDATE.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture)),
                            new XAttribute("BaseDir", Settings.PhotoBaseDir),
                            new XAttribute("BaseDirOverride", album.BASEDIROVERRIDE),
                            entryElement)));

                // return the created XDocument class instance..
                return document;
            }
            catch (Exception ex) // handle an error..
            {
                ExceptionLogger.LogError(ex); // do note that this needs to be "bound" to the application..
                return null; // indicate failure..
            }
        }

        /// <summary>
        /// Reads an and returns photo album data from a XML file.
        /// </summary>
        /// <param name="fileName">A XML file.</param>
        /// <param name="albumName">A name of a photo album the get from the XML file.</param>
        /// <param name="album">A PHOTOALBUM class to contain the photo album data.</param>
        /// <param name="albumEntries">A collection of photo album entry data.</param>
        /// <returns>True if the album was read successfully from the XML file; otherwise false.</returns>
        public static bool GetPhotoAlbumFromXML(string fileName, string albumName, out PHOTOALBUM album, 
            out IEnumerable<PhotoAlbumEntry> albumEntries)
        {
            try // try as a contents of a XML document can be anything..
            {
                // load a XML document..
                XDocument document = XDocument.Load(fileName);

                IEnumerable<XElement> elements = document.Root.Elements("Album");

                // find the photo album's element from the XML document..
                XElement albumElement = elements.
                    FirstOrDefault(f => f.Attribute("Name").Value == albumName);


                // create a PHOTOALBUM class instance from the root element's attributes..
                album = new PHOTOALBUM()
                {
                    NAME = albumElement.Attribute("Name").Value,
                    FIRSTDATE = DateTime.ParseExact(albumElement.Attribute("FirstDate").Value,
                        "yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture),
                    BASEDIROVERRIDE = albumElement.Attribute("BaseDirOverride").Value,
                    PreviousName = albumElement.Attribute("Name").Value
                };

                // get the photo data entry collection from the AlbumEntries element..
                IEnumerable<XElement> albumEntryElements =
                    albumElement.Element("AlbumEntries").Elements("AlbumEntry");

                // initialize the out value for the albumEntries out parameter..
                List<PhotoAlbumEntry> entries = new List<PhotoAlbumEntry>();

                // loop through the elements describing a single photo in the album..
                foreach (XElement element in albumEntryElements)
                {
                    // create a photo album entry class instance of the photo file's XML data..
                    entries.Add(new PhotoAlbumEntry()
                    {
                        NAME = element.Attribute("Name").Value,
                        DESCRIPTION = element.Attribute("Description").Value,
                        DESCRIPTION_REAL = element.Attribute("DescriptionReal").Value,
                        DATETIME = DateTime.ParseExact(element.Attribute("DateTime").Value,
                            "yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture),
                        FILENAME = element.Attribute("FileName").Value,
                        TAGTEXT = element.Attribute("TagText").Value,
                        DATETIME_FREE = element.Attribute("DateTimeFree").Value,
                        MD5HASH = element.Attribute("MD5Hash").Value,
                        BASEDIROVERRIDE = element.Attribute("BaseDirOverride").Value
                    });
                }

                // set the value for the albumEntries out parameter..
                albumEntries = entries;

                return true; // indicate success..
            }
            catch (Exception ex) // "handle" the error..
            {
                // set the out parameters to null..
                album = null; 
                albumEntries = null;

                ExceptionLogger.LogError(ex); // do note that this needs to be "bound" to the application..
                return false; // indicate a failure..
            }
        }



        /// <summary>
        /// Generates a SQL sentence to insert a single photo album into a database.
        /// </summary>
        /// <param name="album">The album to insert.</param>
        /// <param name="albumEntries">A collection of entries to be part of the album.</param>
        /// <returns>A string containing SQL sentences to insert a single photo album into the database.</returns>
        public static string GenPhotoAlbumInsert(PHOTOALBUM album, IEnumerable<PhotoAlbumEntry> albumEntries)
        {
            string sql = // formulate the PHOTOALBUM table insert..
                string.Join(Environment.NewLine, Environment.NewLine,
                $"--ALBUMNAME={album.NAME} ",
                string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                $"INSERT INTO PHOTOALBUM (NAME, FIRSTDATE, BASEDIROVERRIDE) ",
                $"SELECT {QS(album.NAME)}, ",
                // the date and time are inserted as strings but they also must be in a format
                // that the SQLite database can use their values to order data..
                $"{QS(album.FIRSTDATE.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture))}, ",

                // the base directory needs to be overridden if the base directory doesn't match the base
                // directory defined in the program's settings..
                $"{QSNullIf(album.BASEDIROVERRIDE)} ",
                $"WHERE NOT EXISTS(SELECT * FROM PHOTOALBUM WHERE NAME = {QS(album.NAME)}); "));

            // loop through all of the PhotoAlbumEntry class instances which are to be members of this photo album..
            foreach (PhotoAlbumEntry albumEntry in albumEntries)
            {
                sql += // formulate the PHOTOALBUMLINK table insert..
                    string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                    $"INSERT INTO PHOTOALBUMLINK (NAME, MD5HASH) ", 
                    $"SELECT {QS(album.NAME)}, {QS(albumEntry.MD5HASH)} ",
                    $"WHERE NOT EXISTS(SELECT * FROM PHOTOALBUMLINK WHERE MD5HASH = {QS(albumEntry.MD5HASH)}); ");

                sql += // formulate the PHOTODATA table insert..
                    string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                    "INSERT INTO PHOTODATA (MD5HASH, DESCRIPTION, DATETIME) ",
                    $"SELECT {QS(albumEntry.MD5HASH)}, {QS(albumEntry.DESCRIPTION)}, " +
                    // the date and time are inserted as strings but they also must be in a format
                    // that the SQLite database can use their values to order data..
                    $"{QS(albumEntry.DATETIME.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture))} ",
                    $"WHERE NOT EXISTS(SELECT * FROM PHOTODATA WHERE MD5HASH = {QS(albumEntry.MD5HASH)} AND DESCRIPTION = {QS(albumEntry.DESCRIPTION)}); ");

                sql += string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                    $"UPDATE PHOTODATA ",
                    $"SET DESCRIPTION = {QS(albumEntry.DESCRIPTION)}, DATETIME = {QS(albumEntry.DATETIME.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture))} ",
                    $"WHERE MD5HASH = {QS(albumEntry.MD5HASH)}; ");


                sql +=  // formulate the PHOTOFILE table insert..
                    string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                    "INSERT INTO PHOTOFILE (MD5HASH, FILENAME) ",
                    $"SELECT {QS(albumEntry.MD5HASH)}, {QS(albumEntry.FILENAME)} ",
                    $"WHERE NOT EXISTS(SELECT * FROM PHOTOFILE WHERE MD5HASH = {QS(albumEntry.MD5HASH)} AND FILENAME = {QS(albumEntry.FILENAME)}); ");

                // create an array of the comma delimited tags in the PhotoAlbumEntry class instance.. 
                string[] tags = albumEntry.TAGTEXT.Split(new string[] { ", " }, StringSplitOptions.None);

                // fist delete as the tags as they are shared via their file MD5 hashes..
                sql +=
                    string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                    $"DELETE FROM PHOTODATATAG WHERE MD5HASH = {QS(albumEntry.MD5HASH)}; ");

                // loop through the tags..
                foreach (string tag in tags)
                {
                    // empty items are not accepted..
                    if (tag.Trim() == string.Empty)
                    {
                        continue; // ..so do continue..
                    }
                    sql += // formulate the PHOTODATATAG table insert..
                        string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..                    
                        "INSERT INTO PHOTODATATAG (MD5HASH, TAGTEXT) ",
                        $"VALUES ({QS(albumEntry.MD5HASH)}, {QS(tag)}); ");
                }
            }
            return sql;
        }

        /// <summary>
        /// Generates a SQL sentence to update a single photo album in the a database.
        /// </summary>
        /// <param name="album">The album to update.</param>
        /// <param name="albumEntries">A collection of entries being a part of the album to update.</param>
        /// <returns>A string containing SQL sentences to update a single photo album in to the database.</returns>
        public static string GenPhotoAlbumUpdate(PHOTOALBUM album, IEnumerable<PhotoAlbumEntry> albumEntries)
        {
            string sql = // formulate the PHOTOALBUM table update..
                string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                "UPDATE PHOTOALBUM ",
                $"SET NAME = {QS(album.NAME)}, ",
                // the date and time are inserted as strings but they also must be in a format
                // that the SQLite database can use their values to order data..
                $"FIRSTDATE = {QS(album.FIRSTDATE.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture))} ",
                $"WHERE NAME = {QS(album.PreviousName)}; ");

            sql += // formulate the PHOTOALBUMLINK table update..
                string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                "UPDATE PHOTOALBUMLINK ",
                $"SET NAME = {QS(album.NAME)} ",
                $"WHERE NAME = {QS(album.PreviousName)}; ");

            // loop through all of the PhotoAlbumEntry class instances which are members of this photo album..
            foreach (PhotoAlbumEntry albumEntry in albumEntries)
            {
                sql += // formulate the PHOTODATA table update..
                    string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                    "UPDATE PHOTODATA ",
                    $"SET DESCRIPTION = {QS(albumEntry.DESCRIPTION_REAL)}, ",
                    // the date and time are inserted as strings but they also must be in a format
                    // that the SQLite database can use their values to order data..
                    $"DATETIME = {QS(albumEntry.DATETIME.ToString("yyyy-MM-dd HH':'mm':'ss.fff", CultureInfo.InvariantCulture))}, ",
                    $"DATETIME_FREE = {QS(albumEntry.DATETIME_FREE)} ",
                    $"WHERE MD5HASH = {QS(albumEntry.MD5HASH)}; ");

                // create an array of the comma delimited tags in the PhotoAlbumEntry class instance.. 
                string[] tags = albumEntry.TAGTEXT.Split(new string[] { ", " }, StringSplitOptions.None);

                // fist delete as the tags as they are shared via their file MD5 hashes..
                sql +=
                    string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..
                    $"DELETE FROM PHOTODATATAG WHERE MD5HASH = {QS(albumEntry.MD5HASH)}; ");

                // loop through the tags..
                foreach (string tag in tags)
                {
                    // empty items are not accepted..
                    if (tag.Trim() == string.Empty)
                    {
                        continue; // ..so do continue..
                    }
                    sql += // formulate the PHOTODATATAG table insert..
                        string.Join(Environment.NewLine, Environment.NewLine, // new lines to improve debug readability..                        
                        "INSERT INTO PHOTODATATAG (MD5HASH, TAGTEXT) ",
                        $"VALUES ({QS(albumEntry.MD5HASH)}, {QS(tag)}); ");
                }
            }
            return sql;
        }

        /// <summary>
        /// Inserts a new photo album into the program's database.
        /// </summary>
        /// <param name="album">The album to insert.</param>
        /// <param name="albumEntries">A collection of entries to be part of the album.</param>
        /// <returns>True if the SQLite transaction was successful; otherwise false.</returns>
        public static bool InsertPhotoAlbum(PHOTOALBUM album, IEnumerable<PhotoAlbumEntry> albumEntries)
        {
            string sql = GenPhotoAlbumInsert(album, albumEntries); // generate an SQL sentence..
            return ExecuteArbitrarySQL(sql); // execute the "transaction"..
        }


        /// <summary>
        /// Update a new photo album in the program's database.
        /// </summary>
        /// <param name="album">The album to update.</param>
        /// <param name="albumEntries">A collection of entries to being a part of the album.</param>
        /// <returns>True if the SQLite transaction was successful; otherwise false.</returns>
        public static bool UpdatePhotoAlbum(PHOTOALBUM album, IEnumerable<PhotoAlbumEntry> albumEntries)
        {
            string sql = GenPhotoAlbumUpdate(album, albumEntries); // generate an SQL sentence..
            return ExecuteArbitrarySQL(sql); // execute the "transaction"..
        }
        #endregion
    }

    #region PhotoClasses    
    /// <summary>
    /// A class describing the PHOTOALBUM table in the database.
    /// </summary>
    public class PHOTOALBUM
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PHOTOALBUM"/> class with the given PHOTOALBUM class instance.
        /// </summary>
        /// <param name="photoAlbum">A PHOTOALBUM class instance to initialize the new instance with.</param>
        public PHOTOALBUM(PHOTOALBUM photoAlbum)
        {
            NAME = photoAlbum.NAME;
            BASEDIROVERRIDE = photoAlbum.BASEDIROVERRIDE;
            FIRSTDATE = photoAlbum.FIRSTDATE;
            PreviousName = photoAlbum.PreviousName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PHOTOALBUM"/> class.
        /// </summary>
        public PHOTOALBUM()
        {

        }

        /// <summary>
        /// Gets or sets the NAME column's value.
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// Gets or sets the BASEDIROVERRIDE column's value.
        /// </summary>
        public string BASEDIROVERRIDE { get; set; }

        /// <summary>
        /// Gets or sets the FIRSTDATE column's value.
        /// </summary>
        public DateTime FIRSTDATE { get; set; }

        /// <summary>
        /// Gets or sets the previous NAME column's value.
        /// </summary>
        public string PreviousName { get; set; }
    }

    /// <summary>
    /// A class containing tag texts used to describe a photo file.
    /// </summary>
    public class PHOTODATATAG
    {
        /// <summary>
        /// Gets or sets the text used to tag/describe a photo file.
        /// </summary>
        public string TAGTEXT { get; set; }
    }
    #endregion
}
