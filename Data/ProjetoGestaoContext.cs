using Microsoft.EntityFrameworkCore;
using ProjetoGestao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestao.Data
{
    public class ProjetoGestaoContext : DbContext
    {
        public ProjetoGestaoContext(DbContextOptions<ProjetoGestaoContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColaboradoresProjeto>()
                .HasKey(bc => new { bc.ProjetoId, bc.ColaboradorId });
        }

        public DbSet<ProjetoGestao.Models.Projeto> Projeto { get; set; }

        public DbSet<ProjetoGestao.Models.Gestor> Gestor { get; set; }

        public DbSet<ProjetoGestao.Models.Colaborador> Colaborador { get; set; }

        public DbSet<ProjetoGestao.Models.Cliente> Cliente { get; set; }

        public DbSet<ProjetoGestao.Models.ColaboradoresProjeto> ColaboradoresProjeto { get; set; }

        public DbSet<ProjetoGestao.Models.Funcao> Funcao { get; set; }

        //public DbSet<ProjetoGestao.Models.Relatorio> Relatorio { get; set; }
        public DbSet<ProjetoGestao.Models.Tarefa> Tarefa { get; set; }

        //public DbSet<ProjetoGestao.Models.Relatorio> Relatorio { get; set; }
        public DbSet<ProjetoGestao.Models.Relatorio> Relatorio { get; set; }
    }
}

