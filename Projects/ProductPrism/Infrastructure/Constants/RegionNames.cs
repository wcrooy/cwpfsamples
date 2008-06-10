/*
 * WorkspaceNames.cs    6/3/2008 4:23:48 PM
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


namespace JohnSands.ProductPrism.Infrastructure.Constants {

    /// <summary>
    /// Region names exposed by the main UI.
    /// </summary>
    /// <remarks>
    /// Try to avoid having to create a region extension where possible in
    /// favour of using a controller item.
    /// </remarks>
    public static class RegionNames {

        /// <summary>
        /// Represents the view menu item.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Once I've figured out how to write a menu service this will be
        /// replaced.
        /// </para>
        /// <para>
        /// There are two reasons 
        /// </para>
        /// </remarks>
        public const string ViewMenu = "ViewMenu";

    }

}
