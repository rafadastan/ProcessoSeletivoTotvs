using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;
using System.Linq;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SqlContext sqlContext;

        public UsuarioRepository(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public Usuario GetByLogin(string login)
        {
            return sqlContext.Usuarios
                .FirstOrDefault(u => u.Email.Equals(login));
        }

        public Usuario GetByLoginAndPassword(string login, string password)
        {
            return sqlContext.Usuarios
                .FirstOrDefault(u => u.Email.Equals(login) && u.Senha.Equals(password));
        }
    }
}
