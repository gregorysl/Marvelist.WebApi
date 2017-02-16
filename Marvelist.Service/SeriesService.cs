﻿using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Marvelist.Entities.ViewModels;

namespace Marvelist.Service
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SeriesService(ISeriesRepository seriesRepository, IUnitOfWork unitOfWork)
        {
            _seriesRepository = seriesRepository;
            _unitOfWork = unitOfWork;
        }


        public Series GetById(int id)
        {
            return _seriesRepository.GetById(id);
        }
        
        public Series Add(Series series)
        {
            series = _seriesRepository.Add(series);
            SaveChanges();
            return series;
        }

        public List<Series> All()
        {
            return _seriesRepository.GetAll();
        }

        public List<SeriesViewModel> GetAllSeries(string userId)
        {
            return _seriesRepository.GetAllSeries(userId);
        }
        public List<SeriesComicsViewModel> GetAllFollowedSeries(string userId)
        {
            return _seriesRepository.GetAllFollowedSeries(userId);
        }

        public List<SeriesViewModel> GetByYear(int year, string userId)
        {
            var series = _seriesRepository.GetByYear(year, userId);
            return series;
        }

        public List<SeriesViewModel> GetByText(string text, string userId)
        {
            var series = _seriesRepository.Filter(text, userId).ToList();
            return series.ToList();
        }

        public SeriesViewModel GetSeriesById(int id, string userId)
        {
            var series = _seriesRepository.GetSeriesById(id, userId);
            return series;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }

    public interface ISeriesService
    {
        List<SeriesViewModel> GetAllSeries(string userId);
        List<SeriesComicsViewModel> GetAllFollowedSeries(string userId);
        SeriesViewModel GetSeriesById(int id, string userId);
        Series GetById(int id);
        Series Add(Series series);
        List<Series> All();
        List<SeriesViewModel> GetByYear(int year, string userId);
        List<SeriesViewModel> GetByText(string text, string userId);
    }
}