using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }

        [Required]
        [StringLength(512)]
        public string NomeColaborador { get; set; }

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

        //Falta a tabela função e colocar a cahve estrangeira

        public ICollection<Projeto> Projetos { get; set; }
    }
}
