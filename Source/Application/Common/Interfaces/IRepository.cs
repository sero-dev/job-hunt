using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Common.Interfaces
{
    public interface IRepository<TDocument> where TDocument : IDocument
    {
        Task<TDocument> GetAsync(Guid id);
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<IEnumerable<TDocument>> Find(Expression<Func<TDocument, bool>> predicate);


        Task AddAsync(TDocument entity);
        Task AddRangeAsync(IEnumerable<TDocument> entities);

        Task RemoveAsync(TDocument entity);
        Task RemoveRangeAsync(IEnumerable<TDocument> entities);
    }
}
