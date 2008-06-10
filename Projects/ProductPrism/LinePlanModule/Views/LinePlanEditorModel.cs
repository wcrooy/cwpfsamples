/*
 * LinePlanEditorDocument.cs    6/8/2008 5:51:42 PM
 *
 * Copyright 2008 John Sands (Australia) Ltd. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using JohnSands.ProductPrism.Infrastructure;
using JohnSands.ProductPrism.LinePlanModule.BusinessEntities;


namespace JohnSands.ProductPrism.LinePlanModule.Views {

    /// <summary>
    /// Document model for editing a line-plan.
    /// </summary>
    public class LinePlanEditorModel : AbstractDocument {

        private LinePlanEditor view;

        /// <summary>
        /// Creates a new instance of <c>LinePlanEditorDocument</c>.
        /// </summary>
        public LinePlanEditorModel(LinePlan linePlan) {
            LinePlan = linePlan;
            view = new LinePlanEditor();
            view.DataContext = this;
        }

        /// <summary>
        /// <see cref="JohnSands.ProductPrism.LinePlanModule.BusinessEntities.LinePlan"/>
        /// object this document represents.
        /// </summary>
        public LinePlan LinePlan {
            get;
            private set;
        }

        /// <summary>
        /// The documents line plan name.
        /// </summary>
        public override string DocumentTitle {
            get { return LinePlan.Name; }
        }

        /// <summary>
        /// The current view for the document.
        /// </summary>
        public override UserControl View {
            get { return view; }
        }

        /// <summary>
        /// Long description for the document.
        /// </summary>
        public override string Description {
            get {
                return
                    String.Format(
                    "Document representing the '{0}' LinePlan.", LinePlan.Name)
                    ;
            }
        }


        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            if (obj != null && obj.GetType().Equals(this.GetType())) {
                LinePlanEditorModel other = obj as LinePlanEditorModel;
                if ((object)other != null) {
                    return Equals(other);
                }
            }
            return false;
        }

        #region Equals(LinePlanEditorDocument) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// LinePlanEditorDocument object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// LinePlanEditorDocument object to compare against.
        /// </param>
        public bool Equals(LinePlanEditorModel other) {
            return LinePlan.Equals(other.LinePlan);
        }
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            return 25 + LinePlan.GetHashCode();
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
                "{0}[LinePlan={1}]",
                GetType().Name,
                LinePlan);
        }

        #endregion

    }

    class LinePlanGroupModel {

        ObservableCollection<object> promotions;
        ObservableCollection<object> brands;
        ObservableCollection<object> segments;
        ObservableCollection<object> statuses;
        ObservableCollection<object> released;

    }

}
