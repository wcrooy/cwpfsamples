/*
 * LateNightBootstrapper.cs    6/13/2008 4:47:44 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms.
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;
using Microsoft.Practices.Unity;

using BrettRyan.LateNight.Constants;
using BrettRyan.LateNight.DocumentModel;


namespace BrettRyan.LateNight {

    /// <summary>
    ///
    /// </summary>
    internal class LateNightBootstrapper : UnityBootstrapper {

        /// <summary>
        /// Creates a new instance of <c>LateNightBootstrapper</c>.
        /// </summary>
        public LateNightBootstrapper() {
        }
        
        /// <summary>
        /// Configures the container.
        /// </summary>
        /// <remarks>
        /// Currently this just registers global services required for the
        /// application.
        /// </remarks>
        protected override void ConfigureContainer() {
            RegisterServices();

            base.ConfigureContainer();
        }

        private void RegisterServices() {
            // This will register the type as a singleton instance.
            Container.RegisterType<LateNightShellModel>(
                new ContainerControlledLifetimeManager());

            Container.RegisterInstance<IDocumentController>(
                ControllerNames.DocumentController, new DocumentController());
        }

        protected override DependencyObject CreateShell() {
            LateNightShellModel model = Container.Resolve<LateNightShellModel>();
            LateNightShell shell = new LateNightShell(model);
            shell.DataContext = model;
            shell.Show();
            return shell;
        }

        /// <summary>
        /// Returns the configured module enumerator.
        /// </summary>
        /// <remarks>
        /// Currently this is staticly built to return the application
        /// configuration implementation provided by
        /// <see cref="ConfigurationStore"/>.
        /// </remarks>
        /// <returns>Application module enumerator.</returns>
        protected override IModuleEnumerator GetModuleEnumerator() {
            // This will use a default ConfigurationStore, see the docs for
            // other module enumerators.
            ConfigurationStore store = new ConfigurationStore();
            return new ConfigurationModuleEnumerator(store);
        }

    }

}
