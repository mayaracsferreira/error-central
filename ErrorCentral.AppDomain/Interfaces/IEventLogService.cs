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
        EventLog Atualizar(int id, EventLog eventLog);
        EventLog Arquivar(int id);
        bool Deletar(int ID);
        List<EventFilterDTO> Agrupar(string environment, string orderBy);
        List<EventFilterDTO> Filtrar(string environment, string orderBy, string searchFor, string field);
        List<EventLogDTO> BuscarPorCampo(string searchFor, string field);
    }
}
