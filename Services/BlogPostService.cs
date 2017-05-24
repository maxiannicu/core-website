using BlogApp.Entities;
using BlogApp.Repository;

namespace BlogApp.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public BlogPost GetById(int id)
        {
            return _blogPostRepository.FindById(id);
        }
    }
}