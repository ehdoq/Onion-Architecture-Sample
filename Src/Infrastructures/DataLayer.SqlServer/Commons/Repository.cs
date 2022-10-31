using Domain.Commons;

namespace DataLayer.SqlServer.Commons
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}