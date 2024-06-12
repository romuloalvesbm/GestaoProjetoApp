using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
        Task SaveChanges();

        IDepartamentoRepository DepartamentoRepository { get; }
        IFuncionarioRepository FuncionarioRepository { get; }
        IParticipacaoRepository ParticipacaoRepository { get; }
        IProjetoRepository ProjetoRepository { get; }

    }
}
