using Core.Model;
using Core.Services;
using Core.Services.Interfaces;
using DataAccess.Context;
using DataAccess.Repository;
using DataAccess.Repository.GenereicRepository;
using DataAccess.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using static Slapper.AutoMapper;

namespace Core.Infrastructure.Config
{
    public class ServiceInjection
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection("ConnectionStrings");

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddSingleton<IConfiguration>(configuration);

            services.AddTransient<IDataContext>(serviceProvider => new DataContext(databaseSettings["ApiConnection"]));
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IStatusService, StatusService>();



        }
    }
}
