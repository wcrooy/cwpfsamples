/*
 * WelcomeModel.cs    6/8/2008 3:31:14 PM
 *
 * Copyright 2008 John Sands (Australia) Ltd. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using JohnSands.ProductPrism.Infrastructure;


namespace JohnSands.ProductPrism.WelcomeModule {

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

        public bool ShowOnStartup {
            get { return Properties.Settings.Default.ShowWelcomeScreen; }
            set {
                if (value != Properties.Settings.Default.ShowWelcomeScreen) {
                    Properties.Settings.Default.ShowWelcomeScreen = value;
                    Properties.Settings.Default.Save();
                }
            }
        }

        public override string DocumentTitle {
            get { return "Welcome"; }
        }

        public override UserControl View {
            get { return view; }
        }

        public override string Description {
            get { return "Welcome to ProductPrism!"; }
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

        #region Equals(WelcomeDocument) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// WelcomeDocument object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// WelcomeDocument object to compare against.
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
