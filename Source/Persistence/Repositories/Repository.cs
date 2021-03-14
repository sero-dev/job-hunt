using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using MongoDB.Driver;

namespace Persistence.Repositories
{
    /// <summary>
    /// Base class for implementors of the IRepository class
    /// </summary>
    /// <typeparam name="TDocument">Generic subtype of IDocument</typeparam>
    public abstract class Repository<TDocument> : IRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<TDocument> _collection;

        /// <summary>
        /// Base class for implementors of the IRepository interface
        /// </summary>
        /// <param name="database">Instance of IMongoDatabase</param>
        /// <param name="collectionName">The name of the base collection</param>
        public Repository(IMongoDatabase database, string collectionName)
        {
            _database = database;
            _collection = database.GetCollection<TDocument>(collectionName);
        }

        /// <summary>
        /// Adds the entity to the default collection name given to the constructor
        /// </summary>
        /// <param name="entity">The entity to be saved in the database</param>
        /// <returns>The result of the insert operation</returns>
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

        /// <summary>
        /// Retrieves all entities from the default collection name given to the constructor
        /// </summary>
        /// <returns>IEnumerable of entities retrieved</returns>
        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            IEnumerable<TDocument> entities = (await _collection.FindAsync(item => true)).ToList();
            return entities;
        }

        /// <summary>
        /// Retrieves the entity with the specified ID from the default collection name given to the constructor
        /// </summary>
        /// <param name="id">The ID of the entity</param>
        /// <returns>The entity retrieved</returns>
        public async Task<TDocument> GetAsync(Guid id)
        {
            TDocument entity = (await _collection.FindAsync(item => item.Id == id)).FirstOrDefault();
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
