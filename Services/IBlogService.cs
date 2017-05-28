using System.Collections.Generic;
using BlogApp.Entities;

namespace BlogApp.Services
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog Get(int id);
        Blog GetBlogWithPosts(int id);
        void Remove(int id);
        void Update(Blog entity);
        void Insert(Blog entity);
    }
}