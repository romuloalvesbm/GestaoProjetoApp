using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IAsyncDisposable
        where TEntity : class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<List<TEntity>>? GetAll();
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> where);

        Task<TEntity>? GetById(TKey id);
        Task SaveChanges();
    }
}
