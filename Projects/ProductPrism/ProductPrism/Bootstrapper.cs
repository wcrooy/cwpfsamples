/*
 * Bootstrapper.cs    6/3/2008 2:59:56 PM
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
using System.Windows;

using Prism.Interfaces;
using Prism.Services;
using Prism.UnityContainerAdapter;

using JohnSands.ProductPrism.Infrastructure;
using JohnSands.ProductPrism.Infrastructure.Constants;
using JohnSands.ProductPrism.Infrastructure.Services;
using JohnSands.ProductPrism.Services;


namespace JohnSands.ProductPrism {

    /// <summary>
    /// Basic prism bootstrapper implementation.
    /// </summary>
    internal sealed class Bootstrapper : UnityPrismBootstrapper {

        /// <summary>
        /// Creates a new instance of <c>Bootstrapper</c>.
        /// </summary>
        public Bootstrapper() {
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
            Container.RegisterInstance<IMessageService>(new MessageService());
            Container.RegisterInstance<IDocumentController>(
                ControllerNames.ExplorerController, new DocumentController());
            Container.RegisterInstance<IDocumentController>(
                ControllerNames.DocumentController, new DocumentController());
        }

        /// <summary>
        /// Creates the application shell.
        /// </summary>
        /// <remarks>
        /// The shell will be shown before it is returned.
        /// </remarks>
        /// <returns>Application main window.</returns>
        protected override DependencyObject CreateShell() {
            Shell shell = Container.Resolve<Shell>();
            shell.DataContext = new ShellModel(Container);
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
