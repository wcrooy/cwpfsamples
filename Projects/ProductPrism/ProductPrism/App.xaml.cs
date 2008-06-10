using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace JohnSands.ProductPrism {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        public App() {
            Bootstrapper bootStrapper = new Bootstrapper();
            bootStrapper.Run();
        }

    }

}
