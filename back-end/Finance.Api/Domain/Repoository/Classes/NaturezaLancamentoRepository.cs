using Finance.Api.Data;
using Finance.Api.Domain.Models;
using Finance.Api.Domain.Repoository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finance.Api.Domain.Repoository.Classes
{
    public class NaturezaLancamentoRepository : INaturezaLancamentoRepository
    {
        private readonly ApplicationContext _context;

        public NaturezaLancamentoRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<NaturezaLancamento> Atualizar(NaturezaLancamento entidade)
        {
            NaturezaLancamento naturezaBanco = await _context.NaturezaLancamento.Where(x => x.Id == entidade.Id)
                .FirstOrDefaultAsync() ?? throw new Exception("Natureza de lançamento não encontrada.");

            _context.Entry(naturezaBanco).CurrentValues.SetValues(entidade);
            await _context.SaveChangesAsync();

            return await ObterPorId(naturezaBanco.Id);
        }

        public async Task<NaturezaLancamento> Criar(NaturezaLancamento entidade)
        {
            await _context.NaturezaLancamento.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task Deletar(NaturezaLancamento entidade)
        {
            _context.Entry(entidade).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<NaturezaLancamento>> Obter()
        {
            throw new NotImplementedException();
        }

        public async Task<NaturezaLancamento> ObterPorId(Guid id)
        {
            return await _context.NaturezaLancamento.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NaturezaLancamento>> ObterPorUsuario(Guid idUsuario)
        {
            return await _context.NaturezaLancamento.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
