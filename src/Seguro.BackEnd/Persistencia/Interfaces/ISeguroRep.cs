using objeto = Seguro.BackEnd.Dominio.ObjetoDeValor;

namespace Seguro.BackEnd.Persistencia.Interfaces
{
    public interface ISeguroRep
    {
        void Inserir(objeto.Seguro seguro);
    }
}
