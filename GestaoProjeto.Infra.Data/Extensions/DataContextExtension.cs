using GestaoProjeto.Domain.Interfaces.Repositories;
using GestaoProjeto.Infra.Data.Context;
using GestaoProjeto.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProjeto.Infra.Data.Extensions
{
    public static class DataContextExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            //injeção de dependência do DataContext
            services.AddDbContext<DataContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DB_GESTAOPROJETO")));

            //injeção de dependência do UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IParticipacaoRepository, ParticipacaoRepository>();
            services.AddTransient<IProjetoRepository, ProjetoRepository>();

            return services;
        }
    }
}
