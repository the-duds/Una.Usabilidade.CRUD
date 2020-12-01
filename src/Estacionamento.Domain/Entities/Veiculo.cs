using Estacionamento.Domain.Atrributes;
using Estacionamento.Domain.Entities.Base;

namespace Estacionamento.Domain.Entities
{
    [BsonCollection("Veiculo")]
    public class Veiculo : Document
    {
        public string Placa { get; set; }
        public string NomeMotorista { get; set; }
        public string CpfMototista { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
    }
}
