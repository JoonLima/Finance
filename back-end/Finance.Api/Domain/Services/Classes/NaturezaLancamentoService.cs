using AutoMapper;
using Finance.Api.Contract.NaturezaLancamento;
using Finance.Api.Domain.Models;
using Finance.Api.Domain.Repoository.Interfaces;
using Finance.Api.Domain.Services.Interfaces;

namespace Finance.Api.Domain.Services.Classes
{
    public class NaturezaLancamentoService : IService<NaturezaLancamentoRequestContract, NaturezaLancamentoResponseContract, Guid>
    {
        private readonly INaturezaLancamentoRepository _repository;
        private readonly IMapper _mapper;

        public NaturezaLancamentoService(INaturezaLancamentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NaturezaLancamentoResponseContract> Atualizar(Guid id, NaturezaLancamentoRequestContract entidade, Guid idUsuario)
        {
            var naturezaLancamentoBanco = await VerificarSeNaturezaPertenceAoUsuario(id, idUsuario);

            var naturezaParaAtualizar = _mapper.Map<NaturezaLancamento>(entidade);

            naturezaParaAtualizar.IdUsuario = naturezaLancamentoBanco.IdUsuario;
            naturezaParaAtualizar.Id = naturezaLancamentoBanco.Id;
            naturezaParaAtualizar.DataCadastro = naturezaLancamentoBanco.DataCadastro;

            return _mapper.Map<NaturezaLancamentoResponseContract>(await _repository.Atualizar(naturezaParaAtualizar));
        }

        public async Task<NaturezaLancamentoResponseContract> Criar(NaturezaLancamentoRequestContract entidade, Guid idUsuario)
        {
            var naturezaLancamento = _mapper.Map<NaturezaLancamento>(entidade);
            naturezaLancamento.DataCadastro = DateTime.Now;
            naturezaLancamento.IdUsuario = idUsuario;
            await _repository.Criar(naturezaLancamento);

            return _mapper.Map<NaturezaLancamentoResponseContract>(naturezaLancamento);
        }

        public async Task Deletar(Guid id, Guid idUsuario)
        {
            var naturezaLancamento = await VerificarSeNaturezaPertenceAoUsuario(id, idUsuario);
            await _repository.Deletar(naturezaLancamento);
        }

        public async Task<IEnumerable<NaturezaLancamentoResponseContract>> Obter(Guid idUsuario)
        {
            var naturezasLancamento = await _repository.ObterPorUsuario(idUsuario);
            return naturezasLancamento.Select(n => _mapper.Map<NaturezaLancamentoResponseContract>(n));
        }

        public async Task<NaturezaLancamentoResponseContract> ObterPorId(Guid id, Guid idUsuario)
        {
            var naturezaLancamento = await VerificarSeNaturezaPertenceAoUsuario(id, idUsuario);
            return _mapper.Map<NaturezaLancamentoResponseContract>(naturezaLancamento);
        }

        private async Task<NaturezaLancamento> VerificarSeNaturezaPertenceAoUsuario(Guid id, Guid idUsuario)
        {
            var naturezaLancamento = await _repository.ObterPorId(id);
            if(naturezaLancamento is null || naturezaLancamento.IdUsuario != idUsuario)
            {
                throw new Exception($"Não foi encontrada nenhuma natureza de lançamento para o id {id}");
            }

            return naturezaLancamento;
        }
    }
}
