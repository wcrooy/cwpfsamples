/*
 * CommonModel.cs    6/15/2008 7:39:18 PM
 *
 * Copyright 2008 John Sands (Australia) Ltd. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BrettRyan.LateNight.Infrastructure;


namespace BrettRyan.LateNight {

    /// <summary>
    ///
    /// </summary>
    public static class CommonModel {

        private static string versionText;

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

        public static string MajorVersion {
            get { return VersionHelper.AssemblyMajorVersion; }
        }

        public static string FrameworkVersion {
            get {
                return System.Runtime.InteropServices
                    .RuntimeEnvironment.GetSystemVersion().ToString();
            }
        }

        public static string FrameworkDirectory {
            get {
                return System.Runtime.InteropServices
                    .RuntimeEnvironment.GetRuntimeDirectory();
            }
        }

        public static string FullVersionNumber {
            get {
                return VersionHelper.AssemblyVersion;
            }
        }

    }

}
