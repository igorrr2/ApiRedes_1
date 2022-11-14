using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FatoresDeMultiplicacaoList : ControllerBase
    {
        private static List<FatorDeMultiplicacao> Fatores = new List<FatorDeMultiplicacao>();
        [HttpGet]
        public List<FatorDeMultiplicacao> Get()
        {
            return Fatores;
        }
        [HttpPost]
        public void Post()
        {

            Fatores.Add(new FatorDeMultiplicacao("Veículo urbano de carga (VUC)", (float)1.00));
            Fatores.Add(new FatorDeMultiplicacao("Caminhão 3/4", (float)1.05));
            Fatores.Add(new FatorDeMultiplicacao("Caminhão toco", (float)1.08));
            Fatores.Add(new FatorDeMultiplicacao("Carreta simples", (float)1.13));
            Fatores.Add(new FatorDeMultiplicacao("Carreta eixo estendido", (float)1.19));
            
           
        }
        [HttpPut]
        public void Put(string veiculo, float fatorDeMultiplicacao)
        {
            FatoresDeMultiplicacaoList retorno = new FatoresDeMultiplicacaoList();
            Fatores = retorno.getForaDaClasse();
            foreach (FatorDeMultiplicacao fator in Fatores)
            {
                if(fator.veiculo == veiculo)
                {
                    fator.fatorDeMultiplicacao = fatorDeMultiplicacao;
                }
            }
        }
       
        [NonAction]
        public List<FatorDeMultiplicacao> getForaDaClasse()
        {
            return Get();
        }
        

    }
}
