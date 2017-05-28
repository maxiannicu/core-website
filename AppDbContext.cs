using System.Linq;
using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}