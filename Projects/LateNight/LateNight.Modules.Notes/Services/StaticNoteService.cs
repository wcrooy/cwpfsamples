/*
 * StaticNoteService.cs    6/16/2008 11:47:19 PM
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
    public class StaticNoteService : INoteService {

        #region INoteServices Members

        public IEnumerable<Note> GetAllNotes() {
            return StaticNoteDataStore.GetAll();
        }

        public Note GetNote(int id) {
            return StaticNoteDataStore.Get(id);
        }

        public Note CreateNewNote() {
            return StaticNoteDataStore.Create();
        }

        public void DeleteNote(Note note) {
            StaticNoteDataStore.Delete(note);
        }

        #endregion

        static class StaticNoteDataStore {

            private static int id;
            private static Dictionary<int, Note> notes;

            static StaticNoteDataStore() {
                notes = new Dictionary<int, Note>();
                int id = NextID();
                notes.Add(id, new Note(id, "Title #1", "This is the content of the note #1"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #2", "This is the content of the note #2"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #3", "This is the content of the note #3"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #4", "This is the content of the note #4"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #5", "This is the content of the note #5"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #6", "This is the content of the note #6"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #7", "This is the content of the note #7"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #8", "This is the content of the note #8"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #9", "This is the content of the note #9"));
                id = NextID();
                notes.Add(id, new Note(id, "Title #10", "This is the content of the note #10"));
            }

            private static int NextID() {
                return ++id;
            }

            public static Note Get(int id) {
                if (notes.ContainsKey(id)) {
                    return notes[id];
                }
                return null;
            }

            public static IEnumerable<Note> GetAll() {
                return notes.Values.AsEnumerable<Note>();
            }

            public static Note Create() {
                Note note = new Note(NextID(), "New Note");
                notes.Add(note.NoteID, note);
                return note;
            }

            public static void Delete(Note note) {
                if (notes.ContainsKey(note.NoteID)) {
                    notes.Remove(note.NoteID);
                }
            }

        }

    }

}
