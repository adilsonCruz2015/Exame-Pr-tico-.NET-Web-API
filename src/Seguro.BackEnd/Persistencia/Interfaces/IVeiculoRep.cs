using Seguro.BackEnd.Dominio.Entidade;
using System;

namespace Seguro.BackEnd.Persistencia.Interfaces
{
    public interface IVeiculoRep
    {
        Veiculo Obter(Guid id);
    }
}
