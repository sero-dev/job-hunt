using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Common.Interfaces
{
    public interface IRepository<TDocument> where TDocument : IDocument
    {
        /// <summary>
        /// Retrieves the entity with the specified ID from the collection
        /// </summary>
        /// <param name="id">The ID of the entity</param>
        /// <returns>The entity retrieved</returns>
        Task<TDocument> GetAsync(Guid id);
        
        /// <summary>
        /// Retrieves all entities from the collection
        /// </summary>
        /// <returns>IEnumerable of entities retrieved</returns>
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<IEnumerable<TDocument>> Find(Expression<Func<TDocument, bool>> predicate);


        /// <summary>
        /// Adds the entity to the collection
        /// </summary>
        /// <param name="entity">The entity to be saved in the database</param>
        Task AddAsync(TDocument entity);
        Task AddRangeAsync(IEnumerable<TDocument> entities);

        /// <summary>
        /// Deletes the entity with the specified ID from the collection
        /// </summary>
        /// <param name="id">The ID of the entity</param>
        /// <returns>The number of entities deleted</returns>
        Task<long> RemoveAsync(Guid id);
        Task RemoveRangeAsync(IEnumerable<TDocument> entities);
    }
}
