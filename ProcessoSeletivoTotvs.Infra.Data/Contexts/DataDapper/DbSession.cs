using Npgsql;
using System;
using System.Data;

namespace ProcessoSeletivoTotvs.Infra.Data.Contexts.DataDapper
{
    public class DbSession : IDisposable
    {
        private Guid Id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession()
        {
            Id = Guid.NewGuid();
            Connection = new NpgsqlConnection(Settings.Configure());
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
