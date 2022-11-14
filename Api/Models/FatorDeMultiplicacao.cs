namespace Api.Models
{
    public class FatorDeMultiplicacao
    {
        public string veiculo { get; set; }

        public float fatorDeMultiplicacao { get; set; }

        public FatorDeMultiplicacao(string veiculo, float fatorDeMultiplicacao)
        {
            this.veiculo = veiculo;
            this.fatorDeMultiplicacao = fatorDeMultiplicacao;
        }
    }
}
