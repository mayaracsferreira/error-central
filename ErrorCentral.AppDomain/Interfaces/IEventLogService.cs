using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Interfaces
{
    public interface IEventLogService
    {

        //services de teste, checar com a Ingrid.
        EventLog EventLogID(int ID);
        EventLog Salvar(EventLog eventLog);
        EventLog Atualizar(EventLog eventLog);
        bool Deletar(int ID);

    }
}
