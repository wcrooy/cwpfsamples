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
using System.Windows.Threading;
using System.Windows;

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;
using Microsoft.Practices.Unity;

using BrettRyan.LateNight.Constants;
using BrettRyan.LateNight.DocumentModel;
using BrettRyan.LateNight.Services;


namespace BrettRyan.LateNight {

    /// <summary>
    ///
    /// </summary>
    internal class LateNightBootstrapper : UnityBootstrapper {

        /// <summary>
        /// Creates a new instance of <c>LateNightBootstrapper</c>.
        /// </summary>
        public LateNightBootstrapper() {
            App.Current.SessionEnding += new SessionEndingCancelEventHandler(DoSessionEnding);
            //App.Current.DispatcherUnhandledException +=
            //    new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(DoUnhandledException);
        }

        private void DoUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            // TODO : Place logic in here that allows modules to alert the
            //        user of a potential loss of data.
        }

        private void DoSessionEnding(object sender, SessionEndingCancelEventArgs e) {
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
            Container.RegisterType<IMessageService, BasicMessageService>();

            // TODO: Create a new document manager that manages multiple
            //       document controller instances. I have an idea of using
            //       a tree of controllers where controllers may be grouped
            //       together. This concept is for a visual studio style
            //       window docking mechanism.
            Container.RegisterInstance<IDocumentController>(
                ControllerNames.DocumentController,
                new DocumentController());
            Container.RegisterInstance<IDocumentController>(
                ControllerNames.SystemDocumentController,
                new DocumentController());
        }

        protected override DependencyObject CreateShell() {
            LateNightShellModel model = Container.Resolve<LateNightShellModel>();
            LateNightShell shell = new LateNightShell(model);
            Container.RegisterInstance<LateNightShell>(shell);
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
