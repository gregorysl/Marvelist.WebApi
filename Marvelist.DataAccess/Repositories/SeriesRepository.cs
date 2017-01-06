using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class SeriesRepository : RepositoryBase<Series>, ISeriesRepository
    {
        public SeriesRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }

        public List<Series> Filter(string text)
        {
            var source = DataContext.Series.AsQueryable();
            var wordsArr = text.Split(' ');
            source = wordsArr.Aggregate(source, (current, txt) => current.Where(x => x.Title.Contains(txt)));
            return source.ToList();
        }
    }
    public interface ISeriesRepository : IRepository<Series>
    {
        List<Series> Filter(string text);
    }
}