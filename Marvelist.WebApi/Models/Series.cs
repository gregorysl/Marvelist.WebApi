using System.Collections.Generic;
using System.Linq;
using MarvelAPI;

namespace Marvelist.WebApi.Models
{
    public class Series :MarvelistModel
    {
        public Series()
        {
        }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Rating { get; set; }

        public Series(MarvelAPI.Series s)
        {
            var series = s.To<Series>();
            Id = s.Id;
            Title = s.Title;
            Description = s.Description;
            StartYear = s.StartYear;
            EndYear = s.EndYear;
            Rating = s.Rating;
            Modified = s.Modified;
            Url = s.Urls.FirstOrDefault(x => x.Type == "detail")?.Url;
            Thumbnail = s.Thumbnail;
        }

        public override void Update(object item)
        {
            var s = (Series)item;

            Id = s.Id;
            Title = s.Title;
            Description = s.Description;
            StartYear = s.StartYear;
            EndYear = s.EndYear;
            Rating = s.Rating;
            Modified = s.Modified;
            Url = s.Url;
            Thumbnail.Extension = s.Thumbnail.Extension;
            Thumbnail.Path = s.Thumbnail.Path;
        }
        public virtual ICollection<Comic> Comics { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}