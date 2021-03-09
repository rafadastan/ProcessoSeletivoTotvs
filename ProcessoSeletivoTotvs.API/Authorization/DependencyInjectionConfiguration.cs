using Microsoft.Extensions.DependencyInjection;
using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.Services;
using ProcessoSeletivoTotvs.Domain.Contracts.CrossCuttings.Cryptography;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Services;
using ProcessoSeletivoTotvs.Infra.CrossCutting;
using ProcessoSeletivoTotvs.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoTotvs.API.Authorization
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
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

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPerfilRepository, PerfilRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion

            #region CrossCutting

            services.AddTransient<IMD5Cryptoghaphy, MD5Cryptography>();

            #endregion
        }
    }
}
