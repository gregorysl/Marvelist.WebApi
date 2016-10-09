
//using System.Collections.Generic;
//using System.Linq;
//using Marvelist.DataAccess.Contracts;
//using Marvelist.Entities;

//namespace Marvelist.Service
//{
//    public interface IUserSeriesService
//    {
//        IEnumerable<UserSeries> GetUserSeriess();
//    }

//    public class UserSeriesService : IUserSeriesService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IUserSeriesService _userSeriesRepository;

//        public UserSeriesService(userSeriesRepository userSeriesRepository, IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//            _userSeriesRepository = userSeriesRepository;
//        }

//        #region IUserSeriesService Members

//        public IEnumerable<UserSeries> GetUserSeriess()
//        {
//            var UserSeries = _userSeriesRepository.GetUserSeriess();
//            return UserSeries;
//        }
        

//        public void CreateUserSeries(UserSeries UserSeries)
//        {
//            //_userSeriesRepository.Insert(UserSeries);
//            SaveUserSeries();
//        }

//        public void DeleteUserSeries(int id)
//        {
//        //    var UserSeries = GetUserSeries(id);
//            //_userSeriesRepository.Delete(UserSeries);
//            SaveUserSeries();
//        }

//        public void SaveUserSeries()
//        {
//            _unitOfWork.SaveChanges();
//        }

//        #endregion
//    }
//}
