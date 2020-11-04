using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Modules
{
    public static class SwaggerExtensions
    {
        public static void UsaSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Estacionamento - Una");

            });
        }

        public static void ConfiguraSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Estacionamento - Una",
                    Description = "Api responsavel pela gestão do estacionamento da Una.",
                    Version = "v1",
                    TermsOfService = new Uri("https://www.redtube.com")
                });



                var apiPath = Path.Combine(AppContext.BaseDirectory, "Estacionamento.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "Estacionamento.Application.xml");

                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(applicationPath);
            });
        }
    }
}
