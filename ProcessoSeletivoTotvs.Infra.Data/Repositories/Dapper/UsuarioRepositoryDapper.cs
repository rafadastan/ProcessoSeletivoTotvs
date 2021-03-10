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
    public class UsuarioRepositoryDapper : BaseRepositoryDapper<Usuario>, IUsuarioRepositoryDapper
    {
        private DbSession _session;

        public UsuarioRepositoryDapper(DbSession session) : base(session.Connection.ConnectionString)
        {
            _session = session;
        }

        public Usuario GetByLogin(string email)
        {
            var query = "select * from Usuario where Email = @Email order by Email";

            using (var connection = new SqlConnection(_session.Connection.ConnectionString))
            {
                return connection.Query<Usuario>(query)
                    .FirstOrDefault();
            }
        }

        public Usuario GetByLoginAndPassword(string email, string password)
        {
            var query = "select * from Perfil where Email = @Email and Senha = @Senha order by Nome";

            using (var connection = new SqlConnection(_session.Connection.ConnectionString))
            {
                return connection.Query<Usuario>(query)
                    .FirstOrDefault();
            }
        }
    }
}
