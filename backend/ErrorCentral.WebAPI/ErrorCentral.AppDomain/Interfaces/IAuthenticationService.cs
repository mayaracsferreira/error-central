using ErrorCentral.AppDomain.Models;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationResult Authenticate(IUser user);
    }
}