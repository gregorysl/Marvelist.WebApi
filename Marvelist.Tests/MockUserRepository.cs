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
        public static IUserRepository MockUserRepository(List<ApplicationUser> users)
        {
            var repo = new Mock<IUserRepository>();
            repo.Setup(x => x.GetAll()).Returns(users);
            repo.Setup(x => x.Add(It.IsAny<ApplicationUser>()))
                .Callback(new Action<ApplicationUser>(us =>
                {
                    us.Id = Guid.NewGuid().ToString();
                    users.Add(us);
                }));
            repo.Setup(x => x.GetByEmail(It.IsAny<string>()))
                .Returns(new Func<string, ApplicationUser>(email => users.FirstOrDefault(z => z.Email == email)));
            repo.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new Func<string, ApplicationUser>(id => users.FirstOrDefault(z => z.Id == id)));

            return repo.Object;
        }
    }
}
