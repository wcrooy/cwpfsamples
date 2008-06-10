/*
 * IMessageService.cs    6/3/2008 5:22:32 PM
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


namespace JohnSands.ProductPrism.Infrastructure.Services {

    /// <summary>
    /// A service contract that allows modules to present messages to the user.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Basic implementations should provide <see cref="System.Windows.MessageBox"/>
    /// equivelants.
    /// </para>
    /// <para>
    /// It is encouraged for module writers to use this service as opposed to
    /// manually displaying messages as this allows for the application
    /// configured implementation to be styled.
    /// </para>
    /// </remarks>
    public interface IMessageService {

        /// <summary>
        /// Show a message to the user.
        /// </summary>
        /// <param name="message">Message to be shown.</param>
        void ShowMessage(string message);

    }

}

