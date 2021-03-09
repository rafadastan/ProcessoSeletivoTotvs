using System.Data;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
