using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Marvelist.API.ViewModels;
using Marvelist.Entities;
using Marvelist.Service;

namespace Marvelist.API.Helpers
{
    public static class Helper
    {
        public static List<SeriesViewModel> ToListSeriesViewModel(this List<Series> list, IUserSeriesService service,
            string userId)
        {
            return list.Select(x => x.ToSeriesViewModel(service, userId)).ToList();
        }

        public static List<ComicsViewModel> ToListComicsViewModel(this ICollection<Comic> list,
            IUserComicService service, string userId)
        {
            return list.Select(c => c.ToComicViewModel(service, userId)).ToList();
        }

        public static SeriesViewModel ToSeriesViewModel(this Series x, IUserSeriesService service, string userId)
        {
            return new SeriesViewModel {Series = x, Following = service.IsFollowing(x.Id, userId)};
        }

        public static ComicsViewModel ToComicViewModel(this Comic x, IUserComicService service, string userId)
        {
            return new ComicsViewModel {Comic = x, Following = service.IsFollowing(x.Id, userId)};
        }

        public static SeriesComicsViewModel ToSeriesComicsViewModel(this Series x, IUserSeriesService service,
            IUserComicService comicService,
            string userId)
        {
            return new SeriesComicsViewModel
            {
                Series = x,
                Comics = x.Comics.ToListComicsViewModel(comicService, userId),
                Following = service.IsFollowing(x.Id, userId)
            };
        }
    }
}