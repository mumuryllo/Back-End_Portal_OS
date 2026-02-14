using FluentValidation;
using PortalOS.Contracts.Request.Fornecedor;

namespace PortalOS.Validators
{
    public class FornecedorRequestValidator : AbstractValidator<FornecedorRequestDto>
    {
        public FornecedorRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(150).WithMessage("Nome deve ter no máximo 150 caracteres.");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("Documento é obrigatório.")
                .MaximumLength(20).WithMessage("Documento deve ter no máximo 20 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .MaximumLength(20).WithMessage("Telefone deve ter no máximo 20 caracteres.");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("Endereço é obrigatório.")
                .MaximumLength(200).WithMessage("Endereço deve ter no máximo 200 caracteres.");
        }
    }
}
