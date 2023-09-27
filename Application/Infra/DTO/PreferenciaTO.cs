namespace Application.Infra.DTO
{
    public class PreferenciaTO
    {
        public PreferenciaTO()
        {
            CdPreferencia = string.Empty;
            ValorPreferencia = string.Empty;
        }
        public int IdPreferencia { get; set; }
        public string CdPreferencia { get; set; }
        public string ValorPreferencia { get; set; }
    }
}
