/*
 * ISecurityService.cs    7/1/2008 4:37:09 PM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;


namespace BrettRyan.LateNight.Services {

    /// <summary>
    /// Service used at application startup to get the secirity principal.
    /// </summary>
    public interface ISecurityService {

        /// <summary>
        /// Return the principal to be used for the application.
        /// </summary>
        /// <returns>
        /// Principal to be used for the application, null should be returned
        /// if a valid principal could not be found/resolved.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Application will shut down when receiving a null result.
        /// </para>
        /// <para>
        /// Implementors should cache this value so it is always returned for
        /// subsequent calls.
        /// </para>
        /// <para>
        /// Once the application has called this method, the result will be
        /// assigned to <see cref="System.Threading.Thread.CurrentPrincipal"/>.
        /// </para>
        /// </remarks>
        /// <exception cref="System.Security.Authentication.AuthenticationException">
        /// Implementors may throw this exception if the user was denied
        /// access to the application.
        /// </exception>
        /// <exception cref="System.Security.Authentication.InvalidCredentialException">
        /// Implementors may throw this exception if an invalid username or
        /// password was entered.
        /// </exception>
        IPrincipal GetPrincipal();

    }

}

