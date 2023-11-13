using Application.Data.Entities;

namespace Application.Domain.Entities
{
    public class Agendamento
    {
        public Agendamento()
        {
        }
        public int IdAgendamento { get; set; }
        public int IdCliente { get; set; }
        public int IdProfissional { get; set; }
        public DateTimeOffset DtRegistro { get; set; }
        public DateTimeOffset DtAgendamento { get; set; }
        public int IdDataHora { get; set; } // Id do HorarioDisponivel
        public int IdServico { get; set; }
        public int Status { get; set; }
        public string? NmServico { get; set; }
        public double? VlServico { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual HorarioDisponivel HorarioDisponivel { get; set; }
        public virtual Servico Servico { get; set; }
    }
}
