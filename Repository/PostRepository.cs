using System.Collections.Generic;
using System.Linq;
using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repository
{
    public class PostRepository : EfRepository<Post>,IPostRepository
    {
        public PostRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}