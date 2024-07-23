namespace Finance.Api.Contract.APagar
{
    public class APagarRequestContract
    {
        public Guid IdNaturezaLancamento { get; set; }

        public string Descricao { get; set; } = String.Empty;

        public double ValorOriginal { get; set; }

        public double ValorPago { get; set; }

        public string? Observacao { get; set; } = String.Empty;

        public DateTime? DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }
    }
}
