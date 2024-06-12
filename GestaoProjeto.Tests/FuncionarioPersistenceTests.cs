using GestaoProjeto.Domain.Interfaces.Persistence;
using GestaoProjeto.Domain.Models.Collection;
using GestaoProjeto.Infra.DataDapper.Persistences;
using GestaoProjeto.Infra.DataDapper.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Tests
{
    public class FuncionarioPersistenceTests
    {
        private readonly FuncionarioPersistence _funcionarioPersistence;
        private readonly string _connectionString;

        public FuncionarioPersistenceTests()
        {
            // Carregando as configurações de teste
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();
            var dapperSettings = new DapperSettings();
            configBuilder.GetSection("DapperSettings").Bind(dapperSettings);

            // Acessando a string de conexão
            _connectionString = dapperSettings.ConnectionString;           
            var options = Options.Create(dapperSettings);
            _funcionarioPersistence = new FuncionarioPersistence(options);          
        }

        [Fact]       
        public async Task GetAll_ReturnsExpectedResults()
        {
            // Arrange
            string email = "";
            string nome = "";

            // Act
            var result = await _funcionarioPersistence.GetAll(email, nome);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Funcionario>>(result);
            // Adicione mais assertivas conforme necessário
        }
    }
}
