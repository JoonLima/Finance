using Finance.Api.Data;
using Finance.Api.Domain.Models;
using Finance.Api.Domain.Repoository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finance.Api.Domain.Repoository.Classes
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Atualizar(Usuario entidade)
        {
            Usuario usuarioBanco = await _context.Usuario.Where(x => x.Id == entidade.Id)
                .FirstOrDefaultAsync() ?? throw new Exception("Usuário não encontrado.");

            _context.Entry(usuarioBanco).CurrentValues.SetValues(entidade);
            await _context.SaveChangesAsync();

            return await ObterPorId(usuarioBanco.Id);
        }

        public async Task<Usuario> Criar(Usuario entidade)
        {
            await _context.Usuario.AddAsync(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task Deletar(Usuario entidade)
        {
            _context.Entry(entidade).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _context.Usuario.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            Usuario? usuarioBanco = await _context.Usuario.Where(x => x.Email == email)
                .FirstOrDefaultAsync();

            return usuarioBanco;
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            Usuario usuarioBanco = await _context.Usuario.Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? throw new Exception("Usuário não encontrado.");

            return usuarioBanco;
        }
    }
}
