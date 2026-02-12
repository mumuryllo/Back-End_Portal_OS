using PortalOS.Interfaces.Repositories;

namespace PortalOS.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
