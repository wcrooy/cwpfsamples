using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Security.Principal;
using System.Threading;
using System.Windows;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using BrettRyan.LateNight.Services;


namespace BrettRyan.LateNight {

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        /// <summary>
        /// Creates a new instance of <c>App</c>
        /// </summary>
        public App() {
        }

        protected IUnityContainer GetContainer() {
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section
                = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (section != null && section.Containers.Default != null) {
                section.Containers.Default.Configure(container);           
            }
            return container;
        }

        protected override void OnStartup(StartupEventArgs e) {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            IUnityContainer container;
            try {
                container = GetContainer();
            } catch (TypeLoadException ex) {
                MessageBox.Show(
                    "There was an error with your application configuration "
                    + "file, this may be due to an error in your unity "
                    + "configuration if it has been specified.\n\n"
                    + ex.Message,
                    "Type Load Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error
                    );
                Shutdown(1);
                return;
            }

            try {
                ISecurityService secSvc = container.Resolve<ISecurityService>();
                IPrincipal p = null;
                try {
                    p = secSvc.GetPrincipal();
                } catch (InvalidCredentialException) {
                    MessageBox.Show(
                        "Invalid username and/or password entered",
                        "Invalid Credentials",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                } catch (AuthenticationException) {
                    MessageBox.Show(
                        "The security service has determined that you are not "
                        + "authorized to use this application",
                        "Not Authorized",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (p == null) {
                    Shutdown(1);
                } else {
                    Thread.CurrentPrincipal = p;
                    StartupContainer(container);
                    base.OnStartup(e);
                }
            } catch (ResolutionFailedException ex) {
                MessageBox.Show(
                    "You do not have a security service mapped in the"
                    + " application configuration file or there is an error"
                    + " with its configuration.\n\n"
                    + "Refer to the program documentation to configure"
                    + "a unity type mapping.\n\n" + ex.Message,
                    "No Security Service Defined",
                    MessageBoxButton.OK, MessageBoxImage.Error
                    );
                Shutdown(1);
            }
        }

        private void StartupContainer(IUnityContainer container) {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            LateNightSplash splash = new LateNightSplash();
            splash.DataContext = new LateNightSplashModel();
            splash.Show();
            Application.Current.MainWindow = null;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            LateNightBootstrapper bootStrapper = new LateNightBootstrapper(container);
            bootStrapper.Run();

            splash.Close();
        }

    }

}
