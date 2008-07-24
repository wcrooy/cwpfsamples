/*
 * StaticSecurityService.cs    7/1/2008 4:37:57 PM
 *
 * Copyright 2008 Brett Ryan. All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Principal;
using System.Text;
using System.Windows;


namespace BrettRyan.LateNight.Services {

    /// <summary>
    /// A simple <see cref="ISecurityService"/> implementation.
    /// </summary>
    public class SimpleSecurityService : ISecurityService {

        private IPrincipal principal;
        private IUserProvider userProvider;

        /// <summary>
        /// Creates a new <c>SimpleSecurityService</c> instance.
        /// </summary>
        /// <param name="userProvider">
        /// Provider to perform authentication and return user roles for
        /// users.
        /// </param>
        public SimpleSecurityService(IUserProvider userProvider) {
            this.userProvider = userProvider;
        }


        #region ISecurityService Members

        /// <summary>
        /// Presents a logon screen which accepts a username/password.
        /// </summary>
        /// <returns></returns>
        public IPrincipal GetPrincipal() {
            if (principal != null) {
                return principal;
            }

            LogOnScreen logon = new LogOnScreen();
#if DEBUG
            logon.HintVisible = true;
#endif
            bool? res = logon.ShowDialog();
            if (!res ?? true) {
                // User clicked cancel.
                return null;
            } else if (userProvider.Authenticate(logon.UserName, logon.Password)) {
                // Credentials were authenticated.
                GenericIdentity ident = new GenericIdentity(logon.UserName);
                principal = new GenericPrincipal(ident, userProvider.GetRoles(logon.UserName));

                if (!principal.IsInRole(userProvider.ApplicationRole)) {
                    throw new AuthenticationException();
                }

                return principal;
            } else {
                // Invalid username/password.
                throw new InvalidCredentialException();
            }
        }

        #endregion

    }

    public class StaticUserProvider : IUserProvider {

        #region IUserProvider Members

        public string ApplicationRole {
            get { return "LateNightAccess"; }
        }

        public bool IsApplicationRoleRequired {
            get { return true; }
        }

        /// <summary>
        /// Tests if a user and password can be authorized.
        /// </summary>
        /// <remarks>
        /// This is a dummy method used only for demonstration purposes.
        /// </remarks>
        /// <param name="user">Username.</param>
        /// <param name="pass">Password.</param>
        /// <returns>
        /// <c>True</c> if user = "admin" and pass = "pass"
        /// </returns>
        public bool Authenticate(string user, string pass) {
            switch (user) {
                case "admin":
                    return String.Equals("pass", pass);
                case "user":
                    return String.Equals("pass", pass);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Get some dummy roles for a provided user.
        /// </summary>
        /// <param name="user">
        /// User name to return roles for.
        /// </param>
        /// <returns>
        /// When <c>admin</c> is provided <c>{ admin, user }</c> will be
        /// returned, otherwise null.
        /// </returns>
        public string[] GetRoles(string user) {
            if ("admin".Equals(user)) {
                return new string[] { "admin", "user", ApplicationRole };
            }
            return null;
        }

        #endregion

    }

}
