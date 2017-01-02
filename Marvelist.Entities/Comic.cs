using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Marvelist.Entities
{
    public class Comic : MarvelistModel
    { 
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string UPC { get; set; }
        public string DiamondCode { get; set; }
        public string EAN { get; set; }
        public string ISSN { get; set; }

        public int PageCount { get; set; }

        public int SeriesId { get; set; }
        [JsonIgnore]
        public virtual Series Series { get; set; }

        public DateTime Date { get; set; }
        public float Price { get; set; }

        [JsonIgnore]
        public virtual ICollection<ComicCreator> ComicCreator { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserComic> UserComic { get; set; }
    }
    public class UserComic
    {
        public int Id { get; set; }
        [Key, Column(Order = 0)]
        public int ComicId { get; set; }
        public virtual Comic Comic { get; set; }
        [Key, Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime? Date { get; set; }
    }
}
