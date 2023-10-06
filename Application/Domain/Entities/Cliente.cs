using Application.Data.Entities;

namespace Application.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Nome = string.Empty;
            Sexo = string.Empty;
            Cpf = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            Telefone = string.Empty;
        }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public DateTimeOffset DtNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Agendamento> Agendamentos { get; set; }
    }
}
