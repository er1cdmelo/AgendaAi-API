namespace Application.Infra.DTO
{
    public class ProfissionalTO
    {
        public ProfissionalTO()
        {
            Nome = string.Empty;
            Sexo = string.Empty;
            Especialidade = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            ImagemPerfil = string.Empty;
            HorariosDisponiveis = new List<HorarioDisponivelTO>();
        }
        public int IdProfissional { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Especialidade { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CdIdentificacao { get; set; }
        public string? ImagemPerfil { get; set; }
        public List<HorarioDisponivelTO> HorariosDisponiveis { get; set; }
    }
}
