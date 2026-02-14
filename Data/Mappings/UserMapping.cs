using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalOS.Domain.Constants;
using PortalOS.Domain.Entities;

namespace PortalOS.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(DatabaseConstants.Tables.Users);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(DatabaseConstants.Columns.Id);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName(DatabaseConstants.Columns.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.PasswordHash)
                .HasColumnName(DatabaseConstants.Columns.PasswordHash)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName(DatabaseConstants.Columns.Role)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Active)
                .HasColumnName("active")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName(DatabaseConstants.Columns.CreatedAt)
                .IsRequired();

        }
    }
}
