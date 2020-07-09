using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

public interface IAuthorizationService
{
    Task<BaseResult<IUser>> AuthorizeAsync(
        LoginUser loginUser);
}