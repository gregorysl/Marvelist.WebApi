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

        public SeriesComicsViewModel GetSeriesDetailsById(int id, string userId)
        {
            var series = DataContext.Series.FirstOrDefault(x => x.Id == id);

            return series == null
                ? new SeriesComicsViewModel()
                : new SeriesComicsViewModel
                {
                    Id = series.Id,
                    Description = series.Description,
                    Following = DataContext.UserSeries.Any(us => us.SeriesId == series.Id && us.UserId == userId),
                    ThumbnailData = series.Thumbnail,
                    Title = series.Title,
                    Url = series.Url,
                    Comics = series.Comics.OrderBy(x => x.IssueNumber).Select(c => new ComicsViewModel
                    {
                        Date = c.Date,
                        Description = c.Description,
                        DiamondCode = c.DiamondCode,
                        EAN = c.EAN,
                        Id = c.Id,
                        Title = c.Title,
                        IssueNumber = c.IssueNumber,
                        ThumbnailData = c.Thumbnail,
                        Url = c.Url,
                        Following = DataContext.UserComics.Any(comic => comic.ComicId == c.Id && comic.UserId == userId),
                        ISBN = c.ISBN,
                        ISSN = c.ISSN,
                        PageCount = c.PageCount,
                        Price = c.Price,
                        UPC = c.UPC

                    }).ToList()
                };
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
        SeriesComicsViewModel GetSeriesDetailsById(int id, string userId);
        SeriesViewModel GetSeriesById(int id, string userId);
        List<SeriesViewModel> Filter(string text, string userId);
        List<SeriesViewModel> GetByYear(int year, string userId);
        List<SeriesViewModel> GetAllSeries(string userId);
    }
}