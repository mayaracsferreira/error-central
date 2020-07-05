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

        public IList<EventLog> EventLogs()
        {
            try
            {
                return _eventlogRepository.Get().ToList();
            }
            catch (Exception e)
            {
                return new List<EventLog>();
            }
        }

        public EventLog EventLogID(int ID)
        {
            try
            {
                return _eventlogRepository.GetById(ID);
            }
            catch
            {
                return null;
            }
        }
        public EventLog Salvar(EventLog eventLog)
        {
            try
            {
                return _eventlogRepository.Save(eventLog);
            }
            catch
            {
                return null;
            }
        }
        public EventLog Atualizar(EventLog eventLog)
        {
            try
            {
                return _eventlogRepository.Update(eventLog);
            }
            catch
            {
                return null;
            }
        }

        public bool Deletar(int ID)
        {
            try
            {
                return _eventlogRepository.Delete(ID);
            }
            catch
            {
                return false;
            }

        }
    }
}
