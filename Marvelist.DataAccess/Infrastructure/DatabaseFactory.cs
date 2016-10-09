namespace Marvelist.DataAccess.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private MarvelEntities _dataContext;
        public MarvelEntities Get()
        {
            return _dataContext ?? (_dataContext = new MarvelEntities());
        }
        protected override void DisposeCore()
        {
            _dataContext?.Dispose();
        }
    }
}
