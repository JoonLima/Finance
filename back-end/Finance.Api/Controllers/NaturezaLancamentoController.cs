using Finance.Api.Contract.NaturezaLancamento;
using Finance.Api.Contract.Usuario;
using Finance.Api.Domain.Repoository.Interfaces;
using Finance.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Security.Authentication;

namespace Finance.Api.Controllers
{
    [ApiController]
    [Route("naturezas-de-lancamento")]
    public class NaturezaLancamentoController : BaseController
    {
        private readonly IService<NaturezaLancamentoRequestContract, NaturezaLancamentoResponseContract, Guid> _naturezaLancamentoService;
        public NaturezaLancamentoController(IService<NaturezaLancamentoRequestContract, NaturezaLancamentoResponseContract, Guid> naturezaLancamentoService) 
        {
            _naturezaLancamentoService = naturezaLancamentoService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Criar(NaturezaLancamentoRequestContract contrato)
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                return Created("", await _naturezaLancamentoService.Criar(contrato, idUsuarioLogado));
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
                return Ok(await _naturezaLancamentoService.Obter(idUsuarioLogado));
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
                return Ok(await _naturezaLancamentoService.ObterPorId(id, idUsuarioLogado));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Atualizar(Guid id, NaturezaLancamentoRequestContract contrato)
        {
            try
            {
                Guid idUsuarioLogado = ObterIdUsuarioLogado();
                return Ok(await _naturezaLancamentoService.Atualizar(id, contrato, idUsuarioLogado));
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
                await _naturezaLancamentoService.Deletar(id, idUsuarioLogado);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
