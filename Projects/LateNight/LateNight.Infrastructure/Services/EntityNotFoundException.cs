/*
 * EntityNotFoundException.cs    6/30/2008 3:49:37 PM
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
    /// Exception to be thrown when an entity could not be found.
    /// </summary>
    /// <remarks>
    /// This may inherit from <see cref="ServiceException"/> in the future,
    /// though it may not be a service that throws this exception, even if
    /// 99.99% of the time it will be a service throwing this exception.
    /// </remarks>
    [Serializable]
    public class EntityNotFoundException : Exception, ISerializable {

        /// <summary>
        /// Creates a new instance of <c>EntityNotFoundException</c>.
        /// </summary>
        public EntityNotFoundException(Type entityType)
            : base() {
            EntityType = entityType.Name;
        }

        /// <summary>
        /// Creates a new instance of <c>EntityNotFoundException</c>.
        /// </summary>
        /// <param name="entityType">Entity type for this exception.</param>
        /// <param name="message">Reason for the exception.</param>
        public EntityNotFoundException(Type entityType, string message)
            : base(message) {
            EntityType = entityType.Name;
        }

        /// <summary>
        /// Create a new instance of <c>EntityNotFoundException</c> from a
        /// serialized context.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        public EntityNotFoundException(
            SerializationInfo info, StreamingContext context)
            : base(info, context) {
            EntityType = info.GetString("EntityType");
        }

        /// <summary>
        /// Adds the <see cref="EntityType"/> property to the info.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        public override void GetObjectData(
            SerializationInfo info, StreamingContext context) {
            info.AddValue("EntityType", EntityType);
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Full type name of entity.
        /// </summary>
        public string EntityType {
            get;
            private set;
        }

    }

}
