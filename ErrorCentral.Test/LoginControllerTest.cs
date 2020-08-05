using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Test
{
    class LoginControllerTest
    {
        private readonly LoginController _controller;
        private readonly IAuthenticationService _authService;
        private readonly IUserService _userService;

        public LoginControllerTest(LoginController login,
            IAuthenticationService authenticationService,
            IUserService userService)
        {
            _controller = login;
            _authService = authenticationService;
            _userService = userService;
        }



        //[Fact]
        //public void Post_WhenUserServiceCheck_Authorize
        //{
        //}

        //[Fact]
        //public void Post_WhenAuthServiceCheck_Authenticate
        //{
        //}

        //[Fact]
        //public void Post_WhenCalled_ReturnsOk
        //{
        //}
    }
}
