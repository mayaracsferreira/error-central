using AutoMapper;
using ErrorCentral.AppDomain.DTO;
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
        private IMapper mapper;
        public EventRepository(EventContext eventcontext, IMapper mapper)
        {
            this.eventcontext = eventcontext;
            this.mapper = mapper;
        }

        public IList<EventLog> GetByLevel(string level)
        {
            var _event = eventcontext.EventLogs.Where(x => x.Level == level)
                .Distinct()
                .ToList();
            if (_event == null)
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
            if (_event != null)
            {
                eventcontext.Entry(_event).State = EntityState.Deleted;
                eventcontext.SaveChanges();
                return true;
            }
            return false;
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

        public List<EventFilterDTO> GetFilters(string environment, string orderBy, string searchFor, string field)
        {
            List<EventLog> events = eventcontext.EventLogs.ToList();
            //var b = events;

            var eventsGrouped = events.GroupBy(x => x.Description).Select(group => new
            {
                Description = group.Key,
                Count = group.Count()
            }).OrderBy(x => x.Count);

            List<EventFilterDTO> eventsDTO = new List<EventFilterDTO>();

            foreach (EventLog evt in events)
            {
                EventFilterDTO eventDTO = mapper.Map<EventFilterDTO>(evt);
                eventDTO.Frequency = eventsGrouped.Where(e => e.Description == eventDTO.Description).Select(e => e.Count).FirstOrDefault();
                eventsDTO.Add(eventDTO);
            }

            if (environment != null)
            {
                eventsDTO = eventsDTO.Where(x => x.Environment.Contains(environment)).ToList();
            }
            if (searchFor != null && field != null)
            {
                switch (searchFor.ToLower())
                {
                    case "level":
                        eventsDTO = eventsDTO.Where(x => x.Level.ToLower().Contains(field.ToLower())).ToList();
                        break;
                    case "description":
                        eventsDTO = eventsDTO.Where(x => x.Description.ToLower().Contains(field.ToLower())).ToList();
                        break;
                    case "origin":
                        eventsDTO = eventsDTO.Where(x => x.Origin.ToLower().Contains(field.ToLower())).ToList();
                        break;
                    default:
                        throw new FilterException("Só é possível procurar por level, descrição ou origem");
                }
            }
            if (orderBy != null)
            {
                switch (orderBy.ToLower())
                {
                    case "level":
                        eventsDTO = eventsDTO.OrderBy(x => x.Level).ToList();
                        break;
                    case "frequency":
                        eventsDTO = eventsDTO.OrderBy(x => x.Frequency).ThenBy(x => x.Description).ToList();
                        break;
                    default:
                        throw new FilterException("Só é possível ordenar por level ou por frequência");
                }
            }
            return eventsDTO;
        }


        public List<EventLogDTO> SearchForField(string searchFor, string field)
        {
            List<EventLog> events = eventcontext.EventLogs.ToList();


            List<EventLogDTO> eventsDTO = new List<EventLogDTO>();
            foreach (EventLog evt in events)
            {
                EventLogDTO eventDTO = mapper.Map<EventLogDTO>(evt);
                eventsDTO.Add(eventDTO);
            }

            if (searchFor != null && field != null)
            {
                switch (searchFor.ToLower())
                {
                    case "level":
                        eventsDTO = eventsDTO.Where(x => x.Level.ToLower().Contains(field.ToLower())).ToList();
                        break;
                    case "description":
                        eventsDTO = eventsDTO.Where(x => x.Description.ToLower().Contains(field.ToLower())).ToList();
                        break;
                    case "origin":
                        eventsDTO = eventsDTO.Where(x => x.Origin.ToLower().Contains(field.ToLower())).ToList();
                        break;
                    default:
                        throw new FilterException("Só é possível procurar por level, descrição ou origem");
                }
            }
            return eventsDTO;
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

        public EventLog Archive(int id)
        {
            var _event = eventcontext.EventLogs.Where(x => x.EventID == id).FirstOrDefault();
            if (_event != null)
            {
                _event.Archived = true;
                eventcontext.Entry(_event).State = EntityState.Modified;
                eventcontext.SaveChanges();
            }
            else
            {
                throw new EventLogNotFoundException("Não foi possível encontrar log de erro com esse ID");
            }
            return _event;
        }
    }
}
