using PortalOS.Interfaces.Repositories;

namespace PortalOS.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IFornecedorRepository Fornecedores { get; }

        Task<int> CommitAsync();
    }
}
