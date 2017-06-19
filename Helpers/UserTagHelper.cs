using AutoMapper;
using BlogApp.Entities;
using BlogApp.Models.Shared;
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
        
        public static UserLayoutModel CurrentUser(this IHtmlHelper helper)
        {
            var mapper = DiContainer.Resolve<IMapper>();
            return mapper.Map<UserLayoutModel>(DiContainer.Resolve<IUserService>().CurrentUser);
        }
    }
}