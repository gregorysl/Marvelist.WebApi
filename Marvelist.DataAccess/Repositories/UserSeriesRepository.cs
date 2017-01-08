using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class UserSeriesRepository : RepositoryBase<UserSeries>, IUserSeriesRepository
    {
        public UserSeriesRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }

        public bool IsFollowing(int id, string userId)
        {
            return DataContext.UserSeries.Any(x => x.UserId == userId && x.Id == id);
        }

        public List<Series> GetAllFollowing(string id)
        {
            return DataContext.UserSeries.Where(x => x.UserId == id).Select(x => x.Series).ToList();
        }
    }
    public interface IUserSeriesRepository : IRepository<UserSeries>
    {
        bool IsFollowing(int id, string userId);
        List<Series> GetAllFollowing(string id);
    }
}