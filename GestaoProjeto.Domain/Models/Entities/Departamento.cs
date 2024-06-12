using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Models.Entities
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string? Nome { get; set; }
        public ICollection<Projeto>? Projetos { get; set; }
        public ICollection<Participacao>? Participacoes { get; set; }
    }
}
