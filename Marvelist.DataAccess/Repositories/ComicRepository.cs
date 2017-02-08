using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class ComicRepository : RepositoryBase<Comic>, IComicRepository
    {
        public ComicRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }

        public List<Comic> Filter(string text)
        {
            var source = DataContext.Comics.AsQueryable();
            var wordsArr = text.Split(' ');
            source = wordsArr.Aggregate(source, (current, txt) => current.Where(x => x.Title.Contains(txt)));
            return source.ToList();
        }

        public List<Comic> GetForSeriesId(int id)
        {
            var series = DataContext.Series.FirstOrDefault(x => x.Id == id);
            return series?.Comics.OrderBy(x=>x.IssueNumber).ToList() ?? new List<Comic>();
        }
        public List<Comic> GetHomeComics(string user)
        {
            var uc = DataContext.UserComics.Where(x => x.UserId == user).Select(x => x.ComicId);
            var us = DataContext.UserSeries.Where(x => x.UserId == user).Select(x => x.SeriesId);

            var results = DataContext.Comics.Where(c => us.Contains(c.SeriesId) && !uc.Contains(c.Id))
                .GroupBy(x => x.SeriesId, (id, series) => series.OrderBy(c => c.Date).FirstOrDefault())
                .OrderBy(c => c.Date)
                .ToList();
            return results;
        }
    }
    public interface IComicRepository : IRepository<Comic>
    {
        List<Comic> Filter(string text);
        List<Comic> GetForSeriesId(int id);
        List<Comic> GetHomeComics(string userId);
    }
}