using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Application.Common.Interfaces;
using Persistence.Repository;

namespace Persistence
{
    public class JobContext : DynamoDBContext
    {
        public JobContext(IAmazonDynamoDB client, string tableName) : base(client) 
        {
            
        }
    }
}
