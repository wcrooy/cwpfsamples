/*
 * ISplashService.cs    6/14/2008 4:27:13 PM
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


namespace BrettRyan.LateNight.Services {

    /// <summary>
    /// Service for other modules to interact with the startup splash screen.
    /// </summary>
    public interface ISplashService {

        /// <summary>
        /// Set a message during startup.
        /// </summary>
        /// <param name="message">
        /// Message to be set in the splash screen.
        /// </param>
        void SetMessage(string message);

    }

}
