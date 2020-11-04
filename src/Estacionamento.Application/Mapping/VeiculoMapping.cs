using AutoMapper;
using Estacionamento.Application.ViewModel;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Application.Mapping
{
    public class VeiculoMapping : Profile
    {
        public VeiculoMapping()
        {
            CreateMap<VeiculoModel, Veiculo>()
            .ForMember(x => x.Placa, model => model.MapFrom(y => y.Placa))
            .ForMember(x => x.NomeMotorista, model => model.MapFrom(y => y.NomeMotorista))
            .ForMember(x => x.CpfMototista, model => model.MapFrom(y => y.CpfMototista))
            .ForMember(x => x.Marca, model => model.MapFrom(y => y.Marca))
            .ForMember(x => x.Modelo, model => model.MapFrom(y => y.Modelo))
            .ForMember(x => x.Cor, model => model.MapFrom(y => y.Cor));
        }
    }
}
