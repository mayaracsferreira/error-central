using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.DTO
{
    public class EventFilterDTO
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string Title { get; set; }
        public string Log { get; set; }
        public string Environment { get; set; }
        public string Origin { get; set; }
        public int Frequency { get; set; }
    }
}