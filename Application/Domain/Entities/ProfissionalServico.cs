using Application.Data.Entities;

namespace Application.Domain.Entities
{
    public class ProfissionalServico
    {
        public int IdProfissional { get; set; }
        public int IdServico { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual Servico Servico { get; set; }
    }
}
