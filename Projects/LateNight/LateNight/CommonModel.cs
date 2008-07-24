/*
 * CommonModel.cs    6/15/2008 7:39:18 PM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace BrettRyan.LateNight {

    /// <summary>
    /// Common module used by the base appliation.
    /// </summary>
    internal static class CommonModel {

        private static string versionText;

        /// <summary>
        /// Returns the version number as a text string with a build of the
        /// build time.
        /// </summary>
        /// <remarks>
        /// The build must have been configured as the M.m.*.* pattern where
        /// M = major and m = minor revision numbers.
        /// </remarks>
        public static string VersionTextAsDateTime {
            get {
                if (versionText == null) {
                    Version ver = VersionHelper.Version;
                    if (ver == null) {
                        versionText = String.Empty;
                    } else {
                        versionText = String.Format("v{0}.{1} (Build {2})",
                            ver.Major, ver.Minor,
                            VersionHelper.GetBuildRevisionAsDateTime(ver));
                    }
                }
                return versionText;
            }
        }

        /// <summary>
        /// Returns the <see cref="VersionHelper.AssemblyMajorVersion"/>
        /// result.
        /// </summary>
        public static string MajorVersion {
            get { return VersionHelper.AssemblyMajorVersion; }
        }

        /// <summary>
        /// Returns the runtime framework version.
        /// </summary>
        /// <seealso cref="RuntimeEnvironment.GetSystemVersion"/>
        public static string FrameworkVersion {
            get {
                return RuntimeEnvironment.GetSystemVersion().ToString();
            }
        }

        /// <summary>
        /// Returns the current runtime environments directory.
        /// </summary>
        /// <seealso cref="RuntimeEnvironment.GetRuntimeDirectory"/>
        public static string FrameworkDirectory {
            get {
                return RuntimeEnvironment.GetRuntimeDirectory();
            }
        }

        /// <summary>
        /// Returns the full version number for this appliction.
        /// </summary>
        /// <seealso cref="VersionHelper.AssemblyVersion"/>
        public static string FullVersionNumber {
            get {
                return VersionHelper.AssemblyVersion;
            }
        }

    }

}
