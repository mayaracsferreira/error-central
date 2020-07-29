using ErrorCentral.AppDomain.DTO;
using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IEventLogService
    {
        IList<EventLog> EventLogs();
        EventLog EventLogID(int ID);
        EventLog Salvar(EventLog eventLog);
        EventLog Atualizar(EventLog eventLog);
        bool Deletar(int ID);
        List<EventFilterDTO> Filtrar(string environment, string orderBy, string searchFor, string field);

    }
}
