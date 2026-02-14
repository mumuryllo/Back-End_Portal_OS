namespace PortalOS.Contracts.Response
{
    public class HistoricoServicoFornecedorResponseDto
    {
        public int Id { get; set; }

        public decimal HorasRealizadas { get; set; }
        public decimal ValorRecebido { get; set; }
        public DateTime DataServico { get; set; }
    }
}
