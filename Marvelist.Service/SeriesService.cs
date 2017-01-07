using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;

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

        public List<Series> GetByYear(int year)
        {
            var series = _seriesRepository.GetByYear(year);
            return series;
        }

        public List<Series> GetByText(string text)
        {
            IList<Series> series = _seriesRepository.Filter(text).ToList();
            return series.ToList();
        }

        public Series GetSeriesById(int id)
        {
            var series = _seriesRepository.GetMany(u => u.Id == id).FirstOrDefault();
            return series;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }

    public interface ISeriesService
    {
        Series GetSeriesById(int id);
        Series Add(Series series);
        List<Series> All();
        List<Series> GetByYear(int year);
        List<Series> GetByText(string text);
    }
}