using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class ComicRepository : RepositoryBase<Comic>, IComicRepository
    {
        public ComicRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
    public interface IComicRepository : IRepository<Comic>
    {
    }
}