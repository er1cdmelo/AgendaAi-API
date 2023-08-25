using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class Profissional
    {
        public Profissional()
        {
            IdProfissional = 0;
            IdUsuario = 0;
            Nome = "";
            Sexo = "";
            Especialidade = "";
            Cidade = "";
            Estado = "";
            CdIdentificacao = 0;
            ImagemPerfil = "";
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
        public virtual Usuario Usuario { get; set; }
    }
}
