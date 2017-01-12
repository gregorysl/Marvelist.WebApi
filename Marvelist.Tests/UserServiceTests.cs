using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Marvelist.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Marvelist.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private IUserService _userService;
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _userRepository = MockRepository.MockUserRepository();
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _userService = new UserService(_userRepository, _unitOfWork);
        }

        [TestMethod]
        public void ShouldAddNewUser()
        {
            var user  = new ApplicationUser {Email = "test@email", UserName = "test"};
            var countBefore = TestData.Users.Count;
            _userService.RegisterUser(user);
            Assert.AreEqual(countBefore + 1, TestData.Users.Count);
        }

        [TestMethod]
        public void ShouldReturnUserById()
        {
            const string id = "1";
            var user = _userService.GetById(id);
            Assert.AreEqual(TestData.Users.Find(x => x.Id == id), user);
        }
        [TestMethod]
        public void ShouldReturnNullById()
        {
            const string id = "test";
            var user = _userService.GetById(id);
            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void ShouldReturnUserByEmail()
        {
            const string email = "first@Marvelist";
            var user = _userService.GetByEmail(email);
            Assert.AreEqual(TestData.Users.Find(x => x.Email == email), user);
        }
        [TestMethod]
        public void ShouldReturnNullByEmail()
        {
            const string email = "last@Marvelist";
            var user = _userService.GetByEmail(email);
            Assert.AreEqual(null, user);
        }

    }
}