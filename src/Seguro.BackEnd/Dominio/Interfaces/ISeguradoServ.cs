using Seguro.BackEnd.Dominio.Entidade;
using System;

namespace Seguro.BackEnd.Dominio.Interfaces
{
    public interface ISeguradoServ
    {
        Segurado Obter(Guid id);
    }
}
