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
        private readonly IUserSeriesService _userSeriesService;
        private readonly IUserComicRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserComicService(IUserSeriesService userSeriesService, IUserComicRepository repository, IUnitOfWork unitOfWork)
        {
            _userSeriesService = userSeriesService;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void AddAll(List<int> comicsList, string userId)
        {
            var contains =_repository.Query(x => comicsList.Contains(x.Id)).Select(x=>x.Id);
            var filtered = comicsList.Except(contains);
            foreach (var comic in filtered)
            {
                AddOrDelete(comic, userId);
            }
        }

        public void DeleteAllForSeries(int seriesId, string userId)
        {
            _repository.DeleteMany(x => x.UserId == userId && x.Comic.SeriesId == seriesId);
            SaveChanges();
        }

        public bool AddOrDelete(int id, string userId)
        {
            bool following;
            if (IsFollowing(id, userId))
            {
                var userComic = GetById(id);
                _repository.Delete(userComic);
                following = false;
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
                _userSeriesService.AddByComicId(id,userId);
                following = true;
            }
            SaveChanges();
            return following;
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
        bool AddOrDelete(int id, string userId);
        void AddAll(List<int> comicsList, string userId);
        void DeleteAllForSeries(int seriesId, string userId);
        IEnumerable<UserComic> All();
        IEnumerable<Comic> GetAllFollowing(string id);
        bool IsFollowing(int id, string userId);
    }
}