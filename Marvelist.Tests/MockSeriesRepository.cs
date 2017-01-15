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
        public static ISeriesRepository MockSeriesRepository(List<Series> series)
        {
            var repo = new Mock<ISeriesRepository>();
            repo.Setup(x => x.GetAll()).Returns(series);
            repo.Setup(x => x.Add(It.IsAny<Series>()))
                .Callback(new Action<Series>(s =>
                {
                    s.Id = series.Last().Id + 1;
                    series.Add(s);
                }));
            repo.Setup(x => x.Filter(It.IsAny<string>()))
                .Returns(new Func<string, List<Series>>(id => Filter(id, series)));
            repo.Setup(x => x.GetByYear(It.IsAny<int>()))
                .Returns(new Func<int, List<Series>>(year => GetForYear(series, year)));
            repo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Series>(id => series.Find(x => x.Id == id)));
            return repo.Object;
        }

        private static List<Series> GetForYear(List<Series> series, int year)
        {
            return series.Where(x => x.StartYear == year).OrderBy(x => x.StartYear).ToList();
        }

        private static List<Series> Filter(string id, IEnumerable<Series> series)
        {
            return id.Split(' ').Aggregate(series, (current, txt) => current.Where(x => x.Title.Contains(txt))).ToList();
        }
    }
}