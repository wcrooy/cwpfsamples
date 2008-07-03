/*
 * IUserProvider.cs    7/2/2008 2:23:32 PM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BrettRyan.LateNight.Services {

    /// <summary>
    /// Basic security provider contract for use with
    /// <see cref="ISecurityService"/> implementations.
    /// </summary>
    /// <remarks>
    /// It isn't required that a <see cref="ISecurityService"/> use this
    /// contract, this is here as a convenience to help create
    /// implementations.
    /// </remarks>
    public interface IUserProvider {

        /// <summary>
        /// Application role user must be a member of in order to start the
        /// application.
        /// </summary>
        /// <remarks>
        /// If <see cref="IsApplicationRoleRequired"/> is <c>False</c> then
        /// this will be ignored.
        /// </remarks>
        string ApplicationRole { get; }

        /// <summary>
        /// True if the a user must be a member of
        /// <see cref="ApplicationRole"/> to use the application.
        /// </summary>
        bool IsApplicationRoleRequired { get; }

        /// <summary>
        /// Simple authenticate method to test credentials.
        /// </summary>
        /// <param name="user">User to test.</param>
        /// <param name="pass">Password for user.</param>
        /// <returns>True if the authentication was successfull.</returns>
        bool Authenticate(string user, string pass);

        /// <summary>
        /// Get an array of roles user belongs to.
        /// </summary>
        /// <param name="user">User to return roles for.</param>
        /// <returns>Array of roles user belongs to.</returns>
        string[] GetRoles(string user);

    }

}
