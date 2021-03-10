using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;

namespace ProcessoSeletivoTotvs.API.Authorization
{
    public class EntityFrameworkConfiguration
    {
        public static void AddPostgreSQLEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BDTotvs");

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<SqlContext>(opt=> opt.UseNpgsql(connectionString));
        }
    }   
}
