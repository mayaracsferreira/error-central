using ErrorCentral.AppDomain.Models;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface ILoggedUserService
    {
        BaseResult<T> GetLoggedUser<T>()
            where T : class, IUser;
    }
}
