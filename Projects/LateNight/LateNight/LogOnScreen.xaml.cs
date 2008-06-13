/*
 * LogOnScreen.cs    6/13/2008 6:06:24 PM
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
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace BrettRyan.LateNight {

    /// <summary>
    /// Interaction logic for LogOnScreen.xaml
    /// </summary>
    public partial class LogOnScreen : Window, INotifyPropertyChanged {

        private Visibility hintVisibility;

        /// <summary>
        /// Creates a new instance of <c>LogOnScreen</c>.
        /// </summary>
        public LogOnScreen() {
            InitializeComponent();

            DataContext = this;
            HintVisibility = Visibility.Hidden;
            xUsername.Focus();
        }

        /// <summary>
        /// Returns the username entered within the UI.
        /// </summary>
        public string UserName {
            get { return xUsername.Text; }
        }

        /// <summary>
        /// Returns the password entered within the UI.
        /// </summary>
        public string Password {
            get { return xPassword.Password; }
        }

        private void DoLogonClick(object sender, RoutedEventArgs e) {
            DialogResult = true;
            Close();
        }

        public bool HintVisible {
            get { return HintVisibility == Visibility.Visible; }
            set {
                if (value) {
                    HintVisibility = Visibility.Visible;
                } else {
                    HintVisibility = Visibility.Hidden;
                }
            }
        }

        public Visibility HintVisibility {
            get { return hintVisibility; }
            set {
                if (value != hintVisibility) {
                    this.hintVisibility = value;
                    OnPropertyChanged("HintVisibility");
                }
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

        private void DoCredentialsFocussed(object sender, RoutedEventArgs e) {
            TextBoxBase tb = sender as TextBoxBase;
            if (tb == null) {
                PasswordBox pwb = sender as PasswordBox;
                pwb.SelectAll();
            } else {
                tb.SelectAll();
            }
        }
    }

}
