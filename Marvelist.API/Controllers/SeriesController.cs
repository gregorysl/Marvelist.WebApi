using System.Web.Http;
using Marvelist.API.Helpers;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class SeriesController : BasicController
    {
        private readonly ISeriesService _series;
        private readonly IUserSeriesService _userSeries;

        public SeriesController(ISeriesService series, IUserSeriesService userSeries)
        {
            _series = series;
            _userSeries = userSeries;
        }

        [Route("api/Series")]
        public IHttpActionResult GetAll()
        {
            var series = _series.All().ToListSeriesViewModel(_userSeries, UserId);
            return Ok(series);
        }

        [Route("api/Series/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var series = _series.GetSeriesById(id).ToSeriesComicsViewModel(_userSeries,UserId);
            return Ok(series);
        }

        [Route("api/Series/y{year:int}")]
        public IHttpActionResult GetByYear(int year)
        {
            var series = _series.GetByYear(year).ToListSeriesViewModel(_userSeries,UserId);
            return Ok(series);
        }
        
        //Todo: New comics
    }
}