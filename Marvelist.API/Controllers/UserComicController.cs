using System.Web.Http;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    [RoutePrefix("api/FollowC")]
    public class UserComicController : BasicController
    {
        private readonly IUserComicService _userComicService;

        public UserComicController(IUserComicService userComicService)
        {
            _userComicService = userComicService;
        }

        [HttpPost]
        [Route("{id:int}")]
        public IHttpActionResult Follow(int id)
        {
            if (_userComicService.IsFollowing(id, UserId))
            {
                _userComicService.Delete(id, UserId);
            }
            else
            {
                _userComicService.Add(id, UserId);
            }
            return Ok();
        }
    }
}