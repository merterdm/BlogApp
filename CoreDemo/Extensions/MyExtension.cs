using BusinessLayer.Abstract;
using BusinessLayer.Concrete;

namespace CoreDemo.Extensions
{
    public static class MyExtension
    {
        public static IServiceCollection AddBlogApp(this IServiceCollection services)
        {
            services.AddScoped<ICategoryManager, CategoryManager>();
            return services;
        }
    }
}
