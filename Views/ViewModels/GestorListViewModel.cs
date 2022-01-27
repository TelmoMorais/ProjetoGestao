using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoGestao.Models;

namespace ProjetoGestao.Views.ViewModels
{
    public class GestorListViewModel
    {
        public IEnumerable<Gestor> Gestors { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ProcuraNome { get; set; }

    }
}
