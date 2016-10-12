using System;
using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;

namespace Marvelist.Service
{
    public class UserComicService : IUserComicService
    {
        private readonly IUserComicRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserComicService(IUserComicRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public UserComic Add(UserComic userComic)
        {
            userComic = _repository.Add(userComic);
            SaveChanges();
            return userComic;
        }

        public void AddOrDelete(int id, string userId)
        {
            if (IsFollowing(id, userId))
            {
                var userComic = GetById(id);
                _repository.Delete(userComic);
            }
            else
            {
                var userComic = new UserComic
                {
                    Date = DateTime.Now,
                    ComicId= id,
                    UserId = userId
                };
                _repository.Add(userComic);
            }
        }

        public IEnumerable<UserComic> All()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Comic> GetAllFollowing(string id)
        {
            var comics = _repository.Query(x => x.UserId == id).Select(x => x.Comic).ToList();
            return comics;
        }

        public bool IsFollowing(int id, string userId)
        {
            var isFollowing = _repository.Query(x => x.UserId == userId && x.Id == id).Any();
            return isFollowing;
        }

        public UserComic GetById(int id)
        {
            var userComic = _repository.GetMany(u => u.Id == id).FirstOrDefault();
            return userComic;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }

    public interface IUserComicService
    {
        UserComic GetById(int id);
        void AddOrDelete(int id, string userId);
        UserComic Add(UserComic userComic);
        IEnumerable<UserComic> All();
        IEnumerable<Comic> GetAllFollowing(string id);
        bool IsFollowing(int id, string userId);
    }
}