using GestaoProjeto.Domain.Interfaces.Persistence;
using GestaoProjeto.Domain.Interfaces.Repositories;
using GestaoProjeto.Domain.Interfaces.Services;
using GestaoProjeto.Domain.Models.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Services
{
    public class FuncionarioDomainService : BaseDomainService<Models.Entities.Funcionario, int>, IFuncionarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFuncionarioPersistence _funcionarioPersistence;

        public FuncionarioDomainService(IUnitOfWork unitOfWork, IFuncionarioPersistence funcionarioPersistence) : base(unitOfWork.FuncionarioRepository)
        {
            _unitOfWork = unitOfWork;
            _funcionarioPersistence = funcionarioPersistence;
        }

        public async override Task Add(Models.Entities.Funcionario entity)
        {
           var funcionario = await _funcionarioPersistence.ObterPorId(entity.FuncionarioId);
            
            try
            {
                if (funcionario != null && !await _unitOfWork.FuncionarioRepository.NameExist(entity.Nome))
                {
                    await _unitOfWork.BeginTransaction();

                    await _unitOfWork.FuncionarioRepository.Add(entity);
                    await _unitOfWork.FuncionarioRepository.SaveChanges();

                    await _unitOfWork.Commit();
                }
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
