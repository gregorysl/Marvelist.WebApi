
//using System.Collections.Generic;
//using System.Linq;
//using Marvelist.DataAccess.Contracts;
//using Marvelist.Entities;

//namespace Marvelist.Service
//{
//    public interface IUserComicService
//    {
//        IEnumerable<UserComic> GetUserComics();
//        //UserComic GetUserComic(int id);
//        //void CreateUserComic(UserComic UserComic);
//        //void DeleteUserComic(int id);
//        //void SaveUserComic();
//    }

//    public class UserComicService : IUserComicService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IUserComicService _userComicService;

//        public UserComicService(IUserComicService userComicService, IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//            _userComicService = userComicService;
//        }

//        #region IUserComicService Members

//        public IEnumerable<UserComic> GetUserComics()
//        {
//            var userComic = _userComicService.GetUserComics();
//            return userComic;
//        }

//        //public UserComic GetUserComic(int id)
//        //{
//        //    var UserComic = _unitOfWork.Repository<UserComic>().Gets(x => x.Id == id).First();
//        //    return UserComic;
//        //}

//        //public void CreateUserComic(UserComic UserComic)
//        //{
//        //    _unitOfWork.Repository<UserComic>().Insert(UserComic);
//        //    SaveUserComic();
//        //}

//        //public void DeleteUserComic(int id)
//        //{
//        //    var UserComic = GetUserComic(id);
//        //    _unitOfWork.Repository<UserComic>().Delete(UserComic);
//        //    SaveUserComic();
//        //}

//        //public void SaveUserComic()
//        //{
//        //    _unitOfWork.Commit();
//        //}

//        #endregion
//    }
//}
