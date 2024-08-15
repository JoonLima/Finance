using Finance.Api.Contract.AReceber;
using Finance.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers
{
    [ApiController]
    [Route("titulos-a-receber")]
    public class AReceberController : BaseController
    {
        private readonly IService<AReceberRequestContract, AReceberResponseContract, Guid> _areceberService;

        public AReceberController(IService<AReceberRequestContract, AReceberResponseContract, Guid> areceberService)
        {
            _areceberService = areceberService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Criar(AReceberRequestContract contrato)
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                return Created("", await _areceberService.Criar(contrato, idUsuarioLogado));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                return Ok(await _areceberService.Obter(idUsuarioLogado));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Obter(Guid id)
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                return Ok(await _areceberService.ObterPorId(id, idUsuarioLogado));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Atualizar(Guid id, AReceberRequestContract contrato)
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                return Ok(await _areceberService.Atualizar(id,contrato, idUsuarioLogado));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                await _areceberService.Deletar(id, idUsuarioLogado);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
