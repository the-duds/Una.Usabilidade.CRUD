namespace Estacionamento.Application.Interfaces.Boundaries.Veiculos
{
    public class VeiculoOutput
    {
        public VeiculoOutput(string response)
        {
            Result = response;
        }

        public string Result { get; private set; }
    }
}
