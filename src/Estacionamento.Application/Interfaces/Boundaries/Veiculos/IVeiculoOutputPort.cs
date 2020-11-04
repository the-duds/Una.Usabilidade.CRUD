using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento.Application.Interfaces.Boundaries.Veiculos
{
    public interface IVeiculoOutputPort : IOutputPortStandard<VeiculoOutput>, IOutputPortNotFound, IOutputPortError { }
    
}
