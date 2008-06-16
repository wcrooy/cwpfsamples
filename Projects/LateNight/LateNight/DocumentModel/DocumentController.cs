/*
 * DocumentController.cs    6/14/2008 6:05:01 AM
 *
 * Copyright Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Microsoft.Practices.Composite.Events;


namespace BrettRyan.LateNight.DocumentModel {

    /// <summary>
    /// Document Controller implementation of the
    /// <see cref="BrettRyan.LateNight.DocumentModel.IDocumentController"/>
    /// interface.
    /// </summary>
    public class DocumentController : IDocumentController, INotifyPropertyChanged {

        private AbstractDocument currentDocument;

        /// <summary>
        /// Creates a new instance of <c>AbstractDocumentController</c>.
        /// </summary>
        public DocumentController() {
            Documents = new ObservableCollection<AbstractDocument>();
        }

        #region IDocumentController Members

        /// <summary>
        /// Fired prior to a document being closed.
        /// </summary>
        public event EventHandler<DocumentClosingEventArgs> DocumentClosing;

        /// <summary>
        /// Fired after a document has been cloed.
        /// </summary>
        public event EventHandler<DataEventArgs<AbstractDocument>> DocumentClosed;

        /// <summary>
        /// Fired after a document has been opened.
        /// </summary>
        public event EventHandler<DataEventArgs<AbstractDocument>> DocumentOpened;


        protected void OnDocumentClosing(object sender, DocumentClosingEventArgs args) {
            if (DocumentClosing != null) {
                DocumentClosing(sender, args);
            }
        }

        protected void OnDocumentClosed(object sender, DataEventArgs<AbstractDocument> args) {
            if (DocumentClosed != null) {
                DocumentClosed(sender, args);
            }
        }

        protected void OnDocumentOpened(object sender, DataEventArgs<AbstractDocument> args) {
            if (DocumentOpened != null) {
                DocumentOpened(sender, args);
            }
        }

        /// <summary>
        /// List of documents this controller is managing.
        /// </summary>
        /// <remarks>
        /// It is advised not to add/remove to this collection directly as you
        /// may not be updating the
        /// <see cref="DocumentController.CurrentDocument"/> property.
        /// </remarks>
        public ObservableCollection<AbstractDocument> Documents {
            get;
            private set;
        }

        /// <summary>
        /// Current document that has been selected.
        /// </summary>
        /// <remarks>
        /// This controller interface only supports a single document being
        /// active at one point in time.
        /// </remarks>
        public AbstractDocument CurrentDocument {
            get { return currentDocument; }
            set {
                if (Object.Equals(currentDocument, value)) {
                    return;
                }
                currentDocument = value;
                OnPropertyChanged("CurrentDocument");
            }
        }

        /// <summary>
        /// Open a document into the view.
        /// </summary>
        /// <remarks>
        /// Open does not involve fetching the document, it merely opens the
        /// document into the controller.
        /// </remarks>
        /// <param name="document">Document to be opened.</param>
        public void OpenDocument(AbstractDocument document) {
            if (!Documents.Contains(document)) {
                Documents.Add(document);
            }
            CurrentDocument = document;
            OnDocumentOpened(this, new DataEventArgs<AbstractDocument>(document));
        }

        /// <summary>
        /// Remove a document from the view.
        /// </summary>
        /// Close does not involve saving the document, it merely removes the
        /// document from the controller.
        /// <param name="document">Document to be removed.</param>
        public void CloseDocument(AbstractDocument document) {
            if (Documents.Contains(document)) {
                DocumentClosingEventArgs closeArgs = new DocumentClosingEventArgs(document);

                OnDocumentClosing(this, closeArgs);
                if (closeArgs.Cancel) {
                    //TODO: Work out the best way to handle this.
                    return;
                }

                if (document.Equals(CurrentDocument)) {
                    CurrentDocument = null;
                }
                Documents.Remove(document);
                OnDocumentClosed(this, new DataEventArgs<AbstractDocument>(document));
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Fires when a property change has occured.
        /// </summary>
        /// <see cref="System.ComponentModel.INotifyPropertyChanged"/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fires the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">Property to fire the event for.</param>
        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }

}
