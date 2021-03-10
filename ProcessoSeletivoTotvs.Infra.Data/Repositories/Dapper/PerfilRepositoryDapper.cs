using Dapper;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;
using ProcessoSeletivoTotvs.Infra.Data.Contexts.DataDapper;
using ProcessoSeletivoTotvs.Infra.Data.Repositories.BaseRepository;
using System.Data.SqlClient;
using System.Linq;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class PerfilRepositoryDapper : BaseRepositoryDapper<Perfil>, IPerfilRepositoryDapper
    {
        private DbSession _session;

        public PerfilRepositoryDapper(DbSession session) : base(session.Connection.ConnectionString) 
        {
            _session = session;
        }

        public Perfil Get(string perfil)
        {
            var query = "select * from Perfil where Perfil = @Perfil order by Perfis";

            using (var connection = new SqlConnection(_session.Connection.ConnectionString))
            {
                return connection.Query<Perfil>(query)
                    .FirstOrDefault();
            }
        }
    }
}
