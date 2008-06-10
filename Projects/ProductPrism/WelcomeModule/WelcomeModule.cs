/*
 * WelcomeModule.cs    6/3/2008 4:48:58 PM
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
using JohnSands.ProductPrism.Infrastructure.Services;


namespace JohnSands.ProductPrism.WelcomeModule {

    /// <summary>
    /// Module used to display a simple welcome screen.
    /// </summary>
    public class WelcomeModule : IModule {

        //private readonly IDocumentController documentController;
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        private readonly WelcomeModuleController controller;

        /// <summary>
        /// Creates a new instance of <c>WelcomeModule</c>.
        /// </summary>
        public WelcomeModule(
            IUnityContainer container,
            IRegionManager regionManager
            ) {
            this.container = container;
            this.regionManager = regionManager;
            controller = new WelcomeModuleController(container);
        }


        #region IModule Members

        public void Initialize() {
            container.RegisterInstance<WelcomeModuleController>(controller);

            IRegion x = regionManager.GetRegion(RegionNames.ViewMenu);
            if (x != null) {
                MenuItem mi = new MenuItem();
                mi.Header = "Welcome Screen";
                x.Add(mi);

                MenuItem sh = new MenuItem();
                sh.Header = "_Show";
                sh.Click += new System.Windows.RoutedEventHandler(sh_Click);
                mi.Items.Add(sh);

                //MenuItem als = new MenuItem();
                //als.Header = "Show _on startup";
                //mi.Items.Add(als);
            }

            if (Properties.Settings.Default.ShowWelcomeScreen) {
                controller.ShowWelcomeCommand.Execute(null);
            } else {
                IMessageService msgSvc = container.Resolve<IMessageService>();
                msgSvc.ShowMessage(
                    "This is a message to show you have disabled the welcome"
                    + " screen.\n"
                    + "Since there is not options dialog implementation yet,"
                    + " this message\nwill continue to appear."
                    );
            }
        }

        void sh_Click(object sender, System.Windows.RoutedEventArgs e) {
            controller.ShowWelcomeCommand.Execute(null);
        }

        #endregion

    }

}
