namespace PortalOS.Domain.Entities
{
    public class HistoricoServicoFornecedor
    {
        public int Id { get; private set; }

        public Guid FornecedorId { get; private set; }
        public Fornecedor Fornecedor { get; private set; } = null!;

        public decimal HorasRealizadas { get; private set; }
        public decimal ValorRecebido { get; private set; }

        public DateTime DataServico { get; private set; }
        public DateTime CriadoEm { get; private set; }

        protected HistoricoServicoFornecedor() { }

        public HistoricoServicoFornecedor(Guid fornecedorId, decimal horasRealizadas, decimal valorRecebido, DateTime dataServico)
        {
            if (horasRealizadas <= 0)
                throw new ArgumentException("Horas realizadas deve ser maior que zero.");

            if (valorRecebido < 0)
                throw new ArgumentException("Valor recebido não pode ser negativo.");

            FornecedorId = fornecedorId;
            HorasRealizadas = horasRealizadas;
            ValorRecebido = valorRecebido;
            DataServico = dataServico;

            CriadoEm = DateTime.UtcNow;
        }

        public decimal CalcularValorHoraMedio()
        {
            if (HorasRealizadas == 0)
                return 0;

            return ValorRecebido / HorasRealizadas;
        }
    }
}
