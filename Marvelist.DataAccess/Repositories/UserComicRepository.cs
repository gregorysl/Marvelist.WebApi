using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Repositories
{
    public class UserComicRepository : RepositoryBase<UserComic>, IUserComicRepository
    {
        public UserComicRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
        
        public bool IsFollowing(int id, string userId)
        {
            return DataContext.UserComics.Any(x => x.UserId == userId && x.ComicId == id);
        }

        public List<Comic> GetAllFollowing(string id)
        {
            return DataContext.UserComics.Where(x => x.UserId == id).Select(x => x.Comic).ToList();
        }

        public void DeleteByComicId(int comicId, string userId)
        {
            var item = DataContext.UserComics.FirstOrDefault(x => x.UserId == userId && x.ComicId == comicId);
            Delete(item);
        }
    }
    public interface IUserComicRepository : IRepository<UserComic>
    {
        bool IsFollowing(int id, string userId);
        List<Comic> GetAllFollowing(string id);
        void DeleteByComicId(int comicId, string userId);
    }
}