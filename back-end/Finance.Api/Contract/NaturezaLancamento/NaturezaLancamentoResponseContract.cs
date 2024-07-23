using System.ComponentModel.DataAnnotations;

namespace Finance.Api.Contract.NaturezaLancamento
{
    public class NaturezaLancamentoResponseContract : NaturezaLancamentoRequestContract
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
    }
}
