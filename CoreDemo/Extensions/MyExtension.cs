using BusinessLayer.Abstract;
using BusinessLayer.Concrete;

namespace CoreDemo.Extensions
{
    public static class MyExtension
    {
        public static IServiceCollection AddBlogApp(this IServiceCollection services)
        {
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IBlogManager, BlogManager>();
            services.AddScoped<IAboutManager, AboutManager>();
            services.AddScoped<ICommentManager, CommentManager>();
            services.AddScoped<IContactManager, ContactManager>();
            services.AddScoped<IWriterManager, WriterManager>();            
            return services;
        }
    }
}
