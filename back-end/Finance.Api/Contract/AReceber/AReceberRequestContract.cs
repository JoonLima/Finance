namespace Finance.Api.Contract.AReceber
{
    public class AReceberRequestContract
    {
        public Guid IdNaturezaLancamento { get; set; }

        public string Descricao { get; set; } = String.Empty;

        public double ValorOriginal { get; set; }

        public double ValorRecebido { get; set; }

        public string? Observacao { get; set; } = String.Empty;

        public DateTime? DataVencimento { get; set; }

        public DateTime? DataRecebimento { get; set; }
    }
}
