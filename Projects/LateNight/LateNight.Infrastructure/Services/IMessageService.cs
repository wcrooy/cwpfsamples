/*
 * IMessageService.cs    6/17/2008 6:32:43 AM
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
    /// A messaging contract for modules to be able to communicate with the
    /// user.
    /// </summary>
    /// <remarks>
    /// Implementors may simply wrapp up System.Windows.MessageBox calls.
    /// </remarks>
    public interface IMessageService {

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to show.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="caption">Caption for the message window.</param>
        void ShowMessage(string message, string caption);

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="icon">Icon for the window.</param>
        void ShowMessage(string message, MessageBoxImage icon);

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="caption">Caption for the message window.</param>
        /// <param name="icon">Icon for the window.</param>
        void ShowMessage(
            string message,
            string caption,
            MessageBoxImage icon);

    }

}
