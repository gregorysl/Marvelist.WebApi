using System;
using System.Linq;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Marvelist.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Marvelist.Tests
{
    [TestClass]
    public class ComicsServiceTests
    {
        private IComicService _comicService;
        private IComicRepository _comicRepository;
        private IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _comicRepository = MockRepository.MockComicRepository();
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _comicService = new ComicService(_comicRepository, _unitOfWork);
        }

        [TestMethod]
        public void ShouldReturnAllComics()
        {
            var comic = _comicService.All();
            Assert.AreEqual(TestData.Comics, comic);
        }
        [TestMethod]
        public void ShouldAddNewComic()
        {
            var comic = new Comic
            {
                Date = DateTime.Now,
                Title = "comicServiceTests"
            };
            _comicService.Add(comic);
            Assert.AreEqual(TestData.Comics.Find(x => x.Id == comic.Id).Title, comic.Title);
        }

        [TestMethod]
        public void ShouldReturnComicById()
        {
            const int id = 12767;
            var comic = _comicService.GetById(id);
            Assert.AreEqual(TestData.Comics.Find(x => x.Id == id), comic);
        }

        [TestMethod]
        public void ShouldReturnNullById()
        {
            const int id = 127617;
            var comic = _comicService.GetById(id);
            Assert.AreEqual(null, comic);
        }

        [TestMethod]
        public void ShouldReturnComicsListForSeriesId()
        {
            var comic = _comicService.GetComicsForSeriesId(1997);
            Assert.AreEqual(50, comic.Count);
        }

        [TestMethod]
        public void ShouldReturnEmptyListForWrongSeriesId()
        {
            var comic = _comicService.GetComicsForSeriesId(1);
            Assert.AreEqual(0, comic.Count);
        }

    }
}