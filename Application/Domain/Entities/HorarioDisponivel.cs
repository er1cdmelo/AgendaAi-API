using Application.Data.Entities;
using Application.Models;

namespace Application.Domain.Entities
{
    public class HorarioDisponivel
    {
        public HorarioDisponivel()
        {
            Status = "Disponivel";
        }
        public int Id { get; set; }
        public int IdProfissional { get; set; }
        public DateTimeOffset DtHora { get; set; }
        public string Status { get; set; }
        public virtual Profissional Profissional { get; set; }
    }
}
