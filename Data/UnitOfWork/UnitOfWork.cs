using PortalOS.Data.Context;
using PortalOS.Interfaces;
using PortalOS.Interfaces.Repositories;

namespace PortalOS.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortalOSDbContext _context;

        public IUserRepository Users { get; }
        public IFornecedorRepository Fornecedores { get; }

        public UnitOfWork(
            PortalOSDbContext context,
            IUserRepository userRepository,
            IFornecedorRepository fornecedorRepository)
        {
            _context = context;
            Users = userRepository;
            Fornecedores = fornecedorRepository;
        }

        public async Task<int> CommitAsync()
            => await _context.SaveChangesAsync();
    }
}
