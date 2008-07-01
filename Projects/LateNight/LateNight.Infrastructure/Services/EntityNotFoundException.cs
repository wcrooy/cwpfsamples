/*
 * EntityNotFoundException.cs    6/30/2008 3:49:37 PM
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
        public EntityNotFoundException(Type entityType, string message)
            : base(message) {
            EntityType = entityType.Name;
        }

        public EntityNotFoundException(
            SerializationInfo info, StreamingContext context)
            : base(info, context) {
            EntityType = info.GetString("EntityType");
        }

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

