using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Persistence
{
    public class JobRepository : IRepository<Job>
    {
        private readonly AmazonDynamoDBClient _client;

        public JobRepository(AmazonDynamoDBClient client) 
        {
            _client = client;
        }

        public void Add(Job entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Job> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> Find(Expression<Func<Job, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Job Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Job entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Job> entities)
        {
            throw new NotImplementedException();
        }
    }
}
