using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguro.BackEnd.Dominio.Entidade;
using Seguro.BackEnd.Dominio.Interfaces;
using Seguro.BackEnd.Persistencia.Interfaces;
using Seguro.BackEnd.Test.DI;
using Objeto = Seguro.BackEnd.Dominio.ObjetoDeValor;

namespace Seguro.BackEnd.Test
{
    [TestClass]
    public class SeguroTeste
    {
        [ClassInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            InjecaoDeDependencia.InicarMock();
        }

        [TestMethod]
        public void Calcular_Seguro()
        {
            ISeguroServ _rep = InjecaoDeDependencia.Invocar<ISeguroServ>();
            Veiculo veiculo = new Veiculo(10000, "Volksvagem", "Gol Mi");
            decimal resultado = 0;

            resultado = _rep.CalcularSeguro(veiculo);
        }

        [TestMethod]
        public void Inserir_Seguro()
        {
            ISeguroRep _rep = InjecaoDeDependencia.Invocar<ISeguroRep>();
            int resultado = 0;

            Veiculo veiculo = new Veiculo(10000, "Volksvagem", "Gol Mi");
            Segurado segurado = new Segurado("Max", "123456789", 25);
            Objeto.Seguro seguro = new Objeto.Seguro(veiculo, segurado);

            resultado =_rep.Inserir(seguro);

            Assert.IsTrue(resultado.Equals(1));
        }
    }
}
