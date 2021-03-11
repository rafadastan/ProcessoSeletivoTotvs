using Dapper;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Contexts.DataDapper;
using ProcessoSeletivoTotvs.Infra.Data.Repositories.BaseRepository;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class PerfilRepositoryDapper : BaseRepositoryDapper<Perfil>, IPerfilRepositoryDapper
    {
        private DbSession _session;

        public PerfilRepositoryDapper(DbSession session) : base(session) 
        {
            _session = session;
        }

        public Perfil Get(string perfil)
        {
            var query = $"SELECT * FROM public.\"Perfil\" where \"Perfis\" = '{perfil}' ;";

                return _session.Connection.Query<Perfil>(query)
                    .FirstOrDefault();
        }

        public List<Perfil> GetAllPerfil()
        {
            var query = "SELECT * FROM public.\"Perfil\" order by \"Perfis\" ";

            return _session.Connection.Query<Perfil>(query)
                .ToList();
        }
    }
}
