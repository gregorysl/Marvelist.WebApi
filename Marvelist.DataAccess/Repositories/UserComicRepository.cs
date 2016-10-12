using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class UserComicRepository : RepositoryBase<UserComic>, IUserComicRepository
    {
        public UserComicRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
    public interface IUserComicRepository : IRepository<UserComic>
    {
    }
}