using Seguro.BackEnd.Dominio.Commando.SeguroCmd;
using Seguro.BackEnd.Dominio.Entidade;
using Seguro.BackEnd.Dominio.Interfaces;
using Seguro.BackEnd.Persistencia.Interfaces;
using System;
using Objeto = Seguro.BackEnd.Dominio.ObjetoDeValor;

namespace Seguro.BackEnd.Dominio.Servicos
{
    public class SeguroServ : ISeguroServ
    {
        public SeguroServ(ISeguroRep seguroRep,
                          IVeiculoRep veiculoRep,
                          ISeguradoRep seguradoRep)
        {
            _seguroRep = seguroRep;
            _veiculoRep = veiculoRep;
            _seguradoRep = seguradoRep;
        }

        private readonly ISeguroRep _seguroRep;
        private readonly IVeiculoRep _veiculoRep;
        private readonly ISeguradoRep _seguradoRep;
        
        public decimal CalcularSeguro(Veiculo veiculo)
        {
            Objeto.Seguro seguro = new Objeto.Seguro(veiculo);

            return seguro.CalcularSeguro();
        }

        public int Inserir(Guid idVeiculo, Guid IdSegurado)
        {
            Veiculo veiculo = null;
            Segurado segurado = null;
            Objeto.Seguro seguro = null;
            int resultado = 0;

            if (!object.Equals(idVeiculo, null))
                veiculo = _veiculoRep.Obter(idVeiculo);

            if (!object.Equals(IdSegurado, null))
                segurado = _seguradoRep.Obter(IdSegurado);

            if(!object.Equals(idVeiculo, null) && !object.Equals(IdSegurado, null))
            {
                seguro = new Objeto.Seguro(veiculo, segurado);
                resultado = _seguroRep.Inserir(seguro);
            }

            return resultado;
        }

        public Objeto.Seguro[] Filtrar(FiltrarCmd comando)
        {
            return _seguroRep.Filtrar(comando);
        }
    }
}
