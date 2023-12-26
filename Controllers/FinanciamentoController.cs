using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEdubank.Context;
using apiEdubank.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace apiEdubank.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        [HttpGet ("(id:int)", Name="GetFinanciamento")]
        public ActionResult<Financiamento> Get(int id){
            var financiamento = _context.Financiamentos.FirstOrDefault(p => p.Id_financiamento == id);
            if(financiamento is null)
                return NotFound("Financiamento não encontrado.");
            
            return financiamento;
        }
        [HttpGet ("(id:int)", Name="GetFinanciamentobyUserID")]
        public ActionResult<Financiamento> GetbyUserID(int user_id){
            var financiamento = _context.Financiamentos.FirstOrDefault(p => p.Id_usuario == user_id);
            if(financiamento is null)
                return NotFound("Financiamento não encontrado.");
            
            return financiamento;
        }
        [HttpPost]
        public ActionResult Post(Financiamento financiamento){
            _context.Financiamentos.Add(financiamento);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetFinanciamento", new{id = financiamento.Id_financiamento,}, financiamento);
        }
        [HttpPut ("{id:int}")]
        public ActionResult Put(int id, Financiamento financiamento){
            if(id != financiamento.Id_financiamento)
                return BadRequest();

            _context.Entry(financiamento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(financiamento);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var financiamento = _context.Financiamentos.FirstOrDefault(p => p.Id_financiamento == id);
            if (financiamento is null)
                return NotFound();
            
            _context.Financiamentos.Remove(financiamento);
            _context.SaveChanges();

            return Ok(financiamento);
        }
    }
}
