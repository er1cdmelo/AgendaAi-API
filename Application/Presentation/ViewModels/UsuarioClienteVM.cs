namespace Application.Presentation.ViewModels
{
    public class UsuarioClienteVM
    {
        public UsuarioClienteVM()
        {
            IdUsuario = 0;
            Nome = string.Empty;
            Sexo = string.Empty;
            Cpf = string.Empty;
            DtNascimento = DateTimeOffset.MinValue;
            Cidade = string.Empty;
            Estado = string.Empty;
            Email = string.Empty;
            Username = string.Empty;
            Senha = string.Empty;
        }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; } // M ou F
        public string Cpf { get; set; }
        public DateTimeOffset DtNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
    }
}
