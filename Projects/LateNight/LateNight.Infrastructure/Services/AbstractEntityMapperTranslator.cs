/*
 * AbstractEntityMapperTranslator.cs    7/2/2008 16:47:04
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
    /// Represents the base translator mapping service entities to
    /// application domain entities.
    /// </summary>
    public abstract class AbstractEntityMapperTranslator<TBusinessEntity, TServiceEntity>
        : AbstractEntityTranslator {

        /// <summary>
        /// Returns true if the target type and source type match the generic
        /// type definitions.
        /// </summary>
        /// <remarks>
        /// Source and target types are reverse checked if they are not found
        /// explicitly.
        /// </remarks>
        /// <param name="targetType">Target type.</param>
        /// <param name="sourceType">Source type.</param>
        /// <returns></returns>
        public override bool CanTranslate(Type targetType, Type sourceType) {
            return
                (targetType == typeof(TBusinessEntity)&&
                sourceType == typeof(TServiceEntity))
                ||
                (targetType == typeof(TServiceEntity) &&
                sourceType == typeof(TBusinessEntity));
        }

        /// <summary>
        /// Perform object translation.
        /// </summary>
        /// <param name="service">Parent service.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="source">Source object.</param>
        /// <returns>
        /// Object with entity translation performed.
        /// </returns>
        public override object Translate(
            IEntityTranslatorService service, Type targetType, object source) {
            if (targetType == typeof(TBusinessEntity))
                return ServiceToBusiness(service, (TServiceEntity)source);
            if (targetType == typeof(TServiceEntity))
                return BusinessToService(service, (TBusinessEntity)source);

            throw new EntityTranslatorException(
                "Translator is not registered for target type: " + targetType.ToString());
        }

        /// <summary>
        /// Translates a business object to a service object.
        /// </summary>
        /// <param name="service">Service containing this translator.</param>
        /// <param name="value">Business object to translate.</param>
        /// <returns>Resulting service object.</returns>
        protected abstract TServiceEntity BusinessToService(
            IEntityTranslatorService service, TBusinessEntity value);

        /// <summary>
        /// Translates a service object to a business object.
        /// </summary>
        /// <param name="service">Service containing this translator.</param>
        /// <param name="value">Service object to translate.</param>
        /// <returns>Resulting business object.</returns>
        protected abstract TBusinessEntity ServiceToBusiness(
            IEntityTranslatorService service, TServiceEntity value);

    }

}

