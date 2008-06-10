/*
 * LinePlanService.cs    6/5/2008 7:27:53 PM
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
    /// Implementation of the <see cref="ILinePlanService"/> interface.
    /// </summary>
    public class LinePlanService : ILinePlanService {

        /// <summary>
        /// Creates a new instance of <c>LinePlanService</c>.
        /// </summary>
        public LinePlanService() {
        }


        #region ILinePlanService Members

        /// <summary>
        /// Returns a collection of all available line-plans.
        /// </summary>
        /// <returns>Collection of line-plans.</returns>
        public ICollection<LinePlan> GetLinePlans() {
            ICollection<LinePlan> res = new List<LinePlan>();
            res.Add(new LinePlan() { LinePlanID = 1, Name = "Dummy 1" });
            res.Add(new LinePlan() { LinePlanID = 2, Name = "Dummy 2" });
            res.Add(new LinePlan() { LinePlanID = 3, Name = "Dummy 3" });
            res.Add(new LinePlan() { LinePlanID = 4, Name = "Dummy 4" });
            return res;
        }

        #endregion

    }

}

