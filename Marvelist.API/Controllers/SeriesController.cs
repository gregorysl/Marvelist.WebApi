﻿using System.Linq;
using System.Web.Http;
using Marvelist.Entities.ViewModels;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class SeriesController : BasicController
    {
        private readonly ISeriesService _series;
        private readonly IUserSeriesService _userSeries;
        private readonly IUserComicService _userComic;

        public SeriesController(ISeriesService series, IUserSeriesService userSeries, IUserComicService userComic)
        {
            _series = series;
            _userSeries = userSeries;
            _userComic = userComic;
        }

        [HttpGet]
        [Route("api/Series")]
        public IHttpActionResult GetAll(int page = 0, int pagesize = 50)
        {
            var series = _series.GetAllSeries(UserId, page, pagesize);
            return Ok(series);
        }

        [HttpGet]
        [Route("api/Series/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var series = _series.GetById(id);
            var isFollowing = _userSeries.IsFollowing(id, UserId);
            var comics = _userComic.GetAllFollowingForSeriesId(id, UserId);
            var results = new SeriesWithDetailsViewModel
            {
                Id = series.Id,
                Description = series.Description,
                Following = isFollowing,
                ThumbnailData = series.Thumbnail,
                Title = series.Title,
                Url = series.Url,
                ComicCount = comics.Count,
                Read = comics.Count(x => x.Following),
                Comics = comics
            };
            return Ok(results);
        }

        [HttpGet]
        [Route("api/Series/y{year:int}")]
        public IHttpActionResult GetByYear(int year, int page = 0, int pagesize = 50)
        {
            var series = _series.GetByYear(year, UserId, page, pagesize);
            return Ok(series);
        }

        [HttpGet]
        [Route("api/Dashboard")]
        public IHttpActionResult Dashboard()
        {
            var series = _series.GetAllFollowedSeries(UserId);
            return Ok(series);
        }

        [Route("api/Search/{text}")]
        [HttpGet]
        public IHttpActionResult Search(string text, int page = 0, int pagesize = 50)
        {
            var series = _series.GetByText(text, UserId, page, pagesize);
            return Ok(series);
        }

        //Todo: New comics
    }
}