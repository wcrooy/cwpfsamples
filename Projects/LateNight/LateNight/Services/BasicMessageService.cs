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
    ///
    /// </summary>
    public class BasicMessageService : IMessageService {

        /// <summary>
        /// Creates a new instance of <c>MessageService</c>.
        /// </summary>
        public BasicMessageService() {
        }


        #region IMessageService Members

        public void ShowMessage(string message) {
            ShowMessage(message, String.Empty);
        }

        public void ShowMessage(string message, string caption) {
            ShowMessage(message, caption, MessageBoxImage.Information);
        }

        public void ShowMessage(string message, MessageBoxImage icon) {
            ShowMessage(message, String.Empty, icon);
        }

        public void ShowMessage(string message, string caption, MessageBoxImage icon) {
            MessageBox.Show(message, caption, MessageBoxButton.OK, icon);
        }

        #endregion
    }

}
