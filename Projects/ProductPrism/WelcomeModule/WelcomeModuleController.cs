/*
 * WelcomeModuleController.cs    6/10/2008 2:39:32 AM
 *
 * Copyright 2008 John Sands (Australia) Ltd. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;

using Prism.Commands;

using JohnSands.ProductPrism.Infrastructure;
using JohnSands.ProductPrism.Infrastructure.Constants;


namespace JohnSands.ProductPrism.WelcomeModule {

    /// <summary>
    ///
    /// </summary>
    public class WelcomeModuleController {

        private readonly IDocumentController documentController;

        /// <summary>
        /// Creates a new instance of <c>WelcomeModuleController</c>.
        /// </summary>
        public WelcomeModuleController(IUnityContainer container) {
            this.documentController = container.Resolve<IDocumentController>(
                ControllerNames.DocumentController);
            ShowWelcomeCommand = new DelegateCommand<object>(DoShowWelcome);
        }

        public DelegateCommand<object> ShowWelcomeCommand {
            get;
            private set;
        }

        private void DoShowWelcome(object obj) {
            documentController.OpenDocument(new WelcomeModel());
        }

    }

}
