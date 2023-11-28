using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.Domain.Entities;

namespace Application.Data.Entities
{
    public class Profissional
    {
        public Profissional()
        {
            Nome = string.Empty;
            Sexo = string.Empty;
            Especialidade = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            ImagemPerfil = string.Empty;
            HorariosDisponiveis = new List<HorarioDisponivel>();
            Agendamentos = new List<Agendamento>();
            ProfissionalServicos = new List<ProfissionalServico>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto increment
        public int IdProfissional { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; } // M ou F
        public string Especialidade { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CdIdentificacao { get; set; }
        public string? ImagemPerfil { get; set; }
        public virtual List<HorarioDisponivel> HorariosDisponiveis { get; set; }
        public virtual List<Agendamento> Agendamentos { get; set; }
        public virtual List<ProfissionalServico> ProfissionalServicos { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
