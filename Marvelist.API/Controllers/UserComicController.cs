using System.Linq;
using System.Web.Http;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    [RoutePrefix("api/FollowC")]
    public class UserComicController : BasicController
    {
        private readonly IUserComicService _userComicService;
        private readonly IComicService _comicService;

        public UserComicController(IUserComicService userComicService, IComicService comicService)
        {
            _userComicService = userComicService;
            _comicService = comicService;
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


        [HttpPost]
        [Route("all{seriesId:int}")]
        public IHttpActionResult FollowAll(int seriesId)
        {
            var comics = _comicService.GetComicsForSeriesId(seriesId).Select(x => x.Id).ToList();
            _userComicService.AddAll(comics,UserId);
            return Ok();
        }
    }
}