﻿using GestaoProjeto.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Interfaces.Repositories
{
    public interface IDepartamentoRepository : IBaseRepository<Departamento, int>
    {
        Task<Departamento> GetByNome(string nome);
    }
}
