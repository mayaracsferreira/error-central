using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
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
            return false;
        }

        public IEnumerable<EventLog> Get()
        {
            return eventcontext.EventLogs;
        }

        public EventLog GetById(int Id)
        {
            return eventcontext.EventLogs.Where(x => x.EventID == Id).FirstOrDefault();
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
            var _event = eventcontext.EventLogs.Where(x => x.EventID == eventLog.EventID)
                .FirstOrDefault();
            if (_event != null){
                _event.Title = eventLog.Title;
                eventcontext.Entry(_event).State = EntityState.Modified;
                eventcontext.SaveChanges();
            }
            return eventLog;
        }
    }
}
