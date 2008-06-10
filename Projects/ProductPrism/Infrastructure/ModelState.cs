/*
 * ModelState.cs    6/6/2008 6:12:00 PM
 *
 * Copyright 2008  All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JohnSands.ProductPrism.Infrastructure {

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

