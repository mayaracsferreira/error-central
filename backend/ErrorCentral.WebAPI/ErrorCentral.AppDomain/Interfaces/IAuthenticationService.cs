using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

public interface IAuthenticationService
{
    Task<AuthenticationResult> AuthenticateAsync(
        IUser user);
}