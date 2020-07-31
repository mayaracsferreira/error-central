using AutoMapper;
using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using ErrorCentral.AppDomain.Services;
using ErrorCentral.Infra.Data.Exceptions;
using ErrorCentral.Infrastructure.Repository;
using ErrorCentral.WebAPI;
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
    public class EventLogControllerTest : TestWithSqLite
    {
        private readonly EventLogController _controller;
        private readonly IEventLogRepository _repository;
        private readonly IEventLogService _service;

        public EventLogControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            _repository = new EventRepository(DbContext, mappingConfig.CreateMapper());
            _service = new EventLogService(_repository);
            _controller = new EventLogController(_service);
        }

        [Fact]
        public void ShouldCreateNewEventLog()
        {
            var log = new EventLog()
            {
                Level = "ERROR",
                Title = "development.StaticOperation.Service: <failed>",
                CollectedBy = "yvqnygr3i1xl47wanrg2",
                Log = "IOException",
                Description = "It is thrown when an input-output operation failed or interrupted",
                Origin = "app.server.com.br",
                Environment = "Development",
                CreatedDate = new DateTime(2008, 5, 1, 8, 30, 52)
            };
            IActionResult okResult = _controller.Post(log);

            Assert.IsType<OkObjectResult>(okResult);
        }

    }

}
