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
    }
    public interface IComicRepository : IRepository<Comic>
    {
        List<Comic> Filter(string text);
        List<Comic> GetForSeriesId(int id);
    }
}