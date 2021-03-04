using Application.Common.Interfaces;
using Domain.Entities;
using Persistence.Utilities;

namespace Persistence.Repository
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public override string DefaultTableName => nameof(DatabaseTable.Jobs);

        public JobRepository(JobContext context) : base(context)
        {

        }
    }
}
