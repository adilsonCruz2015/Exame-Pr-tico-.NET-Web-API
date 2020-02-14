using Seguro.BackEnd.Api.Model;
using Seguro.BackEnd.Dominio.Commando.SeguroCmd;
using Seguro.BackEnd.Dominio.Entidade;
using Seguro.BackEnd.Dominio.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Objeto = Seguro.BackEnd.Dominio.ObjetoDeValor;

namespace Seguro.BackEnd.Api.Controllers
{
    [RoutePrefix("Servico/Seguro")]
    [Description("Gerenciar Seguros")]
    public class SeguroController : ApiController
    {
        public SeguroController(ISeguroServ serv)
        {
            _serv = serv;
        }

        private readonly ISeguroServ _serv;

        [HttpGet, Route("Filtrar")]
        [Display(Name = "Filtrar")]
        public async Task<HttpResponseMessage> Get([FromUri] FiltrarCmd parametros)
        {
            if (object.Equals(parametros, null))
                parametros = new FiltrarCmd();

            Objeto.Seguro[] resultados = new Objeto.Seguro[] { };
            resultados = _serv.Filtrar(parametros);

            return Request.CreateResponse(HttpStatusCode.OK, resultados);
        }

        [HttpPost, Route("Calcular")]
        [Display(Name = "Calcular")]
        public async Task<HttpResponseMessage> Calcular([FromBody] VeiculoModel model)
        {
            Veiculo veiculo = null;
            model.Aplicar(ref veiculo);
            decimal resultado = 0;

            resultado = _serv.CalcularSeguro(veiculo);

            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpPost, Route]
        [Display(Name = "Inserir")]
        public async Task<HttpResponseMessage> Post([FromBody] SeguroModel model)
        {
            int resultado = _serv.Inserir(model.Veiculo, model.Segurado);

            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }
    }
}