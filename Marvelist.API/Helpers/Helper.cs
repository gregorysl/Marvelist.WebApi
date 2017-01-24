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
            return list.OrderBy(x => x.IssueNumber).Select(c => c.ToComicViewModel(service, userId)).ToList();
        }

        public static SeriesViewModel ToSeriesViewModel(this Series x, IUserSeriesService service, string userId)
        {
            var svm = new SeriesViewModel();
            AutoMapper.Mapper.Map(x, svm);
            svm.Following = service.IsFollowing(x.Id, userId);
            return svm;
        }

        public static ComicsViewModel ToComicViewModel(this Comic x, IUserComicService service, string userId)
        {
            var cvm = new ComicsViewModel();
            AutoMapper.Mapper.Map(x, cvm);
            cvm.Following = service.IsFollowing(x.Id, userId);
            return cvm;
        }

        public static SeriesComicsViewModel ToSeriesComicsViewModel(this Series x, IUserSeriesService service,
            IUserComicService comicService,
            string userId)
        {
            var svm = new SeriesComicsViewModel();
            AutoMapper.Mapper.Map(x, svm);
            svm.Comics = x.Comics.ToListComicsViewModel(comicService, userId);
            svm.Following = service.IsFollowing(x.Id, userId);
            return svm;
        }
    }
}