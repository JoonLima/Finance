namespace Finance.Api.Contract.AReceber
{
    public class AReceberResponseContract : AReceberRequestContract
    {
        public Guid Id { get; set; }

        public Guid IdUsuario { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
