using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Application.Dtos
{
    public class FuncionarioDto
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public int? SupervisorId { get; set; }
        public FuncionarioDto? Supervisor { get; set; }
        public ICollection<FuncionarioDto>? FuncionarioDtos { get; set; }        
    }
}
