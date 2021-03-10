using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
