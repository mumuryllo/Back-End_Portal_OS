namespace PortalOS.Contracts.Request
{
    public class HistoricoServicoFornecedorRequestDto
    {
        public decimal HorasRealizadas { get; set; }
        public decimal ValorRecebido { get; set; }
        public DateTime DataServico { get; set; }
    }
}
