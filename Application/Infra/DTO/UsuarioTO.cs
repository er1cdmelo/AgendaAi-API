using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Infra.DTO
{
    public class UsuarioTO
    {
        public UsuarioTO()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Username = string.Empty;
        }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int IdRole { get; set; }

    }
}
