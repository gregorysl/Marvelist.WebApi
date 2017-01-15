﻿using System;
using System.Collections.Generic;
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
        private IUnitOfWork _unitOfWork;
        private List<Series> _series;

        [TestInitialize]
        public void Setup()
        {
            _series = new TestData().Series();
            _seriesRepository = MockRepository.MockSeriesRepository(_series);
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _seriesService = new SeriesService(_seriesRepository, _unitOfWork);
        }

        [TestMethod]
        public void ShouldReturnAllSeries()
        {
            var series = _seriesService.All();
            Assert.AreEqual(_series, series);
        }

        [TestMethod]
        public void ShouldAddNewSeries()
        {
            var serie = new Series
            {
                StartYear = DateTime.Now.Year,
                Title = "SeriesServiceTests"
            };
            _seriesService.Add(serie);
            Assert.AreEqual(_series.Find(x => x.Id == serie.Id).Title, serie.Title);
        }

        [TestMethod]
        public void ShouldReturnRightSeries()
        {
            const int id = 1997;
            var series = _seriesService.GetSeriesById(id);
            Assert.AreEqual(_series.Find(x => x.Id == id), series);
        }

        [TestMethod]
        public void ShouldReturnNullForId()
        {
            const int id = 19971;
            var series = _seriesService.GetSeriesById(id);
            Assert.AreEqual(null, series);
        }

        [TestMethod]
        public void ShouldReturnRightSeriesForYear()
        {
            var series = _seriesService.GetByYear(2013);
            Assert.AreEqual(1, series.Count);
        }

        [TestMethod]
        public void ShouldReturnEmptyListForYear()
        {
            var series = _seriesService.GetByYear(2020);
            Assert.AreEqual(0, series.Count);
        }

        [TestMethod]
        public void ShouldReturnRightSeriesForText()
        {
            var series = _seriesService.GetByText("Guardians");
            Assert.AreEqual(1, series.Count);
            var firstOrDefault = series.FirstOrDefault();
            if (firstOrDefault != null)
                Assert.AreEqual("Guardians of the Galaxy (2013 - Present)", firstOrDefault.Title);
            else Assert.Fail("Should return series.");
        }

        [TestMethod]
        public void ShouldReturnRightSeriesForText1()
        {
            var series = _seriesService.GetByText("Iron Man");
            Assert.AreEqual(0, series.Count);
        }
    }
}