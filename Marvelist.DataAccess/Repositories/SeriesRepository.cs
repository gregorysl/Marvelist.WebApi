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

        public List<SeriesViewModel> GetAllSeries(string userId)
        {
            var seriesViewModels = ToSeriesViewModel(DataContext.Series, userId);
            return seriesViewModels;
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
            var series = DataContext.Series.Where(x => x.StartYear == year).OrderBy(x => x.StartYear);
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
            }).ToList();
        }
    }

    public interface ISeriesRepository : IRepository<Series>
    {
        SeriesViewModel GetSeriesById(int id, string userId);
        List<SeriesViewModel> Filter(string text, string userId);
        List<SeriesViewModel> GetByYear(int year, string userId);
        List<SeriesViewModel> GetAllSeries(string userId);
    }
}