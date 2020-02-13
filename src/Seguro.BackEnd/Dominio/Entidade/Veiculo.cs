
namespace Seguro.BackEnd.Dominio.Entidade
{
    public class Veiculo
    {
        public Veiculo(double valorVeiculo,
                       string marca,
                       string modelo
            )
        {
            ValorVeiculo = valorVeiculo;
            Marca = marca;
            Modelo = modelo;
        }        
        
        public double ValorVeiculo { get; private set; }        

        public string Marca { get; private set; }

        public string Modelo { get; private set; }
    }
}
