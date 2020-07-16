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
        private readonly IUserService _userService;

        public UserController(ILoggedUserService loggedUserService, IUserService userService)
        {
            _loggedUserService = loggedUserService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.Get();

            return Ok(users);
        }
        [HttpPost]
        public IActionResult Save(User user)
        {
            var users = _userService.Save(user);

            return Ok(users);
        }
    }
}
