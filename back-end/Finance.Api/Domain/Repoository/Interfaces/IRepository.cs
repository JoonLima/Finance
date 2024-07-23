namespace Finance.Api.Domain.Repoository.Interfaces
{
    public interface IRepository<Tipo, Identificador> where Tipo : class
    {
        Task<IEnumerable<Tipo>> Obter();
        Task<Tipo> ObterPorId(Identificador id);
        Task<Tipo> Criar(Tipo entidade);
        Task<Tipo> Atualizar(Tipo entidade);
        Task Deletar(Tipo entidade);

    }
}
