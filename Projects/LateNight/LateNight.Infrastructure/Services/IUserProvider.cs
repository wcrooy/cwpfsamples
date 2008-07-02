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
    ///
    /// </summary>
    public interface IUserProvider {

        string ApplicationRole { get; }

        bool IsApplicationRoleRequired { get; }

        bool Authenticate(string user, string pass);

        string[] GetRoles(string user);

    }

}

