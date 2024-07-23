using Finance.Api.Data;
using Finance.Api.Domain.Models;
using Finance.Api.Domain.Repoository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finance.Api.Domain.Repoository.Classes
{
    public class APagarRepository : IAPagarRepository
    {
        private readonly ApplicationContext _context;

        public APagarRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<APagar> Atualizar(APagar entidade)
        {
            APagar tituloBanco = await _context.APagar.Where(x => x.Id == entidade.Id)
                .FirstOrDefaultAsync() ?? throw new Exception("Titulo a pagar não encontrado.");

            _context.Entry(tituloBanco).CurrentValues.SetValues(entidade);
            await _context.SaveChangesAsync();

            return await ObterPorId(tituloBanco.Id);
        }

        public async Task<APagar> Criar(APagar entidade)
        {
            await _context.APagar.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task Deletar(APagar entidade)
        {
            _context.Entry(entidade).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<APagar>> Obter()
        {
            throw new NotImplementedException();
        }

        public async Task<APagar> ObterPorId(Guid id)
        {
            return await _context.APagar.Where(x => x.Id == id).FirstOrDefaultAsync()
                ?? throw new Exception("Titulo a pagar não encontrado.");
        }

        public async Task<IEnumerable<APagar>> ObterPorUsuario(Guid idUsuario)
        {
            return await _context.APagar.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
