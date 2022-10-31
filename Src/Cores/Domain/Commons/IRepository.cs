namespace Domain.Commons
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetQueryable();
        T Get(int id);
        void Insert(T entity);
        void Remove(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}