/*
 * EntityTranslatorService.cs    7/2/2008 15:48:12
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
    public class EntityTranslatorService : IEntityTranslatorService {

        private List<IEntityTranslator> translators;

        /// <summary>
        /// Creates a new instance of <c>EntityTranslatorService</c>.
        /// </summary>
        public EntityTranslatorService() {
            translators = new List<IEntityTranslator>();
        }


        private object TranslateArray(Type targetType, object source) {
            Type targetItemType = targetType.GetElementType();
            Array sourceArray = (Array)source;
            Array result = (Array)Activator.CreateInstance(targetType, sourceArray.Length);
            for (int i = 0; i < sourceArray.Length; i++) {
                object value = sourceArray.GetValue(i);
                if (value != null)
                    result.SetValue(Translate(targetItemType, sourceArray.GetValue(i)), i);
            }
            return result;
        }

        private bool IsArrayConversionPossible(Type targetType, Type sourceType) {
            if (targetType.IsArray && targetType.GetArrayRank() == 1 && sourceType.IsArray && sourceType.GetArrayRank() == 1) {
                return CanTranslate(targetType.GetElementType(), sourceType.GetElementType());
            }
            return false;
        }

        private IEntityTranslator FindTranslator(Type targetType, Type sourceType) {
            IEntityTranslator translator = translators.Find(delegate(IEntityTranslator test) {
                return test.CanTranslate(targetType, sourceType);
            });

            return translator;
        }


        #region IEntityTranslatorService Members

        public bool CanTranslate(Type targetType, Type sourceType) {
            if (targetType == null)
                throw new ArgumentNullException("targetType");
            if (sourceType == null)
                throw new ArgumentNullException("sourceType");

            return IsArrayConversionPossible(targetType, sourceType) || FindTranslator(targetType, sourceType) != null;
        }

        public bool CanTranslate<TTarget, TSource>() {
            return CanTranslate(typeof(TTarget), typeof(TSource));
        }

        public object Translate(Type targetType, object source) {
            if (targetType == null)
                throw new ArgumentNullException("targetType");

            if (source == null) {
                if (targetType.IsArray) {
                    return null;
                } else {
                    throw new ArgumentNullException("source");
                }
            }

            Type sourceType = source.GetType();

            if (IsArrayConversionPossible(targetType, sourceType)) {
                return TranslateArray(targetType, source);
            } else {
                IEntityTranslator translator = FindTranslator(targetType, sourceType);
                if (translator != null) {
                    return translator.Translate(this, targetType, source);
                }
            }

            throw new EntityTranslatorException("No translator is available to perform the operation.");
        }

        public TTarget Translate<TTarget>(object source) {
            return (TTarget)Translate(typeof(TTarget), source);
        }

        public void RegisterEntityTranslator(IEntityTranslator translator) {
            if (translator == null)
                throw new ArgumentNullException("translator");

            translators.Add(translator);
        }


        public void RemoveEntityTranslator(IEntityTranslator translator) {
            if (translator == null)
                throw new ArgumentNullException("translator");

            translators.Remove(translator);
        }

        #endregion

    }

}
