/*
 * ModelState.cs    6/14/2008 5:56:10 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms.
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BrettRyan.LateNight {

    /// <summary>
    ///
    /// </summary>
    /// <remarks>
    /// This is based on the DataModel-View-ViewModel sample by Dan Crevier
    /// (<see cref="http://blogs.msdn.com/dancre/archive/2006/07/23/676300.aspx"/>)
    /// </remarks>
    public enum ModelState {

        /// <summary>
        /// The model is fetching data
        /// </summary>
        Fectching,

        /// <summary>
        /// The model is in an invalid state
        /// </summary>
        Invalid,

        /// <summary>
        /// The model has fetched its data
        /// </summary>
        Active

    }

}
