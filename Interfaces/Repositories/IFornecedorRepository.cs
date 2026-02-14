using PortalOS.Domain.Entities;

namespace PortalOS.Interfaces.Repositories
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor?> ObterPorDocumentoAsync(string documento);
        Task<Fornecedor?> ObterPorIdComHistoricosAsync(Guid id);
    }
}
