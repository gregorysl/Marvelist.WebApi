using System;
using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;

namespace Marvelist.Service
{
    public class UserSeriesService : IUserSeriesService
    {
        private readonly IUserSeriesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserSeriesService(IUserSeriesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void AddOrDelete(int id, string userId)
        {
            if (IsFollowing(id, userId))
            {
                var userSeries = GetById(id);
                _repository.Delete(userSeries);
                //Todo delete all comics
            }
            else
            {
                var userSeries = new UserSeries
                {
                    Date = DateTime.Now,
                    SeriesId = id,
                    UserId = userId
                };
                _repository.Add(userSeries);
            }
        }
        
        public UserSeries GetById(int id)
        {
            var userComic = _repository.GetMany(u => u.Id == id).FirstOrDefault();
            return userComic;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<UserSeries> All()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Series> GetAllFollowing(string id)
        {
            var comics = _repository.Query(x => x.UserId == id).Select(x => x.Series).ToList();
            return comics;
        }

        public bool IsFollowing(int id, string userId)
        {
            var isFollowing = _repository.Query(x => x.UserId == userId && x.Id == id).Any();
            return isFollowing;
        }

    }

    public interface IUserSeriesService
    {
        UserSeries GetById(int id);
        void AddOrDelete(int id, string userId);
        IEnumerable<UserSeries> All();
        IEnumerable<Series> GetAllFollowing(string id);
        bool IsFollowing(int id, string userId);

    }
}