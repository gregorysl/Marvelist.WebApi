using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class ComicCreatorRepository : RepositoryBase<ComicCreator>, IComicCreatorRepository
    {
        public ComicCreatorRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
    public interface IComicCreatorRepository : IRepository<ComicCreator>
    {
    }
}