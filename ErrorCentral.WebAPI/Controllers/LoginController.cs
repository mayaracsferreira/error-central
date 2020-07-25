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

        /// <summary>
        /// Realiza login do usuário no sistema
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///        "email": "matancredi@hotmail.com",
        ///        "senha": "senha"
        ///     }
        ///
        /// </remarks>
        /// <param email="string"></param>
        /// <param senha="string"></param>
        /// <response code="200">Login realizado com sucesso</response>
        /// <response code="401">Não foi possível realizar login, confira os dados</response> 
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