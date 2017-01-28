using System.Web.Http;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class SeriesController : BasicController
    {
        private readonly ISeriesService _series;
        public SeriesController(ISeriesService series)
        {
            _series = series;
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
            var series = _series.GetSeriesDetailsById(id, UserId);
            return Ok(series);
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