using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using Marvelist.API.ViewModels;
using Marvelist.Entities;
using Marvelist.Service;

namespace Marvelist.API.Helpers
{
    public static class Helper
    {
        public static List<SeriesViewModel> ToSeriesViewModel(this List<Series> list, IUserSeriesService service, string userId)
        {
            return list.Select(x => new SeriesViewModel { Series = x, Following = service.IsFollowing(x.Id, userId) }).ToList();
        }
    }

    public static class OwinHelper
    {
    }
}