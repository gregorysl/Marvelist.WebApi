using Marvelist.DataAccess.Contracts;

namespace Marvelist.DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private MarvelEntities _dbContext;
        private readonly IDatabaseFactory _dbFactory;

        protected MarvelEntities DbContext
        {
            get
            {
                if (_dbContext != null) return _dbContext;
                _dbContext = _dbFactory.Get();
                return _dbContext;
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
