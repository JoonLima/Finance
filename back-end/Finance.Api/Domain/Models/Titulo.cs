using System.ComponentModel.DataAnnotations;

namespace Finance.Api.Domain.Models
{
    public abstract class Titulo
    {
        public Guid Id { get; set; }

        public Guid IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        public Guid IdNaturezaLancamento { get; set; }

        public NaturezaLancamento NaturezaLancamento { get; set; }

        [Required(ErrorMessage = "O descrição de nome é obrigatório.")]
        public string Descricao { get; set; } = String.Empty;

        [Required(ErrorMessage = "O campo valor original é obrigatório.")]
        public double ValorOriginal { get; set; }

        public string? Observacao { get; set; } = String.Empty;

        [Required]
        public DateTime DataCadastro { get; set; }

        public DateTime? DataVencimento { get; set; }

    }
}
