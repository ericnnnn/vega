using AutoMapper;
using WebApplication3.Controllers.Resources;
using WebApplication3.Models;

namespace WebApplication3.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model,ModelResource>();
        }
    }
}