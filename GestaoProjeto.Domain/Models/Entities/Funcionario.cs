using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Models.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public int? SupervisorId { get; set; }
        public Funcionario? Supervisor { get; set; }
        public ICollection<Funcionario>? Funcionarios { get; set; }
        public ICollection<Participacao>? Participacoes { get; set; }
    }
}
