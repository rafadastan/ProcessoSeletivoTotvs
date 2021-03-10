using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProcessoSeletivoTotvs.Infra.Data.Contexts
{
    public class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings")
                .GetSection("BDTotvs").Value;

            //instanciar a classe SqlContext
            var builder = new DbContextOptionsBuilder<SqlContext>();
            builder.UseNpgsql(connectionString);

            return new SqlContext(builder.Options);
        }
    }
}
