using Seguro.BackEnd.Dominio.Entidade;

namespace Seguro.BackEnd.Dominio.Interfaces
{
    public interface ISeguroServ
    {
        double CalcularSeguro(Veiculo veiculo, Segurado segurado);
    }
}
