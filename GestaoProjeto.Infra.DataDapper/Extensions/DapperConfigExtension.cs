using Dapper.FluentMap;
using GestaoProjeto.Domain.Interfaces.Persistence;
using GestaoProjeto.Domain.Interfaces.Repositories;
using GestaoProjeto.Domain.Models.Entities;
using GestaoProjeto.Infra.DataDapper.Persistences;
using GestaoProjeto.Infra.DataDapper.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestaoProjeto.Domain.Models.Collection.Funcao;

namespace GestaoProjeto.Infra.DataDapper.Extensions
{
    public static class DapperConfigExtension
    {
        public static IServiceCollection AddDapperConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DapperSettings>(configuration.GetSection("DapperSettings"));
            services.AddTransient<IFuncionarioPersistence, FuncionarioPersistence>();
            services.AddTransient<IFuncaoPersistence, FuncaoPersistence>();

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new FuncaoCollectionModelMap());
            });

            return services;

        }
    }
}
