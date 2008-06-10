/*
 * IDocumentController.cs    6/8/2008 7:20:19 PM
 *
 * Copyright 2008 John Sands (Australia) Ltd. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace JohnSands.ProductPrism.Infrastructure {

    /// <summary>
    /// Controller interface for managing documents.
    /// </summary>
    /// <seealso cref="AbstractDocument"/>
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
