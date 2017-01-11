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
        IUnitOfWork _unitOfWork;

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
            Assert.AreEqual(comic, TestData.Comics);
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
            Assert.AreEqual(comic.Title, TestData.Comics.Find(x=>x.Id== comic.Id).Title);
        }

        [TestMethod]
        public void ShouldReturnRightComicById()
        {
            const int id = 12767;
            var comic = _comicService.GetById(id);
            Assert.AreEqual(comic, TestData.Comics.Find(x => x.Id == id));
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