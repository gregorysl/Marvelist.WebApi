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
        public Series Series { get; set; }
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