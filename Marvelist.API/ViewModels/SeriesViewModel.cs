using Marvelist.Entities;

namespace Marvelist.API.ViewModels
{
    public class Mvm
    {
        public bool Following { get; set; }
        public string Class => Following ? "followed" : "follow";
    }
    public class SeriesViewModel : Mvm
    {
        public Series Series { get; set; }
        public string Place => "series";
        public string Type => Place;
        public string ButtonText => Following ? "Unfollow" : "Follow";
    }
}