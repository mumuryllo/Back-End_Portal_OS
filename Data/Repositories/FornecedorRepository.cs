using Microsoft.EntityFrameworkCore;
using PortalOS.Data.Context;
using PortalOS.Domain.Entities;
using PortalOS.Interfaces.Repositories;

namespace PortalOS.Data.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(PortalOSDbContext context) : base(context) { }

        public async Task<Fornecedor?> ObterPorDocumentoAsync(string documento)
        {
            return await _context.Set<Fornecedor>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Documento == documento);
        }

        public async Task<Fornecedor?> ObterPorIdComHistoricosAsync(Guid id)
        {
            return await _context.Set<Fornecedor>()
                .Include(x => x.HistoricoValorHora)
                .Include(x => x.HistoricoServicos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
