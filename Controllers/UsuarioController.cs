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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController>_logger;

        public UsuarioController
        (ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet (Name = "usuarios")]
        public List<Usuario> GetUsuario(){
            List<Usuario> usuarios = new List<Usuario>();

            Usuario a1 = new Usuario();
            a1.Id_usuario= 2020103401;
            a1.Nome= "Jojo";
            a1.DataDeNascimento= "28/12/2004";
            a1.CPF= "xxx.xxx.xxx-xx";
            a1.Email= "jojo@gmail.com";

            Usuario a2 = new Usuario();
            a2.Id_usuario= 2020103402;
            a2.Nome= "GaleguinhoBR";
            a2.DataDeNascimento= "31/05/2005";
            a2.CPF= "xxx.xxx.xxx-xx";
            a2.Email= "galeguinhobr2@gmail.com";

            usuarios.Add(a1);
            usuarios.Add(a2);

            return usuarios;

        }    
    }
}