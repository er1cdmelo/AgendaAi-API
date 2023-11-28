using Application.Domain.Entities;

namespace Application.Infra.DTO
{
    public class ServicoTO
    {
        public ServicoTO()
        {
            NmServico = string.Empty;
            DsServico = string.Empty;
            FlAtivo = true;
            Profissionais = new List<int>();
        }
        public int IdServico { get; set; }
        public string NmServico { get; set; }
        public string DsServico { get; set; }
        public double VlServico { get; set; }
        public bool FlAtivo { get; set; }
        public List<int> Profissionais { get; set; }
    }
}
