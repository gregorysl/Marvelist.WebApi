using AutoMapper;
using Marvelist.API.ViewModels;
using Marvelist.Entities;

namespace Marvelist.API
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(mapper =>
            { 
                mapper.CreateMap<RegisterViewModel, ApplicationUser>();
                mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            });
            
        }
    }
}