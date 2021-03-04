using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Table _table;
        public virtual string DefaultTableName => "";

        public Repository(IAmazonDynamoDB client) 
        {
            _table = Table.LoadTable(client, DefaultTableName);
        }

        public async Task AddAsync(T entity)
        {
            string json = JsonSerializer.Serialize(entity);
            Document entry = Document.FromJson(json);
            await _table.PutItemAsync(entry);
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
            List<Document> documents = await _table.Scan(new ScanFilter()).GetNextSetAsync();
            List<T> entries = documents.ConvertAll(document => JsonSerializer.Deserialize<T>(document.ToJson()));
            return entries;
        }

        public async Task<T> GetAsync(string id)
        {
            Document result = await _table.GetItemAsync(id.ToString());

            if (result == null)
            {
                return null;
            }

            T entry = JsonSerializer.Deserialize<T>(result.ToJson());
            return entry;
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
