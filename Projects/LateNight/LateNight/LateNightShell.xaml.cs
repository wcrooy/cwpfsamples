/*
 * LateNightShell.cs    6/13/2008 4:59:03 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms.
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


namespace BrettRyan.LateNight {

    /// <summary>
    /// Interaction logic for LateNightShell.xaml
    /// </summary>
    public partial class LateNightShell : Window {

        /// <summary>
        /// Creates a new instance of <c>LateNightShell</c>.
        /// </summary>
        public LateNightShell() {
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
