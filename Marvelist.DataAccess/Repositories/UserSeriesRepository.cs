using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class UserSeriesRepository : RepositoryBase<UserSeries>, IUserSeriesRepository
    {
        public UserSeriesRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
    public interface IUserSeriesRepository : IRepository<UserSeries>
    {
    }
}