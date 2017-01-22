using AutoMapper;
using Marvelist.API.ViewModels;
using Marvelist.Entities;
using Marvelous;
using Series = Marvelist.Entities.Series;

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
                mapper.CreateMap<Series, SeriesViewModel>()
                    .ForMember(a => a.Thumbnail, b => b.MapFrom(c => c.Thumbnail.ToString(Image.PortraitUncanny)))
                    .ForMember(a => a.ComicCount, b => b.MapFrom(c => c.Comics.Count));
            });
            
        }
    }
}