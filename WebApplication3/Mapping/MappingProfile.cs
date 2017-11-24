using System.Linq;
using AutoMapper;
using WebApplication3.Controllers.Resources;
using WebApplication3.Models;

namespace WebApplication3.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //domain->api
            CreateMap<Make, MakeResource>();
            CreateMap<Model,ModelResource>();
            CreateMap<Feature, FeatureResource>();

            //api->domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v=>v.ContactName,opt=>opt.MapFrom(vr=>vr.Contact.Name))
                .ForMember(v=>v.ContactEmail,opt=>opt.MapFrom(vr=>vr.Contact.Email))
                .ForMember(v=>v.ContactPhone,opt=>opt.MapFrom(vr=>vr.Contact.Phone))
                .ForMember(v=>v.Features,opt=>opt.MapFrom(vr=>vr.Features.Select(id=>new VehicleFeature{FeatureId=id})))
            ;
        }
    }
}