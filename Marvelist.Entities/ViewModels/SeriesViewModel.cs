using System;
using System.Collections.Generic;
using Marvelous;
using Newtonsoft.Json;


namespace Marvelist.Entities.ViewModels
{
    public class Mvm
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Thumbnail => ThumbnailData.ToString(Image.PortraitUncanny);

        [JsonIgnore]
        public MarvelImage ThumbnailData { get; set; }

        public string Description { get; set; }
        public bool Following { get; set; }

        public override string ToString()
        {
            return $"{Title} {Following}";
        }
    }

    public class SeriesViewModel : Mvm
    {
        public int ComicCount { get; set; }
    }

    public class SeriesPaginatedModel
    {
        public List<SeriesViewModel> Series { get; set; }
        public int Count { get; set; }
    }

    public class SeriesComicsViewModel : Mvm
    {
        public int ComicCount { get; set; }
        public int Read { get; set; }
        public List<ComicsViewModel> Comics { get; set; }
    }

    public class ComicsViewModel : Mvm
    {
        public int SeriesId { get; set; }
        public int IssueNumber { get; set; }
        public string ISBN { get; set; }
        public string UPC { get; set; }
        public string DiamondCode { get; set; }
        public string EAN { get; set; }
        public string ISSN { get; set; }
        public int PageCount { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
    }
}