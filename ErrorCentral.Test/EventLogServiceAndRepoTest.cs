using AutoMapper;
using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using ErrorCentral.AppDomain.Services;
using ErrorCentral.Infra.Data.Exceptions;
using ErrorCentral.Infrastructure.Context;
using ErrorCentral.Infrastructure.Repository;
using ErrorCentral.WebAPI;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ErrorCentral.Test
{
    public class EventLogServiceAndRepoTest
    {
        private readonly EventRepository _eventRepository;
        private readonly EventContext _context;
        private readonly EventLogService _service;
        private readonly EventLog _testlog;

        public EventLogServiceAndRepoTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            _context = new EventContext();
            _eventRepository = new EventRepository(_context, mappingConfig.CreateMapper());
            _service = new EventLogService(_eventRepository);
            _testlog = _service.Salvar(new EventLog()
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
        public void Eventlogs_WhenCalled_ShouldReturnProper()
        {
            if (_context.EventLogs.Any())
            {
                Assert.IsType<List<EventLog>>(_service.EventLogs());
                Assert.IsType<List<EventLog>>(_eventRepository.Get());
            }
            else
            {
                Assert.IsType<EventLogNotFoundException>(_service.EventLogs());
                Assert.IsType<EventLogNotFoundException>(_eventRepository.Get());
            }
        }

        [Fact]
        public void EventLogId_WhenCalled_()
        {
            int id = _testlog.EventID;
            if(_context.EventLogs.Where(x => x.EventID == id).Any())
            {
                Assert.IsType<EventLog>(_service.EventLogID(id));
                Assert.IsType<EventLog>(_eventRepository.GetById(id));
            }
            else
            {
                Assert.IsType<EventLogNotFoundException>(_service.EventLogID(id));
                Assert.IsType<EventLogNotFoundException>(_eventRepository.GetById(id));
            }
        }
    }
}
