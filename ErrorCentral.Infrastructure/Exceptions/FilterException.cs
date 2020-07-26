using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Infra.Data.Exceptions
{
    public class FilterException : Exception
    {
        public FilterException()
        {

        }

        public FilterException(string message)
            : base(message)
        {
        }

        public FilterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}