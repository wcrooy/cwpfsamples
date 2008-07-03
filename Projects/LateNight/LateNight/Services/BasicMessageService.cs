/*
 * BasicMessageService.cs    6/17/2008 6:38:10 AM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


namespace BrettRyan.LateNight.Services {

    /// <summary>
    /// A simple <see cref="IMessageService"/> implementation that wraps
    /// calls arround <see cref="System.Windows.MessageBox.Show"/>.
    /// </summary>
    public class BasicMessageService : IMessageService {

        /// <summary>
        /// Creates a new instance of <c>MessageService</c>.
        /// </summary>
        public BasicMessageService() {
        }


        #region IMessageService Members

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to show.</param>
        public void ShowMessage(string message) {
            ShowMessage(message, String.Empty);
        }

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="caption">Caption for the message window.</param>
        public void ShowMessage(string message, string caption) {
            ShowMessage(message, caption, MessageBoxImage.Information);
        }

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="icon">Icon for the window.</param>
        public void ShowMessage(string message, MessageBoxImage icon) {
            ShowMessage(message, String.Empty, icon);
        }

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="caption">Caption for the message window.</param>
        /// <param name="icon">Icon for the window.</param>
        public void ShowMessage(string message, string caption, MessageBoxImage icon) {
            MessageBox.Show(message, caption, MessageBoxButton.OK, icon);
        }

        #endregion

    }

}
