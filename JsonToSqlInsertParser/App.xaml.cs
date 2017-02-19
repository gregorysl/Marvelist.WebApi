using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AutoMapper;
using MarvelAPI;
using Comic = Marvelist.Entities.Comic;

namespace JsonToSqlInsertParser
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<MarvelImage, Marvelous.MarvelImage>();
                mapper.CreateMap<Series, Marvelist.Entities.Series>()
                    .ForSourceMember(a => a.Characters, x => x.Ignore())
                    .ForSourceMember(a => a.Comics, x => x.Ignore())
                    .ForSourceMember(a => a.Creators, x => x.Ignore())
                    .ForSourceMember(a => a.Events, x => x.Ignore())
                    .ForSourceMember(a => a.Next, x => x.Ignore())
                    .ForSourceMember(a => a.Previous, x => x.Ignore())
                    .ForSourceMember(a => a.Events, x => x.Ignore())
                    .ForMember(a => a.Comics, x => x.Ignore())
                    .ForMember(a => a.UserSeries, x => x.Ignore())
                    .ForMember(a => a.Thumbnail, b => b.MapFrom(x => x.Thumbnail))
                    .ForMember(a => a.Url, b => b.MapFrom(c => c.Urls.GetlUrl()));
                mapper.CreateMap<MarvelAPI.Comic, Comic>()
                    .ForSourceMember(a => a.Characters, x => x.Ignore())
                    .ForSourceMember(a => a.Series, x => x.Ignore())
                    .ForSourceMember(a => a.Creators, x => x.Ignore())
                    .ForSourceMember(a => a.Events, x => x.Ignore())
                    .ForSourceMember(a => a.CollectedIssues, x => x.Ignore())
                    .ForSourceMember(a => a.Collections, x => x.Ignore())
                    .ForSourceMember(a => a.TextObjects, x => x.Ignore())
                    .ForSourceMember(a => a.Events, x => x.Ignore())
                    .ForMember(a => a.ComicCreator, x => x.Ignore())
                    .ForMember(a => a.UserComic, x => x.Ignore())
                    .ForMember(a => a.Series, x => x.Ignore())
                    .ForMember(a => a.SeriesId, b => b.MapFrom(c => c.Series.GetSeriesId()))
                    .ForMember(a => a.Url, b => b.MapFrom(c => c.Urls.GetlUrl()))
                    .ForMember(a => a.Price, b => b.MapFrom(c => c.Prices.GetPrintPrices()))
                    .ForMember(a => a.Date, b => b.MapFrom(c => c.Dates.GetSaleDate()));
            });

            Mapper.AssertConfigurationIsValid();

            base.OnStartup(e);
        }
    }

    public static class ExtensionsMapper
    {
        public static string GetlUrl(this List<MarvelUrl> uri)
        {
            return uri.First(x => x.Type == "detail").Url;
        }

        public static float GetPrintPrices(this List<ComicPrice> prices)
        {
            return prices.First(x => x.Type == "printPrice").Price;
        }

        public static DateTime GetSaleDate(this List<ComicDate> prices)
        {
            return prices.First(x => x.Type == "onsaleDate").Date;
        }

        public static int GetSeriesId(this SeriesSummary series)
        {
            return int.Parse(series.ResourceURI.Substring(series.ResourceURI.LastIndexOf('/') + 1));
        }
    }
}