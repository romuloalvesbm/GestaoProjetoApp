using GestaoProjeto.Domain.Interfaces.Persistence;
using GestaoProjeto.Domain.Models.Collection;
using GestaoProjeto.Infra.DataDapper.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GestaoProjeto.Infra.DataDapper.Persistences
{
    public class FuncaoPersistence : IFuncaoPersistence
    {
        private readonly DapperSettings _settings;

        public FuncaoPersistence(IOptions<DapperSettings> settings)
        {
            _settings = settings.Value;
        }

        public Task Alterar(Funcao obj)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Funcao>> Consultar()
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Funcao obj)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Funcao>> GetFuncoesComFuncionarios()
        {
            using (IDbConnection db = new SqlConnection(_settings.ConnectionString))
            {
                string query = "SELECT f.*, fi.* FROM Funcao f LEFT JOIN Funcionario fi ON f.IdFuncao = fi.IdFuncao";

                var funcoes = new Dictionary<int, Funcao>();

                var queryResult = await db.QueryAsync<Funcao, Domain.Models.Collection.Funcionario, Funcao>(query,
                    (funcao, funcionario) =>
                    {
                        if (!funcoes.TryGetValue(funcao.IdFuncao, out var funcaoEntry))
                        {
                            funcaoEntry = funcao;
                            funcaoEntry.FuncionarioCollections = new List<Funcionario>();
                            funcoes.Add(funcaoEntry.IdFuncao, funcaoEntry);
                        }
                        if (funcionario != null)
                            funcaoEntry.FuncionarioCollections.Add(funcionario);
                        return funcaoEntry;
                    },
                    splitOn: "IdFuncao");

                return queryResult.Distinct().ToList();
            }
        }

            public Task Inserir(Funcao obj)
        {
            throw new NotImplementedException();
        }

        public Task<Funcao> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
