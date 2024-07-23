namespace Finance.Api.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface genérica para criação de serviços do tipo CRUD.
    /// </summary>
    /// <typeparam name="Request">Contrato de request</typeparam>
    /// <typeparam name="Response">Contrato de response</typeparam>
    /// <typeparam name="Identificador">Tipo do ID</typeparam>
    public interface IService<Request, Response, Identificador> where Request : class
    {
        Task<IEnumerable<Response>> Obter(Identificador idUsuario);
        Task<Response> ObterPorId(Identificador id, Identificador idUsuario);
        Task<Response> Criar(Request entidade, Identificador idUsuario);
        Task<Response> Atualizar(Identificador id, Request entidade, Identificador idUsuario);
        Task Deletar(Identificador id, Identificador idUsuario);

    }
}
