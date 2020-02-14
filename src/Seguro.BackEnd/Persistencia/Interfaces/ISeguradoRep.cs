using Seguro.BackEnd.Dominio.Entidade;
using System;

namespace Seguro.BackEnd.Persistencia.Interfaces
{
    public interface ISeguradoRep
    {
        Segurado Obter(Guid id);
    }
}
