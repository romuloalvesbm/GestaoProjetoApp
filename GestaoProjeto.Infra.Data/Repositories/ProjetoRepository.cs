using GestaoProjeto.Domain.Interfaces.Repositories;
using GestaoProjeto.Domain.Models.Entities;
using GestaoProjeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Infra.Data.Repositories
{
    public class ProjetoRepository : BaseRepository<Projeto, int>, IProjetoRepository
    {
        private readonly DataContext _dataContext;

        public ProjetoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
