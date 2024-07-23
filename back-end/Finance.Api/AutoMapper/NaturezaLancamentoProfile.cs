using AutoMapper;
using Finance.Api.Contract.NaturezaLancamento;
using Finance.Api.Domain.Models;

namespace Finance.Api.AutoMapper
{
    public class NaturezaLancamentoProfile : Profile
    {
        public NaturezaLancamentoProfile()
        {
            CreateMap<NaturezaLancamento, NaturezaLancamentoRequestContract>().ReverseMap();
            CreateMap<NaturezaLancamento, NaturezaLancamentoResponseContract>().ReverseMap();

        }
    }
}
