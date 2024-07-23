namespace Finance.Api.Contract.Usuario
{
    public class UsuarioResponseContract : UsuarioRequestContract
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
