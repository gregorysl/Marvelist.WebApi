using System;
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
    public class ComicsServiceTests
    {
        private IComicService _comicService;
        private IComicRepository _comicRepository;
        private IUnitOfWork _unitOfWork;
        private List<Comic> _comics;

        [TestInitialize]
        public void Setup()
        {
            _comics = new TestData().Comics();
            _comicRepository = MockRepository.MockComicRepository(_comics);
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _comicService = new ComicService(_comicRepository, _unitOfWork);
        }

        [TestMethod]
        public void ShouldReturnAllComics()
        {
            var comic = _comicService.All();
            Assert.AreEqual(_comics, comic);
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
            Assert.AreEqual(_comics.Find(x => x.Id == comic.Id).Title, comic.Title);
        }

        [TestMethod]
        public void ShouldReturnComicById()
        {
            const int id = 12767;
            var comic = _comicService.GetById(id);
            Assert.AreEqual(_comics.Find(x => x.Id == id), comic);
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