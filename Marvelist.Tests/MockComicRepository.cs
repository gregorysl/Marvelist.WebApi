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
        public static IComicRepository MockComicRepository()
        {
            var repo = new Mock<IComicRepository>();
            var comics = TestData.Comics;
            repo.Setup(x => x.GetAll()).Returns(comics);
            repo.Setup(x => x.Add(It.IsAny<Comic>()))
                .Callback(new Action<Comic>(c =>
                {
                    c.Id = comics.Last().Id + 1;
                    comics.Add(c);
                }));
            repo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Comic>(id => comics.Find(x => x.Id == id)));
            repo.Setup(x => x.GetForSeriesId(It.IsAny<int>()))
                .Returns(
                    new Func<int, List<Comic>>(
                        id =>
                            TestData.Series.Find(x => x.Id == id)?.Comics.OrderBy(z => z.IssueNumber).ToList() ??
                            new List<Comic>()));
            return repo.Object;
        }
    }
}
