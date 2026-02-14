namespace PortalOS.Domain.Entities
{
    public class Fornecedor
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; } = null!;
        public string Documento { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Telefone { get; private set; } = null!;
        public string Endereco { get; private set; } = null!;
        public bool Ativo { get; private set; }

        public DateTime CriadoEm { get; private set; }
        public DateTime? AtualizadoEm { get; private set; }

        public ICollection<HistoricoValorHoraFornecedor> HistoricoValorHora { get; private set; }
            = new List<HistoricoValorHoraFornecedor>();

        public ICollection<HistoricoServicoFornecedor> HistoricoServicos { get; private set; }
            = new List<HistoricoServicoFornecedor>();

        protected Fornecedor() { }

        public Fornecedor(string nome, string documento, string email, string telefone, string endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Ativo = true;

            CriadoEm = DateTime.UtcNow;
        }

        public void AtualizarContato(string email, string telefone, string endereco)
        {
            Email = email;
            Telefone = telefone;
            Endereco = endereco;

            AtualizadoEm = DateTime.UtcNow;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
            AtualizadoEm = DateTime.UtcNow;
        }

        public void Desativar()
        {
            Ativo = false;
            AtualizadoEm = DateTime.UtcNow;
        }

        public void Ativar()
        {
            Ativo = true;
            AtualizadoEm = DateTime.UtcNow;
        }

        public void AdicionarNovoValorHora(decimal valorHora, DateTime dataInicio)
        {
            if (valorHora <= 0)
                throw new ArgumentException("O valor hora deve ser maior que zero.");

            var valorHoraAtual = HistoricoValorHora
                .FirstOrDefault(x => x.DataFim == null);

            if (valorHoraAtual != null)
                valorHoraAtual.Encerrar(dataInicio);

            HistoricoValorHora.Add(new HistoricoValorHoraFornecedor(Id, valorHora, dataInicio));
        }

        public void RegistrarServico(decimal horasRealizadas, decimal valorRecebido, DateTime dataServico)
        {
            if (horasRealizadas <= 0)
                throw new ArgumentException("Horas realizadas deve ser maior que zero.");

            if (valorRecebido < 0)
                throw new ArgumentException("Valor recebido não pode ser negativo.");

            HistoricoServicos.Add(new HistoricoServicoFornecedor(Id, horasRealizadas, valorRecebido, dataServico));
        }

        public decimal ObterValorHoraAtual()
        {
            var atual = HistoricoValorHora
                .OrderByDescending(x => x.DataInicio)
                .FirstOrDefault(x => x.DataFim == null);

            if (atual == null)
                return 0;

            return atual.ValorHora;
        }
    }
}
