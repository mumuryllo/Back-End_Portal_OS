using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalOS.Domain.Constants;
using PortalOS.Domain.Entities;

namespace PortalOS.Data.Mappings
{
    public class HistoricoValorHoraFornecedorMapping : IEntityTypeConfiguration<HistoricoValorHoraFornecedor>
    {
        public void Configure(EntityTypeBuilder<HistoricoValorHoraFornecedor> builder)
        {
            builder.ToTable(DatabaseConstants.Tables.HistoricoValorHoraFornecedor);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(DatabaseConstants.Columns.Id);

            builder.Property(x => x.FornecedorId)
                .HasColumnName("fornecedor_id")
                .IsRequired();

            builder.Property(x => x.ValorHora)
                .HasColumnName(DatabaseConstants.Columns.ValorHora)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.DataInicio)
                .HasColumnName(DatabaseConstants.Columns.DataInicio)
                .IsRequired();

            builder.Property(x => x.DataFim)
                .HasColumnName(DatabaseConstants.Columns.DataFim);

            builder.Property(x => x.CriadoEm)
                .HasColumnName(DatabaseConstants.Columns.CriadoEm)
                .IsRequired();
        }
    }
}
