using System;

namespace Marvelist.DataAccess.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        MarvelEntities Get();
    }
}
