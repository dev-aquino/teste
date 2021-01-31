using Application.Interfaces;
using Domain.Services;
using Infrastructure.Database.Contexts;
using Infrastructure.Database.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public static class IoCTest
    {
        public static IConfiguration GetIConfigurationRoot()
        {
            return (IConfiguration)new ConfigurationBuilder()
            .SetBasePath(@"C:\teste\PDV\Tests")
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

        }

        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var configuration = GetIConfigurationRoot();
            services.AddSingleton(configuration);

            services.AddDbContext<SqlServerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PdvConnection")));

            services.AddScoped<IPdvService, PdvService>();
            services.AddScoped<IPdvRepository, PdvRepository>();

            services.AddTransient<PdvTests>();

            return services;
        }
    }
}
