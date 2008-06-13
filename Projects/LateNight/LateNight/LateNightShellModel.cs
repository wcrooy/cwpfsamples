/*
 * LateNightShellModel.cs    6/14/2008 4:20:27 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms.
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using BrettRyan.LateNight.Infrastructure;


namespace BrettRyan.LateNight {

    /// <summary>
    /// Model used for the main visual component (UI).
    /// </summary>
    internal sealed class LateNightShellModel : INotifyPropertyChanged {

        private string versionText;

        /// <summary>
        /// Creates a new instance of <c>LateNightShellModel</c>.
        /// </summary>
        public LateNightShellModel() {
            Version ver = VersionHelper.Version;
            if (ver == null) {
                versionText = String.Empty;
            } else {
#if DEBUG
                //versionText = String.Format("v{0}.{1} (Build {2}, Revision {3})",
                //    ver.Major, ver.Minor, ver.Build, ver.Revision);
                versionText = String.Format("v{0}.{1} (Build {2})",
                    ver.Major, ver.Minor,
                    VersionHelper.GetBuildRevisionAsDateTime(ver));
#else
                versionText = String.Format("v{0}.{1}",
                    ver.Major, ver.Minor);
#endif
            }
        }

        /// <summary>
        /// Used by the UI to get the current version number text.
        /// </summary>
        public string ProductVersionText {
            get { return versionText; }
            set {
                if (!String.Equals(versionText, value)) {
                    versionText = value;
                    OnPropertyChanged("ProductVersionText");
                }
            }
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    LateNightShellModel other = obj as LateNightShellModel;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(LateNightShellModel) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(LateNightShellModel) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// LateNightShellModel object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// LateNightShellModel object to compare against.
        ///// </param>
        //public bool Equals(LateNightShellModel other) {
        //    //TODO: Add Equals implementation
        //    return base.Equals(other);
        //}
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            //TODO: create real implementation for GetHashCode()
            // Implementations should at the least return an exclusive or of
            // all properties (prop1.GetHashCode() ^ prop2.GetHashCode()).
            // Improve this by performing binary shifts for values too large
            // for an integer eg. dbl ^ ((uint)dbl >> 32) where dbl is some
            // double.
            //
            // Sample (NetBeans 6.0 Implementation):
            // int hash = {Num};
            // hash = {Num} * hash + this.intProp;
            // hash = {Num} * hash + this.dblProp ^ ((uint)this.dblProp >> 32);
            // hash = {Num} * hash + this.strProp == null
            //                              ? 0 : this.strProp.GetHashCode();
            // return hash;
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
            //return GetType().Name
            //    + "["
            ////  TODO: Add property list to output
            ////        Example: Property=value,Property2=value
            //    + "]"
            //    ;
            return base.ToString();
        }

        #endregion


        #region INotifyPropertyChanged Members

        private event PropertyChangedEventHandler propertyChangedEvent;

        public event PropertyChangedEventHandler PropertyChanged {
            add { propertyChangedEvent += value; }
            remove { propertyChangedEvent -= value; }
        }

        protected void OnPropertyChanged(string prop) {
            if (propertyChangedEvent != null)
                propertyChangedEvent(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

    }

}
