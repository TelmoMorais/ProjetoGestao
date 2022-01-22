using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required]
        [StringLength(512)]
        public string NomeTarefa { get; set; }

        [Required]
        public string DataPrevistaInicio { get; set; }

     
        public string DataEfetivaInicio { get; set; }

       
        public string DataEfetivaFim { get; set; }

        [Required]
        public string DataPrevistaFim { get; set; }

        public string ColaboradorResponsavelTarefa { get; set; }
        public Colaborador Colaborador { get; set; }
        public string EstadoTarefa { get; set; }

        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
