using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;
using Marvelist.Entities.ViewModels;

namespace Marvelist.DataAccess.Repositories
{
    public class SeriesRepository : RepositoryBase<Series>, ISeriesRepository
    {
        public SeriesRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }

        public SeriesViewModel GetSeriesById(int id, string userId)
        {
            var series = DataContext.Series.Where(x => x.Id == id);
            return ToSeriesViewModel(series, userId).FirstOrDefault();
        }

        public SeriesPaginatedModel GetAllSeries(string userId, int page, int pagesize)
        {
            var allSeries = DataContext.Series.OrderBy(x => x.Title);
            var seriesViewModels = ToSeriesViewModel(allSeries, userId);
            var series = seriesViewModels.Skip(page * pagesize).Take(pagesize);
            return new SeriesPaginatedModel
            {
                PageData = new PageData
                {
                    Count = seriesViewModels.Count(),
                    Page = page,
                    PageSize = pagesize
                }
                ,
                Series = series.ToList()
            };
        }

        public SeriesPaginatedModel GetAllFollowedSeries(string userId)
        {
            var seriesViewModels = DataContext.UserSeries.Where(x => x.UserId == userId).Select(x =>
                new SeriesViewModel
                {
                    Id = x.SeriesId,
                    Description = x.Series.Description,
                    Following = true,
                    ThumbnailData = x.Series.Thumbnail,
                    Title = x.Series.Title,
                    Url = x.Series.Url,
                    ComicCount = x.Series.Comics.Count,
                    Read = DataContext.UserComics.Count(c => x.Series.Comics.Select(s => s.Id).Contains(c.ComicId))
                }).OrderBy(x => x.Title);
            return new SeriesPaginatedModel
            {
                PageData = new PageData
                {
                    Count = seriesViewModels.Count(),
                    Page = 0,
                    PageSize = seriesViewModels.Count()
                }
                ,
                Series = seriesViewModels.ToList()
            };
        }

        public SeriesPaginatedModel Filter(string text, string userId, int page, int pagesize)
        {
            var source = DataContext.Series.AsQueryable();
            var wordsArr = text.Split(' ');
            source = wordsArr.Aggregate(source, (current, txt) => current.Where(x => x.Title.Contains(txt)));
            var seriesViewModels = ToSeriesViewModel(source, userId);
            var series = seriesViewModels.Skip(page * pagesize).Take(pagesize);
            return new SeriesPaginatedModel
            {
                PageData = new PageData
                {
                    Count = seriesViewModels.Count(),
                    Page = page,
                    PageSize = pagesize
                },
                Series = series.ToList()
            };
        }

        public List<SeriesViewModel> GetByYear(int year, string userId)
        {
            var series = DataContext.Series.Where(x => x.StartYear == year);
            return ToSeriesViewModel(series, userId).ToList();
        }

        private IOrderedQueryable<SeriesViewModel> ToSeriesViewModel(IQueryable<Series> query, string userId)
        {
            return query.Select(c => new SeriesViewModel
            {
                Id = c.Id,
                ComicCount = c.Comics.Count,
                Description = c.Description,
                Following = DataContext.UserSeries.Any(us => us.SeriesId == c.Id && us.UserId == userId),
                ThumbnailData = c.Thumbnail,
                Title = c.Title,
                Url = c.Url
            }).OrderBy(x => x.Title);
        }
    }

    public interface ISeriesRepository : IRepository<Series>
    {
        SeriesPaginatedModel GetAllFollowedSeries(string userId);
        SeriesViewModel GetSeriesById(int id, string userId);
        SeriesPaginatedModel Filter(string text, string userId, int page, int pagesize);
        List<SeriesViewModel> GetByYear(int year, string userId);
        SeriesPaginatedModel GetAllSeries(string userId, int page, int pagesize);
    }
}