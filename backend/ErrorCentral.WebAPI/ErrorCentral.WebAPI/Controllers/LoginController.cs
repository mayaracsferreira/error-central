using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


[Route("api/login")]
[ApiController]
public sealed class LoginController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ErrorCentral.AppDomain.Interfaces.IAuthorizationService _authorizationService;
 
    public LoginController(
        IAuthenticationService authenticationService,
        ErrorCentral.AppDomain.Interfaces.IAuthorizationService authorizationService)
    {
        _authenticationService = authenticationService;
        _authorizationService = authorizationService;
    }
 
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostAsync(
        [FromBody] LoginUser loginUser)
    {
        var authorization = await _authorizationService.AuthorizeAsync(loginUser);
        if (!authorization.Success)
        {
            return Ok(authorization);
        }

        var authentication = _authenticationService.Authenticate(authorization.Data);
        if (!authentication.Success)
        {
            return Ok(authentication);
        }

        return Ok(authentication);
    }
}