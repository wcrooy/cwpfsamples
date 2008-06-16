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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Composite.Wpf.Commands;
using Microsoft.Practices.Unity;

using BrettRyan.LateNight.Constants;
using BrettRyan.LateNight.DocumentModel;
using BrettRyan.LateNight.Modules.Notes.Entities;
using BrettRyan.LateNight.Modules.Notes.Services;


namespace BrettRyan.LateNight.Modules.Notes.Views {

    /// <summary>
    ///
    /// </summary>
    public class NotesBrowserModel : AbstractDocument {

        private FrameworkElement view;
        private INoteService service;
        private IDocumentController documentController;
        private Note selectedNote;

        /// <summary>
        /// Creates a new instance of <c>NotesBrowserModel</c>.
        /// </summary>
        public NotesBrowserModel(IUnityContainer container) {
            OpenNoteCommand = new DelegateCommand<Note>(OpenNote);
            DeleteSelectedNoteCommand = new DelegateCommand<object>(
                DeleteSelectedNote, CanDeleteSelectedNote);
            CreateNewNoteCommand = new DelegateCommand<object>(CreateNewNote);

            view = new NotesBrowser(this);
            service = container.Resolve<INoteService>();
            documentController = container.Resolve<IDocumentController>(
                ControllerNames.DocumentController);

            Notes = new ObservableCollection<Note>();
            LoadAllNotes();
        }

        /// <summary>
        /// Command which will open a note as a ntoe editor
        /// </summary>
        public DelegateCommand<Note> OpenNoteCommand {
            get;
            private set;
        }

        public DelegateCommand<object> DeleteSelectedNoteCommand {
            get;
            private set;
        }

        public DelegateCommand<object> CreateNewNoteCommand {
            get;
            private set;
        }

        private void OpenNote(Note note) {
            documentController.OpenDocument(new NoteEditorModel(note));
        }

        private bool CanDeleteSelectedNote(object arg) {
            return SelectedNote != null;
        }

        private void DeleteSelectedNote(object arg) {
            if (SelectedNote != null) {
                documentController.CloseDocument(new NoteEditorModel(SelectedNote));
                service.DeleteNote(SelectedNote);
                Notes.Remove(SelectedNote);
            }
        }

        private void CreateNewNote(object arg) {
            Note note = service.CreateNewNote();
            Notes.Add(note);
            documentController.OpenDocument(new NoteEditorModel(note));
        }


        private void LoadAllNotes() {
            IEnumerable<Note> res = service.GetAllNotes();
            foreach (Note note in res) {
                Notes.Add(note);
            }
        }

        public ObservableCollection<Note> Notes {
            get;
            private set;
        }

        public Note SelectedNote {
            get { return selectedNote; }
            set {
                if (!Object.Equals(selectedNote, value)) {
                    selectedNote = value;
                    OnPropertyChanged("SelectedNote");
                    DeleteSelectedNoteCommand.RaiseCanExecuteChanged();
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

