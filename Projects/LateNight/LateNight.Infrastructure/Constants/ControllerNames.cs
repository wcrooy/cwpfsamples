/*
 * ControllerNames.cs    6/14/2008 6:14:53 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BrettRyan.LateNight.Constants {

    /// <summary>
    /// Names for controller items.
    /// </summary>
    public static class ControllerNames {

        /// <summary>
        /// Document controller for the main work area.
        /// </summary>
        public const string DocumentController = "DocumentController";

        /// <summary>
        /// Document controlelr for extension points within the application.
        /// </summary>
        /// <remarks>
        /// This is currently just the left hand side of the application
        /// though it may is likely I will extend this at a later date to
        /// allow for multiple extension regions. This behaviour could then
        /// reflect the docking behaviour in Visual Studio.
        /// </remarks>
        public const string SystemDocumentController = "SystemDocumentController";

    }

}
