using Amazon.DynamoDBv2.DataModel;
using Application.Common.Interfaces;
using Domain.Entities;
using Persistence.Utilities;

namespace Persistence.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(IDynamoDBContext context) : base(context, DatabaseTable.Jobs)
        {
        }
    }
}
