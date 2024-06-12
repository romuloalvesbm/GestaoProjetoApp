using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Models.Entities
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string? Descricao { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public ICollection<Participacao>? Participacoes { get; set; }
    }
}
