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

        bool Delete(int ID);

    }
}
