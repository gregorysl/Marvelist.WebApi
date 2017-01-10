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
    public class SeriesServiceTests
    {
        private ISeriesService _seriesService;
        private ISeriesRepository _seriesRepository;
        IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _seriesRepository = MockRepository.MockSeriesRepository();
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _seriesService = new SeriesService(_seriesRepository, _unitOfWork);
        }

        [TestMethod]
        public void ShouldReturnAllSeries()
        {
            var series = _seriesService.All();
            Assert.AreEqual(series, TestData.Series);
        }
        [TestMethod]
        public void ShouldAddNewSeries()
        {
            var serie = new Series
            {
                StartYear = DateTime.Now.Year,
                Title = "SeriesServiceTests"
            };
            var countBefore = TestData.Series.Count;
            _seriesService.Add(serie);
            Assert.AreEqual(serie.Title, TestData.Series.Find(x=>x.Id==serie.Id).Title);
        }

        [TestMethod]
        public void ShouldReturnRightSeries()
        {
            var series = _seriesService.GetSeriesById(1997);
            Assert.AreEqual(series, TestData.Series.Find(x => x.Id == 1997));
        }

        [TestMethod]
        public void ShouldReturnRightSeriesForYear()
        {
            var series = _seriesService.GetByYear(2013);
            Assert.AreEqual(series.Count, 1);
        }

        [TestMethod]
        public void ShouldReturnRightSeriesForText()
        {
            var series = _seriesService.GetByText("Guardians");
            Assert.AreEqual(series.Count, 1);
            var firstOrDefault = series.FirstOrDefault();
            if (firstOrDefault != null) Assert.AreEqual(firstOrDefault.Title, "Guardians of the Galaxy (2013 - Present)");
            else Assert.Fail("Should return series.");
        }
    }
}