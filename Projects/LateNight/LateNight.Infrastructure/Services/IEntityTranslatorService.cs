/*
 * IEntityTranslatorService.cs    7/2/2008 16:02:39
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
    /// Service to manage <see cref="IEntityTranslator"/> instances.
    /// </summary>
    public interface IEntityTranslatorService {

        bool CanTranslate(Type targetType, Type sourceType);

        /// <summary>
        /// Determines if a given type can be translated to a target type.
        /// </summary>
        /// <typeparam name="TTarget">
        /// Target type.
        /// </typeparam>
        /// <typeparam name="TSource">
        /// Source type.
        /// </typeparam>
        /// <returns>
        /// True if a translator exists for the provided types.
        /// </returns>
        bool CanTranslate<TTarget, TSource>();

        /// <summary>
        /// Translate a source object to a target type.
        /// </summary>
        /// <param name="targetType">Target type to translate to.</param>
        /// <param name="source">Source object to be translated.</param>
        /// <returns>
        /// New object translated from <c>source</c> to <c>targetType</c>.
        /// </returns>
        object Translate(Type targetType, object source);

        /// <summary>
        /// Translate an object to a desired type.
        /// </summary>
        /// <typeparam name="TTarget">
        /// Type to translate object to.
        /// </typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TTarget Translate<TTarget>(object source);

        /// <summary>
        /// Register a translator with the translator service.
        /// </summary>
        /// <param name="translator">Translator to register.</param>
        void RegisterEntityTranslator(IEntityTranslator translator);

        /// <summary>
        /// Remove a translator from the service.
        /// </summary>
        /// <param name="translator">Translator to remove.</param>
        void RemoveEntityTranslator(IEntityTranslator translator);

    }

}
