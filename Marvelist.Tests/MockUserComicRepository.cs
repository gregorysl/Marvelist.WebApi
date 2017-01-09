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
        public static IUserComicRepository MockUserComicRepository()
        {
            var repo = new Mock<IUserComicRepository>();
            var userComics = TestData.UserComics;
            repo.Setup(x => x.GetAll()).Returns(userComics);
            repo.Setup(x => x.GetAllFollowing(It.IsAny<string>()))
                .Returns(new Func<string, List<Comic>>(id => userComics.Where(z => z.UserId == id).Select(x => x.Comic).ToList()));
            repo.Setup(x => x.IsFollowing(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Func<int, string, bool>((id,userId) => userComics.Any(z => z.UserId == userId && z.Id == id)));
            repo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, UserComic>(id => userComics.Find(x => x.Id == id)));

            return repo.Object;
        }
    }
}
