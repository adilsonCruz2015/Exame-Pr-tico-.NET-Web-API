using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seguro.BackEnd.Api.Controllers
{
    [RoutePrefix("Servico/Seguro")]
    public class SeguroController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            List<string> dados = new List<string>()
            {
                "Carro",
                "Carro1"
            };

            return Request.CreateResponse(HttpStatusCode.OK, dados);
        }
    }
}