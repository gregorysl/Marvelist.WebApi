using System.Collections.Generic;
using Newtonsoft.Json;

namespace Marvelist.Entities
{
    public class Creator : MarvelistModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string FullName { get; set; }

        [JsonIgnore]
        public virtual ICollection<ComicCreator> ComicCreator { get; set; }
    }

    public class ComicCreator
    {
        public int Id { get; set; }
        public int ComicId { get; set; }
        public virtual Comic Comic { get; set; }
        public int CreatorId { get; set; }
        public virtual Creator Creator { get; set; }
        public string Role { get; set; }
    }
}
