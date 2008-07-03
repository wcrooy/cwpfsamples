/*
 * AstractDataModel.cs    6/14/2008 5:45:54 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms.
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Threading;


namespace BrettRyan.LateNight {

    /// <summary>
    /// Base abstract model implementation.
    /// </summary>
    /// <remarks>
    /// This is based on the DataModel-View-ViewModel sample by Dan Crevier
    /// (<see cref="http://blogs.msdn.com/dancre/archive/2006/07/23/676300.aspx"/>)
    /// </remarks>
    public abstract class AbstractDataModel : INotifyPropertyChanged {

        private ModelState state;

        /// <summary>
        /// Creates a new instance of <c>DataModel</c>.
        /// </summary>
        public AbstractDataModel() {
            Dispatcher = Dispatcher.CurrentDispatcher;
            VerifyCalledOnUIThread();
        }

        /// <summary>
        /// <see cref="System.Windows.Threading.Dispatcher"/> this model was
        /// created on.
        /// </summary>
        protected Dispatcher Dispatcher {
            get;
            private set;
        }

        /// <summary>
        /// State of the data mode.
        /// </summary>
        /// <seealso cref="BrettRyan.LateNight.ModelState"/>
        public ModelState State {
            get {
                VerifyCalledOnUIThread();
                return state;
            }
            set {
                VerifyCalledOnUIThread();
                if (value != state) {
                    state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        /// <summary>
        /// Verifies that the call is not on the UI thread.
        /// </summary>
        /// <remarks>
        /// This simply checks that the process is executing on the thread
        /// that the model was created on.
        /// </remarks>
        [Conditional("DEBUG")]
        protected void VerifyCalledOnUIThread() {
            Debug.Assert(Dispatcher.CurrentDispatcher == this.Dispatcher,
                "Call must be made on UI thread.");
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    DataModel other = obj as DataModel;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(DataModel) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(DataModel) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// DataModel object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// DataModel object to compare against.
        ///// </param>
        //public bool Equals(DataModel other) {
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

        /// <summary>
        /// Fired whenever the model determines that a state property has
        /// been altered.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged {
            add {
                VerifyCalledOnUIThread();
                propertyChangedEvent += value;
            }
            remove {
                VerifyCalledOnUIThread();
                propertyChangedEvent -= value;
            }
        }

        /// <summary>
        /// Fires the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="prop">Property to fire a changed event for.</param>
        /// <seealso cref="System.ComponentModel.INotifyPropertyChanged"/>
        protected void OnPropertyChanged(string prop) {
            VerifyCalledOnUIThread();
            if (propertyChangedEvent != null)
                propertyChangedEvent(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

    }

}
