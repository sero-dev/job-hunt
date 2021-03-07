using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Application.Common.Interfaces;
using Persistence.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDynamoDBContext _context;

        public IJobRepository Jobs { get; }

        public UnitOfWork(IAmazonDynamoDB client)
        {
            _context = new DynamoDBContext(client);
            Jobs = new JobRepository(_context);
        }

    }
}
