using System.Linq;
using System.Web.Http;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class SearchController : BasicController
    {
        private readonly ISeriesService _seriesService;

        public SearchController(ISeriesService servicesService)
        {
            _seriesService = servicesService;
        }

        [Route("api/Search/{text}")]
        [HttpGet]
        public IHttpActionResult Search(string text)
        {
            var series = _seriesService.GetByText(text,UserId);
            return Ok(series);
        }
    }
}