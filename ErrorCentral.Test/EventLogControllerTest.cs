using AutoMapper;
using ErrorCentral.AppDomain.DTO;
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
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace ErrorCentral.Test
{
    public class EventLogControllerTest : TestWithSqLite
    {
        private readonly EventLogController _controller;
        private readonly IEventLogRepository _repository;
        private readonly IEventLogService _service;
        private readonly EventContext _context;
        private EventLog _testLog;

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
            _testLog = _service.Salvar(new EventLog()
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
            }
            );
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

        [Fact]
        public void IdGet_WhenFindId_ReturnsOk()
        {
            var okResult = _controller.Get(_testLog.EventID);

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void IdGet_WhenOk_ReturnsContent()
        {
            var okResult = _controller.Get(_testLog.EventID).Result as OkObjectResult;
            Assert.IsType<EventLog>(okResult.Value);

            Assert.Equal(_testLog.EventID, (okResult.Value as EventLog).EventID);
        }

        [Fact]
        public void IdGet_WhenFailed_ReturnsNoContent()
        {
            _service.Deletar(_testLog.EventID);
            EventLog temp = _context.EventLogs.Where(x => x.EventID == _testLog.EventID).FirstOrDefault();
            if (temp != null)
            {
                throw new Exception("ERROR: file still present after deletion. Please contact support.");
            }
        }


        [Fact]
        public void FiltersGet_WhenFindFiltered_ReturnsOk()
        {
            var okResult = _controller.Get("production", "level", "level", "a");
            List<EventFilterDTO> events = _service.Filtrar("production", "level", "level", "a");
            if(events != null)
            {
                Assert.IsType<OkObjectResult>(okResult);
            }
        }

        [Fact]
        public void FiltersGet_WhenNoFiltered_ReturnsNoContent()
        {
            var okResult = _controller.Get("production", "level", "level", "a");
            List<EventFilterDTO> events = _service.Filtrar("production", "level", "level", "z");
            if (events == null)
            {
                Assert.IsType<NoContentResult>(okResult);
            }
        }

        [Fact]
        public void FiltersGet_WhenOk_ReturnsContent()
        {
            var okResult = _controller.Get("production", "level", "level", "a") as OkObjectResult;
            List<EventFilterDTO> events = _service.Filtrar("production", "level", "level", "a");
            if (events != null)
            {

                Assert.IsType<List<EventFilterDTO>>(okResult.Value);
                Assert.Equal((okResult.Value as List<EventFilterDTO>).Count, events.Count);
            }
        }

        [Fact]
        public void Post_WhenCalled_ReturnsOk ()
        {
            var okResult = _controller.Post(new EventLog()
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
            }
            );
            //This test is unable to check for id different than zero since only the user has access to those elements.
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Post_WhenCalled_ReturnsLog()
        {
            var okResult = _controller.Post(new EventLog()
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
            }
            ) as OkObjectResult;

            Assert.IsType<EventLog>(okResult.Value);
            //Here it would be far easier to test the Logs directly against each other, however once it gets
            //posted they automatically differ in ids, so we test everything except that.
            Assert.Equal(_testLog.Level, (okResult.Value as EventLog).Level);
            Assert.Equal(_testLog.Title, (okResult.Value as EventLog).Title);
            Assert.Equal(_testLog.CollectedBy, (okResult.Value as EventLog).CollectedBy);
            Assert.Equal(_testLog.Log, (okResult.Value as EventLog).Log);
            Assert.Equal(_testLog.Description, (okResult.Value as EventLog).Description);
            Assert.Equal(_testLog.Origin, (okResult.Value as EventLog).Origin);
            Assert.Equal(_testLog.Environment, (okResult.Value as EventLog).Environment);
            Assert.Equal(_testLog.CreatedDate, (okResult.Value as EventLog).CreatedDate);
        }

        [Fact]
        public void Put_WhenOkEvent_ReturnsOk()
        {
            EventLog temp = _service.Salvar(new EventLog()
            {
                Level = "ERROR",
                Title = "development.StaticOperation.Service: <failed>",
                CollectedBy = "yvqnygr3i1xl47wanrg2",
                Log = "IOException",
                Description = "It is thrown when an input-output operation failed or interrupted",
                Origin = "app.server.com.br",
                Environment = "Development",
                CreatedDate = new DateTime(2008, 5, 1, 8, 30, 52)
            }
            );
            var _event = _service.Atualizar(temp.EventID, temp);
            if(_event != null)
            {
                var okResult = _controller.Put(temp.EventID, temp);
                Assert.IsType<OkObjectResult>(okResult.Result);
            }
        }

        [Fact]
        public void Put_WhenNotOkEvent_ReturnsNoContent()
        {
            var _event = _service.Atualizar(_testLog.EventID, _testLog);
            if (_event == null)
            {
                Assert.IsType<NoContentResult>(_controller.Put(0, _testLog).Result);
            }
        }

        [Fact]
        public void Put_WhenOk_ReturnsContent()
        {
            EventLog temp = _service.Salvar(new EventLog()
            {
                Level = "ERROR",
                Title = "development.StaticOperation.Service: <failed>",
                CollectedBy = "yvqnygr3i1xl47wanrg2",
                Log = "IOException",
                Description = "It is thrown when an input-output operation failed or interrupted",
                Origin = "app.server.com.br",
                Environment = "Development",
                CreatedDate = new DateTime(2008, 5, 1, 8, 30, 52)
            }
            );
            var _event = _service.Atualizar(temp.EventID, temp);
            if (_event != null)
            {
                var okResult = _controller.Put(temp.EventID, temp).Result as OkObjectResult;
                Assert.IsType<EventLog>(okResult.Value);
                //Same as the method in #173
                Assert.Equal(temp.Level, (okResult.Value as EventLog).Level);
                Assert.Equal(temp.Title, (okResult.Value as EventLog).Title);
                Assert.Equal(temp.CollectedBy, (okResult.Value as EventLog).CollectedBy);
                Assert.Equal(temp.Log, (okResult.Value as EventLog).Log);
                Assert.Equal(temp.Description, (okResult.Value as EventLog).Description);
                Assert.Equal(temp.Origin, (okResult.Value as EventLog).Origin);
                Assert.Equal(temp.Environment, (okResult.Value as EventLog).Environment);
                Assert.Equal(temp.CreatedDate, (okResult.Value as EventLog).CreatedDate);
            }
        }

        [Fact]
        public void Delete_IfNotFound_ReturnNotFound()
        {
            Assert.IsType<NoContentResult>(_controller.Delete(0).Result);
        }

        [Fact]
        public void Delete_IfFound_ReturnOk()
        {
            EventLog temp = _service.Salvar(new EventLog()
            {
                Level = "ERROR",
                Title = "development.StaticOperation.Service: <failed>",
                CollectedBy = "yvqnygr3i1xl47wanrg2",
                Log = "IOException",
                Description = "It is thrown when an input-output operation failed or interrupted",
                Origin = "app.server.com.br",
                Environment = "Development",
                CreatedDate = new DateTime(2008, 5, 1, 8, 30, 52)
            }
);
            Assert.IsType<OkObjectResult>(_controller
                .Delete(temp.EventID).Result);
        }
    }

}
