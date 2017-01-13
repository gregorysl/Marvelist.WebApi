using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Marvelist.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Marvelist.Tests
{
    [TestClass]
    public class UserComicServiceTests
    {
        private IUserComicService _service;
        private IUserComicRepository _userComicRepository;
        private IComicRepository _comicRepository;
        private IUnitOfWork _unitOfWork;
        private const string UserId = "1";

        [TestInitialize]
        public void Setup()
        {
            _comicRepository = MockRepository.MockComicRepository();
            _userComicRepository = MockRepository.MockUserComicRepository();
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _service = new UserComicService(_userComicRepository, _comicRepository, _unitOfWork);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFollowing()
        {
            var isFollowing = _service.IsFollowing(12767,UserId);
            Assert.IsTrue(isFollowing);
        }
    }
}
