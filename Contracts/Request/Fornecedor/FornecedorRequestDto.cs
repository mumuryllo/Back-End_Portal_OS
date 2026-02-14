namespace PortalOS.Contracts.Request.Fornecedor
{
    public class FornecedorRequestDto
    {
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Endereco { get; set; } = null!;
    }
}