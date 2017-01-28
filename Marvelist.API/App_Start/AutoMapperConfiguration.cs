using AutoMapper;
using Marvelist.Entities;
using Marvelist.Entities.ViewModels;
using Marvelous;
using Comic = Marvelist.Entities.Comic;
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
                mapper.CreateMap<Series, SeriesComicsViewModel>()
                    .ForMember(a => a.Thumbnail, b => b.MapFrom(c => c.Thumbnail.ToString(Image.PortraitUncanny)));
                mapper.CreateMap<Comic, ComicsViewModel>()
                    .ForMember(a => a.Thumbnail, b => b.MapFrom(c => c.Thumbnail.ToString(Image.PortraitUncanny)));
            });
            
        }
    }
}