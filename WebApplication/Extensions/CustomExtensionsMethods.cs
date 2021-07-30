using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace WebApplication.Extensions
{
    public static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "Test",
                    Version = "v1",
                    Description = "CRUD",
                    Contact = new OpenApiContact
                    {
                        Name = "Prueba"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Derechos Reservados"
                    },
                });
            });

            return services;
        }
    }
}
