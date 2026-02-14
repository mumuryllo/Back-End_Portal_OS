namespace PortalOS.Domain.Constants
{
    public static class DatabaseConstants
    {
        public static class Tables
        {
            public const string Users = "users";
            public const string Fornecedores = "fornecedores";
            public const string HistoricoValorHoraFornecedor = "fornecedor_valor_hora_historico";
            public const string HistoricoServicoFornecedor = "fornecedor_servico_historico";
        }

        public static class Columns
        {
            public const string Id = "id";

            // User
            public const string Email = "email";
            public const string PasswordHash = "password_hash";
            public const string Role = "role";
            public const string CreatedAt = "created_at";

            // Fornecedor
            public const string Nome = "nome";
            public const string Documento = "documento";
            public const string Telefone = "telefone";
            public const string Endereco = "endereco";
            public const string Ativo = "ativo";
            public const string CriadoEm = "criado_em";
            public const string AtualizadoEm = "atualizado_em";

            // Histórico Valor Hora
            public const string ValorHora = "valor_hora";
            public const string DataInicio = "data_inicio";
            public const string DataFim = "data_fim";

            // Histórico Serviço
            public const string HorasRealizadas = "horas_realizadas";
            public const string ValorRecebido = "valor_recebido";
            public const string DataServico = "data_servico";
        }
    }
}
