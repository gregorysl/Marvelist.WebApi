using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Marvelist.Entities
{
    public class Series : MarvelistModel
    {
        public string Description { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Rating { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Comic> Comics { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserSeries> UserSeries { get; set; }
        
        public override string ToString()
        {
            return Title;
        }
    }

    public class UserSeries 
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime? Date { get; set; }
    }
}
