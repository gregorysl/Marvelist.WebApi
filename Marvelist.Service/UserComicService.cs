using System;
using System.Collections.Generic;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Marvelist.Entities.ViewModels;

namespace Marvelist.Service
{
    public class UserComicService : IUserComicService
    {
        private readonly IUserComicRepository _repository;
        private readonly IComicRepository _comicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserComicService(IUserComicRepository repository, IComicRepository comicRepository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _comicRepository = comicRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddAll(List<int> comicsList, string userId)
        {
            var filtered = _repository.FilterFollowed(comicsList, userId);
            foreach (var comic in filtered)
            {
                Add(comic, userId);
            }
        }

        public void DeleteAllForSeries(int seriesId, string userId)
        {
            _repository.DeleteAllForSeries(seriesId, userId);
            SaveChanges();
        }

        public void Add(int id, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) return;
            var comic = _comicRepository.GetById(id);
            if (comic == null) return;
            if (IsFollowing(id, userId)) return;

            var userComic = new UserComic
            {
                Date = DateTime.Now,
                ComicId = id,
                UserId = userId
            };
            _repository.Add(userComic);
            SaveChanges();
        }

        public void Delete(int id, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) || IsFollowing(id, userId))
            {
                _repository.DeleteByComicId(id, userId);
                SaveChanges();
            }
        }

        public List<Comic> GetAllFollowing(string id)
        {
            var comics = _repository.GetAllFollowing(id);
            return comics;
        }

        public List<int> GetAllFollowingId(string id)
        {
            var ids = _repository.GetAllFollowingId(id);
            return ids;
        }

        public List<ComicsViewModel> GetAllFollowingForSeriesId(int seriesId, string userId)
        {
            return _repository.GetAllFollowingForSeriesId(seriesId, userId);
        }

        public bool IsFollowing(int id, string userId)
        {
            if (string.IsNullOrEmpty(userId)) return false;
            var isFollowing = _repository.IsFollowing(id, userId);
            return isFollowing;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }

    public interface IUserComicService
    {
        void Delete(int id, string userId);
        void Add(int id, string userId);
        void AddAll(List<int> comicsList, string userId);
        void DeleteAllForSeries(int seriesId, string userId);
        List<Comic> GetAllFollowing(string id);
        List<int> GetAllFollowingId(string id);
        List<ComicsViewModel> GetAllFollowingForSeriesId(int seriesId, string userId);
        bool IsFollowing(int id, string userId);
    }
}
