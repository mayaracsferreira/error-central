using AutoMapper;
using ErrorCentral.AppDomain.DTO;
using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCentral.WebAPI
{
    public class EventMapperProfile : Profile
    {
        public EventMapperProfile()
        {
            CreateMap<EventLog, EventLogDTO>().ReverseMap();
        }
    }
}
