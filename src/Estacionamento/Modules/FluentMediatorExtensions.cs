using Estacionamento.Application.Interfaces.Boundaries.Veiculos;
using Estacionamento.Application.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using FluentMediator;

namespace Estacionamento.Modules
{
    public static class FluentMediatorExtensions
    {
        /// <summary>
        /// Metodo chamado no startup para registrar o Mediator
        /// </summary>
        /// <param name="services">Serviço de Mediator</param>
        /// <returns></returns>
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<VeiculoModel>().PipelineAsync()
                       .Call<IVeiculoUseCase>((handler, request) => handler.Execute(request));


                });

            return services;
        }
    }
}
