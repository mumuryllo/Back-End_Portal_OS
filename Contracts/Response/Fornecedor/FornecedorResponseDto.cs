namespace PortalOS.Contracts.Response.Fornecedor
{
    public class FornecedorResponseDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public bool Ativo { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
