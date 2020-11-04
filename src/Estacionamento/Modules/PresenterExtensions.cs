using Estacionamento.Application.Interfaces.Boundaries.Veiculos;
using Estacionamento.Presenter;
using Microsoft.Extensions.DependencyInjection;

namespace Estacionamento.Modules
{
    public static class PresenterExtensions
    {
        /// <summary>
        /// Metodo chamado no startup para registrar os Presenter
        /// </summary>
        /// <param name="services">Serviço de Presenter</param>
        /// <returns></returns>
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<VeiculoPresenter, VeiculoPresenter>();
            services.AddScoped<IVeiculoOutputPort>(x => x.GetRequiredService<VeiculoPresenter>());

            return services;
        }
    }
}
