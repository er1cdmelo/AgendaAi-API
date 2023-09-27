namespace Application.Infra.DTO
{
    public class HorarioDisponivelTO
    {
        public HorarioDisponivelTO()
        {
            Status = "Disponível";
        }
        public int Id { get; set; }
        public int IdCriador { get; set; }
        public DateTimeOffset DtHora { get; set; }
        public string Status { get; set; }
    }
}
