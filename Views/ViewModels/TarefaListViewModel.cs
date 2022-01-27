using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoGestao.Models;

namespace ProjetoGestao.Views.ViewModels
{
    public class TarefaListViewModel
    {
        public IEnumerable<Tarefa> Tarefas { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ProcuraNome { get; set; }
    }
}
