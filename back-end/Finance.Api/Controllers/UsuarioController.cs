using Finance.Api.Contract.Usuario;
using Finance.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Finance.Api.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) 
        { 
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(UsuarioLoginRequestContract contrato)
        {
            try
            {

                return Created("", await _usuarioService.Autenticar(contrato));
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(new { statudCode = 401 , message = ex.Message});
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Criar(UsuarioRequestContract contrato)
        {
            try 
            { 
                Guid guid = Guid.NewGuid();
                return Created("", await _usuarioService.Criar(contrato, guid));
            }
            catch (Exception ex) 
            {
                return Problem(ex.Message);
            }
        }
    }
}
