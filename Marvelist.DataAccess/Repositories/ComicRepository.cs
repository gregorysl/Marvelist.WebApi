using System;
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

        public List<Comic> GetForSeriesId(int id)
        {
            var series = DataContext.Series.FirstOrDefault(x => x.Id == id);
            return series?.Comics.OrderBy(x => x.IssueNumber).ToList() ?? new List<Comic>();
        }

        public int GetSeriesIdForComicId(int id)
        {
            return DataContext.Comics.Find(id).SeriesId;
        }

        public List<Comic> GetHomeComics(string user)
        {
            var uc = DataContext.UserComics.Where(x => x.UserId == user).Select(x => x.ComicId);
            var us = DataContext.UserSeries.Where(x => x.UserId == user).Select(x => x.SeriesId);

            var results = DataContext.Comics.Where(c => us.Contains(c.SeriesId) && !uc.Contains(c.Id))
                .GroupBy(x => x.SeriesId, (id, series) => series.OrderBy(c => c.Date).FirstOrDefault())
                .OrderBy(c => c.Date).ThenBy(c => c.Title)
                .ToList();
            return results;
        }

        public List<Comic> GetComicsForWeek(DateTime weekStart, DateTime weekEnd)
        {
            return DataContext.Comics.Where(x => x.Date >= weekStart && x.Date < weekEnd).OrderBy(x => x.Title).ToList();
        }
    }
    public interface IComicRepository : IRepository<Comic>
    {
        List<Comic> GetForSeriesId(int id);
        int GetSeriesIdForComicId(int id);
        List<Comic> GetHomeComics(string userId);
        List<Comic> GetComicsForWeek(DateTime weekStart, DateTime weekEnd);

    }
}