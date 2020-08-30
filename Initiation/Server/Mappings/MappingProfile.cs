using AutoMapper;
using Initiation.Server.Models;
using Initiation.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiation.Server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Instrument, DtoInstrument>();
            CreateMap<DtoInstrument, Instrument>();
        }
    }
}
