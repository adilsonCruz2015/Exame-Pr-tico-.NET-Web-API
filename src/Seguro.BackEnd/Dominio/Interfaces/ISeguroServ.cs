using Seguro.BackEnd.Dominio.Commando.SeguroCmd;
using Seguro.BackEnd.Dominio.Entidade;
using System;
using Objeto = Seguro.BackEnd.Dominio.ObjetoDeValor;

namespace Seguro.BackEnd.Dominio.Interfaces
{
    public interface ISeguroServ
    {
        decimal CalcularSeguro(Veiculo veiculo);

        int Inserir(Guid idVeiculo, Guid IdSegurado);

        Objeto.Seguro[] Filtrar(FiltrarCmd comando);
    }
}
