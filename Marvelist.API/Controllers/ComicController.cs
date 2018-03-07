using System;
using System.Linq;
using System.Web.Http;
using Marvelist.API.Helpers;
using Marvelist.Entities.ViewModels;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class ComicController : BasicController
    {
        private readonly IComicService _comicService;
        private readonly IUserComicService _userComicService;

        public ComicController(IComicService comicService, IUserComicService userComicService)
        {
            _comicService = comicService;
            _userComicService = userComicService;
        }

        [Route("api/Comics/")]
        [HttpGet]
        public IHttpActionResult HomeComics()
        {
            var comics = _comicService.GetHomeComics(UserId);
            var readComics = _userComicService.GetAllFollowingId(UserId);
            var results = comics.Select(c => new ComicsViewModel
            {
                Date = c.Date,
                Description = c.Description,
                DiamondCode = c.DiamondCode,
                EAN = c.EAN,
                Id = c.Id,
                Title = c.Title,
                IssueNumber = c.IssueNumber,
                ThumbnailData = c.Thumbnail,
                Url = c.Url,
                Following = readComics.Contains(c.Id),
                ISBN = c.ISBN,
                ISSN = c.ISSN,
                PageCount = c.PageCount,
                Price = c.Price,
                UPC = c.UPC,
                SeriesId = c.SeriesId
            }).OrderBy(c => c.Date).ThenBy(c => c.Title).ToList();
            return Ok(results);
        }

        [Route("api/Week/{weekYear}")]
        [HttpGet]
        public IHttpActionResult ComicsForWeekOfYear(string weekYear, int page = 0, int pagesize = 50)
        {
            var data = weekYear.Split('-');
            var week = Convert.ToInt32(data[0]);
            var year = Convert.ToInt32(data[1]);
            var weekStart = DateHelper.FirstDayOfWeek(year, week);
            var weekEnd = weekStart.AddWeek();
            var comics = _comicService.GetComicsForWeek(weekStart, weekEnd);
            var readComics = _userComicService.GetAllFollowingId(UserId);

            var results = comics.Select(c => new ComicsViewModel
            {
                Date = c.Date,
                Description = c.Description,
                DiamondCode = c.DiamondCode,
                EAN = c.EAN,
                Id = c.Id,
                Title = c.Title,
                IssueNumber = c.IssueNumber,
                ThumbnailData = c.Thumbnail,
                Url = c.Url,
                Following = readComics.Contains(c.Id),
                ISBN = c.ISBN,
                ISSN = c.ISSN,
                PageCount = c.PageCount,
                Price = c.Price,
                UPC = c.UPC,
                SeriesId = c.SeriesId
            }).OrderBy(c => c.Date).ThenBy(c => c.Title).ToList();
            return Ok(results);
        }
    }
}