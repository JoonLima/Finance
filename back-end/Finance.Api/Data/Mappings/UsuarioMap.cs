using Finance.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Api.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario")
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("senha")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.DataInativacao)
                .HasColumnName("data_inativacao")
                .HasColumnType("timestamp");
        }
    }
}
