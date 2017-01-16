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
    public class UserSeriesServiceTests
    {
        private IUserSeriesService _service;
        private IUserComicService _userComicService;
        private ISeriesRepository _seriesRepository;
        private IUserSeriesRepository _userSeriesRepository;
        private IUserComicRepository _userComicRepository;
        private IComicRepository _comicRepository;
        private IUnitOfWork _unitOfWork;
        private const string UserId = "1";
        private List<UserSeries> _userSeries;
        private List<Comic> _comics;
        private List<Series> _series;
        private List<UserComic> _userComics;

        [TestInitialize]
        public void Setup()
        {
            _comics= new TestData().Comics();
            _series= new TestData().Series();
            _userComics= new TestData().UserComics();
            _userSeries = new TestData().UserSeries();
            _userComicRepository = MockRepository.MockUserComicRepository(_userComics);
            _userSeriesRepository = MockRepository.MockUserSeriesRepository(_userSeries);
            _comicRepository = MockRepository.MockComicRepository(_comics);
            _seriesRepository = MockRepository.MockSeriesRepository(_series);
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _userComicService = new UserComicService(_userComicRepository,_comicRepository,_unitOfWork);
            _service = new UserSeriesService(_userComicService, _userSeriesRepository, _seriesRepository, _unitOfWork);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFollowing()
        {
            var isFollowing = _service.IsFollowing(1997, UserId);
            Assert.IsTrue(isFollowing);
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotFollowing()
        {
            var isFollowing = _service.IsFollowing(1998, UserId);
            Assert.IsFalse(isFollowing);
        }

        [TestMethod]
        public void ShouldAddNewUserSeries()
        {
            var countBefore = _userSeries.Count;
            _service.Add(16410, UserId);
            Assert.AreEqual(countBefore + 1, _userSeries.Count);
        }

        [TestMethod]
        public void ShouldDeleteUserSeries()
        {
            _service.Add(16410, UserId);
            var countBefore = _userSeries.Count;
            _service.Delete(16410, UserId);
            Assert.AreEqual(countBefore - 1, _userSeries.Count);
        }
    }
}