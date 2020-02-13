using Seguro.BackEnd.Dominio.Entidade;
using Seguro.BackEnd.Dominio.Interfaces;

namespace Seguro.BackEnd.Dominio.Servicos
{
    public class SeguroServ : ISeguroServ
    {
        public SeguroServ()
        {

        }

        
        public double CalcularSeguro(Veiculo veiculo, Segurado segurado)
        {
            ObjetoDeValor.Seguro seguro = new ObjetoDeValor.Seguro(veiculo, segurado);

            return seguro.CalcularSeguro();
        }
    }
}
