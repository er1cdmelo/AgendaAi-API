using Application.Infra.DTO;

namespace Application.Infra.DTO
{
    public class AgendamentoTO
    {
        public AgendamentoTO()
        {
            DsServico = string.Empty;
            Status = "Pendente";
            ClienteTO = new ClienteTO();
            ProfissionalTO = new ProfissionalTO();
            HorarioDisponivelTO = new HorarioDisponivelTO();
        }
        public int IdAgendamento { get; set; }
        public int IdProfissional { get; set; }
        public int IdCliente { get; set; }
        public DateTimeOffset DtRegistro { get; set; }
        public DateTimeOffset DtAgendamento { get; set; }
        public string Status { get; set; }
        public string DsServico { get; set; }
        public ClienteTO ClienteTO { get; set; }
        public ProfissionalTO ProfissionalTO { get; set; }
        public HorarioDisponivelTO HorarioDisponivelTO { get; set; }
    }
}
