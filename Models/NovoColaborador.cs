using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class NovoColaborador
    {
        public int NovoColaboradorId { get; set; }

        [Required]
        [StringLength(512)]
        public string NomeColaborador { get; set; }

        
    }
}
