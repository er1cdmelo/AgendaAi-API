namespace Application.Presentation.ViewModels
{
    public class UsuarioRegistroVM
    {
        public UsuarioRegistroVM()
        {
            Nome = string.Empty;
            Sexo = string.Empty;
            Email = string.Empty;
            Username = string.Empty;
            Senha = string.Empty;
        }
        public string Nome { get; set; }
        public string Sexo { get; set; } // M ou F
        public string Email { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
    }
}
