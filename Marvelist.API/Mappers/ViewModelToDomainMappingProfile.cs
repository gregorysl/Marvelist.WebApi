 using AutoMapper;
using Marvelist.Entities;
using Marvelist.API.ViewModels;

namespace Marvelist.API.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappingProfile";

        protected override void Configure()
        {
            //Mapper.CreateMap<ResourceViewModel, Resource>()
            //    .ForMember(resource => resource.Activities, vm => vm.Ignore())
            //    .ForMember(resource => resource.UserId, vm => vm.Ignore());

            //Mapper.CreateMap<LocationViewModel, Location>();
            //Mapper.CreateMap<ResourceActivityViewModel, ResourceActivity>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();
        }
    }
}