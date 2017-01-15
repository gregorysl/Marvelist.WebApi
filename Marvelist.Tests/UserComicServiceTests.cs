using System.Collections.Generic;
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
        private List<UserComic> _userComics;
        private List<Comic> _comics;

        [TestInitialize]
        public void Setup()
        {
            _userComics = new TestData().UserComics();
            _comics = new TestData().Comics();
            _comicRepository = MockRepository.MockComicRepository(_comics);
            _userComicRepository = MockRepository.MockUserComicRepository(_userComics);
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _service = new UserComicService(_userComicRepository, _comicRepository, _unitOfWork);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFollowing()
        {
            var isFollowing = _service.IsFollowing(12767, UserId);
            Assert.IsTrue(isFollowing);
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotFollowing()
        {
            var isFollowing = _service.IsFollowing(12769, UserId);
            Assert.IsFalse(isFollowing);
        }

        [TestMethod]
        public void ShouldAddNewUserComic()
        {
            var countBefore = _userComics.Count;
            _service.Add(12768, UserId);
            Assert.AreEqual(countBefore + 1, _userComics.Count);
        }

        [TestMethod]
        public void ShouldDeleteUserComic()
        {
            _service.Add(12793, UserId);
            var countBefore = _userComics.Count;
            _service.Delete(12793, UserId);
            Assert.AreEqual(countBefore - 1, _userComics.Count);
        }

        [TestMethod]
        public void ShouldAddAllUserComicsFromList()
        {
            var addList = new List<int> { 12770, 12771, 12772 };
            var countBefore = _userComics.Count;
            _service.AddAll(addList, UserId);
            Assert.AreEqual(countBefore + addList.Count, _userComics.Count);
        }

        [TestMethod]
        public void ShouldAddAllUserComicsFromListExcepExisting()
        {
            var addList = new List<int> { 12767, 12773, 12774 };
            var countBefore = _userComics.Count;
            _service.AddAll(addList, UserId);
            Assert.AreEqual(countBefore + addList.Count - 1, _userComics.Count);
        }

        [TestMethod]
        public void ShouldDeleteAllFollowedSeriesForSeriesId()
        {
            _service.DeleteAllForSeries(1997, UserId);
            Assert.AreEqual(0, _userComics.Count);
        }
    }
}
