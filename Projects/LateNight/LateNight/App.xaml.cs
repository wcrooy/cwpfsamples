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

        private bool Authenticate(string user, string pass) {
            return
                "admin".Equals(user) &&
                "pass".Equals(pass);
        }

        public App() {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            LogOnScreen logon = new LogOnScreen();
            bool? res = logon.ShowDialog();
            //Application.Current.MainWindow = null;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            MessageBox.Show(Application.Current.MainWindow.ToString());
            if (res.HasValue && res.Value && Authenticate(logon.UserName, logon.Password)) {
                LateNightBootstrapper bootStrapper = new LateNightBootstrapper();
                bootStrapper.Run();
            } else {
                MessageBox.Show(
                    "Application is exiting due to invalid credentials",
                    "Application Exit",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Application.Current.Shutdown(1);
            }
        }

    }

}
