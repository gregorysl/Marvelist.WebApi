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

        public IQueryable<Series> QueryAll()
        {
            return DataContext.Series;
        }
    }
    public interface ISeriesRepository : IRepository<Series>
    {
        IQueryable<Series> QueryAll();
    }
}