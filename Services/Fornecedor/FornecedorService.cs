using PortalOS.Contracts.Request.Fornecedor;
using PortalOS.Domain.Entities;
using PortalOS.Exceptions;
using PortalOS.Interfaces;
using PortalOS.Services.Interfaces;

namespace PortalOS.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FornecedorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Fornecedor> CriarFornecedorAsync(FornecedorRequestDto dto)
        {
            var existente = await _unitOfWork.Fornecedores.ObterPorDocumentoAsync(dto.Documento);

            if (existente != null)
                throw new ConflictException("Já existe um fornecedor cadastrado com esse documento.");

            var fornecedor = new Fornecedor(dto.Nome, dto.Documento, dto.Email, dto.Telefone, dto.Endereco);

            await _unitOfWork.Fornecedores.AddAsync(fornecedor);
            await _unitOfWork.CommitAsync();

            return fornecedor;
        }

        public async Task<Fornecedor> ObterFornecedorPorIdAsync(Guid id)
        {
            var fornecedor = await _unitOfWork.Fornecedores.GetByIdAsync(id);

            if (fornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado.");

            return fornecedor;
        }

        public async Task AtualizarContatoFornecedorAsync(Guid fornecedorId, string email, string telefone, string endereco)
        {
            var fornecedor = await _unitOfWork.Fornecedores.GetByIdAsync(fornecedorId);

            if (fornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado.");

            fornecedor.AtualizarContato(email, telefone, endereco);

            _unitOfWork.Fornecedores.Update(fornecedor);
            await _unitOfWork.CommitAsync();
        }

        public async Task AdicionarValorHoraAsync(Guid fornecedorId, decimal valorHora, DateTime dataInicio)
        {
            var fornecedor = await _unitOfWork.Fornecedores.ObterPorIdComHistoricosAsync(fornecedorId);

            if (fornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado.");

            fornecedor.AdicionarNovoValorHora(valorHora, dataInicio);

            _unitOfWork.Fornecedores.Update(fornecedor);
            await _unitOfWork.CommitAsync();
        }

        public async Task RegistrarServicoAsync(Guid fornecedorId, decimal horas, decimal valorRecebido, DateTime dataServico)
        {
            var fornecedor = await _unitOfWork.Fornecedores.ObterPorIdComHistoricosAsync(fornecedorId);

            if (fornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado.");

            fornecedor.RegistrarServico(horas, valorRecebido, dataServico);

            _unitOfWork.Fornecedores.Update(fornecedor);
            await _unitOfWork.CommitAsync();
        }

        public async Task DesativarFornecedorAsync(Guid fornecedorId)
        {
            var fornecedor = await _unitOfWork.Fornecedores.GetByIdAsync(fornecedorId);

            if (fornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado.");

            fornecedor.Desativar();

            _unitOfWork.Fornecedores.Update(fornecedor);
            await _unitOfWork.CommitAsync();
        }
    }
}
