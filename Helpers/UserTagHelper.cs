using BlogApp.Entities;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static bool IsLoggedIn(this IHtmlHelper helper)
        {
            return DiContainer.Resolve<IUserService>().LoggedIn;
        }
        
        public static User CurrentUser(this IHtmlHelper helper)
        {
            return DiContainer.Resolve<IUserService>().CurrentUser;
        }
    }
}