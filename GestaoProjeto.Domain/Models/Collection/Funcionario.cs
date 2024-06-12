using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Domain.Models.Collection
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public int IdFuncao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public Funcao FuncaoCollection { get; set; }
    }
}
