using AutoMapper;
using Finance.Api.Contract.APagar;
using Finance.Api.Domain.Models;
using Finance.Api.Domain.Repoository.Interfaces;
using Finance.Api.Domain.Services.Interfaces;

namespace Finance.Api.Domain.Services.Classes
{
    public class APagarService : IService<APagarRequestContract, APagarResponseContract, Guid>
    {
        private readonly IAPagarRepository _repository;
        private readonly IMapper _mapper;

        public APagarService(IAPagarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<APagarResponseContract> Atualizar(Guid id, APagarRequestContract entidade, Guid idUsuario)
        {
            var tituloBanco = await VerificarSeAPagarPertenceAoUsuario(id, idUsuario);

            var tituloParaAtualizar = _mapper.Map<APagar>(entidade);

            tituloParaAtualizar.IdUsuario = tituloBanco.IdUsuario;
            tituloParaAtualizar.Id = tituloBanco.Id;
            tituloParaAtualizar.DataCadastro = tituloBanco.DataCadastro;

            return _mapper.Map<APagarResponseContract>(await _repository.Atualizar(tituloParaAtualizar));

        }

        public async Task<APagarResponseContract> Criar(APagarRequestContract entidade, Guid idUsuario)
        {
            var tituloAPagar = _mapper.Map<APagar>(entidade);

            tituloAPagar.DataCadastro = DateTime.Now;
            tituloAPagar.IdUsuario = idUsuario;

            tituloAPagar = await _repository.Criar(tituloAPagar);

            return _mapper.Map<APagarResponseContract>(tituloAPagar);
        }

        public async Task Deletar(Guid id, Guid idUsuario)
        {
            var tituloAPagar = await VerificarSeAPagarPertenceAoUsuario(id, idUsuario);
            await _repository.Deletar(tituloAPagar);
        }

        public async Task<IEnumerable<APagarResponseContract>> Obter(Guid idUsuario)
        {
            var tituloAPagar = await _repository.ObterPorUsuario(idUsuario);
            return tituloAPagar.Select(p => _mapper.Map<APagarResponseContract>(p));
        }

        public async Task<APagarResponseContract> ObterPorId(Guid id, Guid idUsuario)
        {
            var tituloAPagar = await VerificarSeAPagarPertenceAoUsuario(id, idUsuario);
            return _mapper.Map<APagarResponseContract>(tituloAPagar);
        }

        private async Task<APagar> VerificarSeAPagarPertenceAoUsuario(Guid id, Guid idUsuario)
        {
            var tituloAPagar = await _repository.ObterPorId(id);
            if (tituloAPagar is null || tituloAPagar.IdUsuario != idUsuario)
            {
                throw new Exception($"Não foi encontrado nenhum título a pagar para o id {id}");
            }

            return tituloAPagar;
        }
    }
}
