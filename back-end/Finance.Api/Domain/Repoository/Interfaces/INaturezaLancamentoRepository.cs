using Finance.Api.Domain.Models;

namespace Finance.Api.Domain.Repoository.Interfaces
{
    public interface INaturezaLancamentoRepository : IRepository<NaturezaLancamento, Guid>
    {
        Task<IEnumerable<NaturezaLancamento>> ObterPorUsuario(Guid idUsuario);
    }
}
