using Seguro.BackEnd.Dominio.Entidade;
using Seguro.BackEnd.Dominio.Interfaces;
using Seguro.BackEnd.Persistencia.Interfaces;
using System;

namespace Seguro.BackEnd.Dominio.Servicos
{
    public class VeiculoServ : IVeiculoServ
    {
        public VeiculoServ(IVeiculoRep rep)
        {
            _rep = rep;
        }

        private readonly IVeiculoRep _rep;

        public Veiculo Obter(Guid id)
        {
            return _rep.Obter(id);
        }
    }
}
