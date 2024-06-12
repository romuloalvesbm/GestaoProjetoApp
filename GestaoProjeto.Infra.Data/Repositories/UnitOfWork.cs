using GestaoProjeto.Domain.Interfaces.Repositories;
using GestaoProjeto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //atributos
        private readonly DataContext context;
        private IDbContextTransaction transaction;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public async Task BeginTransaction()
        {
            transaction = await context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await transaction.CommitAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }

        public async Task Rollback()
        {
            await transaction.RollbackAsync();
        }
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public IDepartamentoRepository DepartamentoRepository => new DepartamentoRepository(context);

        public IFuncionarioRepository FuncionarioRepository => new FuncionarioRepository(context);

        public IParticipacaoRepository ParticipacaoRepository => new ParticipacaoRepository(context);

        public IProjetoRepository ProjetoRepository => new ProjetoRepository(context);
    }
}
