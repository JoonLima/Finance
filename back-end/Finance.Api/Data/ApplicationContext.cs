using Finance.Api.Data.Mappings;
using Finance.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<NaturezaLancamento> NaturezaLancamento { get; set; }
        public DbSet<APagar> APagar { get; set; }
        public DbSet<AReceber> AReceber { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new NaturezaLancamentoMap());
            modelBuilder.ApplyConfiguration(new APagarMap());
            modelBuilder.ApplyConfiguration(new AReceberMap());
        }
    }
}
