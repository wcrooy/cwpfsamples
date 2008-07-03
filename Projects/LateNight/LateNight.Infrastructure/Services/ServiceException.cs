/*
 * ServiceException.cs    6/30/2008 6:54:09 PM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace BrettRyan.LateNight.Services {

    /// <summary>
    /// Base service exception that is advised for service exceptions to
    /// inherit from.
    /// </summary>
    /// <remarks>
    /// It is not required to but is advised that service creators either
    /// throw instances of this exception or derrive custom exceptions from
    /// this exception to assist the container in knowing what class of
    /// exception has occurred.
    /// </remarks>
    [Serializable]
    public class ServiceException : Exception, ISerializable {

        /// <summary>
        /// Creates a new instance of <c>ServiceException</c>.
        /// </summary>
        public ServiceException()
            : base() {
        }

        /// <summary>
        /// Create a new instance of <c>ServiceException</c> with a provided
        /// message.
        /// </summary>
        /// <param name="message">Reason for the exception.</param>
        public ServiceException(string message)
            : base(message) {
        }

        /// <summary>
        /// Create a new isntance of <c>ServiceException</c> wrapping another
        /// exception.
        /// </summary>
        /// <param name="message">Reason for the exception.</param>
        /// <param name="innerException">Parent cause.</param>
        public ServiceException(string message, Exception innerException)
            : base(message, innerException) {
        }

        /// <summary>
        /// Create a new instance of <c>ServiceException</c> from a
        /// serialized context.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="ctx">Streaming context.</param>
        public ServiceException(SerializationInfo info, StreamingContext ctx)
            : base(info, ctx) {
        }

    }

}
