namespace PortalOS.Contracts.Request
{
    public class AtualizarContatoFornecedorRequestDto
    {
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Endereco { get; set; } = null!;
    }
}
