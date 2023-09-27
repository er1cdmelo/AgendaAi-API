using Application.Infra.DTO;

namespace Application.Infra.DTO
{
    public class AgendamentoTO
    {
        public AgendamentoTO()
        {
            DsServico = string.Empty;
            Status = "Pendente";
            UsuarioTO = new UsuarioTO();
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
        public virtual UsuarioTO UsuarioTO { get; set; }
        public virtual ProfissionalTO ProfissionalTO { get; set; }
        public virtual HorarioDisponivelTO HorarioDisponivelTO { get; set; }
    }
}
