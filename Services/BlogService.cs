using System.Collections.Generic;
using BlogApp.Entities;
using BlogApp.Repository;

namespace BlogApp.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public List<Blog> GetAll()
        {
            return _blogRepository.Get();
        }

        public Blog Get(int id)
        {
            return _blogRepository.FindById(id);
        }

        public Blog GetBlogWithPosts(int id)
        {
            return _blogRepository.GetBlogWithPosts(id);
        }

        public void Remove(int id)
        {
            var entity = _blogRepository.FindById(id);
            if(entity != null)
                _blogRepository.Remove(entity);
        }

        public void Update(Blog entity)
        {
            _blogRepository.Update(entity);
        }

        public void Insert(Blog entity)
        {
            _blogRepository.Insert(entity);
        }
    }
}