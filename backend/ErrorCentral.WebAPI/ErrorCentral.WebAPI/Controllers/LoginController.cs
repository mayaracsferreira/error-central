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
        private readonly IUserService _userService;

        public LoginController(
            IAuthenticationService authenticationService,
            IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LoginUser loginUser)
        {
            // Checks if login and user match
            var authorization = _userService.Authorize(loginUser);
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