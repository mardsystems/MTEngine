using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MTEngine.Regras
{
    [Route("[controller]")]
    [ApiController]
    public class RegrasController : ExtendedController
    {
        private readonly ICadastroDeRegras cadastroDeRegras;

        private readonly IRegrasRepository regrasRepository;

        public RegrasController(ICadastroDeRegras cadastroDeRegras, IRegrasRepository regrasRepository)
        {
            this.cadastroDeRegras = cadastroDeRegras;

            this.regrasRepository = regrasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regra>>> Get()
        {
            var regras = await regrasRepository.ObtemRegras();

            return Ok(regras);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<Regra>> Get(string nome)
        {
            var regra = await regrasRepository.ObtemRegraPeloNome(nome);

            return Ok(regra);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastroDeRegraRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await cadastroDeRegras.CadastraRegra(request);

                    //

                    return Ok();
                }
                catch (ApplicationException ex)
                {
                    return BadRequest();
                }
                catch (ArgumentException ex)
                {
                    AddModelError(ex);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{nome}")]
        public async Task<IActionResult> Put(string nome, [FromBody] CadastroDeRegraRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await cadastroDeRegras.AtualizaRegra(nome, request);

                    //

                    return Ok();
                }
                catch (ApplicationException ex)
                {
                    return BadRequest();
                }
                catch (ArgumentException ex)
                {
                    AddModelError(ex);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{nome}")]
        public async Task<IActionResult> Delete(string nome)
        {
            try
            {
                await cadastroDeRegras.ExcluiRegra(nome);

                //

                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest();
            }
        }
    }
}
