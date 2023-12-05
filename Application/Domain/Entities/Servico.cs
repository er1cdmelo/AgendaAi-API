namespace Application.Domain.Entities
{
    public class Servico
    {
        public Servico()
        {
            NmServico = string.Empty;
            DsServico = string.Empty;
            FlAtivo = true;
            ProfissionalServicos = new List<ProfissionalServico>();
        }
        public int IdServico { get; set; }
        public string NmServico { get; set; }
        public string DsServico { get; set; }
        public double VlServico { get; set; }
        public bool FlAtivo { get; set; }
        public virtual List<ProfissionalServico> ProfissionalServicos { get; set; }
    }
}
