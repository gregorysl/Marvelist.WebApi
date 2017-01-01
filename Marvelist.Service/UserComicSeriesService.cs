using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvelist.Service
{
    public class UserComicSeriesService : IUserComicSeriesService
    {
        public void AddOrDeleteSeries(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public void AddOrDeleteComic(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserComicSeriesService
    {
        void AddOrDeleteSeries(int id, string userId);
        void AddOrDeleteComic(int id, string userId);

    }

}
