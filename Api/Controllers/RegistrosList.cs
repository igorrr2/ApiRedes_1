using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosList : ControllerBase
    {
        private static List<Registros> Registros = new List<Registros>();
        [HttpGet]
        public List<Registros> GetT()
        {
            return Registros;
        }
        [HttpPost]
        public void Post(int id, float DistanciaEmRodoviaPavimentada, float DistanciaEmRodoviaNaoPavimentada, string VeiculoUtilizado, int Carga)
        {
            List<FatorDeMultiplicacao> Fatores = new List<FatorDeMultiplicacao>();
            FatoresDeMultiplicacaoList retorno = new FatoresDeMultiplicacaoList();
            Fatores = retorno.getForaDaClasse();
            float FatorDeMultiplicacao = 0;
            float CustoTotal = 0;
            foreach (FatorDeMultiplicacao fator in Fatores)
            {
                if(VeiculoUtilizado == fator.veiculo)
                {
                    FatorDeMultiplicacao = fator.fatorDeMultiplicacao;
                }
            }
            CustoTotal = CustoTotal + (DistanciaEmRodoviaPavimentada * (float)0.63);
            CustoTotal = CustoTotal + (DistanciaEmRodoviaNaoPavimentada * (float)0.72);
            CustoTotal = CustoTotal * FatorDeMultiplicacao;
            if (Carga > 5)
                CustoTotal = CustoTotal + (((Carga - 5) * (float)0.03) * (DistanciaEmRodoviaPavimentada + DistanciaEmRodoviaNaoPavimentada));

            Registros.Add(new Registros(id, DistanciaEmRodoviaPavimentada, DistanciaEmRodoviaNaoPavimentada
                , VeiculoUtilizado, Carga, CustoTotal));
        }
        [HttpDelete]
        public void Delete(int id)
        {
            foreach(Registros item in Registros)
            {
                if (item.Id == id)
                {
                    Registros.Remove(item);
                    break;
                }    
            }
            
        }
        [HttpPut]
        public void Put(int id, float DistanciaEmRodoviaPavimentada, float DistanciaEmRodoviaNaoPavimentada, string VeiculoUtilizado, int Carga)
        {
            List<FatorDeMultiplicacao> Fatores = new List<FatorDeMultiplicacao>();
            FatoresDeMultiplicacaoList retorno = new FatoresDeMultiplicacaoList();
            Fatores = retorno.getForaDaClasse();
            float FatorDeMultiplicacao = 0;
            float CustoTotal = 0;
            foreach (FatorDeMultiplicacao fator in Fatores)
            {
                if (VeiculoUtilizado == fator.veiculo)
                {
                    FatorDeMultiplicacao = fator.fatorDeMultiplicacao;
                }
            }
            foreach (Registros item in Registros)
            {
                if (item.Id == id)
                {

                    CustoTotal = CustoTotal + (DistanciaEmRodoviaPavimentada * (float)0.63);
                    CustoTotal = CustoTotal + (DistanciaEmRodoviaNaoPavimentada * (float)0.72);
                    CustoTotal = CustoTotal * FatorDeMultiplicacao;
                    if (Carga > 5)
                        CustoTotal = CustoTotal + (((Carga - 5) * (float)0.03) * (DistanciaEmRodoviaPavimentada + DistanciaEmRodoviaNaoPavimentada));
                    item.Carga = Carga;
                    item.DistanciaEmRodoviaNaoPavimentada = DistanciaEmRodoviaNaoPavimentada;
                    item.DistanciaEmRodoviaPavimentada = DistanciaEmRodoviaPavimentada;
                    item.CustoTotal = CustoTotal;
                    item.VeiculoUtilizado = VeiculoUtilizado;
                    break;
                }
            }


        }
    }
}
