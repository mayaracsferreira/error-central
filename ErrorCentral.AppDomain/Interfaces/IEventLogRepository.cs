using ErrorCentral.AppDomain.DTO;
using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IEventLogRepository
    {
        IEnumerable<EventLog> Get();
        EventLog GetById(int Id);
        EventLog Save(EventLog eventLog);
        EventLog Update(int id, EventLog eventLog);
        EventLog Archive(int id);
        bool Delete(int ID);
        List<EventFilterDTO> GetFilters(string environment, string orderBy, string searchFor, string field);
        List<EventLogDTO> SearchForField(string searchFor, string field);
    }
}
