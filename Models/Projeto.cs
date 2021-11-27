using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class NovoProjeto
    {
        public int NovoProjetoId { get; set; }

        [Required]
        [StringLength(512)]
        public string NomeProjeto { get; set; }
        public string DescricaoProjeto { get; set; }

        public int NovoGestorId { get; set; }
        public NovoGestor NovoGestor { get; set; }
        public ICollection<NovoColaborador> Colaboradors { get; set; }
    }
}
