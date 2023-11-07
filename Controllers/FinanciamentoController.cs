using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEdubank.Model;
using Microsoft.AspNetCore.Mvc;
using apiEdubank.Context;

namespace apiEdubank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanciamentoController : ControllerBase
    {
        private readonly ILogger<FinanciamentoController> _logger;
        private readonly apiEdubankContext _context;
        public FinanciamentoController(ILogger<FinanciamentoController> logger, apiEdubankContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet(Name = "Financiamentos")]
         public ActionResult<IEnumerable<Financiamento>> Get(){
            var financiamentos = _context.Financiamentos.ToList();
            if (financiamentos is null)
                return NotFound();

            return financiamentos;
        }
    }
}