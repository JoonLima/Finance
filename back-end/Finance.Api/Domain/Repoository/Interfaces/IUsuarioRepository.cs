using Finance.Api.Domain.Models;

namespace Finance.Api.Domain.Repoository.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario, Guid>
    {
        Task<Usuario> ObterPorEmail(string email);
    }
}
