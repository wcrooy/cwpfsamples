/*
 * Shell.cs    6/3/2008 2:56:03 PM
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


namespace JohnSands.ProductPrism {

    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window {

        /// <summary>
        /// Creates a new instance of <c>Shell</c>.
        /// </summary>
        public Shell() {
            InitializeComponent();
        }
        
        private void DoKeyDownHandler(object sender, KeyEventArgs e) {
            if (!xMainMenu.HasItems) {
                return;
            }
            if (xMainMenu.Visibility == Visibility.Visible) {
                return;
            }
            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt) {
                xMainMenu.Visibility = Visibility.Visible;
            }
        }
        
        private void DoKeyUpHandler(object sender, KeyEventArgs e) {
            if (xMainMenu.IsKeyboardFocusWithin) {
                return;
            }
            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt) {
                return;
            }
            xMainMenu.Visibility = Visibility.Collapsed;
        }

        private void DoMenuLostFocus(object sender, DependencyPropertyChangedEventArgs e) {
            if (!xMainMenu.IsKeyboardFocusWithin) {
                if (xMainMenu.Visibility != Visibility.Visible) {
                    return;
                }
                xMainMenu.Visibility = Visibility.Collapsed;
            }
        }

    }

}
