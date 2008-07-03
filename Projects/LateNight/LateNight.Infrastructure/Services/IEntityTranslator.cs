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
    ///
    /// </summary>
    public interface IEntityTranslator {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        bool CanTranslate(Type targetType, Type sourceType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        bool CanTranslate<TTarget, TSource>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="targetType"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        object Translate(IEntityTranslatorService service, Type targetType, object source);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="service"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        TTarget Translate<TTarget>(IEntityTranslatorService service, object source);

    }

}
