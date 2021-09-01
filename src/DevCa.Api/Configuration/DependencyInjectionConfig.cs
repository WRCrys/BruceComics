using DevCA.Business.Interfaces;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Interfaces.Service;
using DevCA.Business.Notifications;
using DevCA.Business.Services;
using DevCa.Data.Context;
using DevCa.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DevCa.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BruceComicsContext>();
            
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookGenderRepository, BookGenderRepository>();
            services.AddScoped<IReserveRepository, ReserveRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookGenderService, BookGenderService>();
            services.AddScoped<IReserveService, ReserveService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<INotificator, Notificator>();
            
            return services;
        }
    }
}