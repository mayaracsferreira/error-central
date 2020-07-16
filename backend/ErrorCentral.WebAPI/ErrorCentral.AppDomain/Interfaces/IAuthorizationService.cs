using ErrorCentral.AppDomain.Models;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IAuthorizationService
    {
        BaseResult<IUser> Authorize(LoginUser loginUser);
    }
}