using System.Linq;
using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private AppDbContext _dbContext;
        private DbSet<User> _dbSet;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<User>();
        }

        public User Find(int id)
        {
            string strId = id.ToString();
            return _dbSet.FirstOrDefault(user => user.Id == strId);
        }
    }
}