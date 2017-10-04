using System.Collections.Generic;
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
        
        public SeriesPaginatedModel GetAllSeries(string userId, int page, int pagesize)
        {
            return _seriesRepository.GetAllSeries(userId, page, pagesize);
        }
        public SeriesPaginatedModel GetAllFollowedSeries(string userId)
        {
            return _seriesRepository.GetAllFollowedSeries(userId);
        }

        public SeriesPaginatedModel GetByYear(int year, string userId, int page, int pagesize)
        {
            var series = _seriesRepository.GetByYear(year, userId, page, pagesize);
            return series;
        }

        public SeriesPaginatedModel GetByText(string text, string userId, int page, int pagesize)
        {
            var series = _seriesRepository.Filter(text, userId, page, pagesize);
            return series;
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
        SeriesPaginatedModel GetAllSeries(string userId, int page, int pagesize);
        SeriesPaginatedModel GetAllFollowedSeries(string userId);
        SeriesViewModel GetSeriesById(int id, string userId);
        Series GetById(int id);
        Series Add(Series series);
        SeriesPaginatedModel GetByYear(int year, string userId, int page, int pagesize);
        SeriesPaginatedModel GetByText(string text, string userId, int page, int pagesize);
    }
}