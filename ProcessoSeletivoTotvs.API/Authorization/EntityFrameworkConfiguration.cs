using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;

namespace ProcessoSeletivoTotvs.API.Authorization
{
    public class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(IServiceCollection services)
        {
            services.AddDbContext<SqlContext>
                (options => options.UseInMemoryDatabase("BDTotvs"));
        }

        public static void AddPostgreSQLEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("");

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<SqlContext>(opt=> opt.UseNpgsql(connectionString));
        }
    }   
}
