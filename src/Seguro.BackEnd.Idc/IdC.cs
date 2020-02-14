using Seguro.BackEnd.Idc.Modulos;
using SimpleInjector;

namespace Seguro.BackEnd.Idc
{
    public static class IdC
    {
        public static void Carregar(Container recipiente)
        {
            ServicoModulo.Carregar(recipiente);
            RepositorioModulo.Carregar(recipiente);
        }
    }
}
