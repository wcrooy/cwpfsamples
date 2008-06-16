/*
 * NotesModule.cs    6/16/2008 5:07:47 PM
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

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Unity;


namespace BrettRyan.LateNight.Modules.Notes {

    /// <summary>
    ///
    /// </summary>
    [Module(ModuleName="Late Night Notes Module", StartupLoaded=true)]
    public class NotesModule : IModule {

        private readonly IUnityContainer container;

        /// <summary>
        /// Creates a new instance of <c>NotesModule</c>.
        /// </summary>
        public NotesModule(IUnityContainer container) {
            this.container = container;
        }


        #region IModule Members

        public void Initialize() {
        }

        #endregion
    }

}

