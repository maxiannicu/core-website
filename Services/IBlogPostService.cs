using BlogApp.Entities;

namespace BlogApp.Services
{
    public interface IBlogPostService
    {
        BlogPost GetById(int id);
    }
}