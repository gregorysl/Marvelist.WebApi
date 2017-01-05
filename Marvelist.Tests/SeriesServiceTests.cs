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
    public class SeriesServiceTests
    {
        private ISeriesService _seriesService;
        private ISeriesRepository _seriesRepository;
        IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _seriesRepository = SetupSeriesRepository();
            
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _seriesService = new SeriesService(_seriesRepository, _unitOfWork);

        }

        private ISeriesRepository SetupSeriesRepository()
        {
            var repo = new Mock<ISeriesRepository>();
            repo.Setup(x => x.GetMany(z=>true)).Returns(new List<Series>());
            return repo.Object;
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
