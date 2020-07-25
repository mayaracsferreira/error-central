using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Infra.Data.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException()
        {
        }

        public EmailAlreadyExistsException(string message)
            : base(message)
        {
        }

        public EmailAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
