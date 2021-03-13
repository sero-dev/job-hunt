using Application.Common.Interfaces;
using Domain.Entities;
using MongoDB.Driver;
using Persistence.Utilities;

namespace Persistence.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(IMongoDatabase database) : base(database, DatabaseTable.Jobs)
        {
        }
    }
}
