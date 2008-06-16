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


namespace BrettRyan.LateNight.DocumentModel {

    public interface IDocumentController {

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
