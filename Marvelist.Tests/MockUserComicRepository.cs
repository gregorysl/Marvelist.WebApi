using System;
using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Moq;

namespace Marvelist.Tests
{
    public partial class MockRepository
    {
        public static IUserComicRepository MockUserComicRepository(List<UserComic> userComics)
        {
            var repo = new Mock<IUserComicRepository>();
            repo.Setup(x => x.GetAll()).Returns(userComics);
            repo.Setup(x => x.Add(It.IsAny<UserComic>()))
                .Callback(new Action<UserComic>(us =>
                {
                    us.Id = userComics.Last().Id + 1;
                    us.Date = DateTime.Now;
                    userComics.Add(us);
                }));
            repo.Setup(x => x.Delete(It.IsAny<UserComic>()))
                .Callback(new Action<UserComic>(us =>
                {
                    var toRemove = userComics.Find(a => a.Id == us.Id);
                    if (toRemove != null)
                        userComics.Remove(toRemove);
                }));
            repo.Setup(x => x.GetAllFollowing(It.IsAny<string>()))
                .Returns(new Func<string, List<Comic>>(id => userComics.Where(z => z.UserId == id).Select(x => x.Comic).ToList()));
            repo.Setup(x => x.IsFollowing(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Func<int, string, bool>((id, userId) => userComics.Any(z => z.UserId == userId && z.ComicId == id)));
            repo.Setup(x => x.FilterFollowed(It.IsAny<List<int>>(), It.IsAny<string>()))
                .Returns(
                    new Func<List<int>, string, List<int>>(
                        (toFilter, userId) =>
                            toFilter.Except(userComics.Where(x => toFilter.Contains(x.ComicId)).Select(x => x.ComicId))
                                .ToList()));
            repo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, UserComic>(id => userComics.Find(x => x.Id == id)));
            repo.Setup(x => x.DeleteByComicId(It.IsAny<int>(), It.IsAny<string>()))
                .Callback((int id, string userId) =>
                {
                    userComics.Remove(userComics.FirstOrDefault(z => z.UserId == userId && z.ComicId == id));
                });
            repo.Setup(moq => moq.DeleteAllForSeries(It.IsAny<int>(), It.IsAny<string>()))
                .Callback((int seriesId, string userId) =>
                {
                    var uc = userComics.Where(x => x.UserId == userId && x.Comic.SeriesId == seriesId).ToList();
                    foreach (var userComic in uc)
                    {
                        userComics.Remove(userComic);
                    }
                });

            return repo.Object;
        }
    }
}
