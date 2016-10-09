
//using System.Collections.Generic;
//using System.Linq;
//using Marvelist.DataAccess.Contracts;
//using Marvelist.Entities;

//namespace Marvelist.Service
//{
//    public interface IComicService
//    {
//        IEnumerable<Comic> GetComics();
//        Comic GetComic(int id);
//        void CreateComic(Comic comic);
//        void DeleteComic(int id);
//        void SaveComic();
//    }

//    public class ComicService : IComicService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public ComicService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        #region IComicService Members

//        public IEnumerable<Comic> GetComics()
//        {
//            var comic = _unitOfWork.Repository<Comic>().GetAll();
//            return comic;
//        }

//        public Comic GetComic(int id)
//        {
//            var comic = _unitOfWork.Repository<Comic>().Gets(x => x.Id == id).First();
//            return comic;
//        }

//        public void CreateComic(Comic comic)
//        {
//            _unitOfWork.Repository<Comic>().Insert(comic);
//            SaveComic();
//        }

//        public void DeleteComic(int id)
//        {
//            var comic = GetComic(id);
//            _unitOfWork.Repository<Comic>().Delete(comic);
//            SaveComic();
//        }

//        public void SaveComic()
//        {
//            _unitOfWork.Commit();
//        }

//        #endregion
//    }
//}
