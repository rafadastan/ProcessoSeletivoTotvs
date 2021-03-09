using Dapper;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;
using System.Data.SqlClient;
using System.Linq;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        private readonly SqlContext sqlContext;

        public PerfilRepository(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public Perfil Get(string perfil)
        {
            var query = "select * from Perfil where Perfil = @Perfil order by Perfis";

            using (var connection = new SqlConnection())
            {
                return connection.Query<Perfil>(query)
                    .FirstOrDefault();
            }
        }
    }
}
