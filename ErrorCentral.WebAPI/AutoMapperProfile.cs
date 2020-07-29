using AutoMapper;
using ErrorCentral.AppDomain.DTO;
using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCentral.WebAPI
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile()
        {
            CreateMap<EventLog, EventFilterDTO>().ReverseMap();
        }
    }
}
