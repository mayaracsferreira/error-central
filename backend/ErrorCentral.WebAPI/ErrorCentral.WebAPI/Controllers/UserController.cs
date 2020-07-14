using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCentral.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize("Bearer")]
    public sealed class UserController : ControllerBase
    {
        private readonly ILoggedUserService _loggedUserService;

        public UserController(ILoggedUserService loggedUserService)
        {
            _loggedUserService = loggedUserService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var user = _loggedUserService.GetLoggedUser<MyLoggedUser>();

            return Ok(user);
        }
    }
}
