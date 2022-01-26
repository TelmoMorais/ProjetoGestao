using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        [StringLength(512)]
        public string NomeCliente { get; set; }

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

        public ICollection<Projeto> Projetos { get; set; }
    }
}
