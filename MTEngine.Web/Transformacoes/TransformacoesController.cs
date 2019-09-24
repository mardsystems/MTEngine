using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MTEngine.Transformacoes
{
    [Route("[controller]")]
    [ApiController]
    public class TransformacoesController : ExtendedController
    {
        private readonly ITransformacaoDeMensagens transformacaoDeMensagens;

        public TransformacoesController(ITransformacaoDeMensagens transformacaoDeMensagens)
        {
            this.transformacaoDeMensagens = transformacaoDeMensagens;
        }

        [HttpPost]
        public async Task<ActionResult<MensagemDeSaida>> Post([FromHeader] string regra, [FromBody] string conteudo)
        {
            var mensagemDeEntrada = new MensagemDeEntrada
            {
                Regra = regra,
                Conteudo = conteudo
            };

            var mensagem = await transformacaoDeMensagens.Transforma(mensagemDeEntrada);

            return Ok(mensagem);
        }
    }
}
