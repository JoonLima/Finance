using Finance.Api.Domain.Models;

namespace Finance.Api.Domain.Repoository.Interfaces
{
    public interface IAPagarRepository : IRepository<APagar, Guid>
    {
        Task<IEnumerable<APagar>> ObterPorUsuario(Guid idUsuario);
    }
}
