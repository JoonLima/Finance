using System.ComponentModel.DataAnnotations;

namespace Finance.Api.Domain.Models
{
    public class Usuario
     {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Nome { get; set; } = String.Empty;

        [Required(ErrorMessage = "O campo de e-mail é obrigatório.")]
        public string Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "O campo de senha é obrigatório.")]
        public string Senha { get; set; } = String.Empty;

        [Required]
        public DateTime DataCadastro { get; set; }

        public DateTime? DataInativacao { get; set; }
    }
}
