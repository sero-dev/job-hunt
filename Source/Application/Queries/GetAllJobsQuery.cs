using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllJobsQuery : IRequest<IEnumerable<Job>>
    {
        public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, IEnumerable<Job>>
        {
            private readonly IJobRepository _jobRepository;

            public GetAllJobsQueryHandler(IJobRepository jobRepository)
            {
                _jobRepository = jobRepository;
            }

            public async Task<IEnumerable<Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
            {
                var jobs = await _jobRepository.GetAllAsync();
                return jobs;
            }
        }
    }
}
