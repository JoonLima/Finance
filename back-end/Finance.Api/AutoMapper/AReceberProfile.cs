using AutoMapper;
using Finance.Api.Contract.AReceber;
using Finance.Api.Domain.Models;

namespace Finance.Api.AutoMapper
{
    public class AReceberProfile : Profile
    {
        public AReceberProfile()
        {
            CreateMap<AReceber, AReceberRequestContract>().ReverseMap();
            CreateMap<AReceber, AReceberResponseContract>().ReverseMap();
        }
    }
}
