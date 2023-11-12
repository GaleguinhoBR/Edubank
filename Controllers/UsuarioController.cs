using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEdubank.Context;
using apiEdubank.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiEdubank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController>_logger;
        private readonly apiEdubankContext _context;

        public UsuarioController
        (ILogger<UsuarioController> logger, apiEdubankContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get(){
            var usuarios = _context.Usuarios.ToList();
            if(usuarios is null)
                return NotFound();
            
            return usuarios;
        }
        [HttpGet("{id:int}", Name ="GetUsuario")]   
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(p => p.Id_usuario == id);
            if(usuario is null)
                return NotFound("Curso não encontrado.");
            
            return usuario;
        }
        [HttpPost]
        public ActionResult  Post(Usuario usuario){
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetUsuario", new{id = usuario.Id_usuario}, usuario);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Usuario usuario){
            if(id != usuario.Id_usuario)
                return BadRequest();
            
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(usuario);
        }
    }
}