using System.Linq;
using System.Web.Http;
using Marvelist.API.Helpers;
using Marvelist.API.ViewModels;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class SearchController : BasicController
    {
        private readonly ISeriesService _seriesService;
        private readonly IUserSeriesService _userSeriesService;

        public SearchController(ISeriesService servicesService, IUserSeriesService userSeriesService)
        {
            _seriesService = servicesService;
            _userSeriesService = userSeriesService;
        }

        [Route("api/Search/{text}")]
        [HttpGet]
        public IHttpActionResult Search(string text)
        {
            var series = _seriesService.GetByText(text).ToList();
            var svm = series.ToSeriesViewModel(_userSeriesService, UserId);
            return Ok(svm);
        }
    }
}