using System.Web.Http;
using WebActivatorEx;
using Seguro.BackEnd.Api;
using Swashbuckle.Application;
using System.Reflection;
using System;

namespace Seguro.BackEnd.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            string versao = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            config
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion($"v1", $"Documentação API Seguros {versao}");

                        c.IncludeXmlComments(string.Format(
                        @"{0}\bin\SeguroBackend.Api.xml",
                        AppDomain.CurrentDomain.BaseDirectory));

                        c.DescribeAllEnumsAsStrings();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle($"Documentação API Seguros {versao}");

                        c.SupportedSubmitMethods(new string[] { });
                    });
        }
    }
}
