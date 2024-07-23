using System.ComponentModel.DataAnnotations;

namespace Finance.Api.Domain.Models
{
    public class APagar : Titulo
    {
        public double ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
