using Dapper;
using Npgsql;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;
using ProcessoSeletivoTotvs.Infra.Data.Contexts.DataDapper;
using ProcessoSeletivoTotvs.Infra.Data.Repositories.BaseRepository;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class UsuarioRepositoryDapper : BaseRepositoryDapper<Usuario>, IUsuarioRepositoryDapper
    {
        private DbSession _session;

        StringBuilder sql = new StringBuilder();

        public UsuarioRepositoryDapper(DbSession session) : base(session)
        {
            _session = session;
        }

        public Usuario GetByLogin(string email)
        {

            //var querySQL = @"SELECT id, firstname, lastname, email, createtime FROM public.customer;";
            var query = $"SELECT \"Email\" FROM public.\"Usuario\" where \"Email\" = '{email}';";

                return _session.Connection.Query<Usuario>(query)
                    .FirstOrDefault();

        }

        public Usuario GetByLoginAndPassword(string email, string password)
        {
            var query = $"SELECT * FROM \"Usuario\" where \"Email\" = '{email}' and \"Senha\" = '{password}';";

                return _session.Connection.Query<Usuario>(query)
                    .FirstOrDefault();

        }
    }
}
