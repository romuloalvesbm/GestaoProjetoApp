using Dapper;
using Dapper.FluentMap;
using GestaoProjeto.Domain.Interfaces.Persistence;
using GestaoProjeto.Domain.Models.Collection;
using GestaoProjeto.Domain.Models.Entities;
using GestaoProjeto.Infra.DataDapper.Settings;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestaoProjeto.Domain.Models.Collection.Funcao;

namespace GestaoProjeto.Infra.DataDapper.Persistences
{
    public class FuncionarioPersistence : IFuncionarioPersistence
    {
        private readonly DapperSettings _settings;

        public FuncionarioPersistence(IOptions<DapperSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task Inserir(Domain.Models.Collection.Funcionario obj)
        {
            var query = "Insert into Funcionario(IdFuncionario, Nome, Email, " +
                        "DataAdmissao, Salario, Ativo, DataCriacao, " +
                        "DataUltimaAlteracao) " +
                        "values(@IdFuncionario, @Nome, @Email, @DataAdmissao, " +
                        "@Salario, @Ativo, @DataCriacao, @DataUltimaAlteracao)";

            using var connection = new SqlConnection(_settings.ConnectionString);
            await connection.ExecuteAsync(query, obj);
        }

        public async Task Alterar(Domain.Models.Collection.Funcionario obj)
        {
            var query = "update Funcionario set "
                        + "Nome = @Nome, "
                        + "Email = @Email, "
                        + "DataAdmissao = @DataAdmissao, "
                        + "Salario = @Salario, "
                        + "DataUltimaAlteracao = @DataUltimaAlteracao "
                        + "where IdFuncionario = @IdFuncionario";
            using var connection = new SqlConnection(_settings.ConnectionString);
            await connection.ExecuteAsync(query, obj);
        }

        public Task<ICollection<Domain.Models.Collection.Funcionario>> Consultar()
        {
            throw new NotImplementedException();
        }

        public async Task Excluir(Domain.Models.Collection.Funcionario obj)
        {
            var query = "update Funcionario set Ativo = 0 where IdFuncionario = @IdFuncionario";
            using var connection = new SqlConnection(_settings.ConnectionString);
            await connection.ExecuteAsync(query, obj);
        }



        public Task<Domain.Models.Collection.Funcionario> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Domain.Models.Collection.Funcionario>> GetAll(string Email, string Nome, int? IdFuncionario)
        {
            using IDbConnection connection = new SqlConnection(_settings.ConnectionString);
            var parameters = new {Email, Nome, IdFuncionario };
            var queryResult = await connection.QueryAsync<Domain.Models.Collection.Funcionario>("GetFuncionarios", parameters, commandType: CommandType.StoredProcedure);
            return queryResult.ToList();
        }

        public async Task<ICollection<Domain.Models.Collection.Funcionario>> GetAll(string Email, string Nome)
        {
            using var connection = new SqlConnection(_settings.ConnectionString);           

            connection.Open();
            var parameters = new { Email, Nome };
            var query = await connection.QueryAsync("GetFuncionariosFuncao", 
            (Domain.Models.Collection.Funcionario funcionario, Funcao funcao) =>
            {
                funcionario.FuncaoCollection = funcao;
                return funcionario;
            }, parameters, splitOn: "IdFuncao", commandType: CommandType.StoredProcedure);

            return query.ToList();
        }
    }
}
