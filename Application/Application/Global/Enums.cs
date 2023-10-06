namespace Application.Application.Global
{
    public class Enums
    {
        public enum UserRole
        {
            Admin = 1,
            Worker = 2,
            Client = 3
        }

        public enum IdTipoPreferencia
        {
            Texto = 1,
            Numero = 2,
            Data = 3,
            Hora = 4,
            TextoLongo = 5,
            Booleano = 6,
            Lista = 7,
            Imagem = 8
        }

        public enum StatusAgendamento
        {
            Pendente = 1,
            Confirmado = 2,
            Finalizado = 3,
            Cancelado = 4
        }
    }
}
