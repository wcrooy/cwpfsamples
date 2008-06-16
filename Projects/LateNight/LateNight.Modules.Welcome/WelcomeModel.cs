/*
 * WelcomeModel.cs    6/14/2008 7:02:07 AM
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
using System.Windows;

using BrettRyan.LateNight.DocumentModel;


namespace BrettRyan.LateNight.Modules.Welcome {

    /// <summary>
    /// Document to represent the welcome screen.
    /// </summary>
    /// <remarks>
    /// This should be a singleton instance as it should not appear more than
    /// once in the view.
    /// </remarks>
    public class WelcomeModel : AbstractDocument {

        private WelcomeView view;

        /// <summary>
        /// Creates a new instance of <c>WelcomeDocumentModel</c>.
        /// </summary>
        public WelcomeModel() {
            view = new WelcomeView();
            view.DataContext = this;
        }

        public override string DocumentTitle {
            get { return "Welcome"; }
        }

        public override FrameworkElement View {
            get { return view; }
        }

        public override string Description {
            get { return "Welcome to Late Night!"; }
        }


        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            if (obj != null && obj.GetType().Equals(this.GetType())) {
                WelcomeModel other = obj as WelcomeModel;
                if ((object)other != null) {
                    return Equals(other);
                }
            }
            return false;
        }

        #region Equals(WelcomeModel) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// WelcomeModel object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// WelcomeModel object to compare against.
        /// </param>
        public bool Equals(WelcomeModel other) {
            return true;
        }
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            return 413;
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
