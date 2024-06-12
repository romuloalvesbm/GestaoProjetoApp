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
    public class ParticipacaoRepository : BaseRepository<Participacao, int>, IParticipacaoRepository
    {
        private readonly DataContext _dataContext;

        public ParticipacaoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
