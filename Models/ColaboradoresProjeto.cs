using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class ColaboradoresProjeto
    {
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
