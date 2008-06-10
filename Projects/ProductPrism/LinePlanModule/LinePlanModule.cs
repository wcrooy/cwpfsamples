/*
 * LinePlanModule.cs    6/5/2008 4:06:42 PM
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
using System.Windows.Controls;

using Microsoft.Practices.Unity;
using Prism.Interfaces;

using JohnSands.ProductPrism.Infrastructure;
using JohnSands.ProductPrism.Infrastructure.Constants;
using JohnSands.ProductPrism.LinePlanModule.Services;
using JohnSands.ProductPrism.LinePlanModule.Views;


namespace JohnSands.ProductPrism.LinePlanModule {

    /// <summary>
    ///
    /// </summary>
    public class LinePlanModule : IModule {

        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        private readonly IDocumentController explorerController;

        /// <summary>
        /// Creates a new instance of <c>LinePlanModule</c>.
        /// </summary>
        public LinePlanModule(
            IUnityContainer container,
            IRegionManager regionManager
            ) {
            this.container = container;
            this.regionManager = regionManager;
            explorerController = container.Resolve<IDocumentController>(
                ControllerNames.ExplorerController);
        }

        
        #region IModule Members

        public void Initialize() {
            container.RegisterType<ILinePlanService, LinePlanService>(
                // This will register the type as a singleton instance.
                new ContainerControlledLifetimeManager());

            LinePlanExplorerModel model = new LinePlanExplorerModel(container);
            explorerController.OpenDocument(model);
        }

        #endregion

    }

}
