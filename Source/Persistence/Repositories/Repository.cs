using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.DataModel;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using Persistence.Utilities;

namespace Persistence.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private DynamoDBOperationConfig _config;
        protected readonly IDynamoDBContext Context;
        public virtual string DefaultTableName => "";

        public Repository(IDynamoDBContext context) 
        {
            Context = context;
            _config = new DynamoDBOperationConfig()
            {
                OverrideTableName = DefaultTableName
            };
        }

        public async Task AddAsync(T entity)
        {
            
            //string json = JsonSerializer.Serialize(entity);
            //Document entry = Document.FromJson(json);
            //await _table.PutItemAsync(entry);
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
            //List<Document> documents = await _table.Scan(new ScanFilter()).GetNextSetAsync();
            //List<T> entries = documents.ConvertAll(document => JsonSerializer.Deserialize<T>(document.ToJson()));
            //return entries;

            return null;
        }

        public async Task<T> GetAsync(string id)
        {
            T entity = await Context.LoadAsync<T>(id, _config);

            //Document result = await _table.GetItemAsync(id.ToString());

            //if (result == null)
            //{
            //    return null;
            //}

            //T entry = JsonSerializer.Deserialize<T>(result.ToJson());
            //return entry;

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
