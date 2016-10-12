using System;
using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;

namespace Marvelist.Service
{
    public class ComicService : IComicService
    {
        private readonly IComicRepository _comicRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ComicService(IComicRepository comicRepository, IUnitOfWork unitOfWork)
        {
            _comicRepository = comicRepository;
            _unitOfWork = unitOfWork;
        }


        public Comic Add(Comic comic)
        {
            comic = _comicRepository.Add(comic);
            SaveChanges();
            return comic;
        }

        public IEnumerable<Comic> All()
        {
            return _comicRepository.GetAll();
        }
        

        public IEnumerable<Comic> GetByText(string text)
        {
            IEnumerable<Comic> comic = _comicRepository.Query(x => true);
            var keywords = text.Split(' ');
            comic = keywords.Aggregate(comic, (current, keyword) => current.Where(x => x.Title == keyword));
            return comic.ToList();
        }

        public IEnumerable<Comic> GetComicsForSeriesId(int id)
        {
            var comics = _comicRepository.GetMany(x => x.SeriesId == id);
            return comics;
            //Todo order
        }

        public IEnumerable<Comic> GetComicsForCurrentWeek(DateTime weekStart, DateTime weekEnd)
        {
            var comics = _comicRepository.Query(x => x.Date > weekStart && x.Date < weekEnd).OrderBy(x => x.Title).ToList();
            return comics;
        }

        public Comic GetById(int id)
        {
            var comic = _comicRepository.GetMany(u => u.Id == id).FirstOrDefault();
            return comic;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }

    public interface IComicService
    {
        Comic GetById(int id);
        Comic Add(Comic comic);
        IEnumerable<Comic> All();
        IEnumerable<Comic> GetByText(string text);
        IEnumerable<Comic> GetComicsForSeriesId(int id);
        IEnumerable<Comic> GetComicsForCurrentWeek(DateTime weekStart, DateTime weekEnd);
    }
}