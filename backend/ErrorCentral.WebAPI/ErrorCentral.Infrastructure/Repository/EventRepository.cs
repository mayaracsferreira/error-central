using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using ErrorCentral.Infra.Data.Exceptions;
using ErrorCentral.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorCentral.Infrastructure.Repository
{
    public class EventRepository : IEventLogRepository
    {
        private readonly EventContext eventcontext;
        public EventRepository(EventContext eventcontext)
        {
            this.eventcontext = eventcontext;
        }

        public bool Delete(int ID)
        {
            var _event = eventcontext.EventLogs.Where(x => x.EventID == ID).FirstOrDefault();
            if( _event != null)
            {
                eventcontext.Entry(_event).State = EntityState.Deleted;
                eventcontext.SaveChanges();
                return true;
            }
            throw new EventLogNotFoundException("Não foi possível encontrar log com esse id");
            // return false;
        }

        public IEnumerable<EventLog> Get()
        {
            IEnumerable<EventLog> logs = eventcontext.EventLogs;
            if (logs == null)
            {
                throw new EventLogNotFoundException("Não existem logs cadastrados");
            }
            return logs;
        }

        public EventLog GetById(int Id)
        {
            EventLog log = eventcontext.EventLogs.Where(x => x.EventID == Id).FirstOrDefault();
            if (log == null)
            {
                throw new EventLogNotFoundException("Não foram encontrados logs com o id informado");
            }
            return log;
        }

        public EventLog Save(EventLog eventLog)
        {
            var state = eventLog.EventID == 0 ? EntityState.Added : EntityState.Modified;
            eventcontext.Entry(eventLog).State = state;
            eventcontext.Add(eventLog);
            eventcontext.SaveChanges();
            return eventLog;
        }

        public EventLog Update(EventLog eventLog)
        {
            var _event = eventcontext.EventLogs.Where(x => x.EventID == eventLog.EventID).FirstOrDefault();
            if (_event != null){
                _event.Title = eventLog.Title;
                eventcontext.Entry(_event).State = EntityState.Modified;
                eventcontext.SaveChanges();
            }
            else
            {
                throw new EventLogNotFoundException("Não foi possível encontrar log de erro com esse ID");
            }
            return eventLog;
        }
    }
}
