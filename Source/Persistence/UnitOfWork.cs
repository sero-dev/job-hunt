using Application.Common.Interfaces;
using Persistence.Repository;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobContext _context;

        public IJobRepository Jobs { get; private set; }

        public UnitOfWork(JobContext context)
        {
            _context = context;
            Jobs = new JobRepository(_context);
        }

    }
}
