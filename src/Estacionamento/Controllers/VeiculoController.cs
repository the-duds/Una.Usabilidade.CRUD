using FluentMediator;
using System.Threading.Tasks;
using Estacionamento.Application.Interfaces.Boundaries.Veiculos;
using Estacionamento.Application.ViewModel;
using Estacionamento.Domain.Entities;
using Estacionamento.Domain.Repositores;
using Estacionamento.Models;
using Estacionamento.Presenter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMongoRepository<Veiculo> _repository;

        /// <summary>
        /// Controller responsável por rotas relacionadas a leiaute.
        /// </summary>
        /// <param name="mediator">Interface de mediator para chamar os use case da aplicação.</param>
        /// <param name="repository">Interface de repositorio para chamar funcionalidades da aplicação.</param>
        public VeiculoController(IMediator mediator,
                                 IMongoRepository<Veiculo> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }



        /// <summary>
        /// Cadastra Veículos
        /// </summary>
        /// <param name="veiculo">Veiculos.</param>
        /// <param name="presenter">Presenter de retorno.</param>
        /// <returns>Retorna resultado da operação.</returns>
        [HttpPost, Route("")]
        [ProducesResponseType(typeof(VeiculoOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostVeiculo(VeiculoModel veiculo, [FromServices] VeiculoPresenter presenter)
        {
            await _mediator.PublishAsync(veiculo).ConfigureAwait(false);

            return presenter.ViewModel;
        }

        /// <summary>
        /// Lista Veiculos Cadastrados
        /// </summary>
        /// <returns>Rertorna lista de veículos.</returns>
        [HttpGet, Route("All")]
        [ProducesResponseType(typeof(VeiculoOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTudo()
        {

            return Ok(await _repository.GetAll());

        }

        /// <summary>
        /// Buscar Veiculo por Id.
        /// </summary>
        /// <returns>Rertorna veículo no banco.</returns>
        [HttpGet, Route("{id}")]
        [ProducesResponseType(typeof(VeiculoOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetId(string id)
        {

            return Ok(await _repository.FindByIdAsync(id));

        }

        /// <summary>
        /// Buscar Veiculo por Id.
        /// </summary>
        /// <returns>Rertorna veículo no banco.</returns>
        [HttpDelete, Route("{id}")]
        [ProducesResponseType(typeof(VeiculoOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            await _repository.DeleteByIdAsync(id);
            return NoContent();

        }

    }
}
