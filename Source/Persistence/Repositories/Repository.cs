using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDynamoDBContext _context;
        private readonly DynamoDBOperationConfig _config;

        public Repository(IDynamoDBContext context, string defaultTableName) 
        {
            _context = context;
            _config = new DynamoDBOperationConfig()
            {
                OverrideTableName = defaultTableName
            };
        }

        public async Task AddAsync(T entity)
        {
            await _context.SaveAsync(entity, _config);
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> entities = await _context.ScanAsync<T>(new List<ScanCondition>(), _config).GetRemainingAsync();
            return entities;
        }

        public async Task<T> GetAsync(string id)
        {
            T entity = await _context.LoadAsync<T>(id, _config);
            return entity;
        }

        public Task RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
