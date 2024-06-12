using GestaoProjeto.Domain.Interfaces.Repositories;
using GestaoProjeto.Domain.Models.Entities;
using GestaoProjeto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Infra.Data.Repositories
{
    public class FuncionarioRepository : BaseRepository<Funcionario, int>, IFuncionarioRepository
    {
        private readonly DataContext _dataContext;

        public FuncionarioRepository(DataContext dataContext) : base(dataContext) => _dataContext = dataContext;

        public async Task<bool> NameExist(string email)
        {
            return await _dataContext.Funcionarios.AnyAsync(x => x.Equals(email));
        }
    }
}
