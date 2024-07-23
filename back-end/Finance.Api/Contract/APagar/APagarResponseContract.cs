using System.ComponentModel.DataAnnotations;

namespace Finance.Api.Contract.APagar
{
    public class APagarResponseContract : APagarRequestContract
    {
        public Guid Id { get; set; }

        public Guid IdUsuario { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
