using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalOS.Domain.Constants;
using PortalOS.Domain.Entities;

namespace PortalOS.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable(DatabaseConstants.Tables.Fornecedores);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(DatabaseConstants.Columns.Id);

            builder.Property(x => x.Nome)
                .HasColumnName(DatabaseConstants.Columns.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Documento)
                .HasColumnName(DatabaseConstants.Columns.Documento)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName(DatabaseConstants.Columns.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasColumnName(DatabaseConstants.Columns.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Endereco)
                .HasColumnName(DatabaseConstants.Columns.Endereco)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName(DatabaseConstants.Columns.Ativo)
                .IsRequired();

            builder.Property(x => x.CriadoEm)
                .HasColumnName(DatabaseConstants.Columns.CriadoEm)
                .IsRequired();

            builder.Property(x => x.AtualizadoEm)
                .HasColumnName(DatabaseConstants.Columns.AtualizadoEm);

            builder.HasIndex(x => x.Documento)
                .IsUnique();

            builder.HasMany(x => x.HistoricoValorHora)
                .WithOne(x => x.Fornecedor)
                .HasForeignKey(x => x.FornecedorId);

            builder.HasMany(x => x.HistoricoServicos)
                .WithOne(x => x.Fornecedor)
                .HasForeignKey(x => x.FornecedorId);
        }
    }
}
