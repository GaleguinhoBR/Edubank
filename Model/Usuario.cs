using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiEdubank.Model
{
    public class Usuario
    {
        [Key]
        public int Id_usuario { get; set; }
        public string? Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string? CPF { get; set; }
        public string? Email {get; set;}
    }
}