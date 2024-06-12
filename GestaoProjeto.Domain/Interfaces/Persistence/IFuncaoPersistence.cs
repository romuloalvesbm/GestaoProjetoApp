using GestaoProjeto.Domain.Models.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Interfaces.Persistence
{
    public interface IFuncaoPersistence : IBasePersistence<Funcao>
    {
        Task<ICollection<Funcao>> GetFuncoesComFuncionarios();

    }
}
