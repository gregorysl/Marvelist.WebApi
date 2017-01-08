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
        public static ISeriesRepository MockSeriesRepository()
        {
            var repo = new Mock<ISeriesRepository>();
            var series = TestData.Series;
            repo.Setup(x => x.GetAll()).Returns(series);
            repo.Setup(x => x.Filter(It.IsAny<string>()))
                .Returns(
                    new Func<string, List<Series>>(
                        id =>
                            id.Split(' ')
                                .Aggregate(series, (current, txt) => current.Where(x => x.Title.Contains(txt)).ToList())
                                .ToList()));
            repo.Setup(x => x.GetByYear(It.IsAny<int>()))
                .Returns(
                    new Func<int, List<Series>>(
                        year => series.Where(x => x.StartYear == year).OrderBy(x => x.StartYear).ToList()));
            repo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Series>(id => series.Find(x => x.Id == id)));
            return repo.Object;
        }
    }
}
