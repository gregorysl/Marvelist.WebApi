
//using System.Collections.Generic;
//using System.Linq;
//using Marvelist.DataAccess.Contracts;
//using Marvelist.Entities;

//namespace Marvelist.Service
//{
//    public interface ICreatorService
//    {
//        IEnumerable<Creator> GetCreators();
//        Creator GetCreator(int id);
//        void CreateCreator(Creator Creator);
//        void DeleteCreator(int id);
//        void SaveCreator();
//    }

//    public class CreatorService : ICreatorService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CreatorService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        #region ICreatorService Members

//        public IEnumerable<Creator> GetCreators()
//        {
//            var Creator = _unitOfWork.Repository<Creator>().GetAll();
//            return Creator;
//        }

//        public Creator GetCreator(int id)
//        {
//            var Creator = _unitOfWork.Repository<Creator>().Gets(x => x.Id == id).First();
//            return Creator;
//        }

//        public void CreateCreator(Creator Creator)
//        {
//            _unitOfWork.Repository<Creator>().Insert(Creator);
//            SaveCreator();
//        }

//        public void DeleteCreator(int id)
//        {
//            var Creator = GetCreator(id);
//            _unitOfWork.Repository<Creator>().Delete(Creator);
//            SaveCreator();
//        }

//        public void SaveCreator()
//        {
//            _unitOfWork.Commit();
//        }

//        #endregion
//    }
//}
