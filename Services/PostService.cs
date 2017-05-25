using System.Collections.Generic;
using BlogApp.Entities;
using BlogApp.Repository;

namespace BlogApp.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void Insert(Post entity)
        {
            _postRepository.Insert(entity);
        }

        public Post GetById(int id)
        {
            return _postRepository.FindById(id);
        }

        public void Remove(int id)
        {
            var entity = _postRepository.FindById(id);
            if(entity != null)
                _postRepository.Remove(entity);
        }
    }
}