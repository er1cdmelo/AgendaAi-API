using Application.Infra.DTO;

namespace Application.Infra.DTO
{
    public class AgendamentoTO
    {
        public AgendamentoTO()
        {
            Status = "Pendente";
            ClienteTO = new ClienteTO();
            ProfissionalTO = new ProfissionalTO();
            HorarioDisponivelTO = new HorarioDisponivelTO();
        }
        public int IdAgendamento { get; set; }
        public int IdProfissional { get; set; }
        public int IdCliente { get; set; }
        public int IdServico { get; set; }
        public DateTimeOffset DtRegistro { get; set; }
        public DateTimeOffset DtAgendamento { get; set; }
        public string Status { get; set; }
        public string? NmServico { get; set; }
        public double? VlServico { get; set; }
        public ClienteTO ClienteTO { get; set; }
        public ProfissionalTO ProfissionalTO { get; set; }
        public HorarioDisponivelTO HorarioDisponivelTO { get; set; }
        public ServicoTO Servico { get; set; }
    }
}
