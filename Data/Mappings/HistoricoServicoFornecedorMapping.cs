using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalOS.Domain.Constants;
using PortalOS.Domain.Entities;

namespace PortalOS.Data.Mappings
{
    public class HistoricoServicoFornecedorMapping : IEntityTypeConfiguration<HistoricoServicoFornecedor>
    {
        public void Configure(EntityTypeBuilder<HistoricoServicoFornecedor> builder)
        {
            builder.ToTable(DatabaseConstants.Tables.HistoricoServicoFornecedor);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(DatabaseConstants.Columns.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FornecedorId)
                .HasColumnName("fornecedor_id")
                .IsRequired();

            builder.Property(x => x.HorasRealizadas)
                .HasColumnName(DatabaseConstants.Columns.HorasRealizadas)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.ValorRecebido)
                .HasColumnName(DatabaseConstants.Columns.ValorRecebido)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.DataServico)
                .HasColumnName(DatabaseConstants.Columns.DataServico)
                .IsRequired();

            builder.Property(x => x.CriadoEm)
                .HasColumnName(DatabaseConstants.Columns.CriadoEm)
                .IsRequired();
        }
    }
}
