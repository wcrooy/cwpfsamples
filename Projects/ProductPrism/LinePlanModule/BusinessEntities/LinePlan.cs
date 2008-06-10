/*
 * LinePlan.cs    6/5/2008 7:14:50 PM
 *
 * Copyright 2008  All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JohnSands.ProductPrism.LinePlanModule.BusinessEntities {

    /// <summary>
    /// Represents a product line-plan offering.
    /// </summary>
    public class LinePlan {

        /// <summary>
        /// Creates a new instance of <c>LinePlan</c>.
        /// </summary>
        public LinePlan() {
        }

        /// <summary>
        /// Line Plan ID.
        /// </summary>
        public int LinePlanID { get; set; }

        /// <summary>
        /// Line Plan Name.
        /// </summary>
        public string Name { get; set; }


        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            if (obj != null && obj.GetType().Equals(this.GetType())) {
                LinePlan other = obj as LinePlan;
                if ((object)other != null) {
                    return Equals(other);
                }
            }
            return false;
        }

        #region Equals(LinePlan) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// LinePlan object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// LinePlan object to compare against.
        /// </param>
        public bool Equals(LinePlan other) {
            return this.LinePlanID == other.LinePlanID;
        }
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            return LinePlanID;
        }

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        /// <remarks>
        /// Returns a string representation of this object. This is
        /// formatted as a key property list proceeded by the fully qualified
        /// type name.
        /// </remarks>
        public override string ToString() {
            return String.Format(
                "{0}[LinePlanID={1},Name={2}]",
                GetType().Name,
                LinePlanID,
                Name);
        }

        #endregion

    }

}

