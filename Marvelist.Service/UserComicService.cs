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
        private readonly IComicRepository _comicRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserComicService(IUserComicRepository repository, IComicRepository comicRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _comicRepository = comicRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddAll(List<int> comicsList, string userId)
        {
            var contains =_repository.Query(x => comicsList.Contains(x.Id)).Select(x=>x.Id);
            var filtered = comicsList.Except(contains);
            foreach (var comic in filtered)
            {
                Add(comic, userId);
            }
        }

        public void DeleteAllForSeries(int seriesId, string userId)
        {
            _repository.DeleteMany(x => x.UserId == userId && x.Comic.SeriesId == seriesId);
            SaveChanges();
        }

        public void Add(int id, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) || !IsFollowing(id, userId))
            {
                var comic = _comicRepository.GetById(id);
                if (comic == null) return;

                var userComic = new UserComic
                {
                    Date = DateTime.Now,
                    ComicId = id,
                    UserId = userId
                };
                _repository.Add(userComic);
            }
            SaveChanges();
        }

        public void Delete(int id, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) || IsFollowing(id, userId))
            {
                var comic = _comicRepository.GetById(id);
                if (comic == null) return;
                var userComic = GetById(id);
                _repository.Delete(userComic);
            }
            SaveChanges();
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
            var userComic = _repository.GetMany(u => u.ComicId == id).FirstOrDefault();
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
        void Delete(int id, string userId);
        void Add(int id, string userId);
        void AddAll(List<int> comicsList, string userId);
        void DeleteAllForSeries(int seriesId, string userId);
        IEnumerable<UserComic> All();
        IEnumerable<Comic> GetAllFollowing(string id);
        bool IsFollowing(int id, string userId);
    }
}