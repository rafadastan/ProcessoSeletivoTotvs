using Dapper;
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;
using ProcessoSeletivoTotvs.Infra.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        public BaseRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void Create(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Added;
            _sqlContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Deleted;
            _sqlContext.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            var query = "select * from Usuario order by Nome";

            using (var connection = new SqlConnection())
            {
                return connection.Query<TEntity>(query)
                    .ToList();
            }
        }

        public List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            var query = $"select * from Usuario {where} order by Nome";

            using (var connection = new SqlConnection())
            {
                return connection.Query<TEntity>(query).ToList();
            }
        }

        public TEntity GetById(Guid id)
        {
            var query = "select * from Usuario where Id = @Id";

            using (var connection = new SqlConnection())
            {
                return connection.Query<TEntity>(query, new { Id = id }).FirstOrDefault();
            }
        }

        public void Update(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        public TEntity Get(TEntity entity)
        {
            return _sqlContext.Set<TEntity>().Find(entity);
        }

        public void Dispose()
        {
            _sqlContext.Dispose();
        }        
    }
}
