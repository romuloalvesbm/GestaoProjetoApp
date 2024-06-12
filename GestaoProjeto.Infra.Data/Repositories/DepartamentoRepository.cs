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
    public class DepartamentoRepository : BaseRepository<Departamento, int>, IDepartamentoRepository
    {
        private readonly DataContext _dataContext;

        public DepartamentoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Departamento> GetByNome(string nome)
        {
           return await _dataContext.Departamentos.FirstOrDefaultAsync(x => x.Nome.StartsWith(nome));
        }
    }
}
