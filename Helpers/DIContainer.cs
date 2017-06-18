using System;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Helpers
{
    public static class DiContainer
    {
        public static IServiceProvider ServiceProvider;

        public static T Resolve<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}