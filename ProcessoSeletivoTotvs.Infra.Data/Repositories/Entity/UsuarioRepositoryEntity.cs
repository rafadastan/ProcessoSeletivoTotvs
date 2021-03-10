using Dapper;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;
using ProcessoSeletivoTotvs.Infra.Data.Repositories.BaseRepository;
using System.Data.SqlClient;
using System.Linq;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class UsuarioRepositoryEntity : BaseRepositoryEntity<Usuario>, IUsuarioRepositoryEntity
    {
        private readonly SqlContext sqlContext;

        public UsuarioRepositoryEntity(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
