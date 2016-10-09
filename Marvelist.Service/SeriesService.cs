
//using System.Collections.Generic;
//using System.Linq;
//using Marvelist.DataAccess.Contracts;
//using Marvelist.DataAccess.Repositories;
//using Marvelist.Entities;

//namespace Marvelist.Service
//{
//    public interface ISeriesService
//    {
//        IEnumerable<Series> GetSeriess();
//        //Series GetSeries(int id);
//        //void CreateSeries(Series Series);
//        //void DeleteSeries(int id);
//        //void SaveSeries();
//    }

//    public class SeriesService : ISeriesService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public SeriesService( IUserRepository Is, IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        #region ISeriesService Members

//        public IEnumerable<Series> GetSeriess()
//        {
//            var Series = _unitOfWork.Repository<Series>().GetAll();
//            return Series;
//        }

//        public Series GetSeries(int id)
//        {
//            var Series = _unitOfWork.Repository<Series>().Gets(x => x.Id == id).First();
//            return Series;
//        }

//        public void CreateSeries(Series Series)
//        {
//            _unitOfWork.Repository<Series>().Insert(Series);
//            SaveSeries();
//        }

//        public void DeleteSeries(int id)
//        {
//            var Series = GetSeries(id);
//            _unitOfWork.Repository<Series>().Delete(Series);
//            SaveSeries();
//        }

//        public void SaveSeries()
//        {
//            _unitOfWork.Commit();
//        }

//        #endregion
//    }
//}
