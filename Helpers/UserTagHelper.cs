using BlogApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BlogApp.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static bool IsLoggedIn(this IHtmlHelper helper)
        {
            return DiContainer.Resolve<IUserService>().LoggedIn;
        }
    }
}