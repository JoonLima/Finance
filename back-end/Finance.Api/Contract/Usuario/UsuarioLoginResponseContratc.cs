namespace Finance.Api.Contract.Usuario
{
    public class UsuarioLoginResponseContratc
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
    }
}
