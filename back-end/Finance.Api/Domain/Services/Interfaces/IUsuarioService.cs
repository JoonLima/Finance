using Finance.Api.Contract.Usuario;

namespace Finance.Api.Domain.Services.Interfaces
{
    public interface IUsuarioService : IService<UsuarioRequestContract, UsuarioResponseContract, Guid>
    {
        Task<UsuarioLoginResponseContratc> Autenticar(UsuarioLoginRequestContract usuarioLogin);
        Task<UsuarioResponseContract> ObterPorEmail(string email);
    }
}
