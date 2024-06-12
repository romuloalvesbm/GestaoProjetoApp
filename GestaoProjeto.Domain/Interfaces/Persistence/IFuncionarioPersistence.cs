using GestaoProjeto.Domain.Models.Collection;
using GestaoProjeto.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Interfaces.Persistence
{
    public interface IFuncionarioPersistence : IBasePersistence<Models.Collection.Funcionario>
    {
        Task<ICollection<Models.Collection.Funcionario>> GetAll(string Email, string Nome, int? IdFuncionario);
        Task<ICollection<Models.Collection.Funcionario>> GetAll(string Email, string Nome);
    }
}
