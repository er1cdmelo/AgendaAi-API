using Application.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProfissionalVM
    {
        public ProfissionalVM()
        {
            IdProfissional = 0;
            Nome = string.Empty;
            Sexo = string.Empty;
            Especialidade = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            CdIdentificacao = 0;
            ImagemPerfil = string.Empty;
            Email = string.Empty;
            Username = string.Empty;
        }
        public int IdProfissional { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; } // M ou F
        public string Especialidade { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CdIdentificacao { get; set; }
        public string? ImagemPerfil { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

    }
}
