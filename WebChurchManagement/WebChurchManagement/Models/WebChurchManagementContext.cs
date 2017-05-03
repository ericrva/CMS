using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebChurchManagement.Models
{
    public class WebChurchManagementContext : DbContext
    {
        public WebChurchManagementContext() : base("WebChurchManagementDB")
        {

        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Dizimo> Dizimos { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<MembroDepto> MembroDeptos { get; set; }
        public DbSet<MembroFamiliares> MembroFamiliares { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TipoLancamento> TipoLancamentos { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }

    }
}