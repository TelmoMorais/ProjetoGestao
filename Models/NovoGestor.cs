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
        public string NomeGestor { get; set; }

        [Required]
        public string Apelido { get; set; }

        [Required]
        [StringLength(9)]
        public string NumeroTelemovel { get; set; }

        [Required]
        [RegularExpression(@"(\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,6})",
        ErrorMessage = "Endereço de email Incorreto")]
        public string Email { get; set; }

        [Required]
        public string DataNascimento { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string Endereco { get; set; }

        public string ExperienciaComoGestor { get; set; }

        public ICollection<NovoProjeto> Projetos{ get; set; }
    }
}
