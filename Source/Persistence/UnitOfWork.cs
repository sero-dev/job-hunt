using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Persistence.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IJobRepository Jobs { get; }

        public UnitOfWork(IMongoClient client, IConfiguration configuration)
        {
            IMongoDatabase db = client.GetDatabase(configuration["Mongo:DatabaseName"]);
            Jobs = new JobRepository(db);
        }
    }
}
