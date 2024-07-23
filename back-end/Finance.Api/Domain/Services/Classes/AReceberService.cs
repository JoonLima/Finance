using AutoMapper;
using Finance.Api.Contract.AReceber;
using Finance.Api.Domain.Models;
using Finance.Api.Domain.Repoository.Interfaces;
using Finance.Api.Domain.Services.Interfaces;

namespace Finance.Api.Domain.Services.Classes
{
    public class AReceberService : IService<AReceberRequestContract, AReceberResponseContract, Guid>
    {
        private readonly IAReceberRepository _repository;
        private readonly IMapper _mapper;

        public AReceberService(IAReceberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AReceberResponseContract> Atualizar(Guid id, AReceberRequestContract entidade, Guid idUsuario)
        {
            var tituloBanco = await VerificarSeAReceberPertenceAoUsuario(id, idUsuario);

            var tituloParaAtualizar = _mapper.Map<AReceber>(entidade);

            tituloParaAtualizar.IdUsuario = tituloBanco.IdUsuario;
            tituloParaAtualizar.Id = tituloBanco.Id;
            tituloParaAtualizar.DataCadastro = tituloBanco.DataCadastro;

            return _mapper.Map<AReceberResponseContract>(await _repository.Atualizar(tituloParaAtualizar));
        }

        public async Task<AReceberResponseContract> Criar(AReceberRequestContract entidade, Guid idUsuario)
        {
            var tituloAReceber = _mapper.Map<AReceber>(entidade);

            tituloAReceber.DataCadastro = DateTime.Now;
            tituloAReceber.IdUsuario = idUsuario;

            tituloAReceber = await _repository.Criar(tituloAReceber);

            return _mapper.Map<AReceberResponseContract>(tituloAReceber);
        }

        public async Task Deletar(Guid id, Guid idUsuario)
        {
            var tituloAReceber = await VerificarSeAReceberPertenceAoUsuario(id, idUsuario);
            await _repository.Deletar(tituloAReceber);
        }

        public async Task<IEnumerable<AReceberResponseContract>> Obter(Guid idUsuario)
        {
            var tituloAReceber = await _repository.ObterPorUsuario(idUsuario);
            return tituloAReceber.Select(r => _mapper.Map<AReceberResponseContract>(r));
        }

        public async Task<AReceberResponseContract> ObterPorId(Guid id, Guid idUsuario)
        {
            var tituloAReceber = await VerificarSeAReceberPertenceAoUsuario(id, idUsuario);
            return _mapper.Map<AReceberResponseContract>(tituloAReceber);
        }

        private async Task<AReceber> VerificarSeAReceberPertenceAoUsuario(Guid id, Guid idUsuario)
        {
            var tituloAReceber = await _repository.ObterPorId(id);
            if (tituloAReceber is null || tituloAReceber.IdUsuario != idUsuario)
            {
                throw new Exception($"Não foi encontrado nenhum título a receber para o id {id}");
            }

            return tituloAReceber;
        }
    }
}
