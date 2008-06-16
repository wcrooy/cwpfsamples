/*
 * INoteServices.cs    6/16/2008 11:41:01 PM
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

using BrettRyan.LateNight.Modules.Notes.Entities;


namespace BrettRyan.LateNight.Modules.Notes.Services {

    /// <summary>
    ///
    /// </summary>
    public interface INoteService {

        /// <summary>
        /// Returns a collection of all notes.
        /// </summary>
        /// <returns>Enuerable collection of notes.</returns>
        IEnumerable<Note> GetAllNotes();

        /// <summary>
        /// Returns a note based on its unique ID.
        /// </summary>
        /// <param name="id">Note ID.</param>
        /// <returns>New note instance.</returns>
        Note GetNote(int id);

        /// <summary>
        /// Creates a new note.
        /// </summary>
        /// <returns>New note instance.</returns>
        Note CreateNewNote();

        /// <summary>
        /// Deletes the supplied note.
        /// </summary>
        /// <param name="note">Note to be deleted.</param>
        void DeleteNote(Note note);

    }

}
