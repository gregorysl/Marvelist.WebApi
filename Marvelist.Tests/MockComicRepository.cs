using System;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Moq;

namespace Marvelist.Tests
{
    public partial class MockRepository
    {
        public static IComicRepository MockComicRepository()
        {
            var repo = new Mock<IComicRepository>();
            var comics = TestData.Comics;
            repo.Setup(x => x.GetAll()).Returns(comics);
            repo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Comic>(id => comics.Find(x => x.Id == id)));
            return repo.Object;
        }
    }
}
