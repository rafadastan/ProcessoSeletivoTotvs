using NSubstitute;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;
using System.Data;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories.Abstract
{
    public abstract class DapperRepository
    {
        public DapperRepository()
        {
            var inMemory = new InMemoryDatabaseDapper();

            this.Context = Substitute.For<IDbConnection>();
            this.Context.Returns(inMemory.Connection);
        }

        public IDbConnection Context { get; }
    }
}
