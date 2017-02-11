using System.Linq;
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

        [Route("api/Series")]
        public IHttpActionResult GetAll()
        {
            var series = _series.GetAllSeries(UserId);
            return Ok(series);
        }
        
        [Route("api/Series/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var series = _series.GetById(id);
            var isFollowing = _userSeries.IsFollowing(id, UserId);
            var comics = _userComic.GetAllFollowingForSeriesId(id, UserId);
            var results = new SeriesComicsViewModel
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

        [Route("api/Series/y{year:int}")]
        public IHttpActionResult GetByYear(int year)
        {
            var series = _series.GetByYear(year,UserId);
            return Ok(series);
        }
        //Todo: New comics
    }
}