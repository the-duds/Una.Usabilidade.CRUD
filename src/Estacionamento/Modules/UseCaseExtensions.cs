using Estacionamento.Application.Interfaces.Boundaries.Veiculos;
using Estacionamento.Application.Services.Veiculos;
using Microsoft.Extensions.DependencyInjection;

namespace Estacionamento.Modules
{
    public static class UseCaseExtensions
    {
        /// <summary>
        /// Metodo chamado no startup para registrar os UseCase
        /// </summary>
        /// <param name="services">Serviço de UseCase</param>
        /// <returns></returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IVeiculoUseCase, VeiculosUseCase>();

            return services;
        }
    }
}
