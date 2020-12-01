using AutoMapper;
using Estacionamento.Application.Interfaces.Boundaries.Veiculos;
using Estacionamento.Application.ViewModel;
using Estacionamento.Domain.Entities;
using Estacionamento.Domain.Repositores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Application.Services.Veiculos
{
    public class VeiculosUseCase : IVeiculoUseCase
    {
        
        private readonly IVeiculoOutputPort _outputPort;
        private readonly IMongoRepository<Veiculo> _repository;
        private readonly IMapper _mapper;

        public VeiculosUseCase(IVeiculoOutputPort outputPort,
                               IMongoRepository<Veiculo> repository,
                               IMapper mapper)
        {
           
            _outputPort = outputPort;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Execute(VeiculoModel input)
        {
            input.Validate();

            if (input.Valid)
            {
                var carro = _mapper.Map<Veiculo>(input);

                await _repository.InsertOneAsync(carro);

                _outputPort.Success(new VeiculoOutput($"Veiculo cadastrado com Sucesso!{carro.Id}"));
                return;
            }
            _outputPort.WriteError(input.Notifications);
        }
    }
}
