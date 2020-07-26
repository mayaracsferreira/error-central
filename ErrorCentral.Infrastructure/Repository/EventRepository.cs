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

        public IList<EventLog> GetByLevel(string level)
        {
            var _event = eventcontext.EventLogs.Where(x => x.Level == level)
                .Distinct()
                .ToList();
            if(_event == null)
            {
                throw new EventLogNotFoundException("Não existem logs cadastrados");
            }
            return _event;
        }
        public IList<EventLog> GetByOrigin(string origin)
        {
            var _event = eventcontext.EventLogs.Where(x => x.Origin == origin)
                .Distinct()
                .ToList();
            if (_event == null)
            {
                throw new EventLogNotFoundException("Não existem logs cadastrados");
            }
            return _event;
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

        public List<EventLog> GetFilters(string environment, string orderBy, string searchFor, string field)
        {
            List<EventLog> events = eventcontext.EventLogs.ToList();
            if (environment != null)
            {
                events = events.Where(x => x.Environment == environment).ToList();
            }
            if (orderBy != null)
            {
                switch (orderBy.ToLower())
                {
                    case "level":
                        events = events.OrderBy(x => x.Level).ToList();
                        break;
                    //case "frequencia":
                    default:
                        throw new FilterException("Só é possível ordenar por level ou por frequência");
                }
            }
            if (searchFor!= null && field != null)
            {
                switch (searchFor.ToLower())
                {
                    case "level":
                        events = events.Where(x => x.Level == field).ToList();
                        break;
                    case "descrição":
                        events = events.Where(x => x.Description == field).ToList();
                        break;
                    case "origem":
                        events = events.Where(x => x.Origin == field).ToList();
                        break;
                    default:
                        throw new FilterException("Só é possível procurar por level, descrição ou origem");
                }
            }
            return events;
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
