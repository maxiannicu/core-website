using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlogApp.Entities;
using BlogApp.Exceptions;
using BlogApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IUserRepository userRepository, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }

        public bool LoggedIn => _userManager.GetUserAsync(_contextAccessor.HttpContext.User).Result != null;
        public User CurrentUser => _userManager.GetUserAsync(_contextAccessor.HttpContext.User).Result;

        public void CreateUser(User user, string password)
        {
            var identityResult = _userManager.CreateAsync(user, password);
            var result = identityResult.Result;

            if (!result.Succeeded)
            {
                throw new CreateUserException()
                {
                    Errors = result.Errors.Select(s => s.Description).ToList()
                };
            }
        }

        public void SignIn(User user)
        {
            _signInManager.SignInAsync(user,false).Wait();
        }

        public void SignIn(string username, string password)
        {
            var signInResult = _signInManager.PasswordSignInAsync(username,password,false,false).Result;

            if (!signInResult.Succeeded)
            {
                throw new SignInUserException()
                {
                    Errors = new string[]{"Incorrect login or password"}.ToList()
                };
            }
        }

        public void SignOut()
        {
            _signInManager.SignOutAsync().Wait();
        }
    }
}