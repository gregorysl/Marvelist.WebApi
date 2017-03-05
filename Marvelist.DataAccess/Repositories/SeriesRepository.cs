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

        public List<SeriesViewModel> GetAllSeries(string userId, int page, int pagesize)
        {
            var series = DataContext.Series.OrderBy(x => x.Title).Skip(page*pagesize).Take(pagesize);
            var seriesViewModels = ToSeriesViewModel(series, userId);
            return seriesViewModels;
        }
        public List<SeriesComicsViewModel> GetAllFollowedSeries(string userId)
        {
            var series = DataContext.UserSeries.Where(x => x.UserId == userId).Select(x =>
            new SeriesComicsViewModel
            {
                Id = x.Id,
                Description = x.Series.Description,
                Following = true,
                ThumbnailData = x.Series.Thumbnail,
                Title = x.Series.Title,
                Url = x.Series.Url,
                ComicCount = x.Series.Comics.Count,
                Read = DataContext.UserComics.Count(c=>x.Series.Comics.Select(s=>s.Id).Contains(c.ComicId)) 
            }).OrderBy(x=>x.Title).ToList();
            
            return series;
        }

        public List<SeriesViewModel> Filter(string text, string userId)
        {
            var source = DataContext.Series.AsQueryable();
            var wordsArr = text.Split(' ');
            source = wordsArr.Aggregate(source, (current, txt) => current.Where(x => x.Title.Contains(txt)));
            return ToSeriesViewModel(source, userId);
        }

        public List<SeriesViewModel> GetByYear(int year, string userId)
        {
            var series = DataContext.Series.Where(x => x.StartYear == year);
            return ToSeriesViewModel(series, userId);
        }

        private List<SeriesViewModel> ToSeriesViewModel(IQueryable<Series> query, string userId)
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
            }).OrderBy(x=>x.Title).ToList();
        }
    }

    public interface ISeriesRepository : IRepository<Series>
    {
        List<SeriesComicsViewModel> GetAllFollowedSeries(string userId);
        SeriesViewModel GetSeriesById(int id, string userId);
        List<SeriesViewModel> Filter(string text, string userId);
        List<SeriesViewModel> GetByYear(int year, string userId);
        List<SeriesViewModel> GetAllSeries(string userId, int page, int pagesize);
    }
}