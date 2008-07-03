/*
 * IEntityTranslator.cs    7/2/2008 16:02:39
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
    /// Entity translator contract to be consumed by
    /// <see cref="IEntityTranslatorService"/> implementations.
    /// </summary>
    public interface IEntityTranslator {

        /// <summary>
        /// Determines if the source and target types can be translated.
        /// </summary>
        /// <param name="targetType">Target type.</param>
        /// <param name="sourceType">Source type.</param>
        /// <returns>
        /// True if the source and target types can be translated between
        /// each other.
        /// </returns>
        bool CanTranslate(Type targetType, Type sourceType);

        /// <summary>
        /// Determines if the source and target types can be translated.
        /// </summary>
        /// <typeparam name="TTarget">Target type.</typeparam>
        /// <typeparam name="TSource">Source type.</typeparam>
        /// <returns>
        /// True if the source and target types can be translated between
        /// each other.
        /// </returns>
        bool CanTranslate<TTarget, TSource>();

        /// <summary>
        /// Performs translation of a target type from a source type.
        /// </summary>
        /// <param name="service">
        /// Service this translator is registered in.
        /// </param>
        /// <param name="targetType">
        /// Type to translate to.
        /// </param>
        /// <param name="source">
        /// Object to be translated.
        /// </param>
        /// <returns>
        /// Resulting object translated to a type of <c>targetType</c>.
        /// </returns>
        object Translate(
            IEntityTranslatorService service,
            Type targetType,
            object source);

        /// <summary>
        /// Performs translation of a target type from a source type.
        /// </summary>
        /// <typeparam name="TTarget">
        /// Type to translate to.
        /// </typeparam>
        /// <param name="service">
        /// Service this translator is registered in.
        /// </param>
        /// <param name="source">
        /// Object to be translated.
        /// </param>
        /// <returns>
        /// Resulting object translated to a type of <c>TTarget</c>.
        /// </returns>
        TTarget Translate<TTarget>(
            IEntityTranslatorService service,
            object source);

    }

}
