using PortalOS.Contracts.Request.Fornecedor;
using PortalOS.Domain.Entities;

namespace PortalOS.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<Fornecedor> CriarFornecedorAsync(FornecedorRequestDto dto);

        Task<Fornecedor> ObterFornecedorPorIdAsync(Guid id);

        Task AtualizarContatoFornecedorAsync(Guid fornecedorId, string email, string telefone, string endereco);

        Task AdicionarValorHoraAsync(Guid fornecedorId, decimal valorHora, DateTime dataInicio);

        Task RegistrarServicoAsync(Guid fornecedorId, decimal horas, decimal valorRecebido, DateTime dataServico);

        Task DesativarFornecedorAsync(Guid fornecedorId);
    }
}
