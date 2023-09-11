using AutoMapper;
using Imi.Project.Api.Core.Dtos.Response;
using Imi.Project.Api.Core.Dtos.Request;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Animal, AnimalResponseDto>();
            CreateMap<AnimalAddRequestDto, Animal>();

            CreateMap<Kind, KindResponseDto>();
            CreateMap<KindAddRequestDto, Kind>();

            CreateMap<Continent, ContinentResponseDto>();
            CreateMap<ContinentAddRequest, Continent>();
        }
    }
}
