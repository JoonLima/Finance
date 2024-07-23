using System.ComponentModel.DataAnnotations;

namespace Finance.Api.Domain.Models
{
    public class AReceber : Titulo
    {
        public double ValorRecebido { get; set; }
        public DateTime? DataRecebimento { get; set; }
    }
}
