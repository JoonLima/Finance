using Finance.Api.Contract.APagar;
using Finance.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers
{
    [ApiController]
    [Route("titulos-a-pagar")]
    public class APagarController : BaseController
    {
        private readonly IService<APagarRequestContract, APagarResponseContract, Guid> _apagarService;

        public APagarController(IService<APagarRequestContract, APagarResponseContract, Guid> apagarService)
        {
            _apagarService = apagarService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Criar(APagarRequestContract contrato)
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                return Created("", await _apagarService.Criar(contrato, idUsuarioLogado));
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
                return Ok(await _apagarService.Obter(idUsuarioLogado));
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
                return Ok(await _apagarService.ObterPorId(id, idUsuarioLogado));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Atualizar(Guid id, APagarRequestContract contrato)
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                return Ok(await _apagarService.Atualizar(id, contrato, idUsuarioLogado));
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
                await _apagarService.Deletar(id, idUsuarioLogado);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
