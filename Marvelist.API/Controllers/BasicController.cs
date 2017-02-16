using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace Marvelist.API.Controllers
{
    public class BasicController : ApiController
    {
        public string UserName => RequestContext.Principal.Identity.IsAuthenticated
            ? RequestContext.Principal.Identity.Name
            : "";

        public string UserId
        {
            get
            {
                var identity = (ClaimsIdentity) RequestContext.Principal.Identity;
                var claim = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                //return claim == null ? "" : claim.Value;
                return "3ac97d04-ebd6-4699-9fb4-6320b25a9321";
            }
        }
    }
}