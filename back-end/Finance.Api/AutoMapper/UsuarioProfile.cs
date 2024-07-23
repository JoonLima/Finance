using AutoMapper;
using Finance.Api.Contract.Usuario;
using Finance.Api.Domain.Models;

namespace Finance.Api.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioRequestContract>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseContract>().ReverseMap();

        }
    }
}
