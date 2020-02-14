using Seguro.BackEnd.Dominio.Interfaces;
using Seguro.BackEnd.Dominio.Servicos;
using SimpleInjector;

namespace Seguro.BackEnd.Idc.Modulos
{
    public static class ServicoModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<ISeguroServ, SeguroServ>();
            recipiente.Register<IVeiculoServ, VeiculoServ>();
            recipiente.Register<ISeguradoServ, SeguradoServ>();
        }
    }
}
