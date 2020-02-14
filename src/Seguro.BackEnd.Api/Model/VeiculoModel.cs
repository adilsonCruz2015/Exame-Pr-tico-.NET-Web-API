
using Seguro.BackEnd.Dominio.Entidade;

namespace Seguro.BackEnd.Api.Model
{
    public class VeiculoModel
    {
        public decimal ValorVeiculo { get;  set; }

        public string Marca { get;  set; }

        public string Modelo { get;  set; }

        public void Aplicar(ref Veiculo veiculo)
        {
            veiculo = new Veiculo(ValorVeiculo, Marca, Modelo);
        }
    }
}