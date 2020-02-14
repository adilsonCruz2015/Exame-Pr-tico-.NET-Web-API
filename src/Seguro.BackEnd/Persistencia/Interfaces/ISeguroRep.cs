using Seguro.BackEnd.Dominio.Commando.SeguroCmd;
using objeto = Seguro.BackEnd.Dominio.ObjetoDeValor;

namespace Seguro.BackEnd.Persistencia.Interfaces
{
    public interface ISeguroRep
    {
        int Inserir(objeto.Seguro seguro);

        objeto.Seguro[] Filtrar(FiltrarCmd comando);
    }
}
