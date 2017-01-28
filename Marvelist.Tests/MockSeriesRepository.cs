﻿using System;
using System.Collections.Generic;
using System.Linq;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;
using Marvelist.Entities.ViewModels;
using Moq;

namespace Marvelist.Tests
{
    public partial class MockRepository
    {
        public static ISeriesRepository MockSeriesRepository(List<Series> series)
        {
            var repo = new Mock<ISeriesRepository>();
            repo.Setup(x => x.GetAll()).Returns(series);
            repo.Setup(x => x.Add(It.IsAny<Series>()))
                .Callback(new Action<Series>(s =>
                {
                    s.Id = series.Last().Id + 1;
                    series.Add(s);
                }));
            repo.Setup(x => x.Filter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new Func<string,string, List<SeriesViewModel>>((id,userId) => Filter(id,userId, series)));
            repo.Setup(x => x.GetByYear(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Func<int,string, List<SeriesViewModel>>((year,userId) => GetForYear(series, year, userId)));
            repo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Series>(id => series.Find(x => x.Id == id)));
            return repo.Object;
        }

        private static List<SeriesViewModel> GetForYear(List<Series> series, int year, string userId)
        {
            var forYear = series.Where(x => x.StartYear == year).OrderBy(x => x.StartYear).AsQueryable();
            return ToSeriesViewModel(forYear,userId);
        }

        private static List<SeriesViewModel> Filter(string id,string userId, IEnumerable<Series> series)
        {
            var filter = id.Split(' ').Aggregate(series, (current, txt) => current.Where(x => x.Title.Contains(txt))).AsQueryable();
            return ToSeriesViewModel(filter,userId);
        }


        private static List<SeriesViewModel> ToSeriesViewModel(IQueryable<Series> query, string userId)
        {
            return query.Select(c => new SeriesViewModel
            {
                Id = c.Id,
                ComicCount = c.Comics.Count,
                Description = c.Description,
                Following = false,
                ThumbnailData = c.Thumbnail,
                Title = c.Title,
                Url = c.Url
            }).ToList();

        }
    }
}