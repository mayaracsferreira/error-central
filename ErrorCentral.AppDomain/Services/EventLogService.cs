using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorCentral.AppDomain.Services
{
    public class EventLogService : IEventLogService
    {
        private readonly IEventLogRepository _eventlogRepository;

        public EventLogService(IEventLogRepository eventRepository)
        {
            _eventlogRepository = eventRepository;
        }

        public IList<EventLog> EventLogsLevel()
        {
            try
            {
                return _eventlogRepository.Get().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EventLog EventLogID(int ID)
        {
            try
            {
                return _eventlogRepository.GetById(ID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public EventLog Salvar(EventLog eventLog)
        {
            try
            {
                return _eventlogRepository.Save(eventLog);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public EventLog Atualizar(EventLog eventLog)
        {
            try
            {
                return _eventlogRepository.Update(eventLog);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Deletar(int ID)
        {
            try
            {
                return _eventlogRepository.Delete(ID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
