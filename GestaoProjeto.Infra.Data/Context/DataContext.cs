using GestaoProjeto.Domain.Models.Entities;
using GestaoProjeto.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new ProjetoMap());
            modelBuilder.ApplyConfiguration(new ParticipacaoMap());

            modelBuilder.Entity<Participacao>(entity =>
            {
                entity.HasIndex(x => new { x.DepartamentoId, x.FuncionarioId, x.ProjetoId })
                      .HasDatabaseName("IDX_DepartamentoId_FuncionarioId_ProjetoId")
                      .IsUnique();
            });
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Participacao> Participacoes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

    }
}
