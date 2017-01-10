using System;
using System.Linq;
using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }

        public ApplicationUser GetById(string id)
        {
            return DataContext.Users.Find(id);
        }
        public ApplicationUser GetByEmail(string email)
        {
            return DataContext.Users.FirstOrDefault(x => x.Email == email);
        }
    }
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetById(string id);
        ApplicationUser GetByEmail(string email);
    }
}