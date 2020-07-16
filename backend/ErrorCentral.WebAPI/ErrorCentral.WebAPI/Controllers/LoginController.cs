using ErrorCentral.AppDomain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ErrorCentral.WebAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public sealed class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly AppDomain.Interfaces.IAuthorizationService _authorizationService;

        public LoginController(
            IAuthenticationService authenticationService,
            AppDomain.Interfaces.IAuthorizationService authorizationService)
        {
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LoginUser loginUser)
        {
            // Checks if login and user match
            var authorization = _authorizationService.Authorize(loginUser);
            if (!authorization.Success)
            {
                return Ok(authorization);
            }

            // Generates jwt token
            var authentication = _authenticationService.Authenticate(authorization.Data);
            if (!authentication.Success)
            {
                return Ok(authentication);
            }

            return Ok(authentication);
        }
    }
}