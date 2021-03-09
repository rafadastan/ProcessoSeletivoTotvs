using ProcessoSeletivoTotvs.Infra.Data.Scripts;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Data;

namespace ProcessoSeletivoTotvs.Infra.Data.Contexts
{
    public class InMemoryDatabaseDapper
    {
        private readonly OrmLiteConnectionFactory dbFactory =
        new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public InMemoryDatabaseDapper()
        {
            this.Connection = this.dbFactory.OpenDbConnection();
            this.CreateDatabase();
        }

        public IDbConnection Connection { get; }

        private void CreateDatabase()
        {
            using (var connection = this.Connection)
            {
                connection.ExecuteSql(DatabaseScripts.CREATE_USER_REPORT_DATABASE);
                connection.ExecuteSql(DatabaseScripts.INSERT_DATA_INTO_USER_REPORT_DATABASE);
            }
        }
    }
}
