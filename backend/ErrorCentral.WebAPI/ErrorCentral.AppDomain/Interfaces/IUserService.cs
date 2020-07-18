﻿using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IUserService
    {
        BaseResult<IUser> Authorize(LoginUser loginUser);
        List<User> Get();
        User GetByEmail(string Email);
        User Save(User user);
        User Update(User user);
    }
}
