using ErrorCentral.AppDomain.Models;
using System.Collections.Generic;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IUserRepository
    {
        List<User> Get();
        User GetByEmail(string Email);
        User Save(User user);
        User Update(LoginUser user);

    }
}
