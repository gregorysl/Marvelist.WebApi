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
        public static IUserSeriesRepository MockUserSeriesRepository(List<UserSeries> userSeries)
        {
            var repo = new Mock<IUserSeriesRepository>();
            repo.Setup(x => x.GetAll()).Returns(userSeries);
            repo.Setup(x => x.Add(It.IsAny<UserSeries>()))
                .Callback(new Action<UserSeries>(us =>
                {
                    us.Id = userSeries.Last().Id + 1;
                    us.Date = DateTime.Now;
                    userSeries.Add(us);
                }));
            repo.Setup(x => x.DeleteBySeriesId(It.IsAny<int>(), It.IsAny<string>()))
                .Callback((int id, string userId) =>
                {
                    var toRemove = userSeries.Find(a => a.UserId == userId && a.SeriesId == id);
                    if (toRemove != null)
                        userSeries.Remove(toRemove);
                });
            repo.Setup(x => x.GetAllFollowing(It.IsAny<string>()))
                .Returns(new Func<string, List<Series>>(id => userSeries.Where(z => z.UserId == id).Select(x => x.Series).ToList()));
            repo.Setup(x => x.IsFollowing(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Func<int, string, bool>((id,userId) => userSeries.Any(z => z.UserId == userId && z.SeriesId == id)));
            repo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, UserSeries>(id => userSeries.Find(x => x.Id == id)));

            return repo.Object;
        }
    }
}
