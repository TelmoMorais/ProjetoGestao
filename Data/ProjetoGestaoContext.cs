using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoGestao.Models;

namespace ProjetoGestao.Data
{
    public class ProjetoGestaoContext : DbContext
    {
        public ProjetoGestaoContext (DbContextOptions<ProjetoGestaoContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoGestao.Models.Projeto> NovoProjeto { get; set; }

        public DbSet<ProjetoGestao.Models.NovoGestor> NovoGestor { get; set; }

        public DbSet<ProjetoGestao.Models.NovoColaborador> NovoColaborador { get; set; }
    }
}
