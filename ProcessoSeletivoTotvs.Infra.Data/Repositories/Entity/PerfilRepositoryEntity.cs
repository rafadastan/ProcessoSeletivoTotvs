using Dapper;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;
using ProcessoSeletivoTotvs.Infra.Data.Repositories.BaseRepository;
using System.Data.SqlClient;
using System.Linq;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class PerfilRepositoryEntity : BaseRepositoryEntity<Perfil>, IPerfilRepositoryEntity
    {
        private readonly SqlContext sqlContext;


        public PerfilRepositoryEntity(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
