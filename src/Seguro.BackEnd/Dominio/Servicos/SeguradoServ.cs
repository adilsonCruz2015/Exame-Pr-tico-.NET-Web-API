using System;
using Seguro.BackEnd.Dominio.Entidade;
using Seguro.BackEnd.Dominio.Interfaces;
using Seguro.BackEnd.Persistencia.Interfaces;

namespace Seguro.BackEnd.Dominio.Servicos
{
    public class SeguradoServ : ISeguradoServ
    {
        public SeguradoServ(ISeguradoRep rep)
        {
            _rep = rep;
        }

        private readonly ISeguradoRep _rep;

        public Segurado Obter(Guid id)
        {
            return _rep.Obter(id);
        }
    }
}
