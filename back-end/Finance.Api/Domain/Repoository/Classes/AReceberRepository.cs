using Finance.Api.Data;
using Finance.Api.Domain.Models;
using Finance.Api.Domain.Repoository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finance.Api.Domain.Repoository.Classes
{
    public class AReceberRepository : IAReceberRepository
    {
        private readonly ApplicationContext _context;

        public AReceberRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AReceber> Atualizar(AReceber entidade)
        {
            AReceber tituloBanco = await _context.AReceber.Where(x => x.Id == entidade.Id)
                .FirstOrDefaultAsync() ?? throw new Exception("Titulo a receber não encontrado.");

            _context.Entry(tituloBanco).CurrentValues.SetValues(entidade);
            await _context.SaveChangesAsync();

            return await ObterPorId(tituloBanco.Id);
        }

        public async Task<AReceber> Criar(AReceber entidade)
        {
            await _context.AReceber.AddAsync(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task Deletar(AReceber entidade)
        {
            _context.Entry(entidade).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<AReceber>> Obter()
        {
            throw new NotImplementedException();
        }

        public async Task<AReceber> ObterPorId(Guid id)
        {
            return await _context.AReceber.Where(x => x.Id == id).FirstOrDefaultAsync()
                ?? throw new Exception("Titulo a receber não encontrado.");
        }

        public async Task<IEnumerable<AReceber>> ObterPorUsuario(Guid idUsuario)
        {
            return await _context.AReceber.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
