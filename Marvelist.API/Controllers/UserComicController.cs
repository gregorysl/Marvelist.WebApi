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
        private readonly IUserSeriesService _userSeries;

        public UserComicController(IUserComicService userComicService, IComicService comicService, IUserSeriesService userSeries)
        {
            _userComicService = userComicService;
            _comicService = comicService;
            _userSeries = userSeries;
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
                var seriesId = _comicService.GetSeriesIdForComicId(id);
                if (!_userSeries.IsFollowing(seriesId, UserId))
                {
                    _userSeries.Add(seriesId, UserId);
                }
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