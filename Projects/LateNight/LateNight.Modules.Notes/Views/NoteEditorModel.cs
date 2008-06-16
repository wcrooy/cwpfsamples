/*
 * NoteEditorModel.cs    6/17/2008 2:19:10 AM
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
using System.Windows;

using BrettRyan.LateNight.DocumentModel;
using BrettRyan.LateNight.Modules.Notes.Entities;


namespace BrettRyan.LateNight.Modules.Notes.Views {

    /// <summary>
    ///
    /// </summary>
    public class NoteEditorModel : AbstractDocument {

        private NoteEditor view;

        /// <summary>
        /// Creates a new instance of <c>NoteEditorModel</c>.
        /// </summary>
        public NoteEditorModel(Note note) {
            Note = note;
            view = new NoteEditor();
            view.DataContext = this;
        }

        public Note Note {
            get;
            private set;
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            if (obj != null && obj.GetType().Equals(this.GetType())) {
                NoteEditorModel other = obj as NoteEditorModel;
                if ((object)other != null) {
                    return Equals(other);
                }
            }
            return false;
            return base.Equals(obj);
        }

        #region Equals(NoteEditorModel) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// NoteEditorModel object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// NoteEditorModel object to compare against.
        /// </param>
        public bool Equals(NoteEditorModel other) {
            return other.Note.Equals(Note);
        }
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            return 6 * Note.GetHashCode();
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
            get { return Note.Title; }
        }

        public override FrameworkElement View {
            get { return view; }
        }

        public override string Description {
            get { throw new NotImplementedException(); }
        }

    }

}
