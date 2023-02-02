using AutoMapper;
using CodeEvents.Api.Core.Dtos;
using CodeEvents.Api.Core.Entities;

namespace CodeEvents.Api.MapperProfiles
{
    public class CodeEventProfile : Profile
    {
        public CodeEventProfile()
        {
            CreateMap<CodeEvent, CodeEventDto>();
        }
    }
}
