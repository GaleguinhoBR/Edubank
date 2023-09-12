using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEdubank.Model;
using Microsoft.AspNetCore.Mvc;

namespace apiEdubank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanciamentoController : ControllerBase
    {
        private readonly ILogger<FinanciamentoController>_logger;
        public FinanciamentoController(ILogger<FinanciamentoController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "Financiamentos")]
        public List<Financiamento> getFinanciamento(){
            List<Financiamento> Financiamentos = new List<Financiamento>();

            Financiamento a1 = new Financiamento();
            a1.Valor = 100000.00;
            a1.Data = "31-05-2024";
            a1.Descrição = "heheheheheheheh";
            a1.Id_financiamento = 4761453;
            a1.Id_usuario = 2020103401;

            Financiamento a2 = new Financiamento();
            a2.Valor = 125000.00;
            a2.Data = "24-11-2024";
            a2.Descrição = "hahahahahahahah";
            a2.Id_financiamento = 0110101;
            a2.Id_usuario = 2020103402;

            Financiamentos.Add(a1);
            Financiamentos.Add(a2);

            return Financiamentos;
        }
    }
}