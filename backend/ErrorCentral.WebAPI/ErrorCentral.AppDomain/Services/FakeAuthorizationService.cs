using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using System;

namespace ErrorCentral.AppDomain.Services
{
    public sealed class FakeAuthorizationService : IAuthorizationService
    {
        public BaseResult<IUser> Authorize(LoginUser loginUser)
        {
            var loginOrEmail = loginUser?.LoginOrEmail ?? "";
            var password = loginUser?.Password ?? "";

            var result = new BaseResult<IUser>();

            if (loginOrEmail == "fsl" && password == "1234")
            {
                result.Success = true;
                result.Message = "User authorized!";
                result.Data = new User
                {
                    Id = 666,
                    Name = "Name test",
                    Email = loginOrEmail
                };
            }
            else
            {
                result.Success = false;
                result.Message = "Not authorized!";
            }

            return result;
        }
    }
}
