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

        void ShowMessage(string message);

        void ShowMessage(string message, string caption);

        void ShowMessage(string message, MessageBoxImage icon);

        void ShowMessage(
            string message,
            string caption,
            MessageBoxImage icon);

    }

}
