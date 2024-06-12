using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoProjeto.Domain.Models.Entities;

namespace GestaoProjeto.Infra.Data.Mappings
{
    public class ParticipacaoMap : IEntityTypeConfiguration<Participacao>
    {
        public void Configure(EntityTypeBuilder<Participacao> builder)
        {
            //nome da tabela
            builder.ToTable("Participacao");

            //chave primária
            builder.HasKey(x => x.ParticipacaoId);

            builder.Property(x => x.DepartamentoId)                  
                   .IsRequired();

            builder.Property(x => x.FuncionarioId)
                 .IsRequired();

            builder.Property(x => x.ProjetoId)
                 .IsRequired();

            #region Relacionamentos

            builder.HasOne(x => x.Departamento)
                   .WithMany(x => x.Participacoes)
                   .HasForeignKey(x => x.DepartamentoId);

            builder.HasOne(x => x.Funcionario)
                   .WithMany(x => x.Participacoes)
                   .HasForeignKey(x => x.FuncionarioId);

            builder.HasOne(x => x.Projeto)
                   .WithMany(x => x.Participacoes)
                   .HasForeignKey(x => x.ProjetoId)
                   .OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}