public sealed class FakeAuthenticationService : IAuthenticationService
{
    public async Task<AuthenticationResult> AuthenticateAsync(
        IUser user)
    {
        var dateFormat = "yyyy-MM-dd HH:mm:ss";
        var result = new AuthenticationResult()
        {
            Success = true,
            Authenticated = true,
            Created = DateTime.UtcNow.ToString(dateFormat),
            Expiration = DateTime.UtcNow.AddHours(2).ToString(dateFormat),
            Message = "OK",
            AccessToken = "2349urf99de99423r99ifr2"
        };
 
        return await Task.FromResult(result);
    }
}