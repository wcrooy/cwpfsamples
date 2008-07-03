/*
 * DocumentClosingEventArgs.cs    6/16/2008 6:32:00 PM
 *
 * Copyright 2008  All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace BrettRyan.LateNight.DocumentModel {

    /// <summary>
    /// Arguments used when a document is closing.
    /// </summary>
    /// <remarks>
    /// This is a cancellable argument which allows listeners to cancel the
    /// calling event.
    /// </remarks>
    /// <seealso cref="AbstractDocument"/>
    /// <seealso cref="IDocumentController"/>
    /// <seealso cref="DocumentController"/>
    /// <seealso cref="System.ComponentModel.CancelEventArgs"/>
    public class DocumentClosingEventArgs : CancelEventArgs {

        /// <summary>
        /// Creates a new instance of <c>DocumentClosingEventArgs</c>.
        /// </summary>
        /// <param name="doc">Document that is being closed.</param>
        public DocumentClosingEventArgs(AbstractDocument doc)
            : this(doc, false) {
        }

        /// <summary>
        /// Creates a new instance of <c>DocumentClosingEventArgs</c>.
        /// </summary>
        /// <param name="doc">Document that is being closed.</param>
        /// <param name="cancel">
        /// True to default the <see cref="Cancel"/> state.
        /// </param>
        public DocumentClosingEventArgs(AbstractDocument doc, bool cancel)
            : base(cancel) {
            this.Document = doc;
        }

        /// <summary>
        /// Document being closed.
        /// </summary>
        public AbstractDocument Document {
            get;
            private set;
        }

    }

}

