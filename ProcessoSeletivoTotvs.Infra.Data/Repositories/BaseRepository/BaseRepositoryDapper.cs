using Dapper;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
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
        private readonly string _connectionString;

        public BaseRepositoryDapper(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public List<TEntity> GetAll()
        {
            var query = "select * from Usuario order by Nome";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<TEntity>(query)
                    .ToList();
            }
        }

        public List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            var query = $"select * from Usuario {where} order by Nome";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<TEntity>(query).ToList();
            }
        }

        public TEntity GetById(Guid id)
        {
            var query = "select * from Usuario where Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<TEntity>(query, new { Id = id }).FirstOrDefault();
            }
        }
        public TEntity Get(TEntity entity)
        {
            var query = "select * from Usuario where Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<TEntity>(query, new { Id = entity }).FirstOrDefault();
            }
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
