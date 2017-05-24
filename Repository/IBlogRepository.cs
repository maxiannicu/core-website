using System.Collections.Generic;
using BlogApp.Entities;

namespace BlogApp.Repository
{
    public interface IBlogRepository : IRepository<Blog>
    {
        List<Blog> Get(int? skip = null, int? take = null);
    }
}