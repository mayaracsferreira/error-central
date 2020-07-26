using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IEventLogService
    {

        //services de teste, checar com a Ingrid.
        IList<EventLog> EventLogsLevel();
        EventLog EventLogID(int ID);
        IList<EventLog> EventLogsLevel(string level);
        EventLog Salvar(EventLog eventLog);
        EventLog Atualizar(EventLog eventLog);
        bool Deletar(int ID);

    }
}
