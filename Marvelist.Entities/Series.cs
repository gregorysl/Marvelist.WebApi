using System;
using System.Collections.Generic;

namespace Marvelist.Entities
{
    public class Series : MarvelistModel
    {
        public Series()
        {
        }

        public string Description { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Rating { get; set; }

        public virtual ICollection<Comic> Comics { get; set; }
        public virtual ICollection<UserSeries> UserSeries { get; set; }
        
        public override string ToString()
        {
            return Title;
        }
    }

    public class UserSeries 
    {
        public UserSeries()
        {
        }
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime? Date { get; set; }
    }
}
