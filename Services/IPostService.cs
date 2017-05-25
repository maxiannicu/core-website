using System.Collections.Generic;
using BlogApp.Entities;

namespace BlogApp.Services
{
    public interface IPostService
    {
        void Insert(Post entity);
        Post GetById(int id);
        void Remove(int id);
    }
}