
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguro.BackEnd.Dominio.Entidade;

namespace Seguro.BackEnd.Test
{
    [TestClass]
    public class VeiculoTeste
    {
        [TestMethod]
        public void Calcular_Seguro()
        {
            Veiculo veiculos = new Veiculo(10000, "Gol", "Mi");

            //Assert.IsTrue(veiculos.TaxaDeRisco.Equals(0.025));
            //Assert.IsTrue(veiculos.PremioDeRisco.Equals(250));
            //Assert.IsTrue(veiculos.PremidoPuro.Equals(257));
            //Assert.IsTrue(veiculos.PremioComercial.Equals(270.37));
        }
    }
}
