using Application.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            IdUsuario = 0;
            Nome = string.Empty;
            Email = string.Empty;
            Username = string.Empty;
            Senha = string.Empty;
            Token = string.Empty;
            RefreshToken = string.Empty;
            IdRole = 0;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto increment
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public int IdRole { get; set; }

        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public string RefreshToken { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
