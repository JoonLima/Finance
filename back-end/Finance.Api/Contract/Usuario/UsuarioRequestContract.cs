namespace Finance.Api.Contract.Usuario
{
    public class UsuarioRequestContract : UsuarioLoginRequestContract
    {
        public string Nome { get; set; } = String.Empty;
    }
}
