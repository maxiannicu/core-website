using System.Linq;
using BlogApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Blog> Blogs { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}