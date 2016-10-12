using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
    public interface IUserRepository : IRepository<ApplicationUser>
    {
    }
}