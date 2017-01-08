using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
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
        public void TestMethod1()
        {
        }
    }
}
