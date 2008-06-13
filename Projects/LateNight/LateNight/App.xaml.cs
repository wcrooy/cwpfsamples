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
#if DEBUG
            logon.HintVisible = true;
#endif
            bool? res = logon.ShowDialog();
            if (!res ?? true) {
                Shutdown(1);
            } else if (Authenticate(logon.UserName, logon.Password)) {
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                LateNightBootstrapper bootStrapper = new LateNightBootstrapper();
                bootStrapper.Run();
            } else {
                MessageBox.Show(
                    "Application is exiting due to invalid credentials",
                    "Application Exit",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Shutdown(1);
            }
        }

    }

}
