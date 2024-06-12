﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoProjeto.Domain.Models.Entities;

namespace GestaoProjeto.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabela
            builder.ToTable("Funcionario");

            //chave primária
            builder.HasKey(x => x.FuncionarioId);

            builder.Property(t => t.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            #region Relacionamento

            builder.HasOne(x => x.Supervisor)
                   .WithMany(x => x.Funcionarios)
                   .HasForeignKey(x => x.SupervisorId);

            #endregion
        }
    }
}
