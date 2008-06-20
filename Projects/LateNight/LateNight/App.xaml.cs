using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;


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

        protected override void OnStartup(StartupEventArgs e) {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            LogOnScreen logon = new LogOnScreen();
#if DEBUG
            logon.HintVisible = true;
#endif
            bool? res = logon.ShowDialog();
            if (!res ?? true) {
                Shutdown(1);
            } else if (Authenticate(logon.UserName, logon.Password)) {
                StartupContainer();
            } else {
                MessageBox.Show(
                    "Application is exiting due to invalid credentials",
                    "Application Exit",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Shutdown(1);
            }

            base.OnStartup(e);
        }

        /// <summary>
        /// Tests if a user and password can be authorized.
        /// </summary>
        /// <remarks>
        /// This is a dummy method used only for demonstration purposes.
        /// </remarks>
        /// <param name="user">Username.</param>
        /// <param name="pass">Password.</param>
        /// <returns>
        /// <c>True</c> if user = "admin" and pass = "pass"
        /// </returns>
        private bool Authenticate(string user, string pass) {
            return
                "admin".Equals(user) &&
                "pass".Equals(pass);
        }

        private void StartupContainer() {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            LateNightSplash splash = new LateNightSplash();
            splash.DataContext = new LateNightSplashModel();
            splash.Show();
            Application.Current.MainWindow = null;

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            LateNightBootstrapper bootStrapper = new LateNightBootstrapper();
            bootStrapper.Run();

            splash.Close();
        }

    }

}
