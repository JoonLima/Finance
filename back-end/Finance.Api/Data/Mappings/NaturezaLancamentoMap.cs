using Finance.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Api.Data.Mappings
{
    public class NaturezaLancamentoMap : IEntityTypeConfiguration<NaturezaLancamento>
    {
        public void Configure(EntityTypeBuilder<NaturezaLancamento> builder)
        {
            builder.ToTable("natureza_lancamento")
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro")
                .HasColumnType("timestamp")
                .IsRequired();

        }
    }
}
