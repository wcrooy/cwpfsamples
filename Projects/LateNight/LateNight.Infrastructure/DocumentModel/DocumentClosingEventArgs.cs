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
    ///
    /// </summary>
    public class DocumentClosingEventArgs : CancelEventArgs {

        /// <summary>
        /// Creates a new instance of <c>DocumentClosingEventArgs</c>.
        /// </summary>
        public DocumentClosingEventArgs(AbstractDocument doc)
            : this(doc, false) {
        }

        public DocumentClosingEventArgs(AbstractDocument doc, bool cancel)
            : base(cancel) {
            this.Document = doc;
        }

        public AbstractDocument Document {
            get;
            private set;
        }

    }

}

