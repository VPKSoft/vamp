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
using System.Windows.Forms;
using VPKSoft.LangLib; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using System.Reflection;
using System.Runtime.CompilerServices;
using System.IO;
using System.Diagnostics;
using VPKSoft.ErrorLogger; // (C): http://www.vpksoft.net/, GNU Lesser General Public License Version 3
using Gecko; // (C): https://bitbucket.org/geckofx/geckofx-45.0, Mozilla Public License
using CefSharp; // (C): https://github.com/cefsharp/CefSharp/, Modified BSD (3-clause BSD license)

namespace vamp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();

            bool runSetting = false;
            bool runPhotoAlbumEditor = false;

            foreach (string arg in args)
            {
                if (arg == "--configure")
                {
                    runSetting = true;
                }

                if (arg == "--photos")
                {
                    runPhotoAlbumEditor = true;
                }
            }

            if (runSetting)
            {
                if (VPKSoft.Utils.AppRunning.CheckIfRunning("vamp#_normal_setting"))
                {
                    return;
                }
                else
                {
                    ExceptionLogger.Bind(1); // bind before any visual objects are created..
                    ExceptionLogger.ApplicationCrash += ExceptionLogger_ApplicationCrash;
                    Settings.InitSettings();
                    Application.Run(new FormSettings());
                    ExceptionLogger.UnBind(); // unbind so the truncate thread is stopped successfully..
                    return;
                }
            }
            if (runPhotoAlbumEditor)
            {
                if (VPKSoft.Utils.AppRunning.CheckIfRunning("vamp#_normal_photos"))
                {
                    return;
                }
                else
                {
                    ExceptionLogger.Bind(2); // bind before any visual objects are created..
                    ExceptionLogger.ApplicationCrash += ExceptionLogger_ApplicationCrash;
                    Settings.InitSettings();
                    Application.Run(new FormPhotoAlbumEditor());
                    ExceptionLogger.UnBind(); // unbind so the truncate thread is stopped successfully..
                    return;
                }
            }
            else
            {
                if (VPKSoft.Utils.AppRunning.CheckIfRunning("vamp#_normal"))
                {
                    return;
                }
            }

            if (Utils.ShouldLocalize() == null)
            {
                FormSplash.ShowFormSplash();
            }

            FormSplash.SetStatus(FormSplash.MsgBindExceptionLogger, 100);
            ExceptionLogger.Bind(); // bind before any visual objects are created
            ExceptionLogger.ApplicationCrash += ExceptionLogger_ApplicationCrash;
            FormSplash.SetStatus(FormSplash.MsgVisualStyles, 0);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormSplash.SetStatus(FormSplash.MsgVisualStyles, 100);

            AppDomain.CurrentDomain.AssemblyResolve += Resolver;

            // Save languages
            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                new FormMain();
                new FormPlayer();
                new FormSelectSubtitle();
                new FormDialogSelectFileOrDirectory();
                new FormWebBrowserGecko(string.Empty);
                new FormDialogSelectPlaybackPosition();
                new FormDialogSelectLocation();
                new FormAmpMusicPlayer();
                new FormDialogError();
                new FormDialogSelectCustomContent();
                new FormSplash();
                new FormSettings();
                new FormTMDBLoadProgress();
                new FormPhotoAlbumEditor();
                new FormDialogPhotoAlbumQueryName();
                new FormSelectMovie();
                ExceptionLogger.UnBind(); // unbind so the truncate thread is stopped successfully..
                return;
            }

            Settings.InitSettings();

            ExceptionLogger.LogMessage(AppDomain.CurrentDomain.BaseDirectory);

            InitGeckoFx();

            LoadApp(); // Initialize the Chromium web browser

            Xpcom.Shutdown();
            ExceptionLogger.UnBind(); // unbind so the truncate thread is stopped successfully..
        }

        // as the application is about to crash do some cleanup..
        private static void ExceptionLogger_ApplicationCrash()
        {
            // unsubscribe this event handler..
            ExceptionLogger.ApplicationCrash -= ExceptionLogger_ApplicationCrash;
            ExceptionLogger.UnBind(); // unbind the exception logger..

            // kill self as the native inter-op libraries may have some issues of keeping the process alive..
            Process.GetCurrentProcess().Kill();

            // This is the end..
        }

        private static void InitGeckoFx()
        {
            // Perform dependency check to make sure all relevant resources are in our output directory.
            // Discarded: var settings = new CefSettings();

            FormSplash.SetStatus(FormSplash.MsgInitGeckoFXEngine, 0);

            string cachePath = Path.Combine(Environment.GetEnvironmentVariable("LOCALAPPDATA"), "vamp#", "geckofx_cache");
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }

            Xpcom.ProfileDirectory = cachePath;

            string GeckoDLLPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Firefox" + (Environment.Is64BitProcess ? "_x64" : "_x86"));

            ExceptionLogger.LogMessage(GeckoDLLPath);

            Xpcom.Initialize(GeckoDLLPath);

            GeckoPreferences.User["browser.cache.disk.enable"] = true;
            GeckoPreferences.User["browser.cache.memory.enable"] = true;
            GeckoPreferences.User["browser.cache.check doc frequency"] = 3;
            GeckoPreferences.User["browser.cache.disk.capacity"] = 50000;
            GeckoPreferences.User["browser.cache.memory.capacity()"] = -1;
            FormSplash.SetStatus(FormSplash.MsgInitGeckoFXEngine, 100);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void LoadApp()
        {
            string subProcessPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                   Environment.Is64BitProcess ? "x64" : "x86",
                                                   "CefSharp.BrowserSubprocess.exe");


            ExceptionLogger.LogMessage($"CefSharp subprocess: '{subProcessPath}'");


            FormSplash.SetStatus(FormSplash.MsgInitChromiumEmbeddedFrameworkSettings, 0);

            //Perform dependency check to make sure all relevant resources are in our output directory.
            var settings = new CefSettings
            {
                BrowserSubprocessPath = subProcessPath
            };

            string cachePath = Path.Combine(Environment.GetEnvironmentVariable("LOCALAPPDATA"), "vamp#", "CefCache");

            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }

            settings.CachePath = cachePath;


            settings.LogSeverity = LogSeverity.Warning;
            settings.LogFile = Path.Combine(settings.CachePath, "cef.log");
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
            FormSplash.SetStatus(FormSplash.MsgInitChromiumEmbeddedFrameworkSettings, 100);

            FormMain formMain = new FormMain();
            FormSplash.CloseFormSplash();
            Application.Run(formMain);
        }

        // Will attempt to load missing assembly from either x86 or x64 subdirectory
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            FormSplash.SetStatus(FormSplash.MsgLoadChromiumEmbeddedFramework, 0);

            Assembly assembly = null;

            if (args.Name.StartsWith("CefSharp"))
            {
                ExceptionLogger.LogMessage("CefSharp queued..");

                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                       Environment.Is64BitProcess ? "x64" : "x86",
                                                       assemblyName);

                ExceptionLogger.LogMessage($"CefSharp assembly: '{archSpecificPath}'");

                assembly = System.IO.File.Exists(archSpecificPath)
                           ? Assembly.LoadFile(archSpecificPath)
                           : null;
            }
            FormSplash.SetStatus(FormSplash.MsgLoadChromiumEmbeddedFramework, 100);
            return assembly;
        }
    }
}
