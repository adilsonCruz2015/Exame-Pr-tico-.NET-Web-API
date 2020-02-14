

using System.Web.Http;

namespace Seguro.BackEnd.Api
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Permite exibir as mensagens de erro internas do servidor
            //config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;           
        }
    }
}