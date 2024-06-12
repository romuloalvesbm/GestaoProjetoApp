using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Mapping;

namespace GestaoProjeto.Domain.Models.Collection
{
    public class Funcao
    {
        public int IdFuncao { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Funcionario>? FuncionarioCollections { get; set; }

        public class FuncaoCollectionModelMap : EntityMap<Funcao>
        {
            public FuncaoCollectionModelMap()
            {
                Map(p => p.Nome).ToColumn("NomeFuncao");
                Map(p => p.Ativo).ToColumn("AtivoFuncao");
            }
        }
    }
}
