using System.Web.Http;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    [RoutePrefix("api/FollowS")]
    public class UserSeriesController : BasicController
    {
        private readonly IUserSeriesService _userSeries;

        public UserSeriesController(IUserSeriesService userSeries)
        {
            _userSeries = userSeries;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Follow(int id)
        {
            if (_userSeries.IsFollowing(id, UserId))
            {
                _userSeries.Delete(id, UserId);
            }
            else
            {
                _userSeries.Add(id, UserId);
            }
            return Ok();
        }
    }
}