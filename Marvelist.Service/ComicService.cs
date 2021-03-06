﻿using System;
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

        public List<Comic> GetHomeComics(string userId)
        {
            var comics = _comicRepository.GetHomeComics(userId);
            return comics;
        }

        public Comic Add(Comic comic)
        {
            comic = _comicRepository.Add(comic);
            SaveChanges();
            return comic;
        }

        public List<Comic> All()
        {
            return _comicRepository.GetAll();
        }

        public List<Comic> GetComicsForSeriesId(int id)
        {
            var comics = _comicRepository.GetForSeriesId(id);
            return comics;
        }
        public int GetSeriesIdForComicId(int id)
        {
            var comics = _comicRepository.GetSeriesIdForComicId(id);
            return comics;
        }

        public List<Comic> GetComicsForWeek(DateTime weekStart, DateTime weekEnd)
        {
            var comics = _comicRepository.GetComicsForWeek(weekStart, weekEnd);
            return comics;
        }

        public Comic GetById(int id)
        {
            var comic = _comicRepository.GetById(id);
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
        List<Comic> All();
        List<Comic> GetComicsForSeriesId(int id);
        List<Comic> GetComicsForWeek(DateTime weekStart, DateTime weekEnd);
        List<Comic> GetHomeComics(string userId);
        int GetSeriesIdForComicId(int id);
    }
}