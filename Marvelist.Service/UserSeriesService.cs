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
            if(string.IsNullOrWhiteSpace(userId))return;
            var series = _seriesRepository.GetById(id);
            if (series == null) return;
            if (IsFollowing(id, userId)) return;

            var userSeries = new UserSeries
            {
                Date = DateTime.Now,
                SeriesId = id,
                UserId = userId
            };
            _repository.Add(userSeries);
            SaveChanges();
        }
        public void Delete(int id, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) || IsFollowing(id, userId))
            {
                _repository.DeleteBySeriesId(id, userId);
                _userComicService.DeleteAllForSeries(id, userId);
                SaveChanges();
            }
        }

        public void AddByComicId(int comicId, string userId)
        {
            var seriesId = _seriesRepository.GetSeriesIdByComicId(comicId);
            if (seriesId.HasValue)
            {
                Add(seriesId.Value, userId);
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<UserSeries> All()
        {
            return _repository.GetAll();
        }

        public List<Series> GetAllFollowing(string userId)
        {
            var comics = _repository.GetAllFollowing(userId);
            return comics;
        }

        public bool IsFollowing(int id, string userId)
        {
            if (string.IsNullOrEmpty(userId)) return false;
            var isFollowing = _repository.IsFollowing(id, userId);
            return isFollowing;
        }
    }

    public interface IUserSeriesService
    {
        void Add(int id, string userId);
        void Delete(int id, string userId);
        void AddByComicId(int comicId, string userId);
        List<UserSeries> All();
        List<Series> GetAllFollowing(string userId);
        bool IsFollowing(int id, string userId);

    }
}