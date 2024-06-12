using GestaoProjeto.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Infra.Data.Mappings
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            //nome da tabela
            builder.ToTable("Projeto");

            //chave primária
            builder.HasKey(x => x.ProjetoId);

            builder.Property(t => t.Descricao)
                   .HasMaxLength(100)
                   .IsRequired();

            #region Relacionamentos

            builder.HasOne(x => x.Departamento)
                   .WithMany(x => x.Projetos)
                   .HasForeignKey(x => x.DepartamentoId);

            #endregion
        }
    }
}