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

        public IEnumerable<Series> All()
        {
            return _seriesRepository.GetAll();
        }

        public IEnumerable<Series> GetByYear(int year)
        {
            var series = _seriesRepository.Query(x => x.StartYear >= year).OrderBy(x => x.StartYear).ToList();
            return series;
        }

        public IEnumerable<Series> GetByText(string text)
        {
            IEnumerable<Series> series = _seriesRepository.Query(x=>true);
            var keywords = text.Split(' ');
            series = keywords.Aggregate(series, (current, keyword) => current.Where(x => x.Title == keyword));
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
        IEnumerable<Series> All();
        IEnumerable<Series> GetByYear(int year);
        IEnumerable<Series> GetByText(string text);
    }
}