﻿using System;
using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;

namespace Marvelist.Service
{
    public class UserSeriesService : IUserSeriesService
    {
        private readonly IUserComicService _userComicService;
        private readonly IUserSeriesRepository _repository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserSeriesService(IUserComicService userComicService, IUserSeriesRepository repository, ISeriesRepository seriesRepository, IUnitOfWork unitOfWork)
        {
            _userComicService = userComicService;
            _seriesRepository = seriesRepository;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(int id, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)|| !IsFollowing(id, userId))
            {
                var series = _seriesRepository.GetById(id);
                if(series==null)return;
                
                var userSeries = new UserSeries
                {
                    Date = DateTime.Now,
                    SeriesId = id,
                    UserId = userId
                };
                _repository.Add(userSeries);
            }
            SaveChanges();
        }
        public void Delete(int id, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) || IsFollowing(id, userId))
            {
                var series = _seriesRepository.GetById(id);
                if (series == null) return;

                var userSeries = GetById(id);
                _repository.Delete(userSeries);
                _userComicService.DeleteAllForSeries(id,userId);
            }
        }

        public void AddByComicId(int comicId, string userId)
        {
            var seriesId = _seriesRepository.Query(x => x.Comics.Any(z => z.Id == comicId)).First().Id;
            Add(seriesId,userId);
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

        public IEnumerable<Series> GetAllFollowing(string userId)
        {
            var comics = _repository.Query(x => x.UserId == userId).Select(x => x.Series).ToList();
            return comics;
        }

        public bool IsFollowing(int id, string userId)
        {
            var isFollowing = _repository.Query(x => x.UserId == userId && x.SeriesId == id).Any();
            return isFollowing;
        }

    }

    public interface IUserSeriesService
    {
        UserSeries GetById(int id);
        void Add(int id, string userId);
        void Delete(int id, string userId);
        void AddByComicId(int comicId, string userId);
        IEnumerable<UserSeries> All();
        IEnumerable<Series> GetAllFollowing(string userId);
        bool IsFollowing(int id, string userId);

    }
}