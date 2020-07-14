using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface ILoggedUserService
    {
        BaseResult<T> GetLoggedUser<T>()
            where T : class, IUser;
    }
}
