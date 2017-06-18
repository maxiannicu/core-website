using System.Threading.Tasks;
using BlogApp.Entities;

namespace BlogApp.Services
{
    public interface IUserService
    {
        bool LoggedIn { get; }
        User CurrentUser { get; }
        
        void CreateUser(User user,string password);
        void SignIn(User user);
        void SignIn(string username,string password);
    }
}