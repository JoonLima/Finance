using AutoMapper;
using Finance.Api.Contract.Usuario;
using Finance.Api.Domain.Models;
using Finance.Api.Domain.Repoository.Interfaces;
using Finance.Api.Domain.Services.Interfaces;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace Finance.Api.Domain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper, TokenService tokenService)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UsuarioLoginResponseContratc> Autenticar(UsuarioLoginRequestContract usuarioLogin)
        {
            var usuario = await _repository.ObterPorEmail(usuarioLogin.Email);
            var hashSenha = GerarHashSenha(usuarioLogin.Senha);

            if(usuario is null || usuario.Senha != hashSenha)
            {
                throw new AuthenticationException("Usuário ou senha incorretos.");
            }

            return new UsuarioLoginResponseContratc
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Token = _tokenService.GerarToken(_mapper.Map<Usuario>(usuario))
            };
        }
        public Task<UsuarioResponseContract> Atualizar(Guid id, UsuarioRequestContract entidade, Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioResponseContract> Criar(UsuarioRequestContract entidade, Guid idUsuario)
        {
            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Senha = GerarHashSenha(usuario.Senha);
            usuario.DataCadastro = DateTime.Now;

            if (verificarEmailDuplicado(usuario.Email)) throw new Exception("Este e-mail já se encontra em uso.");

            await _repository.Criar(usuario);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        public async Task Deletar(Guid id, Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioResponseContract>> Obter(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioResponseContract> ObterPorEmail(string email)
        {
            var usuario = await _repository.ObterPorEmail(email);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        public async Task<UsuarioResponseContract> ObterPorId(Guid id, Guid idUsuario)
        {
            var usuario = await _repository.ObterPorId(id);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        private string GerarHashSenha(string senha)
        {
            string hashSenha;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] byteSenha = Encoding.UTF8.GetBytes(senha);
                byte[] byteHashSenha = sha256.ComputeHash(byteSenha);
                hashSenha = BitConverter.ToString(byteHashSenha).Replace("-","").ToLower();
            }
            return hashSenha;
        }

        private bool verificarEmailDuplicado(string email)
        {
            var emailUsuario = _repository.ObterPorEmail(email);
            if (emailUsuario.Result == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
