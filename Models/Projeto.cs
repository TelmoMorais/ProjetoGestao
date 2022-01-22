using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }

        [Required]
        [StringLength(512)]
        public string NomeProjeto { get; set; }
        public string DescricaoProjeto { get; set; }

        [Required]
        public string DataPrevistaInicio { get; set; }

       
        public string DataEfetivaInicio { get; set; }

     
        public string DataEfetivaFim { get; set; }

        [Required]
        public string DataPrevistaFim { get; set; }


        public int GestorId { get; set; }
        public Gestor Gestor { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<ColaboradoresProjeto> ColaboradoresProjetos { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }

        public ICollection<Relatorio> Relatorios { get; set; }
    }
}
