using Estacionamento.Domain.Dto.Config;
using Estacionamento.Domain.Repositores;
using Estacionamento.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Estacionamento.Infra.IoC
{
    public static class DependencyResolver
    {
        public static void AddSettingsConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }

        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("Estacionamento"),
                Assembly.Load("Estacionamento.Application"),
                Assembly.Load("Estacionamento.Domain"),
                Assembly.Load("Estacionamento.Infra.Data")
            };
        }
    }
}
