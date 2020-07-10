using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IAuthorizationService
    {
        Task<BaseResult<IUser>> AuthorizeAsync(LoginUser loginUser);
    }
}