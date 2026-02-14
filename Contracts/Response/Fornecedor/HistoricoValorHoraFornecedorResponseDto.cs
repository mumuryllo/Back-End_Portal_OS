namespace PortalOS.Contracts.Response.Fornecedor
{
    public class HistoricoValorHoraFornecedorResponseDto
    {
        public Guid Id { get; set; }

        public decimal ValorHora { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
