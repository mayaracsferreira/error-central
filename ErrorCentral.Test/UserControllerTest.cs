using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using ErrorCentral.AppDomain.Services;
using ErrorCentral.Infra.Data.Exceptions;
using ErrorCentral.Infrastructure.Repository;
using ErrorCentral.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ErrorCentral.Test
{
    public class UserControllerTest : TestWithSqLite
    {
        private readonly UserController _controller;
        private readonly IUserRepository _repository;
        private readonly IUserService _service;

        public UserControllerTest()
        {
            _repository = new UserRepository(DbContext);
            _service = new UserService(_repository);
            _controller = new UserController(_service);
        }

        [Fact]
        public void ShouldCreateNewUser()
        {
            Clear();
            var newUser = new User() { 
                Name = "George Harisson",
                Email = "georgeharisson@abbey.com",
                Password = "beatles123",
            };
            IActionResult okResult = _controller.Save(newUser);

            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void EmailIsRequired()
        {
            var newUser = new User()
            {
                Name = "John Lennon",
                Password = "yoko123",
            };
            Assert.Throws<DbUpdateException>(() => _controller.Save(newUser));
        }

        [Fact]
        public void ChangePassword()
        {
            Clear();
            var newUser = new User()
            {
                Name = "John Lennon",
                Email = "john@gmail.com",
                Password = "yoko123",
            };
            _controller.Save(newUser);

            var change = new LoginUser()
            {
                LoginOrEmail = "john@gmail.com",
                Password = "newyork123",
            };

            IActionResult okResult = _controller.ChangePassword(change);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void EmailAlreadyUsedError()
        {
            Clear();
            var newUser = new User()
            {
                Name = "Paul McCartney",
                Email = "abbeyroad@gmail.com",
                Password = "linda123",
            };
            _controller.Save(newUser);

            var newUser2 = new User()
            {
                Name = "Ringo Starr",
                Email = "abbeyroad@gmail.com",
                Password = "ringo123",
            };
            Assert.Throws<EmailAlreadyExistsException>(() => _controller.Save(newUser));
        }
    }

}
