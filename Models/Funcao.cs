using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class Funcao
    {

        public int FuncaoId { get; set; }

        [Required]
        [StringLength(512)]
        public string NomeFuncao { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
