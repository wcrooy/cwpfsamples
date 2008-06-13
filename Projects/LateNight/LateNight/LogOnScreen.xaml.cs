﻿/*
 * LogOnScreen.cs    6/13/2008 6:06:24 PM
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
using System.Windows.Controls;
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
    public partial class LogOnScreen : Window {

        /// <summary>
        /// Creates a new instance of <c>LogOnScreen</c>.
        /// </summary>
        public LogOnScreen() {
            InitializeComponent();
        }

        public string UserName {
            get { return xUsername.Text; }
        }

        public string Password {
            get { return xPassword.Password; }
        }

        private void DoLogonClick(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
            this.Close();
        }

        private void DoCancelClick(object sender, RoutedEventArgs e) {
            this.Close();
        }

    }

}