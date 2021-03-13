using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Contracts;
using MongoDB.Driver;

namespace Persistence.Repositories
{
    public abstract class Repository<TDocument> : IRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<TDocument> _collection;

        public Repository(IMongoDatabase database, string collectionName)
        {
            _database = database;
            _collection = database.GetCollection<TDocument>(collectionName);
        }

        public async Task AddAsync(TDocument entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TDocument> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDocument>> Find(Expression<Func<TDocument, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            IEnumerable<TDocument> entities = (await _collection.FindAsync(item => true)).ToList();
            return entities;
        }

        public async Task<TDocument> GetAsync(string id)
        {
            TDocument entity = (await _collection.FindAsync(item => item.Id.ToString() == id)).FirstOrDefault();
            return entity;
        }

        public Task RemoveAsync(TDocument entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<TDocument> entities)
        {
            throw new NotImplementedException();
        }
    }
}
