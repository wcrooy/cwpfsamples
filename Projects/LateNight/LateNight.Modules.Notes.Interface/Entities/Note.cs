/*
 * Note.cs    6/16/2008 5:10:39 PM
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


namespace BrettRyan.LateNight.Modules.Notes.Entities {

    /// <summary>
    ///
    /// </summary>
    public class Note {

        /// <summary>
        /// Creates a new instance of <c>Note</c>.
        /// </summary>
        public Note() {
        }

        public Note(int noteId) {
            NoteID = noteId;
        }

        public Note(int noteId, string title) {
            Title = title;
        }

        public Note(int noteId, string title, string content) {
            NoteID = noteId;
            Title = title;
            Content = content;
        }

        public int NoteID {
            get;
            set;
        }

        public string Title {
            get;
            set;
        }

        public string Content {
            get;
            set;
        }


        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            if (obj != null && obj.GetType().Equals(this.GetType())) {
                Note other = obj as Note;
                if ((object)other != null) {
                    return Equals(other);
                }
            }
            return false;
        }

        #region Equals(Note) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// Note object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// Note object to compare against.
        /// </param>
        public bool Equals(Note other) {
            return NoteID == other.NoteID;
        }
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            return 24 * NoteID;
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
            return String.Format("{0}[NoteID={2},Title={4}]",
                GetType().Name,
                NoteID,
                Title);
        }

        #endregion

    }

}

