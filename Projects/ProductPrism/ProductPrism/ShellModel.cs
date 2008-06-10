/*
 * ShellModel.cs    6/5/2008 6:54:33 PM
 *
 * Copyright 2008  All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Unity;

using JohnSands.ProductPrism.Infrastructure;
using JohnSands.ProductPrism.Infrastructure.Constants;
using JohnSands.ProductPrism.Properties;


namespace JohnSands.ProductPrism {

    /// <summary>
    /// Model used for the main visual component (UI).
    /// </summary>
    internal sealed class ShellModel : INotifyPropertyChanged {

        private string versionText;
        private Visibility menuVisibility;

        /// <summary>
        /// Creates a new instance of <c>ShellModel</c>.
        /// </summary>
        public ShellModel(IUnityContainer container) {
            DocumentController = container.Resolve<IDocumentController>(
                ControllerNames.DocumentController);
            ExplorerController = container.Resolve<IDocumentController>(
                ControllerNames.ExplorerController);

            Version ver = VersionHelper.Version;
            if (ver == null) {
                versionText = String.Empty;
            } else {
#if DEBUG
                //versionText = String.Format("v{0}.{1} (Build {2}, Revision {3})",
                //    ver.Major, ver.Minor, ver.Build, ver.Revision);
                versionText = String.Format("v{0}.{1} (Build {2})",
                    ver.Major, ver.Minor,
                    VersionHelper.GetBuildRevisionAsDateTime(ver));
#else
                versionText = String.Format("v{0}.{1}",
                    ver.Major, ver.Minor);
#endif
            }
        }

        /// <summary>
        /// Returns the current instance of the document controller.
        /// </summary>
        public IDocumentController DocumentController {
            get;
            private set;
        }

        /// <summary>
        /// Returns the current instance of the explorer controller.
        /// </summary>
        public IDocumentController ExplorerController {
            get;
            private set;
        }

        /// <summary>
        /// Used by the UI to get the current version number text.
        /// </summary>
        public string ProductVersionText {
            get { return versionText; }
        }

        private Settings Settings {
            get { return Properties.Settings.Default; }
        }

        public Visibility MenuVisibility {
            get {
                return menuVisibility;
            }
            set {
                if (menuVisibility == value) {
                    return;
                }
                menuVisibility = value;
                OnPropertyChanged("MenuVisibility");
            }
        }

        #region INotifyPropertyChanged Members

        private event PropertyChangedEventHandler propertyChangedEvent;

        public event PropertyChangedEventHandler PropertyChanged {
            add { propertyChangedEvent += value; }
            remove { propertyChangedEvent -= value; }
        }

        protected void OnPropertyChanged(string prop) {
            if (propertyChangedEvent != null)
                propertyChangedEvent(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

    }

}
