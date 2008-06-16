/*
 * NotesBrowserModel.cs    6/16/2008 9:33:41 PM
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
using System.Windows;

using BrettRyan.LateNight.DocumentModel;


namespace BrettRyan.LateNight.Modules.Notes.Views {

    /// <summary>
    ///
    /// </summary>
    public class NotesBrowserModel : AbstractDocument {

        private FrameworkElement view;

        /// <summary>
        /// Creates a new instance of <c>NotesBrowserModel</c>.
        /// </summary>
        public NotesBrowserModel() {
            this.view = new FrameworkElement();
        }


        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            if (obj != null && obj.GetType().Equals(this.GetType())) {
                NotesBrowserModel other = obj as NotesBrowserModel;
                if ((object)other != null) {
                    return Equals(other);
                }
            }
            return false;
        }

        #region Equals(NotesBrowserModel) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// NotesBrowserModel object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// NotesBrowserModel object to compare against.
        /// </param>
        public bool Equals(NotesBrowserModel other) {
            return true;
        }
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            return 76;
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
            //return GetType().Name
            //    + "["
            ////  TODO: Add property list to output
            ////        Example: Property=value,Property2=value
            //    + "]"
            //    ;
            return base.ToString();
        }

        #endregion


        public override string DocumentTitle {
            get { return "Notes"; }
        }

        public override System.Windows.FrameworkElement View {
            get { return view; }
        }

        public override string Description {
            get { return "Notes Browser"; }
        }

    }

}

