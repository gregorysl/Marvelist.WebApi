using System.Web.Http;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class UserComicController : BasicController
    {
        private readonly IUserComicService _userComicService;

        public UserComicController(IUserComicService userComicService)
        {
            _userComicService = userComicService;
        }

        [Route("api/Follow/c{id:int}")]
        private void Follow(int id)
        {
            if (_userComicService.IsFollowing(id, UserId))
            {
                _userComicService.Delete(id, UserId);
            }
            else
            {
                _userComicService.Add(id, UserId);
            }
        }
    }
}