using System.ComponentModel.DataAnnotations;

namespace Finance.Api.Contract.NaturezaLancamento
{
    public class NaturezaLancamentoRequestContract
    {
        public string Descricao { get; set; } = String.Empty;
        public string? Observacao { get; set; } = String.Empty;
    }
}
