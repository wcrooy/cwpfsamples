/*
 * ILinePlanService.cs    6/5/2008 7:13:30 PM
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

using JohnSands.ProductPrism.LinePlanModule.BusinessEntities;


namespace JohnSands.ProductPrism.LinePlanModule.Services {

    /// <summary>
    /// Service used to work with line plans.
    /// </summary>
    public interface ILinePlanService {

        /// <summary>
        /// Returns a collection of all available line-plans.
        /// </summary>
        /// <returns>Collection of line-plans.</returns>
        ICollection<LinePlan> GetLinePlans();

    }

}

