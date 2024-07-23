using Finance.Api.Domain.Models;

namespace Finance.Api.Domain.Repoository.Interfaces
{
    public interface IAReceberRepository : IRepository<AReceber, Guid>
    {
        Task<IEnumerable<AReceber>> ObterPorUsuario(Guid idUsuario);
    }
}
