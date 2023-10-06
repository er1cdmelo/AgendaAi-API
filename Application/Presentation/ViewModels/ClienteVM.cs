namespace Application.Presentation.ViewModels
{
    public class ClienteVM
    {
        public ClienteVM()
        {
            nome = string.Empty;
            cpf = string.Empty;
            telefone = string.Empty;
            sexo = string.Empty;
        }
        public int id;
        public String nome;
        public string cpf;
        public string telefone;
        public string sexo;
        public int idUsuario;
    }
}
