using Seguro.BackEnd.Persistencia.Interfaces;
using Seguro.BackEnd.Persistencia.Repositorios;
using SimpleInjector;

namespace Seguro.BackEnd.Idc.Modulos
{
    public static class RepositorioModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<ISeguroRep, SeguroRep>();
            recipiente.Register<IVeiculoRep, VeiculoRep>();
            recipiente.Register<ISeguradoRep, SeguradoRep>();
        }
    }
}
