﻿using BLL.Models.Account;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for user registration and logon
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Execute user registration
        /// </summary>
        /// <param name="user">Register model</param>
        /// <returns>Result of action</returns>
        Task<IdentityResult> Register(Register user);

        /// <summary>
        /// Execute user logon
        /// </summary>
        /// <param name="logon">Logon model</param>
        /// <returns>User model</returns>
        Task<UserModel> Logon(Logon logon);
    }
}
