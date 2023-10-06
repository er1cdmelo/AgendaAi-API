namespace Application.Infra.DTO
{
    public class ClienteTO
    {
        public ClienteTO()
        {
            Nome = string.Empty;
            Sexo = string.Empty;
            Cpf = string.Empty;
            Agendamentos = new List<AgendamentoTO>();
        }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public List<AgendamentoTO> Agendamentos { get; set; }
    }
}
