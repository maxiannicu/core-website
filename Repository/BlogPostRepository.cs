using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repository
{
    public class BlogPostRepository : EfRepository<BlogPost>,IBlogPostRepository
    {
        public BlogPostRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}