using Dapper;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Infra.Data.Contexts.DataDapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories.BaseRepository
{
    public class BaseRepositoryDapper<TEntity> : IBaseRepositoryDapper<TEntity>
        where TEntity : class
    {
        private DbSession _session;

        public BaseRepositoryDapper(DbSession session)
        {
            _session = session;
        }

        public List<TEntity> GetAll()
        {
            var query = "SELECT * FROM public.\"Usuario\" order by \"Nome\" ";

                return _session.Connection.Query<TEntity>(query)
                    .ToList();
        }

        public List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            var query = $"SELECT * FROM public.\"Usuario\" {where} order by \"Nome\"";
            
                return _session.Connection.Query<TEntity>(query).ToList();
        }

        public TEntity GetById(Guid id)
        {
            var query = $"SELECT * FROM public.\"Usuario\" where \"Id\" = '{id}'";

                return _session.Connection.Query<TEntity>(query, new { Id = id }).FirstOrDefault();
        }
        public TEntity Get(Func<TEntity, bool> where)
        {
            var query = $"SELECT * FROM public.\"Usuario\" {where}";

            return _session.Connection.Query<TEntity>(query).FirstOrDefault();
        }

    }
}
