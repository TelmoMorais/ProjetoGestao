using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Nome")]
        public string NomeColaborador { get; set; }

        [Required]
        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayName("Número Telemóvel")]
        public string NumeroTelemovel { get; set; }

        [Required]
        [RegularExpression(@"(\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,6})",
        ErrorMessage = "Endereço de email Incorreto")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Data de Nascimento")]
        public string DataNascimento { get; set; }

        [Required]
        [DisplayName("Género")]
        public string Genero { get; set; }

        [Required]
        [DisplayName("Endereco")]
        public string Endereco { get; set; }

        public int FuncaoId { get; set; }
        public Funcao Funcao { get; set; }
        public ICollection<ColaboradoresProjeto> ColaboradoresProjetos { get; set; }
    }
}
