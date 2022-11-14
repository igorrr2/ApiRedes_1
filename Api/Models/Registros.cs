namespace Api.Models
{
    public class Registros
    {
        public int Id { get; set; }
        public float DistanciaEmRodoviaPavimentada { get; set; }
        public float DistanciaEmRodoviaNaoPavimentada { get; set; }
        public string VeiculoUtilizado { get; set; }
        public int Carga { get; set; }
        public float CustoTotal { get; set; }

        public Registros(int id, float distanciaEmRodoviaPavimentada, float DistanciaEmRodoviaNaoPavimentada, string veiculoUtilizado, int carga, float custoTotal)
        {
            Id = id;
            DistanciaEmRodoviaPavimentada = distanciaEmRodoviaPavimentada;
            DistanciaEmRodoviaNaoPavimentada = DistanciaEmRodoviaNaoPavimentada;
            VeiculoUtilizado = veiculoUtilizado;
            Carga = carga;
            CustoTotal = custoTotal;
        }
    }
}
