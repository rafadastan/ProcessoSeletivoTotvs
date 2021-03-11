using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.Services;
using ProcessoSeletivoTotvs.Domain.Contracts.CrossCuttings.Cryptography;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories.UnitOfWork;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Contracts.User;
using ProcessoSeletivoTotvs.Domain.Services;
using ProcessoSeletivoTotvs.Domain.UserHttpContext;
using ProcessoSeletivoTotvs.Infra.CrossCutting;
using ProcessoSeletivoTotvs.Infra.Data.Contexts.DataDapper;
using ProcessoSeletivoTotvs.Infra.Data.Repositories;
using ProcessoSeletivoTotvs.Infra.Data.Repositories.UnitOfWork;

namespace ProcessoSeletivoTotvs.API.Authorization
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            #region Application

            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
            services.AddTransient<IPerfilApplicationService, PerfilApplicationService>();

            #endregion

            #region Domain

            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IPerfilDomainService, PerfilDomainService>();

            #endregion

            #region InfraStructure

            services.AddScoped<DbSession>();

            services.AddTransient<IUsuarioRepositoryEntity, UsuarioRepositoryEntity>();
            services.AddTransient<IPerfilRepositoryEntity, PerfilRepositoryEntity>();


            services.AddTransient<IUsuarioRepositoryDapper, UsuarioRepositoryDapper>();
            services.AddTransient<IPerfilRepositoryDapper, PerfilRepositoryDapper>();

            services.AddTransient<IUnitOfWorkEntity, UnitOfWorkEntity>();
            services.AddTransient<IUnitOfWorkDapper, UnitOfWorkDapper>();

            #endregion

            #region CrossCutting

            services.AddTransient<IMD5Cryptoghaphy, MD5Cryptography>();

            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, UserContext>();
        }
    }
}
