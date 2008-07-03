/*
 * EntityTranslatorException.cs    7/2/2008 16:02:39
 * 
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Implementation is based from guidance provided in Microsoft patterns &
 * practices - Smart Client Software Factory.
 * 
 * Original copyright notice.
 * ==========================================================================
 * Copyright (C) Microsoft Corporation.  All rights reserved.
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
 * OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE.
 * ==========================================================================
 * The example companies, organizations, products, domain names,
 * e-mail addresses, logos, people, places, and events depicted
 * herein are fictitious.  No association with any real company,
 * organization, product, domain name, email address, logo, person,
 * places, or events is intended or should be inferred.
 * ==========================================================================
 * 
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BrettRyan.LateNight.Services {

    /// <summary>
    /// Exception thrown by <see cref="IEntityTranslator"/> implementations.
    /// </summary>
    [Serializable]
    public class EntityTranslatorException : Exception {

        /// <summary>
        /// Creates a new instance of <c>EntityTranslatorException</c>.
        /// </summary>
        public EntityTranslatorException() : base() { }

        /// <summary>
        /// Creates a new instance of <c>EntityTranslatorException</c> with a
        /// given reason..
        /// </summary>
        /// <param name="message">Reason for the exception.</param>
        public EntityTranslatorException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance of <c>EntityTranslatorException</c> with a.
        /// given reason and originating cause.
        /// </summary>
        /// <param name="message">Reason for the exception.</param>
        /// <param name="innerException">Parent cause.</param>
        public EntityTranslatorException(
            string message,
            Exception innerException)
            : base(message, innerException) { }

    }

}
