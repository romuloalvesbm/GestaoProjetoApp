using GestaoProjeto.Domain.Interfaces.Repositories;
using GestaoProjeto.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Services
{
    public abstract class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey>
       where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TKey> _baseRepository;
        private bool _disposed = false;

        protected BaseDomainService(IBaseRepository<TEntity, TKey> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async virtual Task Add(TEntity entity)
        {
            await _baseRepository.Add(entity);
            await _baseRepository.SaveChanges();
        }

        public async virtual Task Update(TEntity entity)
        {
            await _baseRepository.Update(entity);
            await _baseRepository.SaveChanges();
        }

        public async virtual Task Delete(TEntity entity)
        {
            await _baseRepository.Delete(entity);
            await _baseRepository.SaveChanges();
        }

        public async virtual Task<List<TEntity>>? GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async virtual Task<TEntity>? GetById(TKey id)
        {
            return await _baseRepository.GetById(id);
        }

        public async ValueTask DisposeAsync()
        {
            //Testar
            if (!_disposed)
            {
                _disposed = true;
                if (_baseRepository != null)
                {
                    await _baseRepository.DisposeAsync();
                }
            }
        }
    }
}