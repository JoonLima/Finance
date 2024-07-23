namespace Finance.Api.Contract.Usuario
{
    public class UsuarioLoginRequestContract
    {
        public string Email { get; set; } = String.Empty;
        public string Senha { get; set; } = String.Empty;
    }
}
