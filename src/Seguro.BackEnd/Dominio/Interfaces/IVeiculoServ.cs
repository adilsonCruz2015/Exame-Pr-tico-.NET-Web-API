using Seguro.BackEnd.Dominio.Entidade;
using System;

namespace Seguro.BackEnd.Dominio.Interfaces
{
    public interface IVeiculoServ
    {
        Veiculo Obter(Guid id);
    }
}
