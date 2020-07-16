using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IUserService
    {
        List<User> Get();
        User GetByEmail(string Email);
        User Save(User user);
        User Update(User user);
    }
}
