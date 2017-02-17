using System.Linq;
using System.Web.Http;
using Marvelist.Entities.ViewModels;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class ComicController : BasicController
    {
        private readonly IComicService _comicService;
        private readonly IUserComicService _userComicService;

        public ComicController(IComicService comicService, IUserComicService userComicService)
        {
            _comicService = comicService;
            _userComicService = userComicService;
        }

        [Route("api/Comics/")]
        [HttpGet]
        public IHttpActionResult HomeComics()
        {
            var comics = _comicService.GetHomeComics(UserId);
            var readComics = _userComicService.GetAllFollowingId(UserId);
            var results = comics.Select(c => new ComicsViewModel
            {
                Date = c.Date,
                Description = c.Description,
                DiamondCode = c.DiamondCode,
                EAN = c.EAN,
                Id = c.Id,
                Title = c.Title,
                IssueNumber = c.IssueNumber,
                ThumbnailData = c.Thumbnail,
                Url = c.Url,
                Following = readComics.Contains(c.Id),
                ISBN = c.ISBN,
                ISSN = c.ISSN,
                PageCount = c.PageCount,
                Price = c.Price,
                UPC = c.UPC,
                SeriesId = c.SeriesId
            }).OrderBy(c => c.Date).ThenBy(c => c.Title).ToList();
            return Ok(results);
        }
    }
}