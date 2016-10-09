
//using System.Collections.Generic;
//using System.Linq;
//using Marvelist.DataAccess.Contracts;
//using Marvelist.Entities;

//namespace Marvelist.Service
//{
//    public interface IComicCreatorService
//    {
//        IEnumerable<ComicCreator> GetComicCreators();
//        ComicCreator GetComicCreator(int id);
//        void CreateComicCreator(ComicCreator comicCreator);
//        void DeleteComicCreator(int id);
//        void SaveComicCreator();
//    }

//    public class ComicCreatorService : IComicCreatorService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public ComicCreatorService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        #region IComicCreatorService Members

//        public IEnumerable<ComicCreator> GetComicCreators()
//        {
//            var comicCreator = _unitOfWork.Repository<ComicCreator>().GetAll();
//            return comicCreator;
//        }

//        public ComicCreator GetComicCreator(int id)
//        {
//            var comicCreator = _unitOfWork.Repository<ComicCreator>().Gets(x => x.Id == id).First();
//            return comicCreator;
//        }

//        public void CreateComicCreator(ComicCreator comicCreator)
//        {
//            _unitOfWork.Repository<ComicCreator>().Insert(comicCreator);
//            SaveComicCreator();
//        }

//        public void DeleteComicCreator(int id)
//        {
//            var comicCreator = GetComicCreator(id);
//            _unitOfWork.Repository<ComicCreator>().Delete(comicCreator);
//            SaveComicCreator();
//        }

//        public void SaveComicCreator()
//        {
//            _unitOfWork.Commit();
//        }

//        #endregion
//    }
//}
