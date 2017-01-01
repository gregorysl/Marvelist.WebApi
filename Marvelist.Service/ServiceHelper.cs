using System.Linq;
using Marvelist.Entities;

namespace Marvelist.Service
{
    public static class ServiceHelper
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> source, string text) where T : Series
        {
            var textArr = text.Split(' ');
            foreach (var txt in textArr)
            {
                source = source.Where(x => x.Title.Contains(txt));
            }
            return source;
        }
    }
}
