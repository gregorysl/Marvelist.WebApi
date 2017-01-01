using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Marvelist.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserSeries> Series { get; set; }
        public virtual ICollection<UserComic> Comics { get; set; }
    }
}
