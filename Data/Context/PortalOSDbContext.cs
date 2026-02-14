using Microsoft.EntityFrameworkCore;
using PortalOS.Data.Mappings;
using PortalOS.Domain.Entities;

namespace PortalOS.Data.Context
{
    public class PortalOSDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public PortalOSDbContext(DbContextOptions<PortalOSDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.ApplyConfiguration(new UserMapping());

            //Fornecedor
            modelBuilder.ApplyConfiguration(new FornecedorMapping());
            modelBuilder.ApplyConfiguration(new HistoricoValorHoraFornecedorMapping());
            modelBuilder.ApplyConfiguration(new HistoricoServicoFornecedorMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
