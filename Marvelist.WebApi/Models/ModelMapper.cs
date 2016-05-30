using System.Linq;
using AutoMapper;

namespace Marvelist.WebApi.Models
{
    public static class MapExtensions
    {
        public static T To<T>(this object from)
        {
            return Mapper.Map<T>(from);
        }
    }
    public static class AutoMapperConfig
    {
        private static MapperConfiguration _configuration;
        public static MapperConfiguration Configuration => _configuration ?? (_configuration = Configure());

        private static MapperConfiguration Configure()
        {
            return new MapperConfiguration(AutoMapperBusinessConfig.Configure);
        }
    }
    public static class AutoMapperBusinessConfig
    {
        public static void Configure(IProfileExpression profile)
        {
            profile.CreateMap<Series, MarvelAPI.Series>();
            profile.CreateMap<MarvelAPI.Series, Series>()
                .ForMember(t => t.Url, f => f.MapFrom(z => z.Urls.First(x => x.Type == "detail").Url));
        }
    }
}