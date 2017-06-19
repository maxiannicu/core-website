using System.Collections.Generic;
using BlogApp.Entities;
using BlogApp.Exceptions;
using BlogApp.Repository;

namespace BlogApp.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUserService _userService;

        public BlogService(IBlogRepository blogRepository, IUserService userService)
        {
            _blogRepository = blogRepository;
            _userService = userService;
        }

        public List<Blog> GetAll()
        {
            return _blogRepository.Get();
        }

        public Blog Get(int id)
        {
            return _blogRepository.FindById(id);
        }

        public void Remove(int id)
        {
            var entity = _blogRepository.FindById(id);

            if (entity != null)
            {
                _blogRepository.Remove(entity);
            }
        }

        public void Update(Blog entity)
        {
            _blogRepository.Update(entity);
        }

        public void Insert(Blog entity)
        {
            entity.Author = _userService.CurrentUser;
            _blogRepository.Insert(entity);
        }
    }
}