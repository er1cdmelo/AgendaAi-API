using Application.Data.Entities;

namespace Application.Domain.Entities
{
    public class Agendamento
    {
        public Agendamento()
        {
            DsServico = string.Empty;
            Usuario = new Usuario();
            Profissional = new Profissional();
            HorarioDisponivel = new HorarioDisponivel();
        }
        public int IdAgendamento { get; set; }
        public int IdCliente { get; set; }
        public int IdProfissional { get; set; }
        public DateTimeOffset DtRegistro { get; set; }
        public DateTimeOffset DtAgendamento { get; set; }
        public int IdDataHora { get; set; } // Id do HorarioDisponivel
        public int Status { get; set; }
        public string DsServico { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual HorarioDisponivel HorarioDisponivel { get; set; }
    }
}
