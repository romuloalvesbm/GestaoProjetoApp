using GestaoProjeto.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario, int>    {
        Task<bool> NameExist(string email);
    }
}
