namespace PortalOS.Domain.Entities
{
    public class HistoricoValorHoraFornecedor
    {
        public int Id { get; private set; }

        public Guid FornecedorId { get; private set; }
        public Fornecedor Fornecedor { get; private set; } = null!;

        public decimal ValorHora { get; private set; }

        public DateTime DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }

        public DateTime CriadoEm { get; private set; }

        protected HistoricoValorHoraFornecedor() { }

        public HistoricoValorHoraFornecedor(Guid fornecedorId, decimal valorHora, DateTime dataInicio)
        {
            if (valorHora <= 0)
                throw new ArgumentException("Valor hora deve ser maior que zero.");

            FornecedorId = fornecedorId;
            ValorHora = valorHora;
            DataInicio = dataInicio;

            CriadoEm = DateTime.UtcNow;
        }

        public void Encerrar(DateTime dataFim)
        {
            if (dataFim <= DataInicio)
                throw new ArgumentException("A data fim deve ser maior que a data início.");

            DataFim = dataFim;
        }
    }
}
