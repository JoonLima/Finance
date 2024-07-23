using System.ComponentModel.DataAnnotations;

namespace Finance.Api.Domain.Models
{
    public class NaturezaLancamento
    {
        public Guid Id { get; set; }

        public Guid IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "O descrição de nome é obrigatório.")]
        public string Descricao { get; set; } = String.Empty;

        public string? Observacao { get; set; } = String.Empty;

        [Required]
        public DateTime DataCadastro { get; set; }
    }
}
