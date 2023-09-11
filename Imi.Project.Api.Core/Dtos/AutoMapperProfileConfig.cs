using AutoMapper;
using Imi.Project.Api.Core.Dtos.Response;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Dtos
{
    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig() : this("DefaultProfile")
        {

        }

        protected AutoMapperProfileConfig(string profileName) : base(profileName)
        {
            CreateMap<AnimalResponseDto, Animal>().ReverseMap();
        }
    }
}
