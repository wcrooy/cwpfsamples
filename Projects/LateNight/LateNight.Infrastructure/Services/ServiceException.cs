/*
 * ServiceException.cs    6/30/2008 6:54:09 PM
 *
 * Copyright 2008  All rights reserved.
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
    ///
    /// </summary>
    [Serializable]
    public class ServiceException : Exception, ISerializable {

        /// <summary>
        /// Creates a new instance of <c>ServiceException</c>.
        /// </summary>
        public ServiceException()
            : base() {
        }

        public ServiceException(string message)
            : base(message) {
        }

        public ServiceException(string message, Exception innerException)
            : base(message, innerException) {
        }

        public ServiceException(SerializationInfo info, StreamingContext ctx)
            : base(info, ctx) {
        }

    }

}

