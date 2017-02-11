using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Infrastructure;
using Marvelist.Entities;
using Marvelist.Entities.ViewModels;

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
        public List<int> GetAllFollowingId(string id)
        {
            return DataContext.UserComics.Where(x => x.UserId == id).Select(x => x.ComicId).ToList();
        }

        public void DeleteByComicId(int comicId, string userId)
        {
            var item = DataContext.UserComics.FirstOrDefault(x => x.UserId == userId && x.ComicId == comicId);
            Delete(item);
        }

        public List<int> FilterFollowed(List<int> toFilter, string userId)
        {
            var contains = DataContext.UserComics.Where(x => toFilter.Contains(x.ComicId)).Select(x => x.Id);
            return toFilter.Except(contains).ToList();
        }

        public List<ComicsViewModel> GetAllFollowingForSeriesId(int seriesId, string userId)
        {
            var comics = DataContext.Comics.Where(x => x.SeriesId == seriesId).Select(c => new ComicsViewModel
            {
                Date = c.Date,
                Description = c.Description,
                DiamondCode = c.DiamondCode,
                EAN = c.EAN,
                Id = c.Id,
                Title = c.Title,
                IssueNumber = c.IssueNumber,
                ThumbnailData = c.Thumbnail,
                Url = c.Url,
                Following = DataContext.UserComics.Any(x => x.UserId == userId && x.ComicId == c.Id),
                ISBN = c.ISBN,
                ISSN = c.ISSN,
                PageCount = c.PageCount,
                Price = c.Price,
                UPC = c.UPC,
                SeriesId = c.SeriesId
            }).OrderBy(x=>x.IssueNumber).ToList();
            return comics;
        }
    }
    public interface IUserComicRepository : IRepository<UserComic>
    {
        bool IsFollowing(int id, string userId);
        List<Comic> GetAllFollowing(string id);
        List<int> GetAllFollowingId(string id);
        void DeleteByComicId(int comicId, string userId);
        List<int> FilterFollowed(List<int> id, string userId);
        List<ComicsViewModel> GetAllFollowingForSeriesId(int seriesId, string userId);
    }
}