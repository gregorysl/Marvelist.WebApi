using System;
using System.Collections.Generic;

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
        public virtual Series Series { get; set; }

        public DateTime Date { get; set; }
        public float Price { get; set; }

        public virtual ICollection<ComicCreator> ComicCreator { get; set; }
        public virtual ICollection<UserComic> UserComic { get; set; }
    }
    public class UserComic
    {
        public int Id { get; set; }
        public int ComicId { get; set; }
        public virtual Comic Comic { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime? Date { get; set; }
    }
}
