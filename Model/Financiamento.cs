using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiEdubank.Model
{
    public class Financiamento
    {
        [Key]
        public int Id_financiamento{get; set;}
        public int Id_usuario{get; set;}
        public double Valor{get; set;}
        public DateTime Data{get; set;}
        public string? Descrição{get; set;}
    }
}