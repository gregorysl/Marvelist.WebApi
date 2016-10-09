using AutoMapper;
using Marvelist.API.ViewModels;
using Marvelist.Entities;

namespace Marvelist.API.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }


        protected override void Configure()
        {
            //Mapper.CreateMap<Resource, ResourceViewModel>();
            //Mapper.CreateMap<Location, LocationViewModel>();
            //Mapper.CreateMap<ResourceActivity,ResourceActivityViewModel>().ForMember(vm => vm.ActivityDateString, dm=> dm.MapFrom(dModel => dModel.ActivityDate.ToLongDateString()));
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
        }
    }
}