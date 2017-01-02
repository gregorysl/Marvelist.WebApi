using System.Collections.Generic;
using System.Linq;
using Marvelist.API.ViewModels;
using Marvelist.Entities;
using Marvelist.Service;

namespace Marvelist.API.Helpers
{
    public static class Helper
    {
        public static List<SeriesViewModel> ToListSeriesViewModel(this List<Series> list, IUserSeriesService service, string userId)
        {
            return list.Select(x => x.ToSeriesViewModel(service, userId)).ToList();
        }

        public static SeriesViewModel ToSeriesViewModel(this Series x, IUserSeriesService service, string userId)
        {
            return new SeriesViewModel { Series = x, Following = service.IsFollowing(x.Id, userId) };
        }
        public static SeriesComicsViewModel ToSeriesComicsViewModel(this Series x, IUserSeriesService service, string userId)
        {
            return new SeriesComicsViewModel { Series = x, Comics = x.Comics.ToList() , Following = service.IsFollowing(x.Id, userId) };
        }
    }

    public static class OwinHelper
    {
    }
}