using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Finance.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected Guid ObterIdUsuarioLogado()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid.TryParse(id, out Guid idUsuario);
            return idUsuario;
        }
    }
}
