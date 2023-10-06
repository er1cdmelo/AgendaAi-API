namespace Application.Application.Global
{
    public class FuncoesGerais
    {
        public static string TiraPontuacaoCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }
    }
}
