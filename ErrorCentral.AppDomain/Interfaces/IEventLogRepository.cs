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
        EventLog Update(EventLog eventLog);
       IList<EventLog> GetByLevel(string level);
       //IList<EventLog> GetByOrigin(string origin);
        
        bool Delete(int ID);

        List<EventFilterDTO> GetFilters(string environment, string orderBy, string searchFor, string field);

    }
}
