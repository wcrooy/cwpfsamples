/*
 * IDocumentController.cs    6/14/2008 5:43:58 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms.
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.Practices.Composite.Events;


namespace BrettRyan.LateNight.DocumentModel {

    /// <summary>
    /// Document controller interface.
    /// </summary>
    public interface IDocumentController {

        /// <summary>
        /// Fired prior to a document being closed.
        /// </summary>
        event EventHandler<DocumentClosingEventArgs> DocumentClosing;

        /// <summary>
        /// Fired after a document has been cloed.
        /// </summary>
        event EventHandler<DataEventArgs<AbstractDocument>> DocumentClosed;

        /// <summary>
        /// Fired after a document has been opened.
        /// </summary>
        event EventHandler<DataEventArgs<AbstractDocument>> DocumentOpened;

        /// <summary>
        /// List of documents this controller is managing.
        /// </summary>
        /// <remarks>
        /// It is advised not to add/remove to this collection directly as you
        /// may not be dereferencing the
        /// <see cref="IDocumentController.CurrentDocument"/> property.
        /// </remarks>
        ObservableCollection<AbstractDocument> Documents {
            get;
        }

        /// <summary>
        /// Current document that has been selected.
        /// </summary>
        /// <remarks>
        /// This controller interface only supports a single document being
        /// active at one point in time.
        /// </remarks>
        AbstractDocument CurrentDocument {
            get;
            set;
        }

        /// <summary>
        /// Open a document into the view.
        /// </summary>
        /// <param name="document">Document to be opened.</param>
        void OpenDocument(AbstractDocument document);

        /// <summary>
        /// Remove a document from the view.
        /// </summary>
        /// <param name="document">Document to be removed.</param>
        void CloseDocument(AbstractDocument document);

    }

}
