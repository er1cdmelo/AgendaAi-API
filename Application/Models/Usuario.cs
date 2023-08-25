using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    public class Usuario
    {
        public Usuario()
        {
            IdUsuario = 0;
            Nome = "";
            Email = "";
            Username = "";
            Senha = "";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto increment
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
    }
}
