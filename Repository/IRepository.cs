using BlogApp.Entities;

namespace BlogApp.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Remove(T entity);
        void Update(T entity);
        T FindById(int id);
    }
}