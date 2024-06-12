using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Interfaces.Persistence
{
    public interface IBasePersistence<TEntity> where TEntity : class
    {
        Task Inserir(TEntity obj);
        Task Alterar(TEntity obj);
        Task Excluir(TEntity obj);
        Task<ICollection<TEntity>> Consultar();
        Task<TEntity> ObterPorId(int id);
    }
}
