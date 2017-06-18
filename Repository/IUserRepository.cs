using BlogApp.Entities;

namespace BlogApp.Repository
{
    public interface IUserRepository
    {
        User Find(int id);
    }
}