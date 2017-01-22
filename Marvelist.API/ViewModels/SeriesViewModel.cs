using System.Collections.Generic;
using Marvelist.Entities;

namespace Marvelist.API.ViewModels
{
    public class Mvm
    {
        public bool Following { get; set; }
    }
    public class SeriesViewModel : Mvm
    {
        public int Id { get; set; }
        public int ComicCount { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
    }
    public class SeriesComicsViewModel : Mvm
    {
        public Series Series { get; set; }
        public List<ComicsViewModel> Comics { get; set; }
    }
    public class ComicsViewModel : Mvm
    {
        public Comic Comic { get; set; }
    }
}