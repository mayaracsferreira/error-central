using AutoMapper;
using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using ErrorCentral.AppDomain.Services;
using ErrorCentral.Infra.Data.Exceptions;
using ErrorCentral.Infrastructure.Context;
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
        private readonly EventContext _context;

        public EventLogControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            _repository = new EventRepository(DbContext, mappingConfig.CreateMapper());
            _service = new EventLogService(_repository);
            _controller = new EventLogController(_service);
            _context = new EventContext();
        }


        [Fact]
        public void GetAll_WhenCalled_ReturnsOkOrNoContent()
        {
            var eventLogs = _service.EventLogs().ToList();
            var okResult = _controller.GetAll();

            if (eventLogs.Any())
            {
                Assert.IsType<OkObjectResult>(okResult);
            }
            else
            {
                Assert.IsType<NoContentResult>(okResult);
            }
        }

        [Fact]
        public void GetAll_WhenOk_ReturnsEventLogList()
        {
            var eventLogs = _service.EventLogs().ToList();
            if (eventLogs.Any())
            {
                var okResult = _controller.GetAll() as OkObjectResult;
                var items = Assert.IsType<List<EventLog>>(okResult.Value);

                Assert.Equal(_context.EventLogs.Count(), items.Count());
            }
        }

        //[Fact]
        //public void IdGet_WhenCalled_ReturnsOkOrNoContent()
        //{
        //    REQUIRES ID ALWAYS VALID AND ANOTHER ID ALWAYS INVALID
        //}

        //[Fact]
        //public void IdGet_WhenOk_ReturnsContent()
        //{
        //    throw new NotImplementedException();
        //    REQUIRES build test eventlog with fixed Id that responds to controller
        //}

        //[Fact]
        //public void FiltersGet_WhenFindFiltered_ReturnsOk()
        //{
        //    throw new NotImplementedException(); //in progress
        //}

        //[Fact]
        //public void FiltersGet_WhenNoFiltered_ReturnsNoContent()
        //{
        //    throw new NotImplementedException(); //in progress
        //}

        //[Fact]
        //public void FiltersGet_WhenOk_ReturnsContent()
        //{
        //    throw new NotImplementedException(); //in progress
        //}



        [Fact]
        public void Post_WhenCalled_ReturnsOk ()
        {
            var log = new EventLog()
            {
                EventID = 0,
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
