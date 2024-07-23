using AutoMapper;
using Finance.Api.Contract.APagar;
using Finance.Api.Domain.Models;

namespace Finance.Api.AutoMapper
{
    public class APagarProfile : Profile
    {
        public APagarProfile()
        {
            CreateMap<APagar, APagarRequestContract>().ReverseMap();
            CreateMap<APagar, APagarResponseContract>().ReverseMap();
        }
    }
}
