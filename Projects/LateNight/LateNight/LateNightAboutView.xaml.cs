/*
 * LateNightAboutView.cs    6/15/2008 3:36:44 AM
 *
 * Copyright 2008 John Sands (Australia) Ltd. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
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

using BrettRyan.LateNight.Infrastructure;


namespace BrettRyan.LateNight {

    /// <summary>
    /// Interaction logic for LateNightAboutView.xaml
    /// </summary>
    public partial class LateNightAboutView : Window {

        /// <summary>
        /// Creates a new instance of <c>LateNightAboutView</c>.
        /// </summary>
        public LateNightAboutView() {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

    }

}
