using Finance.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Api.Data.Mappings
{
    public class AReceberMap : IEntityTypeConfiguration<AReceber>
    {
        public void Configure(EntityTypeBuilder<AReceber> builder)
        {
            builder.ToTable("a_receber")
                 .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);

            builder.HasOne(x => x.NaturezaLancamento)
                .WithMany()
                .HasForeignKey(x => x.IdNaturezaLancamento);

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.ValorOriginal)
                .HasColumnName("valor_original")
                .HasColumnType("double precision")
                .IsRequired();

            builder.Property(x => x.ValorRecebido)
                .HasColumnName("valor_recebido")
                .HasColumnType("double precision");

            builder.Property(x => x.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.DataVencimento)
                .HasColumnName("data_vencimento")
                .HasColumnType("timestamp");

            builder.Property(x => x.DataRecebimento)
                .HasColumnName("data_recebimento")
                .HasColumnType("timestamp");
        }
    }
}
