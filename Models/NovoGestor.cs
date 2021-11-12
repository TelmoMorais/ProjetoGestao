using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class NovoGestor
    {
        public int NovoGestorId { get; set; }

        [Required]
        [StringLength(512)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
