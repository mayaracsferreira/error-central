using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Infra.Data.Exceptions
{
    public class EventLogNotFoundException : Exception
    {
        public EventLogNotFoundException()
        {
        }

        public EventLogNotFoundException(string message)
            : base(message)
        {
        }

        public EventLogNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
