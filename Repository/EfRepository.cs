using System.Linq;
using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repository
{
    public class EfRepository<T> : IRepository<T> where T:BaseEntity
    {
        private AppDbContext _dbContext;
        private DbSet<T> _dbSet;

        protected virtual IQueryable<T> Table => _dbSet;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public virtual T FindById(int id)
        {
            return Table.FirstOrDefault(entity => entity.Id == id);
        }
    }
}