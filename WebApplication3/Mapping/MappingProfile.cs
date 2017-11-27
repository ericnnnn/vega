using System.Collections.Generic;
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
            CreateMap<Vehicle, SaveVehicleResource>()
            .ForMember(vr=>vr.Contact,opt=>opt.MapFrom(v=>new ContactResource{Name=v.ContactName,Email=v.ContactEmail,Phone=v.ContactPhone}))
            .ForMember(vr=>vr.Features,opt=>opt.MapFrom(v=>v.Features.Select(vf=>vf.FeatureId) ))
            ;
            CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr=>vr.Make,opt=>opt.MapFrom(v=>v.Model.Make))
            .ForMember(vr=>vr.Contact,opt=>opt.MapFrom(v=>new ContactResource{Name=v.ContactName,Email=v.ContactEmail,Phone=v.ContactPhone}))
            .ForMember(vr=>vr.Features,opt=>opt.MapFrom(v=>v.Features.Select(vf=>new FeatureResource{Id=vf.Feature.Id, Name=vf.Feature.Name}) ))
            ;

            //api->domain
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v=>v.Id,opt=>opt.Ignore())
                .ForMember(v=>v.ContactName,opt=>opt.MapFrom(vr=>vr.Contact.Name))
                .ForMember(v=>v.ContactEmail,opt=>opt.MapFrom(vr=>vr.Contact.Email))
                .ForMember(v=>v.ContactPhone,opt=>opt.MapFrom(vr=>vr.Contact.Phone))
//                .ForMember(v=>v.Features,opt=>opt.MapFrom(vr=>vr.Features.Select(id=>new VehicleFeature{FeatureId=id})))
                .ForMember(v=>v.Features,opt=>opt.Ignore())
                .AfterMap((vr,v)=>{
                    
                    //remove unselected features

                    //non linq version
                    //var removedFeatures=new List<VehicleFeature>();
                    // foreach(var f in v.Features)
                    //     if(!vr.Features.Contains(f.FeatureId))
                    //         //v.Features.Remove(f);
                    //         removedFeatures.Add(f);

                    //linq version
                    var removedFeatures=v.Features.Where(f=>!vr.Features.Contains(f.FeatureId));

                    foreach(var f in removedFeatures)
                        v.Features.Remove(f);

                    //add new features
                    //non linq version
                    // foreach(var id in vr.Features)
                    //     if(!v.Features.Any(f=>f.FeatureId==id))
                    //         v.Features.Add(new VehicleFeature{FeatureId=id});

                    //linq version
                    //var addedFeatures=vr.Features.Where(id=>!v.Features.Any(f=>f.FeatureId==id));
                    var addedFeatures=vr.Features.Where(id=>!v.Features.Any(f=>f.FeatureId==id)).Select(id=>new VehicleFeature{FeatureId=id});
                    //foreach(var id in addedFeatures)
                        //v.Features.Add(new VehicleFeature{FeatureId=id});
                    foreach(var f in addedFeatures)
                        v.Features.Add(f);
                })
            ;
        }
    }
}