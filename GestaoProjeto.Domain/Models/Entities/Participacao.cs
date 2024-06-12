using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Models.Entities
{
    public class Participacao
    {
        public int ParticipacaoId { get; set; }
        public int DepartamentoId { get; set; }
        public int ProjetoId { get; set; }
        public int FuncionarioId { get; set; }
        public Departamento? Departamento { get; set; }
        public Projeto? Projeto { get; set; }
        public Funcionario? Funcionario { get; set; }

    }
}
