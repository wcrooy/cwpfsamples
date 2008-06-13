/*
 * AbstractDocument.cs    6/14/2008 5:45:17 AM
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
using System.Windows.Controls;


namespace BrettRyan.LateNight.Infrastructure {

    /// <summary>
    /// Base document meant to be consumed by an
    /// <see cref="IDocumentController"/>.
    /// </summary>
    public abstract class AbstractDocument : AbstractDataModel {

        /// <summary>
        /// Document title.
        /// </summary>
        /// <remarks>
        /// This is meant to be used as the header within a WPF control.
        /// </remarks>
        public abstract string DocumentTitle {
            get;
        }

        /// <summary>
        /// Document work area.
        /// </summary>
        /// <remarks>
        /// Will become the content control for the document within a WPF
        /// environment.
        /// </remarks>
        public abstract UserControl View {
            get;
        }

        /// <summary>
        /// Long document description.
        /// </summary>
        /// <remarks>
        /// May be displayed in extended forms from the UI (possibly a tooltip
        /// for example).
        /// </remarks>
        public abstract string Description {
            get;
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    AbstractDocument other = obj as AbstractDocument;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(AbstractDocument) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(AbstractDocument) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// AbstractDocument object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// AbstractDocument object to compare against.
        ///// </param>
        //public bool Equals(AbstractDocument other) {
        //    return Document.Equals(other.Document);
        //}
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            //return 25 + Document.GetHashCode();
            return base.GetHashCode();
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
                "{0}[DocumentTitle={1}]",
                GetType().Name,
                DocumentTitle
                );
        }

        #endregion

    }

}
