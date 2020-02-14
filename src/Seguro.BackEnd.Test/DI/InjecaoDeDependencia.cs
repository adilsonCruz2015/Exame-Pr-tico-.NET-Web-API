using Seguro.BackEnd.Idc.Modulos;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Seguro.BackEnd.Test.DI
{
    public class InjecaoDeDependencia
    {
        static Container _container;

        public static void InicarMock()
        {
            // 1. Create a new Simple Injector container
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            RepositorioModulo.Carregar(_container);
            ServicoModulo.Carregar(_container);

            AsyncScopedLifestyle.BeginScope(_container);
        }


        public static Tipo Invocar<Tipo>()
            where Tipo : class
        {
            return _container.GetInstance<Tipo>();
        }

    }
}
